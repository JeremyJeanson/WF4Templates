using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace $rootnamespace$
{
    /// <summary>
    /// Activity based on NativeActivity<TResult>
    /// </summary>
    public sealed class $safeitemrootname$ : NativeActivity
    {
        // Define an activity input argument of Type String
        [RequiredArgument]
        [DefaultValue(null)]
        public InArgument<String> Text { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="context">WF context</param>
        /// <returns></returns>
        protected override void Execute(NativeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            String text = context.GetValue(this.Text);

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
                        "[Text] argument must be set!",
                        false,
                        "Text"));
            }

            // TODO : Add arguments ... etc ...
        }
    }
}
