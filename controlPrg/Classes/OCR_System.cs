using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlPrg.Classes
{
    class OCR_System
    {
        //ИНС РАБОТА
        private int IMAGE_SIZE = 64;
        private int NEURONS_COUNT = 3;
        private int INPUTS_COUNT;
        private List<int[]> inputList = new List<int[]>();
        private List<int[]> outputList = new List<int[]>();
        public static NeuralNetwork FirstLayer;

        //агенты
        MultiagentSystem ms;

        public OCR_System(int size_of_element_image, int element_types_count)
        {
            IMAGE_SIZE = size_of_element_image;
            NEURONS_COUNT = element_types_count;
            initSystem();
        }

        public OCR_System() { initSystem(); }

        private void initSystem()
        {
            INPUTS_COUNT = IMAGE_SIZE * IMAGE_SIZE;
            FirstLayer = new NeuralNetwork(NEURONS_COUNT, INPUTS_COUNT);
            ms = new MultiagentSystem();
        }

        public void teachAgents(string path_to_folder_with_xml_files)
        {
            List<Element> templates = Create_Elements_Database_From_Template_XML(path_to_folder_with_xml_files);

            foreach (Element e in templates)
            {
                ms.AddTemplate(e);
            }
        }

        public int checkAgentExist(Element e)
        {
            return ms.AgentExist(e);
        }

        public void RemoveElementAt(int i)
        {
            ms.RemoveElementAt(i);
        }

        public void RemoveRelationAt(int i)
        {
            ms.RemoveRelationAt(i);
        }
        public void AddElement(Element el)
        {
            ms.AddTemplate(el);
        }
        public Element GetElement(int number)
        {
            return ms.GetElement(number);
        }
        public List<Element> GetElements()
        {
            return ms.GetElements();
        }
        public int GetCountOfElements()
        {
            return ms.GetCountElements();
        }
        public void AddRelation(Relation r)
        {
            ms.AddRelation(r);
        }
        public Relation GetRelation(int number)
        {
            return ms.GetRelation(number);
        }
        public List<Relation> GetRelations()
        {
            return ms.GetRelations();
        }
        public int GetCountOfRelations()
        {
            return ms.GetCountRelations();
        }
        public void ClearAll()
        {
            ms.ClearAll();
        }
        public int GetNumberElement(int number)
        {
            return ms.GetNumberOfElement(number);
        }
        public void SetNumberElement(int number)
        {
            ms.SetNumberOfElement(number);
        }
        public bool teachFirstLayer(string path_to_folder_with_images)
        {
            if (!Directory.Exists(path_to_folder_with_images)) return false;

            DirectoryInfo dir = new DirectoryInfo(path_to_folder_with_images);
            FileInfo[] fileList = dir.GetFiles();
            Image<Gray, byte> img;
            string line;
            string teach_set = "";

            for (int i = 0; i < fileList.Length; i++)
            {
                if (fileList[i].FullName.Contains("Thumbs.db")) continue;
                img = new Image<Gray, byte>(fileList[i].FullName);
                line = IntArrayToString(convertToTXT(img.Bitmap));
                int e_type = fileList[i].FullName.ElementAt(fileList[i].FullName.LastIndexOf('.') - 1) - 48;
                line += ' ';
                for (int k = 0; k < NEURONS_COUNT; k++)
                {
                    if (k == e_type)
                        line += '1';
                    else
                        line += '0';
                }
                teach_set += line + "\n";
            }

            parseTechSetFromString(teach_set, inputList, outputList);
            for (int i = 0; i < inputList.Count() - 1; i++)
            {
                FirstLayer.teach(inputList[i], outputList[i]);
            }

            return true;
        }

        public int[] testFirstLayer(string path_to_image)
        {
            Image<Gray, byte> img = new Image<Gray, byte>(path_to_image);
            int[] input = convertToTXT(img.Bitmap);
            return FirstLayer.Raspozn(input);
        }

        private void readTeachSet(string path, List<int[]> inputL, List<int[]> outputL)
        {
            int[] input = new int[INPUTS_COUNT];
            int[] output = new int[NEURONS_COUNT];
            string line = "";
            string[] words;

            StreamReader file;
            try
            {
                file = new StreamReader(path);
            }
            catch
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "TXT Files(*.txt)|*.txt|All files (*.*)|*.*";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                    path = ofd.FileName;
                else
                    return;
            }
            file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                if (line == "") continue;
                words = line.Split(' ');
                input = stringToIntArray(words[0]);
                inputL.Add((int[])input.Clone());
                output = stringToIntArray(words[1]); // если пустая строка - ругается
                outputL.Add((int[])output.Clone());
            }
        }

        private int[] stringToIntArray(string str)
        {
            int[] result = new int[str.Length];
            char[] buffer = str.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                result[i] = (int)buffer[i] - 48;
            }
            return result;
        }

        public static List<Element> Create_Elements_Database_From_Template_XML(string path_to_folder_with_xml_files)
        {
            List<Element> result = new List<Element>();
            string path_to_directory = path_to_folder_with_xml_files;
            DirectoryInfo dir = new DirectoryInfo(path_to_directory);
            FileInfo[] fileList = dir.GetFiles();

            for (int i = 0; i < fileList.Length; i++)
            {
                Skeleton sk = (Skeleton)XML_Worker.Read_from_xml(typeof(Skeleton),fileList[i].FullName);
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
                    int[] fl_out = FirstLayer.Raspozn(convertToTXT(
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
                    result.Add(new Element(e_type, Pb, Pe, length, curvature));
                }
            }
            return result;
        }



        public static List<Element> GetElementsFromXML(string path_to_xml)
        {
            List<Element> result = new List<Element>();
            Skeleton sk = (Skeleton)XML_Worker.Read_from_xml(typeof(Skeleton), path_to_xml);
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
                int[] fl_out = FirstLayer.Raspozn(convertToTXT(
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
                result.Add(new Element(e_type, Pb, Pe, length, curvature));
            }

            return result;
        }
        public static double calcCurvature(double A, double B, double C, int x, int y)
        {
            return Math.Abs(A * x + B * y + C) / Math.Sqrt(A * A + B * B);
        }

        public static int[] convertToTXT(Bitmap img)
        {
            double averageBrightness = 0;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    averageBrightness += img.GetPixel(x, y).R;
                }
            }
            averageBrightness /= (img.Width * img.Height);
            int[] result = new int[img.Width * img.Height];
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    if (img.GetPixel(x, y).R < averageBrightness)
                        result[img.Width * y + x] = 0;
                    else
                        result[img.Width * y + x] = 1;
                }
            }
            return result;
        }

        private string IntArrayToString(int[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += Convert.ToString(array[i]);
            }
            return result;
        }

        private void parseTechSetFromString(string teach_set, List<int[]> inputL, List<int[]> outputL)
        {
            int[] input = new int[INPUTS_COUNT];
            int[] output = new int[NEURONS_COUNT];
            string line = "";
            string[] words;
            string[] teach_set_lines = teach_set.Split('\n');

            for (int i = 0; i < teach_set_lines.Length; i++)
            {
                line = teach_set_lines[i];
                if (line == "") continue;
                words = line.Split(' ');
                input = stringToIntArray(words[0]);
                inputL.Add((int[])input.Clone());
                output = stringToIntArray(words[1]); // если пустая строка - ругается
                outputL.Add((int[])output.Clone());
            }
        }

        public void SetElementParametrs(int number,Element e)
        {
            ms.SetElementParametrs(number,e);
        }

        public void SetRelationParametrs(int number, Relation r)
        {
            ms.SetRelationParametrs(number, r);
        }

        public string getResult(List<Element> input)
        {
            Element[] input_elements = new Element[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                input_elements[i] = input[i];
            }
            return ms.getOut(input_elements);
        }
    }
}