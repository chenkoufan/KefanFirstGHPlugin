using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace KefanFirstGHPlugin
{
    public class KefanFirstGHPluginInfo : GH_AssemblyInfo
    {
        public override string Name => "KefanFirstGHPlugin";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("cfc42dbd-00fd-4e7a-8d2d-9acbd7c346ad");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}