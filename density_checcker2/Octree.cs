using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace density_checcker2
{
    public class octree
    {
        //aa
        public static double boxelsize;
        public static point3D cp = new point3D();
        public static point3D bp = new point3D();
        public static point3D pass = new point3D();
        public int deep=1;

        public class Counting
        {
            public int mpoint, boxelsum;
            public ulong sum;
            public double average;

            public Counting()
            {
                mpoint = 0; boxelsum = 0;
                sum = 0;
                average = 0;
            }
        }

        public class Node
        {
            public int count;
            public point3D point;
            public Node[] children;

            public Node()
            {
                count = 0;
                point = new point3D();
                //children = new Node[8];
                children = null;
            }
        }

        public class point3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public point3D()
            {
                X = 0;
                Y = 0;
                Z = 0;
            }

            internal void Ini()
            {
                X = 0;
                Y = 0;
                Z = 0;
            }

            internal class pget : point3D
            {
                public double v1;
                public double v2;
                public double v3;

                public pget(double v1, double v2, double v3)
                {
                    this.X = v1;
                    this.Y = v2;
                    this.Z = v3;
                }
            }
        }

        public void PointWrite(Node node,double currentboxelsize)
        {
            if (currentboxelsize < boxelsize)
            {
                if (node.count == 0) Form1.count.boxelsum++;
                node.count++;
                if (node.count > Form1.count.mpoint) Form1.count.mpoint = node.count;
                Form1.count.sum++;
                //Console.WriteLine(node.count);
                bp.Ini();cp.Ini();
                return;
            }



            int order = 0;//octreeの場所決め
            Node nextnode = new Node();

            double halfsize = currentboxelsize / 2;

            if (bp.X < cp.X)
            {
                order += 4;
                bp.X += currentboxelsize / 4;
            }
            else
            {
                bp.X -= currentboxelsize / 4;
            }

            if (bp.Y < cp.Y)
            {
                order += 2;
                bp.Y += currentboxelsize / 4;
            }
            else
            {
                bp.Y -= currentboxelsize / 4;
            }
            if (bp.Z < cp.Z)
            {
                order += 1;
                bp.Z += currentboxelsize / 4;
            }
            else
            {
                bp.Z -= currentboxelsize / 4;
            }

            //Console.WriteLine(bp.X);
            //Console.WriteLine(bp.Y);
            //Console.WriteLine(bp.Z);
            if (node.children == null) node.children = new Node[8];
            if (node.children[order]==null) node.children[order] = nextnode;
            PointWrite(node.children[order],halfsize);
            Form1.count.average = Form1.count.sum / (double)Form1.count.boxelsum;
        }

        public void PointRead(Node node,StreamWriter writer,point3D rp)
        {
            var convertRGB = new HSVtoRGB();
            deep++;

            if (node.count != 0)
            {
                #region ストリームライター
                    int[] RGB = { 0, 0, 0 };
                    RGB = convertRGB.Convert_RGB((250 - 250 * node.count / 100000), 1, 1); 
                    writer.WriteLine(rp.X + "," + rp.Y + "," + rp.Z + "," + RGB[0] + "," + RGB[1] + "," + RGB[2] + "," + node.count);
                    node = null;
                    deep--;
                    return;
                #endregion
                #region ファイルライター？
                /*
                int[] RGB = { 0, 0, 0 };
                RGB = convertRGB.Convert_RGB((250 - 250 * node.count / 100000), 1, 1);
                File.AppendAllText(@"C:\test\octree2.txt", node.point.X + "," + node.point.Y + "," + node.point.Z + ","  + RGB[0] + "," + RGB[1] + "," + RGB[2] +","+node.count+","+ Environment.NewLine);
                */
                #endregion
            }
            

            if (node.children != null && node.children[0] != null) PointRead(node.children[0], writer, new point3D.pget(rp.X - Form1.check_area / Math.Pow(2, deep), rp.Y - Form1.check_area / Math.Pow(2, deep), rp.Z - Form1.check_area / Math.Pow(2, deep)));
            if (node.children != null && node.children[1] != null) PointRead(node.children[1], writer, new point3D.pget(rp.X - Form1.check_area / Math.Pow(2, deep), rp.Y - Form1.check_area / Math.Pow(2, deep), rp.Z + Form1.check_area / Math.Pow(2, deep)));
            if (node.children != null && node.children[2] != null) PointRead(node.children[2], writer, new point3D.pget(rp.X - Form1.check_area / Math.Pow(2, deep), rp.Y + Form1.check_area / Math.Pow(2, deep), rp.Z - Form1.check_area / Math.Pow(2, deep)));
            if (node.children != null && node.children[3] != null) PointRead(node.children[3], writer, new point3D.pget(rp.X - Form1.check_area / Math.Pow(2, deep), rp.Y + Form1.check_area / Math.Pow(2, deep), rp.Z + Form1.check_area / Math.Pow(2, deep)));
            if (node.children != null && node.children[4] != null) PointRead(node.children[4], writer, new point3D.pget(rp.X + Form1.check_area / Math.Pow(2, deep), rp.Y - Form1.check_area / Math.Pow(2, deep), rp.Z - Form1.check_area / Math.Pow(2, deep)));
            if (node.children != null && node.children[5] != null) PointRead(node.children[5], writer, new point3D.pget(rp.X + Form1.check_area / Math.Pow(2, deep), rp.Y - Form1.check_area / Math.Pow(2, deep), rp.Z + Form1.check_area / Math.Pow(2, deep)));
            if (node.children != null && node.children[6] != null) PointRead(node.children[6], writer, new point3D.pget(rp.X + Form1.check_area / Math.Pow(2, deep), rp.Y + Form1.check_area / Math.Pow(2, deep), rp.Z - Form1.check_area / Math.Pow(2, deep)));
            if (node.children != null && node.children[7] != null) PointRead(node.children[7], writer, new point3D.pget(rp.X + Form1.check_area / Math.Pow(2, deep), rp.Y + Form1.check_area / Math.Pow(2, deep), rp.Z + Form1.check_area / Math.Pow(2, deep)));
            deep--;
            return;

        }
    }
}
