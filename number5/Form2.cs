using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace number5
{
    public partial class Form2 : Form
    {
        NumberFormatInfo numberFormatInfo = new NumberFormatInfo() //Определяет символ разделяющий целую и дробную часть в работе метода double.Parse()
        {
            NumberDecimalSeparator = ".",
        };

        public Form1 Form1;

        public Form2(Form1 form1)
        {
            Form1 = form1;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBoxA.Text == "" || textBoxB.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Пустое поле", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(textBoxA.Text) > Convert.ToInt32(textBoxB.Text))
                {
                    MessageBox.Show("Стартовое значение не может быть больше конечного!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string function = "f(x)=" + textBox1.Text;
                    double a = Double.Parse(textBoxA.Text, numberFormatInfo);
                    double b = Double.Parse(textBoxB.Text, numberFormatInfo);
                    double accuracy = Double.Parse(textBox2.Text, numberFormatInfo);
                    Function f = new Function(function);
                    if (double.IsNaN(f.calculate(a)))
                    {
                        MessageBox.Show("Неверный формат функции", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Form1.function = function;
                        await Form1.WolframAsync(textBox1.Text);
                        Form1.a = a;
                        Form1.b = b;
                        Form1.eps = accuracy;
                        Form1.ClearChart();
                        Form1.InitChart();
                        Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неопознанная ошибка", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.Enabled = true;
        }

        private void Form2_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Form1.Enabled = true;
        }
    }
}
