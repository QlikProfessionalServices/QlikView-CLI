using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVUserCALs")]
    public class NewQVUserCALs : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.UserCALs usercals;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedSessionCAL> Assignedsessioncals = new List<QlikView_CLI.QMSAPI.AssignedSessionCAL>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedUsageCAL> Assignedusagecals = new List<QlikView_CLI.QMSAPI.AssignedUsageCAL>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentCAL> Documentcals = new List<QlikView_CLI.QMSAPI.DocumentCAL>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.LeasedNamedCAL> Leasednamedcals = new List<QlikView_CLI.QMSAPI.LeasedNamedCAL>();
        [Parameter]
        public QlikView_CLI.QMSAPI.AssignedNamedCAL Namedcal = new QlikView_CLI.QMSAPI.AssignedNamedCAL();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            usercals = new QlikView_CLI.QMSAPI.UserCALs() { AssignedSessionCALs = Assignedsessioncals, AssignedUsageCALs = Assignedusagecals, DocumentCALs = Documentcals, LeasedNamedCALs = Leasednamedcals, NamedCAL = Namedcal };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(usercals);
        }
    }
}
