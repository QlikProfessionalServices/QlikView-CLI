using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVServiceStatusDetail")]
    public class NewQVServiceStatusDetail : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ServiceStatusDetail servicestatusdetail;
        [Parameter]
        public List<System.String> Groups = new List<System.String>();
        [Parameter]
        public System.String Host;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public List<System.String> Message = new List<System.String>();
        [Parameter]
        public QlikView_CLI.QMSAPI.ServiceStatusFlag Status = default(QlikView_CLI.QMSAPI.ServiceStatusFlag);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            servicestatusdetail = new QlikView_CLI.QMSAPI.ServiceStatusDetail() { Groups = Groups, Host = Host, ID = ID, Message = Message, Status = Status };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(servicestatusdetail);
        }
    }
}
