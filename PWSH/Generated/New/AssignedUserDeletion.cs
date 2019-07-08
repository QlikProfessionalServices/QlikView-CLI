using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAssignedUserDeletion")]
    public class NewQVAssignedUserDeletion : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.AssignedUserDeletion assigneduserdeletion;
        [Parameter]
        public System.String Id;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            assigneduserdeletion = new QlikView_CLI.QMSAPI.AssignedUserDeletion() { Id = Id };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(assigneduserdeletion);
        }
    }
}
