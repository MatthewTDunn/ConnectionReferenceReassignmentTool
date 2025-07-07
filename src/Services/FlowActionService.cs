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


    }
}
