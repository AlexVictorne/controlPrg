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
            if (this.el.Bitmap != null)
            {
                ibReader.Image = new Image<Gray, byte>(this.el.Bitmap);
                ibReader.Visible = true;
            }
        }


        Skeleton current_skelet_loaded;
        private void button2_Click(object sender, EventArgs e)
        {
            
                ibReader.Visible = true;
                listBox1.Visible = true;
                button3.Visible = true;

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
            if ((listBox1.Items.Count > 0)&&(listBox1.SelectedIndex>-1))
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
            try
            {
                this.el.Bitmap = (Bitmap)ibReader.Image.Bitmap.Clone();
            }
            catch (Exception exp) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Skeleton sk = current_skelet_loaded;

            Classes.Element calculatedElement = calcAtributesOfElement(sk, listBox1.SelectedIndex);

            textBox1.Text = calculatedElement.Type.ToString();
            textBox2.Text = calculatedElement.Curvature.ToString();
            textBox3.Text = calculatedElement.EndPoint.X.ToString();
            textBox9.Text = calculatedElement.EndPoint.Y.ToString();
            textBox5.Text = calculatedElement.BeginPoint.X.ToString();
            textBox10.Text = calculatedElement.BeginPoint.Y.ToString();
            textBox4.Text = calculatedElement.Length.ToString();
            textBox6.Text = Classes.Element.struct_size.ToString();
        }

        public static Classes.Element calcAtributesOfElement(Skeleton sk, int cell_index)
        {
            Bitmap bm = new Bitmap(sk.Size.X, sk.Size.Y);
            int all_length = 0;
            foreach (Skeleton.cell sc in sk.list_of_cell)
                all_length += sc.list_of_node.Count;
            Skeleton.cell selected_cell = null;
            try
            {
                selected_cell = sk.list_of_cell[cell_index];
            }
            catch (Exception e) { }
            int e_type = 0;
            Point Pb, Pe;
            double length = 0;
            int curvature = 0;
            double max_curvature = 0;

            // конечная и начальная точки элемента
            Pb = new Point(selected_cell.list_of_node[0].x, selected_cell.list_of_node[0].y);
            Pe = new Point(selected_cell.list_of_node[selected_cell.list_of_node.Count - 1].x,
                selected_cell.list_of_node[selected_cell.list_of_node.Count - 1].y);
            double current_curvature = 0;
            foreach (Skeleton.node sn in selected_cell.list_of_node)
            {
                bm.SetPixel(sn.x, sn.y, Color.White);
                length += 1;
                current_curvature = Classes.OCR_System.calcCurvature(Pe.Y - Pb.Y, -(Pe.X - Pb.X),
                    (Pe.X - Pb.X) * Pb.Y + (Pe.Y - Pb.Y) * Pb.X,
                    sn.x, sn.y
                    );
                if (max_curvature < current_curvature)
                {
                    max_curvature = current_curvature;
                }
            }
            // e_type = выход 1 слоя при входном изображении bm
            int[] fl_out = Classes.OCR_System.FirstLayer.Raspozn(Classes.OCR_System.convertToTXT(
                    Vectorizer_Form.CopyBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height), 64)
                ));
            for (int k = 0; k < fl_out.Length; k++)
            {
                if (fl_out[k] == 1)
                {
                    e_type = k;
                    break;
                }
            }
            // длина элемента относительно общей длины скелета
            length /= all_length;
            // кривизна элемента
            curvature = (int)max_curvature;

            return new Classes.Element(e_type, Pb, Pe, length, curvature);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ibReader.Visible = true;
            listBox1.Visible = true;
            button3.Visible = true;
            Skeleton sk = new Skeleton();
            listBox1.Items.Clear();
            Data_Form df = new Data_Form();
            df.ShowDialog();
            if (df.DialogResult == DialogResult.OK)
            {
                sk = (Skeleton)XML_Worker.Read_from_string(typeof(Skeleton), df.readed_xml);
                Bitmap bm = new Bitmap(sk.Size.X, sk.Size.Y);
                foreach (Skeleton.cell sc in sk.list_of_cell)
                {
                    foreach (Skeleton.node sn in sc.list_of_node)
                    {
                        bm.SetPixel(sn.x, sn.y, Color.White);
                    }
                }
                ibReader.Image = new Image<Gray, byte>(bm);
                int i = 0;
                current_skelet_loaded = sk;
                foreach (Skeleton.cell c in current_skelet_loaded.list_of_cell)
                {
                    i++;
                    listBox1.Items.Add(i);
                }
            }
        }

        
    }
}
