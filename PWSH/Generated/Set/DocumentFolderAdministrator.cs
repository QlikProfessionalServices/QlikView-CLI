using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Set, "QVDocumentFolderAdministrator")]
    public class SetQVDocumentFolderAdministrator : PSClient
    {

        [Parameter]
        public Guid Folderid;
        [Parameter]
        public string Username;
        [Parameter]
        public QlikView_CLI.QMSAPI.ePermissionObjectType Foldertype;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Connection.client.SetDocumentFolderAdministrator(Folderid, Username, Foldertype);

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
            WriteObject(null);
        }

    }

}
