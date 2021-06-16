using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskReduceDynamic")]
    public class NewQVTaskReduceDynamic : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceDynamic taskreducedynamic;
        [Parameter]
        public System.String Fieldname;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskReductionType Type = default(QlikView_CLI.QMSAPI.TaskReductionType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskreducedynamic = new QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceDynamic() { FieldName = Fieldname, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskreducedynamic);
        }
    }
}
