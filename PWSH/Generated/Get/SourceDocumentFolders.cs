using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVSourceDocumentFolders")]
    public class GetQVSourceDocumentFolders : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolderScope Scope;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentFolder> Documentfolder = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentFolder>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == default)
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
                    Documentfolder = Connection.client.GetSourceDocumentFolders(obj, Scope);
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
            WriteObject(Documentfolder);
        }

    }

}
