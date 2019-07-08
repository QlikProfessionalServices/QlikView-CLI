using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVWSAuthentication")]
    public class NewQVQVWSAuthentication : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVWSAuthentication qvwsauthentication;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVWSAuthenticationType Authenticationtype = default(QlikView_CLI.QMSAPI.QVWSAuthenticationType);
        [Parameter]
        public System.String Header;
        [Parameter]
        public System.String Prefix;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvwsauthentication = new QlikView_CLI.QMSAPI.QVWSAuthentication() { AuthenticationType = Authenticationtype, Header = Header, Prefix = Prefix };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvwsauthentication);
        }
    }
}
