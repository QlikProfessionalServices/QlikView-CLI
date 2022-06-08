using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDocumentFolder")]
    public class GetQVDocumentFolder : PSClient
    {

        [Parameter]
        public Guid Id;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolderScope Scope;
        private QlikView_CLI.QMSAPI.DocumentFolder Documentfolder;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Documentfolder = Connection.client.GetDocumentFolder(Id, Scope);

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
