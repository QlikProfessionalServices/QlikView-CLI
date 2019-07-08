using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskReductionBookmark")]
    public class NewQVTaskReductionBookmark : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskReduction.TaskReductionBookmark taskreductionbookmark;
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskreductionbookmark = new QlikView_CLI.QMSAPI.TaskReduction.TaskReductionBookmark() { Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskreductionbookmark);
        }
    }
}
