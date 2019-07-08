using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSClusterMember")]
    public class NewQVQVSClusterMember : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSClusterMember qvsclustermember;
        [Parameter]
        public System.String Address;
        [Parameter]
        public System.String Externalmachinename;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsclustermember = new QlikView_CLI.QMSAPI.QVSClusterMember() { Address = Address, ExternalMachineName = Externalmachinename, ID = ID };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsclustermember);
        }
    }
}
