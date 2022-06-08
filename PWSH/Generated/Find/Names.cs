using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Find, "QVNames")]
    public class FindQVNames : PSClient
    {
        [Parameter]
        public Guid[] dscID;

        [Parameter]
        public System.Collections.Generic.List<string> Names;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.DirectoryServiceObject> Directoryserviceobject = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.DirectoryServiceObject>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (dscID == null)
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
                    Directoryserviceobject = Connection.client.LookupNames(obj, Names);
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
            WriteObject(Directoryserviceobject);
        }

    }

}
