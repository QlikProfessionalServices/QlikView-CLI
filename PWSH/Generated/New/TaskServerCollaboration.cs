using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskServerCollaboration")]
    public class NewQVTaskServerCollaboration : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerCollaboration taskservercollaboration;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentCollaborationCreationMode Creationmode = default(QlikView_CLI.QMSAPI.DocumentCollaborationCreationMode);
        [Parameter]
        public List<System.String> Creatorusernames = new List<System.String>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskservercollaboration = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerCollaboration() { CreationMode = Creationmode, CreatorUserNames = Creatorusernames };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskservercollaboration);
        }
    }
}
