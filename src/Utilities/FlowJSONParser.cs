using Newtonsoft.Json.Linq;
using SolutionConnectionReferenceReassignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                try
                {
                    flowActionList.Add(new FlowActionModel
                    {
                        ActionName = prop.Name,
                        Type = actionObj?["type"]?.ToString() ?? "(unknown)",
                        ConnectionName = actionObj?["inputs"]?["host"]?["connectionName"]?.ToString() ?? "(none)",
                        OperationId = actionObj?["inputs"]?["host"]?["operationId"]?.ToString() ?? "(none)",
                        Parameters = actionObj?["inputs"]?["parameters"]?.ToString() ?? "(none)"
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"The action of {prop.Name} does not comply with the tooling format requirements. Action skipped");
                }

            }

            return flowActionList;
        }

        public static List<ConnectionReferenceModel> ParseFlowConnectionReferences(JObject clientData)
        {
            var flowConnectionReferenceList = new List<ConnectionReferenceModel>();
            var connectionReferences = clientData?["properties"]?["connectionReferences"] as JObject;
            if (connectionReferences == null) return flowConnectionReferenceList;

            foreach (var prop in connectionReferences.Properties())
            {
                var connectionReferenceItem = prop.Value as JObject;
                flowConnectionReferenceList.Add(new ConnectionReferenceModel
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
