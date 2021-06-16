using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSPerformanceDocument")]
    public class NewQVQVSPerformanceDocument : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceDocument qvsperformancedocument;
        [Parameter]
        public System.Boolean Allowdocumentautoload = new System.Boolean();
        [Parameter]
        public System.Int32 Maxchartsymbols = new System.Int32();
        [Parameter]
        public System.Int32 Objectcalculationtimelimit = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsperformancedocument = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceDocument() { AllowDocumentAutoLoad = Allowdocumentautoload, MaxChartSymbols = Maxchartsymbols, ObjectCalculationTimeLimit = Objectcalculationtimelimit };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsperformancedocument);
        }
    }
}
