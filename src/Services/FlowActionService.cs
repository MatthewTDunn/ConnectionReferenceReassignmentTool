using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SolutionConnectionReferenceReassignment.Services
{
    internal class FlowActionService
    {
        private readonly IOrganizationService _service;

        public FlowActionService(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<FlowActionModel> GetFlowActions(Guid workflowId)
        {
            var actions = new List<FlowActionModel>();

            var workflowQuery = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("workflowid", "name", "clientdata"),
                Criteria = new FilterExpression
                {
                    Conditions =
            {
                new ConditionExpression("workflowid", ConditionOperator.Equal, workflowId)
            }
                }
            };

            var workflows = _service.RetrieveMultiple(workflowQuery).Entities;

            if (!workflows.Any())
            {
                MessageBox.Show("Flow not found.");
                return actions;
            }

            var flow = workflows.First();
            var clientData = flow.GetAttributeValue<string>("clientdata");

            if (string.IsNullOrWhiteSpace(clientData))
                return actions;

            JObject clientDataJson = null;
            try
            {
                clientDataJson = JsonConvert.DeserializeObject<JObject>(clientData);
            }
            catch (JsonException)
            {
                // TODO: MATT LOG IF NEEDED AT SOME POINT
            }

            if (clientDataJson != null)
            {
                actions.AddRange(FlowJSONParser.ParseFlowActions(clientDataJson));
            }

            return actions;
        }
    }
}
