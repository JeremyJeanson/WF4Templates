using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace ActivityLibrary
{
    /// <summary>
    /// Activity based on AsyncCodeActivity
    /// </summary>
    public sealed class MyAsyncCodeActivity : AsyncCodeActivity
    {
        // Define an activity input argument of type string
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<String> Text { get; set; }

        /// <summary>
        /// Begin the async execute
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            // Obtain the runtime value of the Text input argument
            String text = context.GetValue(this.Text);
            Action<String> job = new Action<String>(this.Task);

            context.UserState = job;

            return job.BeginInvoke(text, callback, state);
        }

        /// <summary>
        /// End the async execute
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        protected override void EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            Action<String> job = context.UserState as Action<String>;
            if (job != null)
            {
                job.EndInvoke(result);
            }
        }

        /// <summary>
        /// Task to execute async
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private void Task(String text)
        {
            // TODO : Code the long task here
        }

        /// <summary>
        /// Register activity's metadata
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            // Register In arguments
            RuntimeArgument textArg = new RuntimeArgument("Text", typeof(String), ArgumentDirection.In);
            metadata.AddArgument(textArg);
            metadata.Bind(this.Text, textArg);

            // [Text] Argument must be set
            if (this.Text == null)
            {
                metadata.AddValidationError(
                    new System.Activities.Validation.ValidationError(
                        "[Text] argument must be set!",
                        false,
                        "Text"));
            }

            // TODO : Add arguments ... etc ...
        }        
    }
}
