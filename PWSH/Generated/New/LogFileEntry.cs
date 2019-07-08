using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLogFileEntry")]
    public class NewQVLogFileEntry : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.LogFileEntry logfileentry;
        [Parameter]
        public System.String Text;
        [Parameter]
        public System.DateTime Time = new System.DateTime();
        [Parameter]
        public QlikView_CLI.QMSAPI.LogType Type = default(QlikView_CLI.QMSAPI.LogType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            logfileentry = new QlikView_CLI.QMSAPI.LogFileEntry() { Text = Text, Time = Time, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(logfileentry);
        }
    }
}
