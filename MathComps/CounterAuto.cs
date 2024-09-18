using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace KefanFirstGHPlugin.MathComps
{
    public class CounterAuto : GH_Component
    {
        // persistent fields
        int updates = 0;

        /// <summary>
        /// Initializes a new instance of the Counter class.
        /// </summary>
        public CounterAuto()
          : base("CounterAuto", "CA",
              "Count updates automatically",
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
            pManager.AddBooleanParameter("AutoUpdate", "AU", "Auto update", GH_ParamAccess.item);
            pManager.AddIntegerParameter("UpdateInterval", "I", "Interval in millis", GH_ParamAccess.item);

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
            bool autoupdate = false;
            int millis = 1000;

            if (!DA.GetData(0, ref obj)) return;
            if (!DA.GetData(1, ref reset)) return;
            if (!DA.GetData(2, ref autoupdate)) return;
            if (!DA.GetData(3, ref millis)) return;

            if (millis<5)
            {
                millis = 5;
            }

            if (reset)
            {
                updates = -2;
            }

            ++updates;

            DA.SetData(0, updates);

            // schedule updates if necessary
            if (autoupdate)
            {
                this.OnPingDocument().ScheduleSolution(millis, ScheduleCallback);
            }
        }

        public void ScheduleCallback(GH_Document doc)
        {
            this.ExpireSolution(false);
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
                return Properties.Resources.counterAuto;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("3daf6aba-4927-4c9f-b1f3-f78cbbbefe94"); }
        }
    }
}