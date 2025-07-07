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
    }
}
