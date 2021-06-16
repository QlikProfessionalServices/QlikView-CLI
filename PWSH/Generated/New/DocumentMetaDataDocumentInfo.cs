using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentMetaDataDocumentInfo")]
    public class NewQVDocumentMetaDataDocumentInfo : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataDocumentInfo documentmetadatadocumentinfo;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentAttribute> Attributes = new List<QlikView_CLI.QMSAPI.DocumentAttribute>();
        [Parameter]
        public System.String Category;
        [Parameter]
        public System.String Description;
        [Parameter]
        public System.String Lastacceptedreloadtime;
        [Parameter]
        public System.String Sourcename;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentmetadatadocumentinfo = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataDocumentInfo() { Attributes = Attributes, Category = Category, Description = Description, LastAcceptedReloadTime = Lastacceptedreloadtime, SourceName = Sourcename };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentmetadatadocumentinfo);
        }
    }
}
