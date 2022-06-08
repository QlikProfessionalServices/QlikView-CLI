using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsData.Update, "QVServices")]
    public class UpdateQVServices : PSClient
    {

        [Parameter]
        public System.Collections.Generic.Dictionary<Guid, Uri> Serviceurls;
        [Parameter]
        public QlikView_CLI.QMSAPI.ServiceTypes Servicetype;
        private QlikView_CLI.QMSAPI.ServiceUpdateStatus Serviceupdatestatus;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Serviceupdatestatus = Connection.client.UpdateServices(Serviceurls, Servicetype);

            }
            catch (System.Exception e)
            {
                var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(Serviceupdatestatus);
        }

    }

}
