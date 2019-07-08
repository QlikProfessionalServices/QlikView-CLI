using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVSourceDocumentNodes")]
    public class GetQVSourceDocumentNodes : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public Guid Folderid;
        [Parameter]
        public string Relativepath;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentNode> Documentnode = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentNode>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == null)
            {
                qdsID = Connection.QlikViewDistributionService.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qdsID)
                {
                    Documentnode = Connection.client.GetSourceDocumentNodes(obj, Folderid, Relativepath);
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
            WriteObject(Documentnode);
        }

    }

}
