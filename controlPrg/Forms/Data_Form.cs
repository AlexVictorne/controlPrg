using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlPrg
{
    public partial class Data_Form : Form
    {
        public Data_Form()
        {
            InitializeComponent();
        }

        private void Data_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet1.Table_Data". При необходимости она может быть перемещена или удалена.
            this.table_DataTableAdapter.Fill(this.databaseDataSet1.Table_Data,"1","1",0,0);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.databaseDataSet.Table, 1, "друзь", 0.1, 0, 0, 0);
        }


        

        private void button1_Click_1(object sender, EventArgs e)
        {
            int par1 = 0, par2 = 0, par3 = 0;
            int neuron = 0;
            double weight = 0.0;
            string clasifier = "";
            if (textBox1.Text != "")
            {
                par1 = 1;
                neuron = Convert.ToInt32(textBox1.Text);
            }
            if (textBox2.Text != "")
            {
                par2 = 1;
                clasifier = textBox2.Text;
            }
            if (textBox3.Text != "")
            {
                par3 = 1;
                weight = Convert.ToDouble(textBox3.Text);
            }
            this.tableTableAdapter.Fill(this.databaseDataSet.Table, neuron, clasifier, weight, par2, par1, par3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int par1 = 0, par2 = 0;
            string classifier = "";
            string description = "";
            if (textBox4.Text != "")
            {
                par1 = 1;
                classifier = textBox4.Text;
            }
            if (textBox5.Text != "")
            {
                par2 = 1;
                description = textBox5.Text;
            }
            this.table_DataTableAdapter.Fill(this.databaseDataSet1.Table_Data, classifier, description, par1, par2);
        }

        

    }
}
