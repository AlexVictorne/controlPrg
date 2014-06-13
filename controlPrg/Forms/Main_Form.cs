//Copyright (C) 2014 AlexVictorne, Nikita_blackbeard

using controlPrg.Classes;
using controlPrg.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace controlPrg
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            pictureBox1.ContextMenuStrip = contextMenuStrip1;
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU");
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            ci.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        }


        private void db_btn_Click(object sender, EventArgs e)
        {
            Data_Form df = new Data_Form();
            df.Show();
        }

        //Анимация ИНС
        List<Element> le = new List<Element>();
        List<Relation> lr = new List<Relation>();

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            foreach (Relation re in ocr.GetRelations())
            {
                re.Paint(e.Graphics);
            }
            foreach (Element el in ocr.GetElements())
            {
                el.Paint(e.Graphics);
            }
        }
        private void tick_tack_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ocr.AddElement(new Element(current_click_point.X, current_click_point.Y));
            ocr.SetNumberElement(ocr.GetCountOfElements() - 1);
        }

        int number_of_first_element=-1;
        int number_of_second_element=-1;
        int number_of_relation = -1;
        Point current_click_point;
        int current_chosen_element=-1;
        int current_chosen_relation=-1;
        bool mouse_down = false;


        private void clear_all_chosen()
        {
            if (ocr.GetCountOfElements() > 0)
            {
                if (number_of_first_element > -1 && number_of_first_element < ocr.GetCountOfElements())
                {
                    ocr.GetElement(number_of_first_element).Was_chosen = false;
                    number_of_first_element = -1;
                }
                if (number_of_second_element > -1 && number_of_second_element < ocr.GetCountOfElements())
                {
                    ocr.GetElement(number_of_second_element).Was_chosen = false;
                    number_of_second_element = -1;
                }
            }
            if (ocr.GetCountOfRelations() > 0)
            {
                if (number_of_relation > -1 && number_of_relation < ocr.GetCountOfRelations())
                {
                    ocr.GetRelation(number_of_relation).Was_chosen = false;
                    number_of_relation = -1;
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                current_click_point = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                int res = check_in_circle_el(new Point(e.X, e.Y));
                if (res > -1)
                {
                    if (number_of_first_element == -1)
                    {
                        number_of_first_element = res;
                        ocr.GetElement(res).Was_chosen = true;
                    }
                    else
                    {
                        if ((number_of_relation == -1) && (number_of_second_element == -1))
                        {
                            number_of_second_element = res;
                            ocr.GetElement(res).Was_chosen = true;
                        }
                        else
                            clear_all_chosen();
                    }
                }
                else
                {
                    res = check_in_circle_rel(new Point(e.X, e.Y));
                    if ((res > -1) && (number_of_second_element == -1) && (number_of_relation == -1))
                    {
                        number_of_relation = res;
                        ocr.GetRelation(res).Was_chosen = true;
                    }
                    else
                    {
                        clear_all_chosen();
                    }
                }
            }
            if (e.Button == MouseButtons.Middle)
            {
                mouse_down = true;
                int res = check_in_circle_el(new Point(e.X, e.Y));
                if (res > -1)
                    current_chosen_element = res;
                else
                {
                    res = check_in_circle_rel(new Point(e.X, e.Y));
                    if (res > -1)
                        current_chosen_relation = res;
                }
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down)
            {
                if (current_chosen_element > -1)
                {
                    ocr.GetElement(current_chosen_element).Coordinate = new Point(e.X, e.Y);
                }
                else
                {
                    if (current_chosen_relation > -1)
                    {
                        ocr.GetRelation(current_chosen_relation).Coordinate = new Point(e.X, e.Y);
                    }
                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
            current_chosen_element = -1;
            current_chosen_relation = -1;
        }


         private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             if (e.Button==MouseButtons.Left)
             {
                 int res = check_in_circle_el(new Point(e.X,e.Y));
                 if (res>-1)
                 {
                     ViewProperties_Form vpf = new ViewProperties_Form(ocr.GetElement(res));
                     vpf.ShowDialog();
                     if (vpf.DialogResult==DialogResult.OK)
                     {
                         ocr.SetElementParametrs(res, vpf.Return_Element());
                     }
                     //вызов окна от элемента
                     //ocr.GetElement(res).Was_chosen = false;
                 }
                 else
                 {
                     res = check_in_circle_rel(new Point(e.X, e.Y));
                     if (res>-1)
                     {
                         ViewRelationProperies_Form vrpf = new ViewRelationProperies_Form(ocr.GetRelation(res));
                         vrpf.ShowDialog();
                         if (vrpf.DialogResult == DialogResult.OK)
                         {
                             ocr.SetRelationParametrs(res, vrpf.GetRelation());
                         }
                         //вызов окна от отношения
                         //ocr.GetRelation(res).Was_chosen = false;
                     }
                 }                 
             }
             
         }

        private int check_in_circle_el(Point xy)
        {
            for (int i =0;i<ocr.GetCountOfElements();i++)
                if ((xy.X > ocr.GetElement(i).Coordinate.X - 8) && (xy.X < ocr.GetElement(i).Coordinate.X + 8) && (xy.Y > ocr.GetElement(i).Coordinate.Y - 8) && (xy.Y < ocr.GetElement(i).Coordinate.Y + 8))
                    return i;
            return -1;
        }
        private int check_in_circle_rel(Point xy)
        {
            for (int i = 0; i <ocr.GetCountOfRelations(); i++)
                if ((xy.X > ocr.GetRelation(i).Coordinate.X - 8) && (xy.X < ocr.GetRelation(i).Coordinate.X + 8) && (xy.Y > ocr.GetRelation(i).Coordinate.Y - 8) && (xy.Y < ocr.GetRelation(i).Coordinate.Y + 8))
                    return i;
            return -1;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if ((number_of_first_element>-1)&&(number_of_second_element>-1))
            {
                ocr.GetElement(number_of_first_element).Was_chosen = false;
                ocr.GetElement(number_of_second_element).Was_chosen = false;
                int x = (ocr.GetElement(number_of_first_element).Coordinate.X + ocr.GetElement(number_of_second_element).Coordinate.X) / 2;
                int y = (ocr.GetElement(number_of_first_element).Coordinate.Y + ocr.GetElement(number_of_second_element).Coordinate.Y) / 2;
                ocr.AddRelation(new Relation(ocr.GetElement(number_of_first_element), ocr.GetElement(number_of_second_element), x, y));
                //lr.Add(new Relation(le[number_of_first_element], le[number_of_second_element], x, y));
                number_of_first_element = -1;
                number_of_second_element = -1;
            }
            if ((number_of_first_element>-1)&&(number_of_relation>-1))
            {
                ocr.GetElement(number_of_first_element).Was_chosen = false;
                ocr.GetRelation(number_of_relation).Was_chosen = false;
                int x = (ocr.GetElement(number_of_first_element).Coordinate.X + ocr.GetRelation(number_of_relation).Coordinate.X) / 2;
                int y = (ocr.GetElement(number_of_first_element).Coordinate.Y + ocr.GetRelation(number_of_relation).Coordinate.Y) / 2;
                ocr.AddRelation(new Relation(ocr.GetRelation(number_of_relation), ocr.GetElement(number_of_first_element), x, y));
                number_of_first_element = -1;
                number_of_relation = -1;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ocr.ClearAll();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Structure s = new Structure();
            s.list_of_elements = ocr.GetElements();
            s.list_of_relations = ocr.GetRelations();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XML_Worker.Save_to_xml_file(typeof(Structure),s, saveFileDialog1.FileName);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            Structure s = new Structure();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    s = (Structure)XML_Worker.Read_from_xml(typeof(Structure), openFileDialog1.FileName);
                    foreach (Element el in s.list_of_elements)
                    {
                        ocr.AddElement(el);
                    }
                    foreach (Relation r in s.list_of_relations)
                    {
                        if (r.itRel())
                        {
                            int numelem1 = -1, numrel1 = -1;
                            for (int i = 0; i < ocr.GetCountOfElements(); i++)
                            {
                                if ((ocr.GetElement(i).Coordinate.X == r.GetElem(1).Coordinate.X) && (ocr.GetElement(i).Coordinate.Y == r.GetElem(1).Coordinate.Y))
                                    numelem1 = i;
                            }
                            for (int i = 0; i < ocr.GetCountOfRelations(); i++)
                            {
                                if ((ocr.GetRelation(i).Coordinate.X == r.GetRel().Coordinate.X) && (ocr.GetRelation(i).Coordinate.Y == r.GetRel().Coordinate.Y))
                                    numrel1 = i;
                            }
                            ocr.AddRelation(new Relation(ocr.GetRelation(numrel1), ocr.GetElement(numelem1), r.Coordinate.X, r.Coordinate.Y));
                        }
                        else
                        {
                            int numelem1 = -1, numelem2 = -1;
                            for (int i = 0; i < ocr.GetCountOfElements(); i++)
                            {
                                if ((ocr.GetElement(i).Coordinate.X==r.GetElem(1).Coordinate.X)&&(ocr.GetElement(i).Coordinate.Y==r.GetElem(1).Coordinate.Y))
                                    numelem1 = i;
                                if ((ocr.GetElement(i).Coordinate.X == r.GetElem(2).Coordinate.X) && (ocr.GetElement(i).Coordinate.Y == r.GetElem(2).Coordinate.Y))
                                    numelem2 = i;
                            }
                            ocr.AddRelation(new Relation(ocr.GetElement(numelem1), ocr.GetElement(numelem2), r.Coordinate.X, r.Coordinate.Y));
                        }
                        ocr.SetRelationParametrs(ocr.GetCountOfRelations() - 1, r);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private string Save_to_xml_string(Structure s)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(Structure));
            StringWriter output = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(output);
            ser.WriteObject(writer, s);
            return output.GetStringBuilder().ToString();
        }
        private void Save_to_xml_file(Structure s,string filename)
        {
            XmlTextWriter xw = new XmlTextWriter(filename, Encoding.UTF8);
            xw.Formatting = Formatting.Indented;
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xw);
            DataContractSerializer ser = new DataContractSerializer(typeof(Structure));
            ser.WriteObject(writer, s);
            writer.Close();
            xw.Close();
        }
        public Structure Read_from_string(string str)
        {
            Structure s = new Structure();
            DataContractSerializer ser = new DataContractSerializer(typeof(Structure));
            StringReader input = new StringReader(str);
            XmlTextReader reader = new XmlTextReader(input);
            s = (Structure)ser.ReadObject(reader);
            reader.Close();
            input.Close();
            return s;
        }
        public Structure Read_from_xml_file(string filename)
        {
            Structure s = new Structure();
            var path = filename;

            XmlTextReader xr = new XmlTextReader(path);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateDictionaryReader(xr);
            DataContractSerializer ser = new DataContractSerializer(typeof(Structure));
            s = (Structure)ser.ReadObject(reader);
            reader.Close();
            xr.Close();
            return s;
        }

        private void vectorizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vectorizer_Form vf = new Vectorizer_Form();
            vf.Show();
        }



        //TEST
        OCR_System ocr = new OCR_System();
        private void button5_Click(object sender, EventArgs e)
        {
            ocr = new OCR_System();
            ocr.teachFirstLayer(@"elements\");
            Console.WriteLine("Первый слой обучен");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (ocr == null) return;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "BMP files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            int[] result;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                result = ocr.testFirstLayer(openFileDialog1.FileName);
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
                Console.WriteLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ViewPropertiesOfInputElement_Form edit_form = new ViewPropertiesOfInputElement_Form(openFileDialog1.FileName);
                edit_form.ShowDialog();
                if (edit_form.DialogResult == DialogResult.OK)
                {
                    List<Element> e_list = edit_form.getElementList();
                    Console.WriteLine(ocr.getResult(e_list));
                }
                
                
                //e_list[0].Type = 1; //TEST!
                //e_list[1].Type = 0;
                //
            }

            
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (number_of_first_element > -1)
            {
                for (int i = 0; i < ocr.GetCountOfRelations(); i++)
                {
                    if (ocr.GetRelation(i).GetElem(1).Equals(ocr.GetElement(number_of_first_element)) ||
                        ocr.GetRelation(i).GetElem(2).Equals(ocr.GetElement(number_of_first_element)))
                    {
                        ocr.RemoveRelationAt(i);
                    }
                }
                ocr.RemoveElementAt(number_of_first_element);
                number_of_first_element = -1;
            }
            else
            {
                if (number_of_relation > -1)
                {
                    // не удаляется связь с отношением внутри удаляемого отношения
                    ocr.RemoveRelationAt(number_of_relation);
                    number_of_relation = -1;
                }
            }
        }


        

        
    }









}
