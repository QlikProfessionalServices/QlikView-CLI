using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskReduction")]
    public class NewQVTaskReduction : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskReduction taskreduction;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskReduction.TaskReductionBookmark Bookmark = new QlikView_CLI.QMSAPI.TaskReduction.TaskReductionBookmark();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskReduction.TaskReductionField Field = new QlikView_CLI.QMSAPI.TaskReduction.TaskReductionField();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskReductionType Type = default(QlikView_CLI.QMSAPI.TaskReductionType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskreduction = new QlikView_CLI.QMSAPI.TaskReduction() { Bookmark = Bookmark, Field = Field, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskreduction);
        }
    }
}
