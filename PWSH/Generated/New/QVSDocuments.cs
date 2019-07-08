using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSDocuments")]
    public class NewQVQVSDocuments : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments qvsdocuments;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsObjects Objects = new QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsObjects();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsServer Server = new QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsServer();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsdocuments = new QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments() { Objects = Objects, Server = Server };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsdocuments);
        }
    }
}
