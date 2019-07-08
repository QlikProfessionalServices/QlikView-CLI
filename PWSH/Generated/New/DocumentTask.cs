using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentTask")]
    public class NewQVDocumentTask : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask documenttask;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute Distribute = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentNode Document = new QlikView_CLI.QMSAPI.DocumentNode();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDocumentInfo Documentinfo = new QlikView_CLI.QMSAPI.DocumentTask.TaskDocumentInfo();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskGeneral General = new QlikView_CLI.QMSAPI.DocumentTask.TaskGeneral();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.Guid QDSID;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskReduce Reduce = new QlikView_CLI.QMSAPI.DocumentTask.TaskReduce();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskReload Reload = new QlikView_CLI.QMSAPI.DocumentTask.TaskReload();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTaskScope Scope = default(QlikView_CLI.QMSAPI.DocumentTaskScope);
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskServer Server = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskTriggering Triggering = new QlikView_CLI.QMSAPI.DocumentTask.TaskTriggering();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documenttask = new QlikView_CLI.QMSAPI.DocumentTask() { Distribute = Distribute, Document = Document, DocumentInfo = Documentinfo, General = General, ID = ID, QDSID = QDSID, Reduce = Reduce, Reload = Reload, Scope = Scope, Server = Server, Triggering = Triggering };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documenttask);
        }
    }
}
