using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAssignedUser")]
    public class NewQVAssignedUser : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.AssignedUser assigneduser;
        [Parameter]
        public System.String Id;
        [Parameter]
        public System.String Status;
        [Parameter]
        public System.String Subject;
        [Parameter]
        public System.String Type;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            assigneduser = new QlikView_CLI.QMSAPI.AssignedUser() { id = Id, status = Status, subject = Subject, type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(assigneduser);
        }
    }
}
