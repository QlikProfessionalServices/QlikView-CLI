using System.Management.Automation;

namespace QlikView_CLI
{
    public abstract class PSClient : PSCmdlet
    {
        [Parameter]
        public QMS Connection;

        private PSCmdlet Cmdlet;

        public PSClient()
        {
            Cmdlet = this;
        }

        ~PSClient()
        {
            Cmdlet = this;
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            Management.Globals.Validators.QVValidation.checkConnection(ref Connection);
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}
