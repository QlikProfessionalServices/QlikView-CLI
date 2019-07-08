using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSDocumentsObjects")]
    public class NewQVQVSDocumentsObjects : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsObjects qvsdocumentsobjects;
        [Parameter]
        public System.Boolean Allowmoveobjects = new System.Boolean();
        [Parameter]
        public System.String Defaultlabelothers;
        [Parameter]
        public System.String Defaultlabeltotal;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsdocumentsobjects = new QlikView_CLI.QMSAPI.QVSSettings.QVSDocuments.QVSDocumentsObjects() { AllowMoveObjects = Allowmoveobjects, DefaultLabelOthers = Defaultlabelothers, DefaultLabelTotal = Defaultlabeltotal };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsdocumentsobjects);
        }
    }
}
