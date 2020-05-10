using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        public int n, m;
        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public Form1()
        {
            InitializeComponent();
            openN.Click += openN_Click;
            saveN.Click += saveN_Click;
            openM.Click += openM_Click;
            saveM.Click += saveM_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }
        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public class Parallelogram : Quadrangle
        {
            public Parallelogram(int seed) : base(seed) { }
            int size = 4;
            public void getSideP(int seed)
            {                
                side = new double[4];
                pointParallelo(seed);
                for (int i = 0; i < size; i++)
                {
                    side[i] = (int)Math.Sqrt(Math.Pow(point[(i + 1) % size].x - point[i].x, 2) + Math.Pow(point[(i + 1) % size].y - point[i].y, 2));
                    side[i] = Math.Round(side[i], 0);
                }
            }
            public double getAreaP()
            {
                return side[0] * side[1] * Math.Sin(angle[0]);
            }
            public string ShowInfoP()
            {
                string info = "";
                for (int i = 0; i < size; i++)
                {
                    info += $"Point {i + 1}: х = {point[i].x},\t у = {point[i].y}\n";
                }
                for (int i = 0; i < size; i++)
                {
                    info += $"{i + 1} side :  {side[i]}   \n";
                }              
                info += $"Perimetr: {getPerimetr()}\n";
                info += $"Area: {String.Format("{0:0.00}", getAreaP())}\n\n\n";
                return info;
            }
            public bool checkParallelogram()
            {
                getSide();
                if (side[0] == side[2] && side[1] == side[3])
                    return true;
                else return false;
            }
        }
        private void genN_Click(object sender, EventArgs e)
        {
            QuadrangleText.Text = "";
            try
            {
                N = Convert.ToInt32(NumberN.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            Quadrangle[] quadrangle = new Quadrangle[N];
            int seed = 0;
            for (int i = 0; i < n; i++)
            {
               do
                {
                    quadrangle[i] = new Quadrangle(seed++);
                    quadrangle[i].getSide();
                    quadrangle[i].getAngle();
                    quadrangle[i].getDiagon();
                    quadrangle[i].getPerimetr();
                    quadrangle[i].getArea();
                } while (!quadrangle[i].exist()) ;
                    QuadrangleText.Text += $"[{i+1}] quadrangle's data:\n {quadrangle[i].ShowInfo()}";
            }
            double average = 0;
            double sum = 0;
            int q = 0;
            if (quadrangle.Length > 0)
            {
                for (int i = 0; i < quadrangle.Length; i++)
                {
                    sum += quadrangle[i].getArea();
                }
                average = sum / quadrangle.Length;
            }
            QuadrangleText.Text += $"Average area of quandrangles(N): {String.Format("{0:0.00}", average)}\n\n";
            Parallelogram[] parallelogram = new Parallelogram[N];
            for (int i = 0; i < n; i++)
            {                
                parallelogram[i] = new Parallelogram(seed++);
                if (parallelogram[i].checkParallelogram() == true)
                {
                    QuadrangleText.Text += $"Number of found parallelogram: [{i + 1}]\n";
                    q++;
                }                
            }
            if (q == 0)
                QuadrangleText.Text += $"No parallelograms in the array\n";
        }

       
        private void saveN_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, QuadrangleText.Text);
            MessageBox.Show("File is saved");
        }
        private void openN_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            QuadrangleText.Text = fileText;
            MessageBox.Show("File is opened");
        }

        private void genM_Click(object sender, EventArgs e)
        {
            ParallelogramText.Text = "";
            try
            {
                M = Convert.ToInt32(NumberM.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            Parallelogram[] parallelogrames = new Parallelogram[M];
            int seed = 0;
            for (int i = 0; i < m; i++)
            {
               do
                {
                    parallelogrames[i] = new Parallelogram(seed++);
                    parallelogrames[i].getSideP(seed);
                    parallelogrames[i].getAngle();                    
                    parallelogrames[i].getPerimetr();
                    parallelogrames[i].getAreaP();
                    ParallelogramText.Text += $"[{i + 1}] parallelogram's data:\n {parallelogrames[i].ShowInfoP()}";
                } while (!parallelogrames[i].exist() && !parallelogrames[i].checkParallelogram()) ;
            }
            int max = 0;
            int min = 0;
            if (parallelogrames.Length > 0)
            {
                for (int i = 1; i < parallelogrames.Length; i++)
                {
                    if ((parallelogrames[max].getAreaP()) < (parallelogrames[i].getAreaP()))
                        max = i;
                    if ((parallelogrames[min].getAreaP()) > (parallelogrames[i].getAreaP()))
                        min = i;
                }
            }
            ParallelogramText.Text += $"The number of max parallelogram's area(M): [{(max + 1)}]\n";
            ParallelogramText.Text += $"The number of min parallelogram's area(M): [{(min + 1)}]\n";
        }
       
        private void saveM_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, ParallelogramText.Text);
            MessageBox.Show("File is saved");

        }
        private void openM_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            ParallelogramText.Text = fileText;
            MessageBox.Show("File is opened");
        }

    }
}
