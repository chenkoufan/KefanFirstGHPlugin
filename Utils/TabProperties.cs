using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino;
using Rhino.Geometry;
using Grasshopper;
using Grasshopper.Kernel;

namespace KefanFirstGHPlugin.Utils
{
    public class TabProperties : GH_AssemblyPriority
    {
        public override GH_LoadingInstruction PriorityLoad()
        {
            var server = Grasshopper.Instances.ComponentServer;
            server.AddCategoryShortName("KTools","KT");
            server.AddCategorySymbolName("KTools",'K');
            server.AddCategoryIcon("KTools", Properties.Resources.KTools);

            return GH_LoadingInstruction.Proceed;



        }
    }
}
