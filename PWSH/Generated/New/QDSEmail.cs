using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSEmail")]
    public class NewQVQDSEmail : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSSettings.QDSEmail qdsemail;
        [Parameter]
        public System.String Alerthtmlbody;
        [Parameter]
        public System.String Alerthtmlsubject;
        [Parameter]
        public List<System.String> Alertmailaddresses = new List<System.String>();
        [Parameter]
        public System.String Alertplainbody;
        [Parameter]
        public System.String Alertplainsubject;
        [Parameter]
        public System.String Attachmenthtmlbody;
        [Parameter]
        public System.String Attachmenthtmlsubject;
        [Parameter]
        public System.String Attachmentplainbody;
        [Parameter]
        public System.String Attachmentplainsubject;
        [Parameter]
        public System.String Notifyhtmlbody;
        [Parameter]
        public System.String Notifyhtmlsubject;
        [Parameter]
        public System.String Notifyplainbody;
        [Parameter]
        public System.String Notifyplainsubject;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdsemail = new QlikView_CLI.QMSAPI.QDSSettings.QDSEmail() { AlertHtmlBody = Alerthtmlbody, AlertHtmlSubject = Alerthtmlsubject, AlertMailAddresses = Alertmailaddresses, AlertPlainBody = Alertplainbody, AlertPlainSubject = Alertplainsubject, AttachmentHtmlBody = Attachmenthtmlbody, AttachmentHtmlSubject = Attachmenthtmlsubject, AttachmentPlainBody = Attachmentplainbody, AttachmentPlainSubject = Attachmentplainsubject, NotifyHtmlBody = Notifyhtmlbody, NotifyHtmlSubject = Notifyhtmlsubject, NotifyPlainBody = Notifyplainbody, NotifyPlainSubject = Notifyplainsubject };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdsemail);
        }
    }
}
