using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVUserDocumentFolders")]
    public class GetQVUserDocumentFolders : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolderScope Scope;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentFolder> Documentfolder = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DocumentFolder>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvsID == null)
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
                    Documentfolder = Connection.client.GetUserDocumentFolders(obj, Scope);
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
