using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDocumentInfo")]
    public class NewQVTaskDocumentInfo : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDocumentInfo taskdocumentinfo;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentAttribute> Attributes = new List<QlikView_CLI.QMSAPI.DocumentAttribute>();
        [Parameter]
        public System.String Category;
        [Parameter]
        public System.String Description;
        [Parameter]
        public System.String Lastacceptedreloadtime;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdocumentinfo = new QlikView_CLI.QMSAPI.DocumentTask.TaskDocumentInfo() { Attributes = Attributes, Category = Category, Description = Description, LastAcceptedReloadTime = Lastacceptedreloadtime };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdocumentinfo);
        }
    }
}
