using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVSession")]
    public class NewQVSession : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.QDSDocumentSessionConfiguration Configuration;
        private QlikView_CLI.QMSAPI.QDSDocumentSession Qdsdocumentsession;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Qdsdocumentsession = Connection.client.CreateSession(Configuration);

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
            WriteObject(Qdsdocumentsession);
        }

    }

}
