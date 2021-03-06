using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace ActivityLibrary
{
    /// <summary>
    /// Activity based on CodeActivity<TResult>
    /// </summary>
    public sealed class MyCodeActivityTResult : CodeActivity<String>
    {
        // Define an activity input argument of type string
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<String> Text { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="context">WF context</param>
        /// <returns></returns>
        protected override String Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            String text = context.GetValue(this.Text);

            // TODO : Code this activity

            // Return value
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
