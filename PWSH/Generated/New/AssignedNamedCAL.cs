using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAssignedNamedCAL")]
    public class NewQVAssignedNamedCAL : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.AssignedNamedCAL assignednamedcal;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            assignednamedcal = new QlikView_CLI.QMSAPI.AssignedNamedCAL() { };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(assignednamedcal);
        }
    }
}
