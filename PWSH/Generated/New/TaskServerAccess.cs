using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskServerAccess")]
    public class NewQVTaskServerAccess : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerAccess taskserveraccess;
        [Parameter]
        public System.Int32 Documenttimeout = new System.Int32();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentDownloadAccess Download = default(QlikView_CLI.QMSAPI.DocumentDownloadAccess);
        [Parameter]
        public List<System.String> Downloadusers = new List<System.String>();
        [Parameter]
        public System.Boolean Enablesessioncollaboration = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentDownloadAccess Export = default(QlikView_CLI.QMSAPI.DocumentDownloadAccess);
        [Parameter]
        public List<System.String> Exportusers = new List<System.String>();
        [Parameter]
        public System.UInt32 Maxconcurrentsessions = new System.UInt32();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentAccessMethods Methods = default(QlikView_CLI.QMSAPI.DocumentAccessMethods);
        [Parameter]
        public System.Int32 Sessiontimeout = new System.Int32();
        [Parameter]
        public System.String Zerofootprintclienturl;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskserveraccess = new QlikView_CLI.QMSAPI.DocumentTask.TaskServer.TaskServerAccess() { DocumentTimeout = Documenttimeout, Download = Download, DownloadUsers = Downloadusers, EnableSessionCollaboration = Enablesessioncollaboration, Export = Export, ExportUsers = Exportusers, MaxConcurrentSessions = Maxconcurrentsessions, Methods = Methods, SessionTimeout = Sessiontimeout, ZeroFootprintClientURL = Zerofootprintclienturl };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskserveraccess);
        }
    }
}
