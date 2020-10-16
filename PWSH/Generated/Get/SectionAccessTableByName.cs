﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVSectionAccessTableByName")]
    public class GetQVSectionAccessTableByName : PSClient
    {

        [Parameter]
        public string Tablename;
        [Parameter]
        public QlikView_CLI.QMSAPI.SectionAccessScope Scope;
        private QlikView_CLI.QMSAPI.SectionAccessTable Sectionaccesstable;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Sectionaccesstable = Connection.client.GetSectionAccessTableByName(Tablename, Scope);

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
            WriteObject(Sectionaccesstable);
        }

    }

}
