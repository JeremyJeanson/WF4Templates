using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace ActivityLibrary
{
    /// <summary>
    /// Activity based on NativeActivity<TResult>
    /// </summary>
    public sealed class MyNativeActivity : NativeActivity
    {
        // Define an activity input argument of Type String
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<String> Text { get; set; }

        [DefaultValue(null)]
        public Activity Body { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="context">WF context</param>
        /// <returns></returns>
        protected override void Execute(NativeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            String text = context.GetValue(this.Text);

            if (this.Body != null)
            {
                context.ScheduleActivity(this.Body);
            }
            // TODO : Code this activity
        }

        /// <summary>
        /// Register activity's metadata
        /// </summary>
        /// <param name="metadata"></param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
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
                        "'Text' argument must be set!",
                        false,
                        "Text"));
            }

            metadata.AddChild(this.Body);
            // [Body] must be set
            if (this.Body == null)
            {
                metadata.AddValidationError(
                    new System.Activities.Validation.ValidationError(
                        "'Body' must be set!",
                        false,
                        "Body"));
            }

            // TODO : Add arguments ... etc ...
        }
    }
}
