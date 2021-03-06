﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace laba2
{
    public struct point2D
    {
        public int x;
        public int y;
    }

    public class Quadrangle
    {
        public point2D[] points = new point2D[4];
        public double[] side = new double[4];
        public double[] diagon = new double[2];
        public double[] angle = new double[2];
        public double Perimetr, Area;
        Random r;

        int size = 4;

        public Quadrangle(int seed)
        {
            r = new Random(seed);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = r.Next(-5, 10);
                points[i].y = r.Next(-5, 10);
            }
        }
        public Quadrangle() { }
        public void getSide()
        {
            for (int i = 0; i < points.Length; i++)
            {
                side[i] = (int)Math.Sqrt(Math.Pow(points[(i + 1) % size].x - points[i].x, 2) + Math.Pow(points[(i + 1) % size].y - points[i].y, 2));
                side[i] = Math.Round(side[i], 0);
            }
        }
        public bool IsExist()
        {
            if ((side[0] < side[1] + side[2] + side[3]) && (side[1] < side[0] + side[2] + side[3]) && !double.IsNaN(angle[0]) && !double.IsNaN(angle[1]) && angle[0] > 0)
            {
                if ((side[2] < side[0] + side[1] + side[3]) && (side[3] < side[0] + side[1] + side[2]))
                    return true;
                else return false;
            }
            else return false;
        }
        public void getPerimetr()
        {
            Perimetr = side[0] + side[1] + side[2] + side[3];
        }
        public void getArea()
        {
            double p = Perimetr / 2;
            Area = Math.Sqrt(p * (p - side[0]) * (p - side[1]) * (p - side[2]) * (p - side[3]));
        }
        public void getAngle()
        {
            for (int i = 0; i < 2; i++)
            {
                angle[i] = Math.Acos((points[(i + 1) % size].x * points[i].x + points[(i + 1) % size].y * points[i].y) / (side[i] * side[(i + 1) % size]));
            }
        }
        public void getDiagon()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    diagon[i] = Math.Sqrt(Math.Pow(side[j], 2) + Math.Pow(side[(j + 1) % size], 2) - 2 * side[j] * side[(j + 1) % size] * Math.Cos(angle[i]));
                    diagon[i] = Math.Round(diagon[i], 0);
                }
            }
        }
        public bool checkParallelogram()
        {
            bool result = false;
            if (side[0] == side[2] && side[1] == side[3])
                result = true;
            return result;

        }
        public string ShowInfo()
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
            info += $"1 diagonal : {diagon[0]}\n";
            info += $"2 diagonal : {diagon[1]}\n";
            info += $"Perimetr: {Perimetr}\n";
            info += $"Area: {String.Format("{0:0.00}", Area)}\n\n\n";
            return info;
        }
        public void Write(BinaryWriter bw)
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
            bw.Write(Area);
        }
        public Quadrangle Read(BinaryReader br)
        {
            Quadrangle temp = new Quadrangle();

            for (int i = 0; i < points.Length; i++)
            {
                temp.points[i].x = br.ReadInt32();
                temp.points[i].y = br.ReadInt32();
            }
            for (int i = 0; i < points.Length; i++)
            {
                temp.side[i] = br.ReadDouble();
            }
            for (int i = 0; i < 2; i++)
            {
                temp.diagon[i] = br.ReadDouble();
            }
            temp.Perimetr = br.ReadDouble();
            temp.Area = br.ReadDouble();

            return temp;
        }
    }
}

