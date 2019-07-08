using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSSettings")]
    public class NewQVQDSSettings : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSSettings qdssettings;
        [Parameter]
        public QlikView_CLI.QMSAPI.QDSSettings.QDSAdvanced Advanced = new QlikView_CLI.QMSAPI.QDSSettings.QDSAdvanced();
        [Parameter]
        public QlikView_CLI.QMSAPI.QDSSettings.QDSEmail Email = new QlikView_CLI.QMSAPI.QDSSettings.QDSEmail();
        [Parameter]
        public QlikView_CLI.QMSAPI.QDSSettings.QDSGeneral General = new QlikView_CLI.QMSAPI.QDSSettings.QDSGeneral();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public QlikView_CLI.QMSAPI.QDSSettings.QDSLogin Login = new QlikView_CLI.QMSAPI.QDSSettings.QDSLogin();
        [Parameter]
        public QlikView_CLI.QMSAPI.QDSSettingsScope Scope = default(QlikView_CLI.QMSAPI.QDSSettingsScope);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdssettings = new QlikView_CLI.QMSAPI.QDSSettings() { Advanced = Advanced, Email = Email, General = General, ID = ID, Login = Login, Scope = Scope };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdssettings);
        }
    }
}
