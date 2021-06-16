using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSDocumentsServer")]
    public class NewQVQVSDocumentsServer : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsServer qvsdocumentsserver;
        [Parameter]
        public System.Boolean Allowanonymousserverbookmarkcollaboration = new System.Boolean();
        [Parameter]
        public System.Boolean Allowdocumentdownload = new System.Boolean();
        [Parameter]
        public System.Boolean Allowdocumentupload = new System.Boolean();
        [Parameter]
        public System.Boolean Allowprintandexport = new System.Boolean();
        [Parameter]
        public System.Boolean Allowserverannotations = new System.Boolean();
        [Parameter]
        public System.Boolean Allowservercollaboration = new System.Boolean();
        [Parameter]
        public System.Boolean Allowsessioncollaboration = new System.Boolean();
        [Parameter]
        public System.Boolean Overlaydocuments = new System.Boolean();
        [Parameter]
        public System.Boolean Prohibitqvpxsessionrecovery = new System.Boolean();
        [Parameter]
        public System.Int32 Timeout = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsdocumentsserver = new QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsServer() { AllowAnonymousServerBookmarkCollaboration = Allowanonymousserverbookmarkcollaboration, AllowDocumentDownload = Allowdocumentdownload, AllowDocumentUpload = Allowdocumentupload, AllowPrintAndExport = Allowprintandexport, AllowServerAnnotations = Allowserverannotations, AllowServerCollaboration = Allowservercollaboration, AllowSessionCollaboration = Allowsessioncollaboration, OverlayDocuments = Overlaydocuments, ProhibitQVPXSessionRecovery = Prohibitqvpxsessionrecovery, Timeout = Timeout };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsdocumentsserver);
        }
    }
}
