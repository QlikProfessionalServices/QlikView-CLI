using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsDiagnostic.Resolve, "QVUserGroups")]
    public class ResolveQVUserGroups : PSClient
    {
        [Parameter]
        public Guid[] dscID;

        [Parameter]
        public string User;
        private System.Collections.Generic.List<string> String = new System.Collections.Generic.List<string>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (dscID == null)
            {
                dscID = Connection.QlikViewDirectoryServiceConnector.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in dscID)
                {
                    String = Connection.client.ResolveUserGroups(obj, User);
                }

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
            WriteObject(String);
        }

    }

}
