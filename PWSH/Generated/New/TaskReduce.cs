using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskReduce")]
    public class NewQVTaskReduce : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskReduce taskreduce;
        [Parameter]
        public System.String Documentnametemplate;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceDynamic Dynamic = new QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceDynamic();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceStatic Static = new QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceStatic();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskreduce = new QlikView_CLI.QMSAPI.DocumentTask.TaskReduce() { DocumentNameTemplate = Documentnametemplate, Dynamic = Dynamic, Static = Static };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskreduce);
        }
    }
}
