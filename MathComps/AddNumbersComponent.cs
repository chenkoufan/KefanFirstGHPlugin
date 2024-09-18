using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace KefanFirstGHPlugin.MathComps
{

    //   █████╗ ██████╗ ██████╗                                       
    //  ██╔══██╗██╔══██╗██╔══██╗                                      
    //  ███████║██║  ██║██║  ██║                                      
    //  ██╔══██║██║  ██║██║  ██║                                      
    //  ██║  ██║██████╔╝██████╔╝                                      
    //  ╚═╝  ╚═╝╚═════╝ ╚═════╝                                       
    //                                                                
    //  ████████╗██╗    ██╗ ██████╗                                   
    //  ╚══██╔══╝██║    ██║██╔═══██╗                                  
    //     ██║   ██║ █╗ ██║██║   ██║                                  
    //     ██║   ██║███╗██║██║   ██║                                  
    //     ██║   ╚███╔███╔╝╚██████╔╝                                  
    //     ╚═╝    ╚══╝╚══╝  ╚═════╝                                   
    //                                                                
    //  ███╗   ██╗██╗   ██╗███╗   ███╗██████╗ ███████╗██████╗ ███████╗
    //  ████╗  ██║██║   ██║████╗ ████║██╔══██╗██╔════╝██╔══██╗██╔════╝
    //  ██╔██╗ ██║██║   ██║██╔████╔██║██████╔╝█████╗  ██████╔╝███████╗
    //  ██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██╔══██╗╚════██║
    //  ██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██████╔╝███████╗██║  ██║███████║
    //  ╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝
    //  
    public class AddNumbersComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the AddNumbersComponent class.
        /// </summary>
        public AddNumbersComponent()
          : base("AddNumbers", "AddNums",
              "Add two numbers together",
              "KTools", "Math")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("NumberA", "A", "First value to add", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("NumberB", "B", "Second value to add", GH_ParamAccess.item, 0);
        }

        /// <summary> 
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Result", "R", "Addition result", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // define placeholder variables
            double a = 0;
            double b = 0;

            // load values from those varialbes
            if (!DA.GetData(0, ref a)) return;
            if (!DA.GetData(1, ref b)) return;

            // the code actually does the work
            double sum = a + b;

            // oututs
            DA.SetData(0, sum);
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
                return Properties.Resources.add;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("F8EFA84B-A23B-475D-9B52-40B8ECE554F7"); }
        }
    }
}