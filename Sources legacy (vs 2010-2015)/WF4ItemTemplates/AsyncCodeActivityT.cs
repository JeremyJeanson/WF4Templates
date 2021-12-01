using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace $rootnamespace$
{
    /// <summary>
    /// Activity based on AsyncCodeActivity<TResult>
    /// </summary>
    public sealed class $safeitemrootname$ : AsyncCodeActivity<String>
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
        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, Object state)
        {
            // Obtain the runtime value of the Text input argument
            String text = context.GetValue(this.Text);
            Func<String, String> job = new Func<String, String>(this.Task);

            context.UserState = job;

            return job.BeginInvoke(text, callback, state);
        }

        /// <summary>
        /// End the async execute
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        protected override String EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            Func<String, String> job = context.UserState as Func<String, String>;
            if (job != null)
            {
                String res = job.EndInvoke(result);
                return res;
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Task to execute async
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private String Task(String text)
        {
            // TODO : Code the long task here
            return text;
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

            // Register Out arguments
            RuntimeArgument resultArg = new RuntimeArgument("Result", typeof(String), ArgumentDirection.Out);
            metadata.AddArgument(resultArg);
            metadata.Bind(this.Result, resultArg);

            // [Result] Argument must be set
            if (this.Result == null)
            {
                metadata.AddValidationError(
                    new System.Activities.Validation.ValidationError(
                        "[Result] argument must be set!",
                        false,
                        "Result"));
            }

            // TODO : Add arguments ... etc ...
        }
    }
}
