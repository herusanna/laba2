using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba2
{
    public class Parallelogram : Quadrangle
    {
        public double AreaP;
        public Parallelogram(int seed) : base(seed)
        {
            Random r = new Random();
            r = new Random(seed);
            int num = r.Next(-10, 10);
            points[0].x = r.Next(-5, 5);
            points[0].y = r.Next(-5, 5);
            points[1].x = points[0].x + 5;
            points[1].y = points[0].y;
            points[2].x = points[1].x + num;
            points[2].y = points[1].y + num;
            points[3].x = points[0].x + num;
            points[3].y = points[2].y;
        }
        public Parallelogram() { }
        int size = 4;
        public void getSideP(int seed)
        {
            for (int i = 0; i < size; i++)
            {
                side[i] = (int)Math.Sqrt(Math.Pow(points[(i + 1) % size].x - points[i].x, 2) + Math.Pow(points[(i + 1) % size].y - points[i].y, 2));
                side[i] = Math.Round(side[i], 0);
            }
        }
        public void getAreaP()
        {
            AreaP = side[0] * side[1] * Math.Sin(angle[0]);
        }
        public string ShowInfoP()
        {
            string info = "";
            for (int i = 0; i < size; i++)
            {
                info += $"Point {i + 1}: х = {points[i].x},\t у = {points[i].y}\n";
            }
            for (int i = 0; i < size; i++)
            {
                info += $"{i + 1} side :  {side[i]}   \n";
            }
            info += $"Perimetr: {Perimetr}\n";
            info += $"Area: {String.Format("{0:0.00}", AreaP)}\n\n\n";
            return info;
        }
        public void WriteParal(BinaryWriter bw)
        {
            for (int i = 0; i < points.Length; i++)
            {
                bw.Write(points[i].x);
                bw.Write(points[i].y);
            }
            for (int i = 0; i < points.Length; i++)
            {
                bw.Write(side[i]);
            }
            for (int i = 0; i < 2; i++)
            {
                bw.Write(diagon[i]);
            }
            bw.Write(Perimetr);
            bw.Write(AreaP);
        }
        public Parallelogram Read(BinaryReader br)
        {
            Parallelogram info = new Parallelogram();
            for (int i = 0; i < size; i++)
            {
                info.points[i].x = br.ReadInt32();
                info.points[i].y = br.ReadInt32();
            }
            for (int i = 0; i < size; i++)
            {
                info.side[i] = br.ReadDouble();
            }
            for (int i = 0; i < 2; i++)
            {
                info.angle[i] = br.ReadDouble();
            }
            info.Perimetr = br.ReadDouble();
            info.AreaP = br.ReadDouble();
            return info;
        }

    }
}
