using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace $rootnamespace$
{
    /// <summary>
    /// Activity based on CodeActivity
    /// </summary>
    public sealed class $safeitemrootname$ : CodeActivity
    {
        // Define an activity input argument of type string
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<String> Text { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="context">WF context</param>
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            String text = context.GetValue(this.Text);

            // TODO : Code this activity
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
