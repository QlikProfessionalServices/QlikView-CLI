using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentAccessEntry")]
    public class NewQVDocumentAccessEntry : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentAccessEntry documentaccessentry;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentAccessEntryMode Accessmode = default(QlikView_CLI.QMSAPI.DocumentAccessEntryMode);
        [Parameter]
        public List<System.DayOfWeek> Dayofweekconstraints = new List<System.DayOfWeek>();
        [Parameter]
        public System.Boolean Isanonymous = new System.Boolean();
        [Parameter]
        public System.DateTime Timeconstraintfrom = new System.DateTime();
        [Parameter]
        public System.DateTime Timeconstraintto = new System.DateTime();
        [Parameter]
        public System.String Username;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentaccessentry = new QlikView_CLI.QMSAPI.DocumentAccessEntry() { AccessMode = Accessmode, DayOfWeekConstraints = Dayofweekconstraints, IsAnonymous = Isanonymous, TimeConstraintFrom = Timeconstraintfrom, TimeConstraintTo = Timeconstraintto, UserName = Username };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentaccessentry);
        }
    }
}
