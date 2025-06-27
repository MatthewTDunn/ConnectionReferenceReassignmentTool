using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace SolutionConnectionReferenceReassignment
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Solution Connection Reference Reassignment Tool"),
        ExportMetadata("Description", "Audit and bulk reassign connection references for Power Automate flows in a solution to support governance and service account management."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAYAAAA7MK6iAAAACXBIWXMAAAsTAAALEwEAmpwYAAAC30lEQVR4nO3UXUxSYRgHcL1obW1lW/etm9a66a67LruprdaNW1vU+pg6m2vqaLGs3JrZUbS0D/yaCLUUW04CRY1AUBQEBE1EAQlPfHiQwwGk4CAfbzubNlNeOse2Lpr/7X9zbn57znmek5e3l738i1ziyI8UNRtEJa9Nw0zLqhuzFjdpWLuCr9VN1NTLQoA7FGbU+z3LEUTiCHfpVrHbPN1V5hM/Vp1kC+woE7T6gzdW1T0fHMMAoLprnFU/fu1hrztEB63px5KVnWZ8E/1r/HqD9tkTSSCVC62V4pmyFuOvSbeXP4n57vKnbzKkQX7Rc720XkZkRannpTwjrvSks6JUBVp/WGTA/Co3eY4RfaVadqisZdawEw2DUp4JH/6agKKiGeKHcNwbcqwBYMSSqByNnWGEX67+fIotsDu3wmWts8G+uUgKhkrt3xNtymWcQjc7ha0vKDzkCWaTP9WwHmwsWyV/gRDoVuMwdMRFZhqk9uBWdLNa37pZvBA4yAi/0ajlVnRaI80jaBSGKr1pgIgX8cVwZgdK1RbJAMW3OLNlu9U8eaFxwBmAoeqVDED6bcRcMJUV3Xjd8/2u0GHaaFHTxOmXctQFQ6lyBx2E3htLwVATnvSPovGztNFiRH6UK12y5EJbVW5ctbQWh6EWIk0q3eQ92mghIi941GPRq1fgqFDnDw18IdZgqD0CgNpDvqU/abFxH+fNjHLUB/9BvJ8JRbunfAQMparxJtQyO9hPkwX57C6TSOFOQdGPi9FEu+r3W82yTI4hV/wY7WnvtOt5Mmc8CUOHXWT6xZAzkAudxVO4AiUv0kbLO6Y4Yms0Br1VTwpwJTacukkYaiXSCSVKVtFGS15pzr8z4iHorfoyABHbghYiDUVt1DK5yV7aKJXydkOtypuBfteGwSV82hdP/2GZJiRecCCPSQoReUFFh6GJzZ9u216O0CwUmVf71B6yLVc/ucnjjNC9/Nf5CYeaL4Frv680AAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Blue")]
    public class SolutionConnectionReferenceReassignment : PluginBase
    {


        public override IXrmToolBoxPluginControl GetControl()
        {
            return new SolutionConnectionReferenceReassignmentControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public SolutionConnectionReferenceReassignment()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}