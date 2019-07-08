using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSLogging")]
    public class NewQVQVSLogging : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSLogging qvslogging;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSLogFileSplitMode Filesplitmode = default(QlikView_CLI.QMSAPI.QVSLogFileSplitMode);
        [Parameter]
        public System.String Folder;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSLogging.QVSLoggingLevel Level = new QlikView_CLI.QMSAPI.QVSSettings.QVSLogging.QVSLoggingLevel();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSLogVerbosity Verbosity = default(QlikView_CLI.QMSAPI.QVSLogVerbosity);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvslogging = new QlikView_CLI.QMSAPI.QVSSettings.QVSLogging() { FileSplitMode = Filesplitmode, Folder = Folder, Level = Level, Verbosity = Verbosity };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvslogging);
        }
    }
}
