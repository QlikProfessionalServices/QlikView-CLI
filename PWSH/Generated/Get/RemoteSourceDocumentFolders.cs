using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVRemoteSourceDocumentFolders")]
    public class GetQVRemoteSourceDocumentFolders : PSClient
    {

        [Parameter]
        public Guid Remoteqmsid;
        [Parameter]
        public Guid Remoteqdsid;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolderScope Scope;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentFolder> Documentfolder = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentFolder>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Documentfolder = Connection.client.RemoteGetSourceDocumentFolders(Remoteqmsid, Remoteqdsid, Scope);

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
            WriteObject(Documentfolder);
        }

    }

}
