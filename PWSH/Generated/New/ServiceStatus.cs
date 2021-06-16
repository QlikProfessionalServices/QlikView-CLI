using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVServiceStatus")]
    public class NewQVServiceStatus : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ServiceStatus servicestatus;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.ServiceStatusDetail> Memberstatusdetails = new List<QlikView_CLI.QMSAPI.ServiceStatusDetail>();
        [Parameter]
        public System.String Name;
        [Parameter]
        public QlikView_CLI.QMSAPI.ServiceComposition Servicecomposition = default(QlikView_CLI.QMSAPI.ServiceComposition);
        [Parameter]
        public QlikView_CLI.QMSAPI.ServiceTypes Servicetype = default(QlikView_CLI.QMSAPI.ServiceTypes);
        [Parameter]
        public System.Uri Url;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            servicestatus = new QlikView_CLI.QMSAPI.ServiceStatus() { ID = ID, MemberStatusDetails = Memberstatusdetails, Name = Name, ServiceComposition = Servicecomposition, ServiceType = Servicetype, Url = Url };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(servicestatus);
        }
    }
}
