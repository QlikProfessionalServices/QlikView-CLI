using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSSupervisionAccount")]
    public class NewQVQVSSupervisionAccount : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSupervisionAccount qvssupervisionaccount;
        [Parameter]
        public System.String Accountname;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.String Mountname;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSupervisionAccountType Type = default(QlikView_CLI.QMSAPI.QVSSupervisionAccountType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvssupervisionaccount = new QlikView_CLI.QMSAPI.QVSSupervisionAccount() { AccountName = Accountname, ID = ID, MountName = Mountname, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvssupervisionaccount);
        }
    }
}
