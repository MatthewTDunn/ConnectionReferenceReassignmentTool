using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using SolutionConnectionReferenceReassignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Rest.Serialization;
using System.Diagnostics.Eventing.Reader;

namespace SolutionConnectionReferenceReassignment.Services
{
    internal class FlowActionService
    {
        private readonly IOrganizationService _service;

        public FlowActionService(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<FlowActionModel> GetActionsFromFlow(Guid flowId)
        {
            var flow = _service.Retrieve("workflow", flowId, new ColumnSet("name", "clientdata"));
            var clientData = flow.GetAttributeValue<string>("clientdata");

            if (string.IsNullOrWhiteSpace(clientData))
                return new List<FlowActionModel>();

            var actions = ParseActionsFromJson(clientData);
            return actions;
        }

        private List<FlowActionModel> ParseActionsFromJson(string json)
        {
            var result = new List<FlowActionModel>();

            var obj = JsonConvert.DeserializeObject<JObject>(json);

            var actions = obj?["properties"]?["definition"]?["actions"] as JObject;
            if (actions == null) return result;

            foreach (var prop in actions.Properties())
            {
                var actionObj = prop.Value as JObject;
                result.Add(FlowActionModel.FromJson(prop.Name, actionObj));
            }

            return result;
        }
    }
}
