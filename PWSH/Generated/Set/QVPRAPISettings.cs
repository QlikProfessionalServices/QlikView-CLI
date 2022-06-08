using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Set, "QVQVPRAPISettings")]
    public class SetQVQVPRAPISettings : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.QVPRAPISettings Qvprsettings;
        [Parameter]
        public bool Domigrate;
        private string String;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                String = Connection.client.SetQVPRAPISettings(Qvprsettings, Domigrate);

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
            WriteObject(String);
        }

    }

}
