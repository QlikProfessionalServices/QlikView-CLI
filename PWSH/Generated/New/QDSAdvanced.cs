﻿using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQDSAdvanced")]
    public class NewQVQDSAdvanced : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QDSSettings.QDSAdvanced qdsadvanced;
        [Parameter]
        public List<System.Boolean> Cpuaffinity = new List<System.Boolean>();
        [Parameter]
        public QlikView_CLI.QMSAPI.CPUPriority Cpupriority = default(QlikView_CLI.QMSAPI.CPUPriority);
        [Parameter]
        public System.Int32 Maxqvbadmin = new System.Int32();
        [Parameter]
        public System.Int32 Maxqvbdist = new System.Int32();
        [Parameter]
        public System.String Sectionaccesspassword;
        [Parameter]
        public System.String Sectionaccessusername;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qdsadvanced = new QlikView_CLI.QMSAPI.QDSSettings.QDSAdvanced() { CPUAffinity = Cpuaffinity, CPUPriority = Cpupriority, MaxQvbAdmin = Maxqvbadmin, MaxQvbDist = Maxqvbdist, SectionAccessPassword = Sectionaccesspassword, SectionAccessUsername = Sectionaccessusername };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qdsadvanced);
        }
    }
}
