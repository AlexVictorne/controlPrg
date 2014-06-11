using Emgu.CV;
using Emgu.CV.Structure;
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
    public partial class ViewPropertiesOfInputElement_Form : Form
    {
        private Skeleton current_skelet_loaded;
        private Classes.Element[] element_list;
        public ViewPropertiesOfInputElement_Form(string path_to_xml)
        {
            InitializeComponent();

            try
            {
                current_skelet_loaded = ViewProperties_Form.Read_from_xml(path_to_xml);
                element_list = new Classes.Element[current_skelet_loaded.list_of_cell.Count];
                Bitmap bm = new Bitmap(current_skelet_loaded.Size.X, current_skelet_loaded.Size.Y);
                foreach (Skeleton.cell sc in current_skelet_loaded.list_of_cell)
                {
                    foreach (Skeleton.node sn in sc.list_of_node)
                    {
                        bm.SetPixel(sn.x, sn.y, Color.White);
                    }
                }
                ibReader.Image = new Image<Gray, byte>(bm);
                listBox1.Items.Clear();
                for (int i = 0; i < current_skelet_loaded.list_of_cell.Count; i++)
                    listBox1.Items.Add(i);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((listBox1.Items.Count > 0) && (listBox1.SelectedIndex > -1))
            {
                Paint_element(current_skelet_loaded.list_of_cell[listBox1.SelectedIndex], 
                    current_skelet_loaded.Size.X, 
                    current_skelet_loaded.Size.Y);
                if (element_list[listBox1.SelectedIndex] == null)
                    element_list[listBox1.SelectedIndex] = ViewProperties_Form.calcAtributesOfElement(
                        current_skelet_loaded, listBox1.SelectedIndex);
                SetAttributesToTextBoxes(element_list[listBox1.SelectedIndex]);
            }
        }

        private void SetAttributesToTextBoxes(Classes.Element e)
        {
            textBox1.Text = e.Type.ToString();
            textBox2.Text = e.Curvature.ToString();
            textBox3.Text = e.EndPoint.X.ToString();
            textBox9.Text = e.EndPoint.Y.ToString();
            textBox5.Text = e.BeginPoint.X.ToString();
            textBox10.Text = e.BeginPoint.Y.ToString();
            textBox4.Text = e.Length.ToString();
            textBox6.Text = Classes.Element.struct_size.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            element_list[index].Type = Convert.ToInt32(textBox1.Text);
            element_list[index].Curvature = Convert.ToInt32(textBox2.Text);
            element_list[index].EndPoint = new Point(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox9.Text));
            element_list[index].BeginPoint = new Point(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox10.Text));
            element_list[index].Length = Convert.ToDouble(textBox4.Text);
        }

        public List<Classes.Element> getElementList()
        {
            List<Classes.Element> e_list = new List<Classes.Element>();
            for (int i = 0; i < element_list.Length; i++)
            {
                e_list.Add(element_list[i]);
            }

            return e_list;
        }
    }
}
