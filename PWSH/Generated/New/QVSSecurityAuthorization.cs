using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSSecurityAuthorization")]
    public class NewQVQVSSecurityAuthorization : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthorization qvssecurityauthorization;
        [Parameter]
        public System.Boolean Usedmsauthorization = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvssecurityauthorization = new QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthorization() { UseDMSAuthorization = Usedmsauthorization };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvssecurityauthorization);
        }
    }
}
