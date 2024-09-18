using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace KefanFirstGHPlugin.MathComps
{
    public class Counter : GH_Component
    {
        // persistent fields
        int updates = 0;

        /// <summary>
        /// Initializes a new instance of the Counter class.
        /// </summary>
        public Counter()
          : base("Counter", "C",
              "Count updates",
              "KTools", "Math")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Ticker", "T", "Generic input to tick the component", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Reset", "R", "Reset", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Updates", "I", "Numbers of update", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            object obj = null;
            bool reset = false;

            if (!DA.GetData(0, ref obj)) return;
            if (!DA.GetData(1, ref reset)) return;

            if (reset)
            {
                updates = -2;
            }

            ++updates;

            DA.SetData(0, updates);
        }

        public override GH_Exposure Exposure => GH_Exposure.secondary;

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.counter;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("BF129251-189C-4ADC-A285-F6CA657B6F7D"); }
        }
    }
}