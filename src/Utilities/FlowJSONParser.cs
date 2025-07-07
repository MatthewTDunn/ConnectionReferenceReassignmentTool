using Newtonsoft.Json.Linq;
using SolutionConnectionReferenceReassignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConnectionReferenceReassignment.Utilities
{
    internal static class FlowJSONParser
    {
        public static List<FlowActionModel> ParseFlowActions(JObject clientData)
        {
            var flowActionList = new List<FlowActionModel>();
            var actions = clientData?["properties"]?["definition"]?["actions"] as JObject;
            if (actions == null) return flowActionList;

            foreach (var prop in actions.Properties())
            {
                var actionObj = prop.Value as JObject;
                flowActionList.Add(new FlowActionModel
                {
                    Name = prop.Name,
                    Type = actionObj?["type"]?.ToString() ?? "(unknown)",
                    ConnectionName = actionObj?["inputs"]?["host"]?["connectionName"]?.ToString() ?? "(none)",
                    OperationId = actionObj?["inputs"]?["host"]?["operationId"]?.ToString() ?? "(none)",
                    Parameters = actionObj?["inputs"]?["parameters"]?.ToString() ?? "(none)"
                });
            }
            return flowActionList;
        }

        public static List<FlowConnectionReferenceModel> ParseFlowConnectionReferences(JObject clientData)
        {
            var flowConnectionReferenceList = new List<FlowConnectionReferenceModel>();
            var connectionReferences = clientData?["properties"]?["connectionReferences"] as JObject;
            if (connectionReferences == null) return flowConnectionReferenceList;

            foreach (var prop in connectionReferences.Properties())
            {
                var connectionReferenceItem = prop.Value as JObject;
                flowConnectionReferenceList.Add(new FlowConnectionReferenceModel
                {
                    Name = prop.Name,
                    LogicalName = connectionReferenceItem?["connection"]?["connectionReferenceLogicalName"]?.ToString() ?? "(none)",
                    RuntimeSource = connectionReferenceItem?["runtimeSource"]?.ToString() ?? "(none)"
                });
            }
            return flowConnectionReferenceList;
        }
    }
}
