using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace laba2
{
    public struct point2D
    {
        public int x;
        public int y;
    }
    public static class RandomProvider
    {
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>new Random(Interlocked.Increment(ref seed)));
        public static Random GetThreadRandom()
        {
            return randomWrapper.Value;
        }
    }

    public class Quadrangle { 
        point2D[] points;
        public point2D[] point;
        public double[] side;
        public double[] diagon = new double[2];
        public double[] angle = new double[2];
        Random r;
       
        int size = 4;
    
        public Quadrangle(int seed) 
        {
            r = new Random(seed);
            this.points = new point2D[4];
            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = r.Next(-5, 10);
                points[i].y = r.Next(-5, 10);
            }
        }
        public void pointParallelo(int seed)
        {
            int num = r.Next(-10,10);
            this.point = new point2D[4];
            point[0].x = r.Next(-5, 5);
            point[0].y = r.Next(-5, 5);
            point[1].x = point[0].x + 5;
            point[1].y = point[0].y;
            point[2].x = point[1].x + num;
            point[2].y = point[1].y + num;
            point[3].x = point[0].x + num;
            point[3].y = point[2].y;
        } 
        public void getSide()
        {
            side = new double[4];
            for (int i = 0; i < points.Length; i++)
            {
                side[i] = (int)Math.Sqrt(Math.Pow(points[(i + 1) % size].x - points[i].x, 2) + Math.Pow(points[(i + 1) % size].y - points[i].y, 2));
                side[i] = Math.Round(side[i], 0);
            }
        }
        public bool exist()
        {
            if ((side[0] < side[1] + side[2] + side[3]) && (side[1] < side[0] + side[2] + side[3]))
            {
                if ((side[2] < side[0] + side[1] + side[3]) && (side[3] < side[0] + side[1] + side[2]))
                    return true;
                else return false;
            }
            else return false;
        }
        public double getPerimetr()
        {
            return side[0] + side[1] + side[2] + side[3];
        }
        public double getArea()
        {
            double p = getPerimetr() / 2;
            return Math.Sqrt(p * (p - side[0]) * (p - side[1]) * (p - side[2]) * (p - side[3]));
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
        public string ShowInfo()
        {
            string info="";
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
            info += $"Perimetr: {getPerimetr()}\n";
            info += $"Area: {String.Format("{0:0.00}", getArea())}\n\n\n";
            return info;
        }

    }
}
