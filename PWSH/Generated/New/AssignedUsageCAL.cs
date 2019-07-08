using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAssignedUsageCAL")]
    public class NewQVAssignedUsageCAL : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.AssignedUsageCAL assignedusagecal;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            assignedusagecal = new QlikView_CLI.QMSAPI.AssignedUsageCAL() { };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(assignedusagecal);
        }
    }
}
