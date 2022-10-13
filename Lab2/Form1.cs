namespace Lab2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using System.Reflection.Emit;
    using System.Diagnostics.Metrics;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Обработчик клавиши очистить

        }

        public void Moranda(EventArgs e_Moranda) {
            try
            { //Проверка вводимых значений на пустоту

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите число ошибок первоначально находящихся в программе!", "Модель Джелинского-Моранды");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите коэффициент пропорциональности!", "Модель Джелинского-Моранды");
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Введите количество ошибок спустя время!", "Модель Джелинского-Моранды");
                }
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Введите время обнаружения i-ошибки!", "Модель Джелинского-Моранды");
                }

                int t1;

                if (!int.TryParse(textBox1.Text, out t1))

                    MessageBox.Show("Введите числовое значение!");

                int t2;

                if (!int.TryParse(textBox2.Text, out t2))

                    MessageBox.Show("Введите числовое значение!");

                int t3;

                if (!int.TryParse(textBox3.Text, out t3))

                    MessageBox.Show("Введите числовое значение!");

                int t4;

                if (!int.TryParse(textBox4.Text, out t4))

                    MessageBox.Show("Введите числовое значение!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }

            double lambda, C, N, i, P, t;
            N = Double.Parse(textBox1.Text);

            C = Double.Parse(textBox2.Text);

            i = Double.Parse(textBox4.Text);

            t = Double.Parse(textBox3.Text);

            lambda = C * (N - i + 1);

            P = lambda * Math.Exp(lambda * (-1) * t);

            textBox5.Text = " Функция плотности распределения времени обнаружения i-й ошибки, отсчитываемого от момента выявления:" + P.ToString();

            label8.Text = N.ToString();
            label10.Text = C.ToString();
            label12.Text = i.ToString();
            label14.Text = t.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { //Проверка вводимых значений на пустоту

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите число ошибок первоначально находящихся в программе!", "Модель Джелинского-Моранды");
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите коэффициент пропорциональности!", "Модель Джелинского-Моранды");
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Введите количество ошибок спустя время!", "Модель Джелинского-Моранды");
                }
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Введите время обнаружения i-ошибки!", "Модель Джелинского-Моранды");
                }

                int t1;

                if (!int.TryParse(textBox1.Text, out t1))

                    MessageBox.Show("Введите числовое значение!");

                int t2;

                if (!int.TryParse(textBox2.Text, out t2))

                    MessageBox.Show("Введите числовое значение!");

                int t3;

                if (!int.TryParse(textBox3.Text, out t3))

                    MessageBox.Show("Введите числовое значение!");

                int t4;

                if (!int.TryParse(textBox4.Text, out t4))

                    MessageBox.Show("Введите числовое значение!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }

            double lambda, C, N, i, P, t;

            N = Double.Parse(textBox1.Text);

            C = Double.Parse(textBox2.Text);

            i = Double.Parse(textBox4.Text);

            t = Double.Parse(textBox3.Text);

            lambda = C * (N - i + 1);

            P = lambda * Math.Exp(lambda * (-1) * t);
            decimal res = Convert.ToDecimal(P);
            //res = Math.Round(P, 2);

            textBox5.Text = " Функция плотности распределения времени обнаружения i-й ошибки, отсчитываемого от момента выявления:" + P.ToString();
            richTextBox1.Text = " Функция плотности распределения времени обнаружения i-й ошибки, отсчитываемого от момента выявления:" + res.ToString();

            label8.Text = N.ToString();
            label10.Text = C.ToString();
            label12.Text = i.ToString();
            label14.Text = t.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = textBox6.Text;
            //string[] subs = input.Split(';');
            List<string> subs = new List<string>();
            subs = input.Split(';').ToList();
            //double[] converted = new double[] { };
            List<double> converted = new List<double>();
            //int[] additional = new int[] { };
            List<int> additional = new List<int>();

            int counter = 0;

            double[] errors;
            double[] risk;
            double[] medTime;
            double[] endTest;

            
            foreach (var sub in subs) {
                Console.WriteLine($"Substring: {sub}");
                counter++;
            }

            for (int i = 0; i < counter; i++) {
                converted.Add(Convert.ToDouble(subs[i]));
                additional.Add(i+1);
            }

            double a, x0;
            List<double> bMass = new List<double>();
            for (int i = 0; i < counter; i++) {
                bMass.Add((i + 1) * converted[i]);
            }

            x0 = converted.ToArray().Sum();
            a = bMass.ToArray().Sum()/x0;
            int b = B(26, a);


            //Общее число ошибок в программе (B):
            /*List<double> errorsSum = new List<double>();
            double x1,x2,x3;
            for (int i = 0; i < counter; i++) {
                errorsSum.Add((i+1) * converted[i]);
            }
            x1 = b  * converted.ToArray().Sum();
            x2 = converted.ToArray().Sum();
            x3 = errorsSum.ToArray().Sum();
            double errorsRes = x1/(b+1)*(x2-x3);*/

            label20.Text = b.ToString();


            //Коэффициент пропорциональности (k):
            List<double> riskSum = new List<double>();
            double x4;
            for (int i = 0; i < counter; i++) {
                //riskSum.Add((i+1) * converted[i]);
                riskSum.Add((b - i + 1) * converted[i]);
            }
            //x4 = converted.ToArray().Sum();
            //double riskRes = counter / (b + 1) * x4 - riskSum.ToArray().Sum();
            double riskRes = counter / riskSum.ToArray().Sum();
            label21.Text = riskRes.ToString();


            //Среднее время Xn+1 до появления (n+1)-й ошибки:
            double medTimeSum = 0;
            medTimeSum = 1 / (riskRes * (b - counter));
            label22.Text = medTimeSum.ToString();
            //MessageBox.Show(medTimeSum.ToString());


            //Время до окончания тестирования (t):
            //double[] endTestSum = new double[] { };
            List<double> endTestSum = new List<double>();
            for (int i = 1; i <= b-counter; i++)
            {
                endTestSum.Add(1.0/i);
            }
            double endTestRes = endTestSum.ToArray().Sum();
            endTestRes = (1 / riskRes) * endTestRes;
            label23.Text = endTestRes.ToString();
            //MessageBox.Show(endTestRes.ToString());
        }


        static private double f(int m, int n)
        {
            double f = 0;
            double M = m;
            for (int j = 1; j <= n; j++)
            {
                f = f + (1 / (M - j));
            }
            return f;
        }

        static private double g(int m, int n, double A)
        {
            double g = 0;

            g += n / (m - A);

            return g;
        }

        static private int B(int n, double A)
        {
            double x = 0;
            int b = 0;
            double minX = 9999999;
            int M = 0;
            for (int m = n + 1; m < 100; m++)
            {
                x = Math.Abs(f(m, 26) - g(m, 26, A));
                if (x < minX)
                {
                    minX = x;
                    M = m;
                }
            }
            b = M - 1;
            return b;
        }
    }
}