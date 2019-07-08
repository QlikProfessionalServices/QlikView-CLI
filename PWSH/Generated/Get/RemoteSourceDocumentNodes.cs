using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVRemoteSourceDocumentNodes")]
    public class GetQVRemoteSourceDocumentNodes : PSClient
    {

        [Parameter]
        public Guid Remoteqmsid;
        [Parameter]
        public Guid Remoteqdsid;
        [Parameter]
        public Guid Folderid;
        [Parameter]
        public string Relativepath;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentNode> Documentnode = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentNode>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Documentnode = Connection.client.RemoteGetSourceDocumentNodes(Remoteqmsid, Remoteqdsid, Folderid, Relativepath);

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
            WriteObject(Documentnode);
        }

    }

}
