using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;

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
            this.textBox3.Text = this.el.EndPoint.X.ToString();
            this.textBox9.Text = this.el.EndPoint.Y.ToString();
            this.textBox5.Text = this.el.BeginPoint.X.ToString();
            this.textBox10.Text = this.el.BeginPoint.Y.ToString();
            this.textBox4.Text = this.el.Length.ToString();
            this.textBox6.Text = this.el.Struct_Size.ToString();
            this.textBox7.Text = this.el.Coordinate.X.ToString();
            this.textBox8.Text = this.el.Coordinate.Y.ToString();
        }


        Skeleton current_skelet_loaded;
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Width == 398)
            {
                this.Width = 885;
                ibReader.Visible = true;
                listBox1.Visible = true;
                button3.Visible = true;
            }

            listBox1.Items.Clear();
            current_skelet_loaded = Read_path();
            int i = 0;
            foreach (Skeleton.cell c in current_skelet_loaded.list_of_cell)
            {
                i++;
                listBox1.Items.Add(i);
            }
        }
        private Skeleton Read_path()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            Skeleton sk = new Skeleton();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sk = Read_from_xml(openFileDialog1.FileName);
                    Bitmap bm = new Bitmap(sk.Size.X, sk.Size.Y);
                    foreach (Skeleton.cell sc in sk.list_of_cell)
                    {
                        foreach (Skeleton.node sn in sc.list_of_node)
                        {
                            bm.SetPixel(sn.x, sn.y, Color.White);
                        }
                    }
                    ibReader.Image = new Image<Gray, byte>(bm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            else
            {
                this.Width = 398;
                ibReader.Visible = false;
                listBox1.Visible = false;
                button3.Visible = false;
            }
            return sk;
        }
        public static Skeleton Read_from_xml(string filename)
        {
            Skeleton sk = new Skeleton();
            var path = filename;
            XmlTextReader xr = new XmlTextReader(path);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateDictionaryReader(xr);
            DataContractSerializer ser = new DataContractSerializer(typeof(Skeleton));
            sk = (Skeleton)ser.ReadObject(reader);
            reader.Close();
            xr.Close();
            return sk;
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
                Paint_element(current_skelet_loaded.list_of_cell[listBox1.SelectedIndex], current_skelet_loaded.Size.X, current_skelet_loaded.Size.Y);
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                string new_name = Rename_element();
                if (new_name != "Текст не задан")
                    listBox1.Items[listBox1.SelectedIndex] = new_name;
            }
        }
        private void Paint_element(Skeleton.cell sc, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            foreach (Skeleton.node sn in sc.list_of_node)
            {
                bm.SetPixel(sn.x, sn.y, Color.White);
            }
            ibReader.Image = new Image<Gray, byte>(bm);
        }
        private string Rename_element()
        {
            Entry_Form ef = new Entry_Form("Ввод: имя элемента");
            ef.ShowDialog();
            if (ef.DialogResult == DialogResult.OK)
                return ef.textBox1.Text;
            else
                return "Текст не задан";
        }
        public Classes.Element Return_Element()
        {
            return this.el;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.el.Type = Convert.ToInt32(this.textBox1.Text);
            this.el.Curvature = Convert.ToInt32(this.textBox2.Text);
            this.el.EndPoint = new Point(Convert.ToInt32(this.textBox3.Text),Convert.ToInt32(this.textBox9.Text));
            this.el.BeginPoint = new Point(Convert.ToInt32(this.textBox5.Text), Convert.ToInt32(this.textBox10.Text));
            this.el.Length = Convert.ToDouble(this.textBox4.Text); 
            this.el.Struct_Size = Convert.ToInt32(this.textBox6.Text);
        }

    }
}
