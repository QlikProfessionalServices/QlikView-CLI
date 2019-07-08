using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSSecurity")]
    public class NewQVQVSSecurity : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity qvssecurity;
        [Parameter]
        public System.Boolean Allowalternateadmin = new System.Boolean();
        [Parameter]
        public System.Boolean Allowdynamicupdate = new System.Boolean();
        [Parameter]
        public System.Boolean Allowextensions = new System.Boolean();
        [Parameter]
        public System.Boolean Allowservermacroexecution = new System.Boolean();
        [Parameter]
        public System.Boolean Allowserversystemaccessmacroexecution = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthentication Authentication = new QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthentication();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthorization Authorization = new QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity.QVSSecurityAuthorization();
        [Parameter]
        public System.Boolean Compressnetworktraffic = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSAuditLogLevel Enableauditlogging = default(QlikView_CLI.QMSAPI.QVSAuditLogLevel);
        [Parameter]
        public System.Boolean Enablehttppush = new System.Boolean();
        [Parameter]
        public System.String Extensionsfolder;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvssecurity = new QlikView_CLI.QMSAPI.QVSSettings.QVSSecurity() { AllowAlternateAdmin = Allowalternateadmin, AllowDynamicUpdate = Allowdynamicupdate, AllowExtensions = Allowextensions, AllowServerMacroExecution = Allowservermacroexecution, AllowServerSystemAccessMacroExecution = Allowserversystemaccessmacroexecution, Authentication = Authentication, Authorization = Authorization, CompressNetworkTraffic = Compressnetworktraffic, EnableAuditLogging = Enableauditlogging, EnableHTTPPush = Enablehttppush, ExtensionsFolder = Extensionsfolder };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvssecurity);
        }
    }
}
