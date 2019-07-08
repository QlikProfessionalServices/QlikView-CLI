using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAssignedSessionCAL")]
    public class NewQVAssignedSessionCAL : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.AssignedSessionCAL assignedsessioncal;
        [Parameter]
        public System.DateTime Lastused = new System.DateTime();
        [Parameter]
        public System.String Machineid;
        [Parameter]
        public System.String Username;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            assignedsessioncal = new QlikView_CLI.QMSAPI.AssignedSessionCAL() { LastUsed = Lastused, MachineID = Machineid, UserName = Username };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(assignedsessioncal);
        }
    }
}
