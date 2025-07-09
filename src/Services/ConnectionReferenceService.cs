using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json.Linq;
using SolutionConnectionReferenceReassignment.Models;
using SolutionConnectionReferenceReassignment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolutionConnectionReferenceReassignment.Services
{
    internal class ConnectionReferenceService
    {
        private readonly IOrganizationService _service;

        public ConnectionReferenceService(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<ConnectionReferenceModel> ParseReferencesFromClientData(JObject clientData)
        {
            if (clientData == null) 
                return new List<ConnectionReferenceModel>();

            return FlowJSONParser.ParseFlowConnectionReferences(clientData);
        }

        public Guid GetCurrentUserId()
        {
            try
            {
                var whoAmIRequest = new WhoAmIRequest();
                var whoAmIResponse = (WhoAmIResponse)_service.Execute(whoAmIRequest);
                return whoAmIResponse.UserId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve current user ID.", ex);
            }
        }

        public List<ConnectionReferenceModel>GetConnectionReferencesOwnedByUser()
        {
            Guid userId = GetCurrentUserId();
            var query = new QueryExpression("connectionreference")
            {
                ColumnSet = new ColumnSet("connectionreferencedisplayname", "connectionreferencelogicalname", "ownerid"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("ownerid", ConditionOperator.Equal, userId)
                    }
                }
            };

            var results = _service.RetrieveMultiple(query).Entities;

            return results.Select(e => new ConnectionReferenceModel
            {
                DisplayName = e.GetAttributeValue<string>("connectionreferencedisplayname")
            }).ToList();
        }
    }
}
