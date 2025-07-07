using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolutionConnectionReferenceReassignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SolutionConnectionReferenceReassignment.Utilities
{
    // Thought it may be best to handle this via a helper as both the FlowAction service & FlowMetadata service utilise the same workflow.clientdata JSON.
    // Parse from here to handle once and feed into appropriate services/models.
    internal class FlowDefinitionOrchestrator
    {
        private readonly IOrganizationService _service;

        public FlowDefinitionOrchestrator(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public (List<FlowActionModel> Actions, List<FlowConnectionReferenceModel> ConnectionReferences) GetSolutionFlowDefinitionData(Guid solutionId)
        {

            var actions = new List<FlowActionModel>();
            var connectionReferences = new List<FlowConnectionReferenceModel>();

            var solutionComponentQuery = new QueryExpression("solutioncomponent")
            {
                ColumnSet = new ColumnSet("objectid"),
                Criteria = new FilterExpression
                {
                    Conditions =
        {
            new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId),
            new ConditionExpression("componenttype", ConditionOperator.Equal, 29) // 29 = Workflow
        }
                }
            };

            var solutionComponents = _service.RetrieveMultiple(solutionComponentQuery).Entities;

            // Extract workflow IDs
            var workflowIds = solutionComponents.Select(sc => sc.GetAttributeValue<Guid>("objectid")).ToList();

            if (!workflowIds.Any())
            {
                MessageBox.Show("No modern flows found in this solution.");
                return (new List<FlowActionModel>(), new List<FlowConnectionReferenceModel>());
            }

            // Step 2: Retrieve the workflows by their IDs
            var workflowQuery = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("workflowid", "name", "clientdata"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("workflowid", ConditionOperator.In, workflowIds.Cast<object>().ToArray())
                    }
                }
            };

            var workflows = _service.RetrieveMultiple(workflowQuery).Entities;

            // Proceed with parsing clientdata from these workflows
            foreach (var flow in workflows)
            {
                var solutionFlowClientData = flow.GetAttributeValue<string>("clientdata");
                if (string.IsNullOrWhiteSpace(solutionFlowClientData))
                    continue;

                JObject clientData = null;
                try
                {
                    clientData = JsonConvert.DeserializeObject<JObject>(solutionFlowClientData);

                }
                catch (JsonException)
                {
                    // Log or handle JSON parse error
                }

                // Your existing parsing logic
                actions.AddRange(FlowJSONParser.ParseFlowActions(clientData));
                connectionReferences.AddRange(FlowJSONParser.ParseFlowConnectionReferences(clientData));
            }

            var enricher = new ConnectionReferenceEnricher(_service);
            enricher.DisplayNameEnrichment(connectionReferences);

            return (actions, connectionReferences);

        }


    }

    internal class ConnectionReferenceEnricher
    {
        private readonly IOrganizationService _service;

        public ConnectionReferenceEnricher(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void DisplayNameEnrichment(List<FlowConnectionReferenceModel> connectionReference)
        {
            foreach (var reference in connectionReference)
            {
                try
                {
                    var query = new QueryExpression("connectionreference")
                    {
                        ColumnSet = new ColumnSet("connectionreferencedisplayname"),
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("connectionreferencelogicalname", ConditionOperator.Equal, reference.LogicalName)
                            }
                        }
                    };

                    var result = _service.RetrieveMultiple(query);
                    var entity = result.Entities.FirstOrDefault();

                    reference.DisplayName = entity?.GetAttributeValue<string>("connectionreferencedisplayname") ?? reference.Name;
                }
                catch (Exception ex)
                {
                    reference.DisplayName = $"(error: {ex}";
                }
            }
        }

        public void ConnectionTypeEnrichment(List<FlowConnectionReferenceModel> connectionReference)
        {

        }

    }
}
