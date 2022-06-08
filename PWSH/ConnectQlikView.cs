using System;
using System.Management.Automation;

namespace QlikView_CLI
{
    [Cmdlet(VerbsCommunications.Connect, "QlikView")]
    public class ConnectQlikView : PSCmdlet
    {
        [Parameter(Position = 1)]
        public System.Net.NetworkCredential Credential;

        private QMS client;
        private bool passthru = false;
        private Uri uri;

        [Parameter(Position = 0)]
        public string Hostname { get; set; } = "localhost";

        [Parameter(Position = 1)]
        public SwitchParameter Passthru
        {
            get => passthru;
            set => passthru = value;
        }

        [Parameter(Position = 2)]
        public string Port { get; set; } = "4799";

        [Parameter]
        [ValidateSet("http", "https")]
        public string Scheme { get; set; } = "http";

        public Uri Uri { get => uri; set => uri = value; }

        [Parameter]
        [ValidateSet("IQMS", "IQM1", "IQMS2", "IQMS3", "IQMS4", "IQMS5", "IQMS6")]
        public string Version { get; set; } = "IQMS6";

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            Uri = new Uri($"{Scheme}://{Hostname}:{Port}/QMS/Service");
            client = new QMS();
            if (passthru == false)
            {
                WriteVerbose($"Setting Global Connection: {Uri.AbsoluteUri}");
                QlikView_CLI.Management.Globals.VariableStore.QVConnection = client;
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        protected override void ProcessRecord()
        {
            try
            {
                if (Credential == null)
                {
                    WriteVerbose($"Connecting to: {Uri.AbsoluteUri} using Default Credentials");
                    client.Connect(url: Uri.AbsoluteUri, Version);
                }
                else
                {
                    WriteVerbose($"Connecting to: {Uri.AbsoluteUri} as {Credential.UserName}");
                    client.Connect(url: Uri.AbsoluteUri, Credential: Credential, Version);
                }
            }
            catch (Exception e)
            {
                ErrorRecord errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, client);

                WriteError(errorRecord);
                //WriteWarning($"Connection to: {Uri.Host} Failed:`n {e.Message} ");
            }

            if (client.ServiceInfo != null)
            {
                WriteObject(client);
            }
        }
    }
}
