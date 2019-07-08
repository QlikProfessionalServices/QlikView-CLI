using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSDocumentSession")]
    public class NewQVQDSDocumentSession : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSDocumentSession qdsdocumentsession;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentState Opendocumentresult = default(QlikView_CLI.QMSAPI.DocumentState);
        [Parameter]
        public System.Guid QDSID;
        [Parameter]
        public System.Guid Sessionid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdsdocumentsession = new QlikView_CLI.QMSAPI.QDSDocumentSession() { OpenDocumentResult = Opendocumentresult, QDSID = QDSID, SessionID = Sessionid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdsdocumentsession);
        }
    }
}
