using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVFieldContentList")]
    public class GetQVFieldContentList : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.QDSDocumentSession Session;
        [Parameter]
        public string Forfieldname;
        [Parameter]
        public QlikView_CLI.QMSAPI.FieldContentType Fieldcontenttype;
        [Parameter]
        public int Index;
        [Parameter]
        public int Length;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.FieldContent> Fieldcontent = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.FieldContent>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Fieldcontent = Connection.client.GetFieldContentList(Session, Forfieldname, Fieldcontenttype, Index, Length);

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
