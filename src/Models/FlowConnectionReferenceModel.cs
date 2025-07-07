using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConnectionReferenceReassignment.Models
{
    internal class FlowConnectionReferenceModel
    {
        public string DisplayName { get; set; } // Populated by the Dataverse enrichment function within the orchestrator FlowDefinitionOrchestrator.cs
        public string Name { get; set; }
        public string LogicalName { get; set; }
        public string RuntimeSource { get; set; }
    }
}
