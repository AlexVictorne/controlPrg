using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlPrg.Forms
{
    public partial class ViewRelationProperies_Form : Form
    {

        Classes.Relation r;
        public ViewRelationProperies_Form(Classes.Relation r)
        {
            InitializeComponent();
            this.r = r;
            checkBox1.Checked = r.isFinal();
            if (r.isFinal())
                textBox1.Text = r.Specialization_Char.ToString();
        }

        public Classes.Relation GetRelation()
        {
            return r;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r.setFinal(checkBox1.Checked);
            r.Specialization_Char = textBox1.Text[0];
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
                textBox1.Enabled = true;
            else 
                textBox1.Enabled = false;
        }


    }
}
