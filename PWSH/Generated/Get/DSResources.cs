using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDSResources")]
    public class GetQVDSResources : PSClient
    {
        [Parameter]
        public Guid[] dscID;

        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DSResource> Dsresource = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DSResource>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (dscID == default)
            {
                dscID = Connection.QlikViewDirectoryServiceConnector.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in dscID)
                {
                    Dsresource = Connection.client.GetDSResources(obj);
                }

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
            WriteObject(Dsresource);
        }

    }

}
