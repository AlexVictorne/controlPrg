using controlPrg.Classes;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlPrg.Forms
{
    public partial class OCR_Form : Form
    {
        private NeuralNetwork ANN;
        Vectorizer_Form vf = new Vectorizer_Form();
        private const string elements_images = @"elements_images\";
        public OCR_Form()
        {
            InitializeComponent();
            DirectoryInfo di = new DirectoryInfo(elements_images);
            if (!di.Exists) di.Create();
        }

        public void setFirstLayer(NeuralNetwork ANN)
        {
            this.ANN = ANN;
        }

        private void getElementsFromInputVector()
        {
            if (ANN == null)
            {
                MessageBox.Show("нейронная сеть не создана");
                return;
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"xml_files\";
            string path_to_directory;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path_to_directory = fbd.SelectedPath;
                List<Element> db = new List<Element>();
                db = Create_Elements_Database_From_Template_XML(path_to_directory, ANN);
                int a = 0;
            }
        }

        private void Load_xml_file_btn_Click(object sender, EventArgs e)
        {
            // что-то типа создания выборки
            /*
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"xml_files\";
            ofd.Filter = "XML Files|*.xml";
            ofd.RestoreDirectory = true;
             * */
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"xml_files\";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Parse_All_XML_To_Images(fbd.SelectedPath);
            }
        }

        private void Parse_All_XML_To_Images(string xml_folder)
        {
            DirectoryInfo dir = new DirectoryInfo(xml_folder);
            FileInfo[] fileList = dir.GetFiles();
            int file_counter = new DirectoryInfo(elements_images).GetFiles().Length;
            int cell_counter = 0;

            for (int i = 0; i < fileList.Length; i++)
            {
                if (!fileList[i].Extension.Equals(".xml")) continue;
                Skeleton sk = vf.Read_from_xml(fileList[i].FullName);
                foreach (Skeleton.cell sc in sk.list_of_cell)
                {
                    Bitmap bm = new Bitmap(sk.Size.X, sk.Size.Y); // это будет не 64х64. чо делать?
                    foreach (Skeleton.node sn in sc.list_of_node)
                    {
                        bm.SetPixel(sn.x, sn.y, Color.White);
                    }
                    bm.Save(elements_images + (file_counter + cell_counter++).ToString() + ".bmp", 
                        System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }

        public List<Element> Create_Elements_Database_From_Template_XML(string path_to_folder_with_xml_files, NeuralNetwork ANN)
        {
            List<Element> result = new List<Element>();
            string path_to_directory = path_to_folder_with_xml_files;
            DirectoryInfo dir = new DirectoryInfo(path_to_directory);
            FileInfo[] fileList = dir.GetFiles();

            for (int i = 0; i < fileList.Length; i++)
            {
                Skeleton sk = vf.Read_from_xml(fileList[i].FullName);
                Bitmap bm = new Bitmap(sk.Size.X, sk.Size.Y);
                int all_length = 0;
                foreach (Skeleton.cell sc in sk.list_of_cell)
                    all_length += sc.list_of_node.Count;

                foreach (Skeleton.cell sc in sk.list_of_cell)
                {
                    int e_type = 0;
                    Point Pb, Pe;
                    double length = 0;
                    int curvature = 0;
                    double max_curvature = 0;

                    // конечная и начальная точки элемента
                    Pb = new Point(sc.list_of_node[0].x, sc.list_of_node[0].y);
                    Pe = new Point(sc.list_of_node[sc.list_of_node.Count - 1].x,
                        sc.list_of_node[sc.list_of_node.Count - 1].y);
                    double current_curvature = 0;
                    foreach (Skeleton.node sn in sc.list_of_node)
                    {
                        bm.SetPixel(sn.x, sn.y, Color.White);
                        length += 1;
                        current_curvature = calcCurvature(Pe.Y - Pb.Y, -(Pe.X - Pb.X),
                            (Pe.X - Pb.X) * Pb.Y + (Pe.Y - Pb.Y) * Pb.X,
                            sn.x, sn.y
                            );
                        if (max_curvature < current_curvature)
                        {
                            max_curvature = current_curvature;
                        }
                    }
                    // e_type = выход 1 слоя при входном изображении bm

                    // длина элемента относительно общей длины скелета
                    length /= all_length;
                    // кривизна элемента
                    curvature = (int)max_curvature;
                    result.Add(new Element(e_type, Pb, Pe, length, curvature));
                }
            }
            return result;
        }

        private double calcCurvature(double A, double B, double C, int x, int y)
        {
            return Math.Abs(A * x + B * y + C) / Math.Sqrt(A * A + B * B);
        }
    }
}
