using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Add, "QVSelections")]
    public class AddQVSelections : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.QDSDocumentSession Session;
        [Parameter]
        public System.Collections.Generic.List<QlikView_CLI.QMSAPI.FieldContent> Fieldcontents;
        [Parameter]
        public bool Lockselection;
        [Parameter]
        public bool Toggleselect;
        [Parameter]
        public bool Returnselectedlist;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.FieldContent> Fieldcontent = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.FieldContent>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Fieldcontent = Connection.client.AddSelections(Session, Fieldcontents, Lockselection, Toggleselect, Returnselectedlist);

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
            WriteObject(Fieldcontent);
        }

    }

}
