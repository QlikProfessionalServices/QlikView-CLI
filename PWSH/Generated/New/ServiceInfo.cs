using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVServiceInfo")]
    public class NewQVServiceInfo : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ServiceInfo serviceinfo;
        [Parameter]
        public System.Uri Address;
        [Parameter]
        public System.Int32 Clusternodecount = new System.Int32();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.String Name;
        [Parameter]
        public QlikView_CLI.QMSAPI.ServiceTypes Type = default(QlikView_CLI.QMSAPI.ServiceTypes);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            serviceinfo = new QlikView_CLI.QMSAPI.ServiceInfo() { Address = Address, ClusterNodeCount = Clusternodecount, ID = ID, Name = Name, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(serviceinfo);
        }
    }
}
