using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributeOutputPDF")]
    public class NewQVTaskDistributeOutputPDF : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput.TaskDistributeOutputPDF taskdistributeoutputpdf;
        [Parameter]
        public System.String Reportid;
        [Parameter]
        public System.String Reportname;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributeoutputpdf = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeOutput.TaskDistributeOutputPDF() { ReportID = Reportid, ReportName = Reportname };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributeoutputpdf);
        }
    }
}
