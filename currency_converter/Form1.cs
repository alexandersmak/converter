using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace currency_converter
{

    public partial class Form1 : Form
    {

        CultureInfo culture;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            culture = new CultureInfo("ru-RU"); // Устанавливаем культуру на русскую
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // если НЕ ЧИСЛО                  И    НЕ   управляющий символ
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
            {
                // Если   НЕ запятая          и    ЕСТЬ запятая в тексте
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    //  Символ не обрабатывается
                    e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // если НЕ ЧИСЛО                  И    НЕ   управляющий символ
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
            {
                // Если   НЕ запятая          и    ЕСТЬ запятая в тексте
                if (!((e.KeyChar.ToString() == ",") && (textBox2.Text.IndexOf(",") == -1)))
                    //  Символ не обрабатывается
                    e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k; // Курс (отношение рубля к доллару
            double usd; // Цена в долларах
            double rub; // Цена в рублях

            label4.Text = "";

            try
            {
                // исходные данные
                usd = System.Convert.ToDouble(textBox1.Text);
                k = System.Convert.ToDouble(textBox2.Text);

                // пересчет

                rub = usd * k;
         

                // вывод результата
                label4.Text = usd.ToString("N") + "USD = " + rub.ToString("C", culture);

            }

            catch
            {
                // ловим исключение
                if ((textBox1.Text == "") || (textBox2.Text == ""))
                {
                    MessageBox.Show("Ошибка исходных данных.\n" + "Необходимо ввести данные в оба поля. ", "Конвертер", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ошибка исходных данных.\n" + "Необходимо ввести данные в оба поля. ", "Конвертер", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
