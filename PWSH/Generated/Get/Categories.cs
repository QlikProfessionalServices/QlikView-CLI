using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVCategories")]
    public class GetQVCategories : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.CategoriesScope Scope;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.Category> Category = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.Category>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Category = Connection.client.GetCategories(Scope);

            }
            catch (System.Exception e)
            {
                var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(Category);
        }

    }

}
