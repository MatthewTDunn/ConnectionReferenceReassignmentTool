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
    internal class OwnedConnectionReferenceService
    {
        private readonly IOrganizationService _service;

        public OwnedConnectionReferenceService(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }




        /*
        public List<FlowMetadataModel> GetConnectionReferencesOwnedByUser(Guid ownerid)
        {
            var componentQuery = new QueryExpression("connectionreference")
            {
                ColumnSet = new ColumnSet("connectionreferencedisplayname"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("ownerid", ConditionOperator.Equal, ownerid)
                    }
                }
            };
        }

        public Guid GetCurrentUserId(IOrganizationService service)
        {
            var response = (Microsoft.Xrm.Sdk.Messages.WhoAmIResponse)service.Execute(new Microsoft.Xrm.Sdk.Messages.WhoAmIRequest());
            return response.UserId;
        }
        */

    }
}
