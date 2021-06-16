using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVCAL")]
    public class NewQVCAL : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.CAL cal;
        [Parameter]
        public System.DateTime Lastused = new System.DateTime();
        [Parameter]
        public System.String Machineid;
        [Parameter]
        public System.DateTime Quarantineduntil = new System.DateTime();
        [Parameter]
        public System.String Username;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            cal = new QlikView_CLI.QMSAPI.CAL() { LastUsed = Lastused, MachineID = Machineid, QuarantinedUntil = Quarantineduntil, UserName = Username };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(cal);
        }
    }
}
