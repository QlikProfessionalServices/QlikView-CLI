using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSSecurityAuthentication")]
    public class NewQVQVSSecurityAuthentication : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthentication qvssecurityauthentication;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSAuthenticationLevel Level = default(QlikView_CLI.QMSAPI.QVSAuthenticationLevel);
        [Parameter]
        public System.Boolean Usedomainaccountforanonymous = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvssecurityauthentication = new QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthentication() { Level = Level, UseDomainAccountForAnonymous = Usedomainaccountforanonymous };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvssecurityauthentication);
        }
    }
}
