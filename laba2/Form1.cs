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
        Parallelogram[] parallelograms;
        double average = 0;
        int max = 0;
        int min = 0;
        public int n, m;
        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public Form1()
        {
            InitializeComponent();
        }
        private void genN_Click(object sender, EventArgs e)
        {
            int seed = 0;
            QuadrangleText.Text = "";
            ParallelogramText.Text = "";
            try
            {
                N = Convert.ToInt32(InputN.Text);
                M = Convert.ToInt32(InputM.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            quadrangle = new Quadrangle[N];
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
                } while (!quadrangle[i].IsExist());
                QuadrangleText.Text += $"[{i + 1}] quadrangle's data:\n {quadrangle[i].ShowInfo()}";
            }
            if (n != 0)
            {
                //double average = 0;
                double sum = 0;
                int q = 0;
                if (quadrangle.Length > 0)
                {
                    for (int i = 0; i < quadrangle.Length; i++)
                    {
                        sum += quadrangle[i].Area;
                    }
                    average = sum / quadrangle.Length;
                }
                QuadrangleText.Text += $"Average area of quadrangles(N): {String.Format("{0:0.00}", average)}\n\n";
                for (int i = 0; i < n; i++)
                {
                    if (quadrangle[i].checkParallelogram() == true)
                    {
                        QuadrangleText.Text += $"Number of found parallelogram: [{i + 1}]\n";
                        q++;
                    }
                }
                if (q == 0)
                    QuadrangleText.Text += $"No parallelograms in the array\n";
            }

            parallelograms = new Parallelogram[M];
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
                } while (!parallelograms[i].IsExist() && !parallelograms[i].checkParallelogram());
            }
            //int max = 0;
            //int min = 0;
            if (m != 0)
            {
                for (int i = 1; i < parallelograms.Length; i++)
                {
                    if ((parallelograms[max].AreaP) < (parallelograms[i].AreaP))
                        max = i;
                    if ((parallelograms[min].AreaP) > (parallelograms[i].AreaP))
                        min = i;
                }
                ParallelogramText.Text += $"The number of max parallelogram's area(M): [{(max + 1)}]\n";
                ParallelogramText.Text += $"The number of min parallelogram's area(M): [{(min + 1)}]\n";
            }
        }
        private void openN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Word Documents| *.doc|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
            //инициализируем массив кол-вом значенний 
            N = br.ReadInt32();
            M = br.ReadInt32();

            quadrangle = new Quadrangle[N];
            for (int i = 0; i < N; i++)
            {
            //Считываем значения с файла
                quadrangle[i] = new Quadrangle();
                quadrangle[i] = quadrangle[i].Read(br);
            }
            parallelograms = new Parallelogram[M];
            for (int i = 0; i < M; i++)
            {
                //Считываем значения с файла
                parallelograms[i] = new Parallelogram();
                parallelograms[i] = parallelograms[i].Read(br);
            }
            ShowAll();
            br.Close();
            fs.Close();

            MessageBox.Show("File is opened");
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(N);
            bw.Write(M);
            for (int i = 0; i < N; i++)
            {
                quadrangle[i].Write(bw);
            }
            for (int i = 0; i < M; i++)
            {
                parallelograms[i].WriteParal(bw);
            }
        }

        private void saveN_Click(object sender, EventArgs e)
        {
            if (N != 0 && M != 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Word Documents| *.doc|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                //файловый поток
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                //бинарный записователь 
                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
                Write(bw);
                bw.Close();
                fs.Close();
                MessageBox.Show("File is saved");
            }
            else MessageBox.Show("Input quantity, please");
        }
        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void InputM_TextChanged(object sender, EventArgs e)
        {

        }
        private void InputN_TextChanged(object sender, EventArgs e)
        {

        }
        public void ShowAll()
        {
            QuadrangleText.Text = "";
            ParallelogramText.Text = "";
            for (int i = 0; i < N; i++)
            {
                QuadrangleText.Text += "QUADRANGLE: " + (i + 1) + "\n";
                QuadrangleText.Text += quadrangle[i].ShowInfo();
                QuadrangleText.Text += "******************************\n";
            }
            QuadrangleText.Text += $"Average area of quadrangles(N): {Math.Round(average, 1)}\n\n";
            for (int i = 0; i < M; i++)
            {
                ParallelogramText.Text += "PARALLELOGRAM: " + (i + 1) + "\n";
                ParallelogramText.Text += parallelograms[i].ShowInfoP();
                ParallelogramText.Text += "******************************\n";
            }
            ParallelogramText.Text += $"The number of max parallelogram's area(M): [{(max + 1)}]\n";
            ParallelogramText.Text += $"The number of min parallelogram's area(M): [{(min + 1)}]\n";
            
        }
    }
}

