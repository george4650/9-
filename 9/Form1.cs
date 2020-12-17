using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_15;

namespace _9
{
    public partial class Form1 : Form
    {
        List<Factory> factories = new List<Factory>();
        public Form1()
        {
            InitializeComponent();
        }

        private void добавитьСтанокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Int32.TryParse(textBox2.Text, out int dop))
            {
                Factory factory = new Factory(textBox1.Text, dop);
                factories.Add(factory);
                listBox1.Items.Add(factory.GetString());
            }
            else
            {
                MessageBox.Show("Время должно быть целым числом");
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void удалитьСтанокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // если выбрано значение
            if(listBox1.SelectedIndex!=-1)
            {
                //удаляем сначала из коллекции
                factories.RemoveAt(listBox1.SelectedIndex);
                // потом из листбокса
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Элемент не выбран");
            }
        }

        private void сбросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            factories.Clear();
        }

        private void вывестиСуммарноеВремяПростояToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dt = 0;
            for(int i = 0;i<factories.Count;i++)
            {
                dt += factories[i].DowntimePerMonth;
            }
            textBox3.Text = dt.ToString();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Описать, используя структуру, завод (наименование станка, время простоя в месяц, время работы в месяц). Вывести результат на экран." +
                " Вывести информацию, показывающую общее время простоя на заводе.");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
