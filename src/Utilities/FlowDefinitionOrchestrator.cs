using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SolutionConnectionReferenceReassignment.Utilities
{
    // Thought it may be best to handle this via a helper as both the FlowAction & ConnectionReference service utilise the same workflow.clientdata JSON.
    // Parse from here to handle once and feed into appropriate services/models.
    internal class FlowDefinitionOrchestrator
    {
        private readonly IOrganizationService _service;

        public FlowDefinitionOrchestrator(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public JObject GetClientData(Guid workflowId)
        {
            var query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("clientdata"),
                Criteria = new FilterExpression
                {
                    Conditions =
                {
                    new ConditionExpression("workflowid", ConditionOperator.Equal, workflowId)
                }
                }
            };

            var workflows = _service.RetrieveMultiple(query).Entities;

            if (!workflows.Any())
            {
                MessageBox.Show("Flow not found.");
                return null;
            }

            var clientDataRaw = workflows.First().GetAttributeValue<string>("clientdata");
            if (string.IsNullOrWhiteSpace(clientDataRaw))
                return null;

            try
            {
                return JsonConvert.DeserializeObject<JObject>(clientDataRaw);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error parsing clientData: {ex.Message}");
                return null;
            }
        }

        public (List<FlowActionModel> Actions, List<ConnectionReferenceModel> ConnectionReferences) GetParsedFlowDefinition(Guid workflowId)
        {
            var clientData = GetClientData(workflowId);

            if (clientData == null)
                return (new List<FlowActionModel>(), new List<ConnectionReferenceModel>());

            var actions = FlowJSONParser.ParseFlowActions(clientData);
            var connectionReferences = FlowJSONParser.ParseFlowConnectionReferences(clientData);

            return (actions, connectionReferences);
        }
    }
}
