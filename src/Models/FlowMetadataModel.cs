using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConnectionReferenceReassignment.Models
{
    internal class FlowMetadataModel
    {
        public string Name { get; set; }
        public Guid FlowId { get; set; }
        public string Status => GetStatusText();
        public string State => GetStateText();
        public int StateCode {  get; set; }
        public int StatusCode {  get; set; }

        private string GetStateText()
        {
            switch (StateCode)
            {
                case 0:
                    return "Draft";
                case 1:
                    return "Activated";
                default:
                    return "Unknown";
            };
        }

        private string GetStatusText()
        {
            switch (StatusCode)
            {
                case 1:
                    return "Activated";
                case 2:
                    return "Draft";
                case 3:
                    return "Suspended";
                default:
                    return "Unknown";
                  
            }
        }

    }
}
