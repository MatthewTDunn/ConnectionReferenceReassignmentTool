using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SolutionConnectionReferenceReassignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConnectionReferenceReassignment.Services
{
    internal class FlowService
    {
        private readonly IOrganizationService _service;

        public FlowService(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<FlowModel> GetFlowsInSolution(Guid solutionId)
        {
            var componentQuery = new QueryExpression("solutioncomponent")
            {
                ColumnSet = new ColumnSet("objectid"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId),
                        new ConditionExpression("componenttype", ConditionOperator.Equal, 29) // 29 is flow/workflow
                    }
                }
            };

            var flowComponentIds = _service.RetrieveMultiple(componentQuery)
                .Entities
                .Select(e => e.GetAttributeValue<Guid>("objectid"))
                .ToList();

            var flows = new List<FlowModel>();

            foreach (var flowId in flowComponentIds)
            {
                var flow = _service.Retrieve("workflow", flowId, new ColumnSet("name", "statecode", "statuscode"));

                flows.Add(new FlowModel
                {
                    FlowId = flow.Id,
                    Name = flow.GetAttributeValue<string>("name"),
                    StateCode = flow.GetAttributeValue<OptionSetValue>("statecode")?.Value ?? -1,
                    StatusCode = flow.GetAttributeValue<OptionSetValue>("statuscode")?.Value ?? -1
                });
            }
            return flows;
        }
    }
}
