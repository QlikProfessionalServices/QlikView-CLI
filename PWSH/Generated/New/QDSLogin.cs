using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSLogin")]
    public class NewQVQDSLogin : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSSettings.QDSLogin qdslogin;
        [Parameter]
        public System.String Password;
        [Parameter]
        public System.String Username;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdslogin = new QlikView_CLI.QMSAPI.QDSSettings.QDSLogin() { Password = Password, Username = Username };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdslogin);
        }
    }
}
