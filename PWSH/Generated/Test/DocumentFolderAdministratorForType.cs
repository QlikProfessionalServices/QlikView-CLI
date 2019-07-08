using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsDiagnostic.Test, "QVDocumentFolderAdministratorForType")]
    public class TestQVDocumentFolderAdministratorForType : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.ePermissionObjectType Objecttype;
        private bool Bool;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Bool = Connection.client.IsDocumentFolderAdministratorForType(Objecttype);

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
            WriteObject(Bool);
        }

    }

}
