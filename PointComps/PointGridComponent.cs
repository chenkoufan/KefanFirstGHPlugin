using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace KefanFirstGHPlugin.PointComps
{
    public class PointGridComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the PointGridComponent class.
        /// </summary>
        public PointGridComponent()
          : base("Point Grid", "PtGrid",
              "Creates a grid of ponts",
              "KTools", "Point")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Start", "S", "Starting Point", GH_ParamAccess.item,new Point3d(0,0,0));
            pManager.AddIntegerParameter("CountX", "NX", "Elements in X", GH_ParamAccess.item, 10);
            pManager.AddIntegerParameter("CountY", "NY", "Elements in Y", GH_ParamAccess.item, 10);
            pManager.AddNumberParameter("StepX", "DX", "Distance in X", GH_ParamAccess.item, 1);
            pManager.AddNumberParameter("StepY", "DY", "Distance in Y", GH_ParamAccess.item, 1);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Grids", "P", "Grid of Points", GH_ParamAccess.tree);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d S = Point3d.Unset;
            int NX = 0;
            int NY = 0;
            double DX = 0;
            double DY = 0;

            DA.GetData(0, ref S);
            DA.GetData(1, ref NX);
            DA.GetData(2, ref NY);
            DA.GetData(3, ref DX);
            DA.GetData(4, ref DY);

            // algorithm
            GH_Structure<GH_Point> pts = new GH_Structure<GH_Point>();

            for (int j = 0; j < NY; j++)
            {
                double y = S.Y + DY * j;
                GH_Path path = new GH_Path(j);

                for (int i = 0; i < NX; i++)
                {
                    double x = S.X + DX * i;
                    Point3d p = new Point3d(x, y, S.Z);
                    pts.Append(new GH_Point(p), path);

                }

                DA.SetDataTree(0, pts);

            }

            //for (int i = 0; i < NX; i++)
            //{
            //    for (int i = 0; i < length; i++)
            //    {

            //    }

            //}


        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.grid;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("0A05F1B7-16E0-4972-A5FE-FCE0CC0A0A9F"); }
        }
    }
}