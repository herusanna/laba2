using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace laba2
{
    public partial class Form1 : Form
    {
       Quadrangle[] quadrangle;

        int seed = 0;
        public int n, m;
        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public Form1()
        {
            InitializeComponent();
           // openN.Click += openN_Click;
            //saveN.Click += saveN_Click;
            //openM.Click += openM_Click;
            //saveM.Click += saveM_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            ///saveFileDialog1.Filter = "Word Documents| *.doc|All files (*.*)|*.*";

        }
        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public class Parallelogram : Quadrangle
        {
            double getAP;
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
                getAP = side[0] * side[1] * Math.Sin(angle[0]);
                return getAP;
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
        
        public Parallelogram ReadBin (BinaryReader br)
        {
                int seed = 0;
            Parallelogram info = new Parallelogram(seed++);

            for (int i = 0; i < size; i++)
            {
                info.point[i].x = br.ReadInt32();
                info.point[i].y = br.ReadInt32();
            }
            for (int i = 0; i < size; i++)
            {
                info.side[i] = br.ReadDouble();
            }
            for (int i = 0; i < 3; i++)
            {
                info.angle[i] = br.ReadDouble();
            }
            info.getP = br.ReadDouble();
            info.getAP = br.ReadDouble();
            return info;
        }
        
        }
        Parallelogram[] parallelograms;
        Parallelogram parallelogram;
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
            if (N != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
                WriteBin(bw);
                bw.Close();
                fs.Close(); 
                MessageBox.Show("File is saved");              
                // System.IO.File.WriteAllText(filename, ParallelogramText.Text);
               
            }  else MessageBox.Show("Input quantity");
        }
        private void openN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
            // string fileText = System.IO.File.ReadAllText(filename);
            //QuadrangleText.Text = fileText;
            N = br.ReadInt32();
            M = br.ReadInt32();
            for (int i = 0; i < N; i++)
            {
                quadrangle[i] = new Quadrangle(seed);
                quadrangle[i] = quadrangle[i].ReadBin(br);
            }
            for (int i = 0; i < M; i++)
            {
                parallelograms[i] = new Parallelogram(seed);
                parallelograms[i] = parallelograms[i].ReadBin(br);
            }
            ShowAll();

            if (M != 0)
            {
               Parallelogram parallelogram = new Parallelogram(seed);
                parallelogram = parallelogram.ReadBin(br);
                ParallelogramText.Text += parallelogram.ShowInfoP();
            }
            br.Close();
            fs.Close();
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
            Parallelogram[] parallelograms = new Parallelogram[M];
            for (int i = 0; i < m; i++)
            {
               do
                {
                    parallelograms[i] = new Parallelogram(seed++);
                    parallelograms[i].getSideP(seed);
                    parallelograms[i].getAngle();                    
                    parallelograms[i].getPerimetr();
                    parallelograms[i].getAreaP();
                    ParallelogramText.Text += $"[{i + 1}] parallelogram's data:\n {parallelograms[i].ShowInfoP()}";
                } while (!parallelograms[i].exist() && !parallelograms[i].checkParallelogram()) ;
            }
            int max = 0;
            int min = 0;
            if (parallelograms.Length > 0)
            {
                for (int i = 1; i < parallelograms.Length; i++)
                {
                    if ((parallelograms[max].getAreaP()) < (parallelograms[i].getAreaP()))
                        max = i;
                    if ((parallelograms[min].getAreaP()) > (parallelograms[i].getAreaP()))
                        min = i;
                }
            }
            ParallelogramText.Text += $"The number of max parallelogram's area(M): [{(max + 1)}]\n";
            ParallelogramText.Text += $"The number of min parallelogram's area(M): [{(min + 1)}]\n";
        }
       
        private void saveM_Click(object sender, EventArgs e)
        {
            if (M!=0) {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                if (filename != "")
                {
                    using (StreamWriter sf = new StreamWriter(saveFileDialog1.OpenFile()))
                    {
                        sf.Write("Parallelograms:\n");
                        sf.Write(ParallelogramText.Text);
                    }
                }
                else MessageBox.Show("Input quantity");
                // System.IO.File.WriteAllText(filename, ParallelogramText.Text);
                MessageBox.Show("File is saved");
            }
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
        public void WriteBin(BinaryWriter bw)
        {
            bw.Write(N);
            bw.Write(M);
            Quadrangle[] quadrangle = new Quadrangle[N];
            Parallelogram parallelogram = new Parallelogram(seed);
            Parallelogram[] parallelograms = new Parallelogram[M];
            for (int i = 0; i < N; i++)
            {
                quadrangle[i].WriteBin(bw);
            }
            for (int i = 0; i < M; i++)
            {
                parallelograms[i].WriteBin(bw);
            }
            if (M != 0)
            {
                parallelogram.WriteBin(bw);
            }
        }
        public void ShowAll()
        {
            QuadrangleText.Text = "";
            ParallelogramText.Text = "";
            for (int i = 0; i < N; i++)
            {
                QuadrangleText.Text += "NUMBER: " + (i + 1) + "\n";
                QuadrangleText.Text += quadrangle[i].ShowInfo();
                QuadrangleText.Text += "----------------------------\n";
            }
            for (int i = 0; i < M; i++)
            {
                ParallelogramText.Text += "NUMBER: " + (i + 1) + "\n";
                ParallelogramText.Text += parallelograms[i].ShowInfoP();
                ParallelogramText.Text += "----------------------------\n";
            }
        }
    }
}
