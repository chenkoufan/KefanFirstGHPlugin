using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace KefanFirstGHPlugin.MathComps
{
    public class MassAdditionComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MassAdditionComponent class.
        /// </summary>
        public MassAdditionComponent()
          : base("Mass Addition", "Mass",
              "Adds a list of numbers",
              "KTools", "Math")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Numbers", "N", "List of numbers to add", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Result", "R", "Addition result", GH_ParamAccess.item);
            pManager.AddNumberParameter("Partial", "PR", "Partial Results", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<double> vals = new List<double>();
            if (!DA.GetDataList(0, vals)) return;

            // math
            double sum = 0;
            List<double> partials = new List<double>();

            foreach (double v in vals)
            {
                sum += v;
                partials.Add(sum);

            }

            //outputs
            DA.SetData(0, sum);
            DA.SetDataList(1, partials);


        }

        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.mass;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("A1AAF97E-BC3C-46E5-B006-40B9399E4C13"); }
        }
    }
}