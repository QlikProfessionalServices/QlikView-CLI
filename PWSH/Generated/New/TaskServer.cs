using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskServer")]
    public class NewQVTaskServer : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskServer taskserver;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerAccess Access = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerAccess();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerCollaboration Collaboration = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerCollaboration();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading Documentloading = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading();
        [Parameter]
        public System.Boolean Enableauditlogging = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskserver = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer() { Access = Access, Collaboration = Collaboration, DocumentLoading = Documentloading, EnableAuditLogging = Enableauditlogging };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskserver);
        }
    }
}
