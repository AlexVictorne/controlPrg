//Copyright (C) 2014 AlexVictorne, Nikita_blackbeard

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlPrg
{
    public partial class dataBase_Form : Form
    {
        public dataBase_Form()
        {
            InitializeComponent();
        }

        private void dataBase_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataBaseDataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.dataBaseDataSet.Table);

        }

        private void savechng_btn_Click(object sender, EventArgs e)
        {
            tableTableAdapter.Update(dataBaseDataSet);
        }
    }
}
