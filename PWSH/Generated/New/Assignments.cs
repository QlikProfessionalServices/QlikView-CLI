using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAssignments")]
    public class NewQVAssignments : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Assignments assignments;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Assignment> Assignments = new List<QlikView_CLI.QMSAPI.Assignment>();
        [Parameter]
        public System.String Max;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            assignments = new QlikView_CLI.QMSAPI.Assignments() { assignments = Assignments, max = Max };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(assignments);
        }
    }
}
