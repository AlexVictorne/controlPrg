using System;
using System.Windows.Forms;

namespace controlPrg
{
    public partial class ViewProperties_Form : Form
    {
        Classes.Element el;
        public ViewProperties_Form(Classes.Element el)
        {
            InitializeComponent();
            this.el = el;
            this.textBox1.Text = this.el.Type.ToString();
            this.textBox2.Text = this.el.Curvature.ToString();
            this.textBox3.Text = this.el.EndPoint.ToString();
            this.textBox5.Text = this.el.BeginPoint.ToString();
            this.textBox4.Text = this.el.Length.ToString();
            this.textBox6.Text = this.el.Struct_Size.ToString();
            this.textBox7.Text = this.el.Coordinate.X.ToString();
            this.textBox8.Text = this.el.Coordinate.Y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Width == 325)
            {
                this.Width = 665;
                imageBox1.Visible = true;
                listBox1.Visible = true;
                button3.Visible = true;
            }
            else
            {
                this.Width = 325;
                imageBox1.Visible = false;
                listBox1.Visible = false;
                button3.Visible = false;
            }
        }

        public Classes.Element Return_Element()
        {
            return this.el;
        }

    }
}
