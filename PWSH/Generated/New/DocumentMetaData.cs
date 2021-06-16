using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentMetaData")]
    public class NewQVDocumentMetaData : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentMetaData documentmetadata;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataAuthorization Authorization = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataAuthorization();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataCollaboration Collaboration = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataCollaboration();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataDocumentInfo Documentinfo = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataDocumentInfo();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataLicensing Licensing = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataLicensing();
        [Parameter]
        public System.Guid QVSID;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaDataScope Scope = default(QlikView_CLI.QMSAPI.DocumentMetaDataScope);
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer Server = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentNode Userdocument = new QlikView_CLI.QMSAPI.DocumentNode();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentmetadata = new QlikView_CLI.QMSAPI.DocumentMetaData() { Authorization = Authorization, Collaboration = Collaboration, DocumentInfo = Documentinfo, Licensing = Licensing, QVSID = QVSID, Scope = Scope, Server = Server, UserDocument = Userdocument };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentmetadata);
        }
    }
}
