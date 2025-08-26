using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConnectionReferenceReassignment.Utilities
{
    internal class DataEnricher
    {
        private readonly IOrganizationService _service;

        public DataEnricher(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void EnrichFlowActionsWithFlowMetadata(List<FlowActionModel> actions, string flowName, Guid flowId)
        {
            if (actions == null) 
                return;

            foreach (var action in actions)
            {
                action.FlowName = string.IsNullOrWhiteSpace(flowName) ? "Unidentified Flow Name": flowName;
                action.FlowId = flowId;
            }
        }

        public void EnrichConnectionReferenceDataWithDisplayName(List<ConnectionReferenceModel> connectionReferences)
        {
            
        }
    }
}
