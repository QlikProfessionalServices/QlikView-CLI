using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskServerDocumentLoadServerSetting")]
    public class NewQVTaskServerDocumentLoadServerSetting : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting taskserverdocumentloadserversetting;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting.TaskDocumentLoadClusterSetting> Clustersettings = new List<QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting.TaskDocumentLoadClusterSetting>();
        [Parameter]
        public QlikView_CLI.QMSAPI.ServerDocumentLoadMode Mode = default(QlikView_CLI.QMSAPI.ServerDocumentLoadMode);
        [Parameter]
        public System.Guid Qlikviewserverid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskserverdocumentloadserversetting = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerDocumentLoading.TaskServerDocumentLoadServerSetting() { ClusterSettings = Clustersettings, Mode = Mode, QlikViewServerId = Qlikviewserverid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskserverdocumentloadserversetting);
        }
    }
}
