using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConnectionReferenceReassignment.Models
{
    internal class FlowActionModel
    {
        public string Name { get; set; }
        public string Type {  get; set; }
        public string ConnectionName { get; set; }
        public string OperationId { get ; set; }
        public string Parameters { get; set; }

        public static FlowActionModel FromJson(string name, JObject actionObj)
        {
            return new FlowActionModel
            {
                Name = name,
                Type = actionObj?["type"]?.ToString() ?? "(unknown)",
                ConnectionName = actionObj?["inputs"]?["host"]?["connectionName"]?.ToString() ?? "(none)",
                OperationId = actionObj?["inputs"]?["host"]?["operationId"]?.ToString() ?? "(none)",
                Parameters = actionObj?["inputs"]?["parameters"]?.ToString() ?? "(none)"
            
            };
        }

    }
}
