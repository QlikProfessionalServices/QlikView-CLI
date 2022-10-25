using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVUserDocumentNodes")]
    public class GetQVUserDocumentNodes : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public Guid Folderid;
        [Parameter]
        public string Relativepath;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentNode> Documentnode = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentNode>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvsID == default)
            {
                qvsID = Connection.QlikViewServer.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qvsID)
                {
                    Documentnode = Connection.client.GetUserDocumentNodes(obj, Folderid, Relativepath);
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
