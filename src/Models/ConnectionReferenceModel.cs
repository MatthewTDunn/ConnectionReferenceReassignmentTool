using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConnectionReferenceReassignment.Models
{
    internal class ConnectionReferenceModel
    {
        public string DisplayName { get; set; } // Populated by the Dataverse enrichment function within the orchestrator FlowDefinitionOrchestrator.cs
        public string Name { get; set; }
        public string LogicalName { get; set; }

        #region clientData Exclusive Properties
        public string RuntimeSource { get; set; }
        #endregion

        #region XRMToolbox Tool Properties
        public string ReplacementConnectionReference { get; set; }
        public string ReplacementConnectionReferenceLogicalName {  get; set; }
        public bool AssignmentValid { get; set; }
        #endregion

    }
}
