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
        public string Kind { get; set; }
        public string ConnectionReferenceName { get; set; }
        public string ConnectionLogicalName { get; set; }
        public string ConnectionDisplayName { get; set; }
    }
}
