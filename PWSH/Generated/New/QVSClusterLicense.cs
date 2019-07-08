using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSClusterLicense")]
    public class NewQVQVSClusterLicense : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSCluster.QVSClusterLicense qvsclusterlicense;
        [Parameter]
        public System.Boolean Allowsclustering = new System.Boolean();
        [Parameter]
        public System.String Controlnumber;
        [Parameter]
        public System.String Serialnumber;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsclusterlicense = new QlikView_CLI.QMSAPI.QVSSettings.QVSCluster.QVSClusterLicense() { AllowsClustering = Allowsclustering, ControlNumber = Controlnumber, SerialNumber = Serialnumber };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsclusterlicense);
        }
    }
}
