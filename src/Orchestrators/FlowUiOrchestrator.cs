using Microsoft.Xrm.Sdk;
using NuGet.Packaging;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using SolutionConnectionReferenceReassignment.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolutionConnectionReferenceReassignment.Orchestrators
{
    internal class FlowUiOrchestrator
    {
        private readonly IOrganizationService _service;

        public FlowUiOrchestrator(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public (List<FlowActionModel> Actions, List<ConnectionReferenceModel> ConnectionReferences) GetDataForNode(TreeNode node)
        {
            var orchestrator = new FlowDefinitionOrchestrator(_service);
            var enricher = new DataEnricher(_service);

            List<FlowActionModel> actions = new List<FlowActionModel>();
            List<ConnectionReferenceModel> connectionReferences = new List<ConnectionReferenceModel>();

            if (node.Tag is SolutionModel solution)
            {
                var flowService = new FlowMetadataService(_service);
                var flows = flowService.GetFlowsInSolution(solution.SolutionId);

                foreach (var flow in flows)
                {
                    var (flowActions, flowConnectionReferences) = orchestrator.GetParsedFlowDefinition(flow.FlowId);
                    enricher.EnrichFlowActionsWithFlowMetadata(flowActions, flow.Name, flow.FlowId);

                    actions.AddRange(flowActions);
                    connectionReferences.AddRange(flowConnectionReferences);
                }
            }
            else if (node.Tag is FlowMetadataModel flowMetadata)
            {
                var (flowActions, flowConnectionReferences) = orchestrator.GetParsedFlowDefinition(flowMetadata.FlowId);
                enricher.EnrichFlowActionsWithFlowMetadata(flowActions, flowMetadata.Name, flowMetadata.FlowId);

                actions = flowActions;
                connectionReferences = flowConnectionReferences;
            }
            else if (node.Tag is FlowActionModel flowAction)
            {
                var parentNode = node.Parent;
                if (parentNode?.Tag is FlowMetadataModel parentFlowMetadata)
                {
                    flowAction.FlowName = parentFlowMetadata.Name;
                    flowAction.FlowId = parentFlowMetadata.FlowId;

                    var (flowActions, flowConnectionReferences) = orchestrator.GetParsedFlowDefinition(parentFlowMetadata.FlowId);
                    enricher.EnrichFlowActionsWithFlowMetadata(flowActions, parentFlowMetadata.Name, parentFlowMetadata.FlowId);

                    connectionReferences = flowConnectionReferences;
                }

                actions = new List<FlowActionModel> { flowAction };
            }

            // Remove duplicates from the connection reference list as we want to bulk update based on individual connection reference sources
            var uniqueConnectionReferences = connectionReferences
                .GroupBy(cr => cr.LogicalName)
                .Select(g => g.First())
                .ToList();

            return (actions, uniqueConnectionReferences);
        }

    }
}
