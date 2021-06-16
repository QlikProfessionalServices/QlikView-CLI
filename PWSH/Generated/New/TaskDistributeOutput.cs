using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributeOutput")]
    public class NewQVTaskDistributeOutput : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput taskdistributeoutput;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput.TaskDistributeOutputPDF PDF = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput.TaskDistributeOutputPDF();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskDistributionOutputType Type = default(QlikView_CLI.QMSAPI.TaskDistributionOutputType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributeoutput = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput() { PDF = PDF, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributeoutput);
        }
    }
}
