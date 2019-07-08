using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskServerDocumentLoading")]
    public class NewQVTaskServerDocumentLoading : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading taskserverdocumentloading;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting> Serversettings = new List<QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskserverdocumentloading = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading() { ServerSettings = Serversettings };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskserverdocumentloading);
        }
    }
}
