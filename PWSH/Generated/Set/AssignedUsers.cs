using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Set, "QVAssignedUsers")]
    public class SetQVAssignedUsers : PSClient
    {

        [Parameter]
        public System.Collections.Generic.List<QlikView_CLI.QMSAPI.AssignedUser> Assignments;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.AssignedUser> Assigneduser = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.AssignedUser>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Assigneduser = Connection.client.SetAssignedUsers(Assignments);

            }
            catch (System.Exception e)
            {
                var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(Assigneduser);
        }

    }

}
