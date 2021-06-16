using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVPRAPISettings")]
    public class NewQVQVPRAPISettings : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVPRAPISettings qvprapisettings;
        [Parameter]
        public System.Boolean Connectusingwindowsauthentication = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.SQLConnectionModel Connectionmodel = default(QlikView_CLI.QMSAPI.SQLConnectionModel);
        [Parameter]
        public System.String Database;
        [Parameter]
        public System.Int32 Maxpoolsize = new System.Int32();
        [Parameter]
        public System.String Password;
        [Parameter]
        public System.Int32 Port = new System.Int32();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVPRDbProvider Provider = default(QlikView_CLI.QMSAPI.QVPRDbProvider);
        [Parameter]
        public System.String Server;
        [Parameter]
        public System.String Username;
        [Parameter]
        public System.Int32 Xmlbackupinterval = new System.Int32();
        [Parameter]
        public System.String Xmlbackuppath;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVPRBackupSchedule Xmlbackupschedule = default(QlikView_CLI.QMSAPI.QVPRBackupSchedule);
        [Parameter]
        public System.DateTime Xmlbackuptime = new System.DateTime();
        [Parameter]
        public System.String Xmlbasepath;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvprapisettings = new QlikView_CLI.QMSAPI.QVPRAPISettings() { ConnectUsingWindowsAuthentication = Connectusingwindowsauthentication, ConnectionModel = Connectionmodel, Database = Database, MaxPoolSize = Maxpoolsize, Password = Password, Port = Port, Provider = Provider, Server = Server, UserName = Username, XmlBackupInterval = Xmlbackupinterval, XmlBackupPath = Xmlbackuppath, XmlBackupSchedule = Xmlbackupschedule, XmlBackupTime = Xmlbackuptime, XmlBasePath = Xmlbasepath };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvprapisettings);
        }
    }
}
