using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSGeneral")]
    public class NewQVQVSGeneral : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSGeneral qvsgeneral;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Password;
        [Parameter]
        public System.Boolean Showalerts = new System.Boolean();
        [Parameter]
        public System.String Username;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsgeneral = new QlikView_CLI.QMSAPI.QVSSettings.QVSGeneral() { Name = Name, Password = Password, ShowAlerts = Showalerts, UserName = Username };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsgeneral);
        }
    }
}
