using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVWSSettings")]
    public class NewQVQVWSSettings : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVWSSettings qvwssettings;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.ServiceInfo> Accesspointqvsconnection = new List<QlikView_CLI.QMSAPI.ServiceInfo>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.ServiceInfo> DSC = new List<QlikView_CLI.QMSAPI.ServiceInfo>();
        [Parameter]
        public System.String Defaultqvs;
        [Parameter]
        public System.String Headername;
        [Parameter]
        public System.String Loginaddress;
        [Parameter]
        public System.Int32 Port = new System.Int32();
        [Parameter]
        public System.String Prefix;
        [Parameter]
        public QlikView_CLI.QMSAPI.QvWsAuthenticationType1 Qvwsauthenticationtype = default(QlikView_CLI.QMSAPI.QvWsAuthenticationType1);
        [Parameter]
        public QlikView_CLI.QMSAPI.QvWsLogginLevel Qvwslogginlevel = default(QlikView_CLI.QMSAPI.QvWsLogginLevel);
        [Parameter]
        public QlikView_CLI.QMSAPI.QvWsLoginType Qvwslogintype = default(QlikView_CLI.QMSAPI.QvWsLoginType);
        [Parameter]
        public System.String Servername;
        [Parameter]
        public System.Boolean Usehttps = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvwssettings = new QlikView_CLI.QMSAPI.QVWSSettings() { AccessPointQvsConnection = Accesspointqvsconnection, DSC = DSC, DefaultQvs = Defaultqvs, HeaderName = Headername, LoginAddress = Loginaddress, Port = Port, Prefix = Prefix, QvWsAuthenticationType = Qvwsauthenticationtype, QvWsLogginLevel = Qvwslogginlevel, QvWsLoginType = Qvwslogintype, ServerName = Servername, UseHttps = Usehttps };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvwssettings);
        }
    }
}
