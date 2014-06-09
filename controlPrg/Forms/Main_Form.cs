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


        //ИНС РАБОТА
        private const int IMAGE_SIZE = 16;
        private const int SYMBOLS_COUNT = 32;
        private const int NEURONS_COUNT = SYMBOLS_COUNT; 
        private const int INPUTS_COUNT = IMAGE_SIZE * IMAGE_SIZE;
        List<int[]> inputList = new List<int[]>();
        List<int[]> outputList = new List<int[]>();
        List<int[]> test_inputList = new List<int[]>();
        List<int[]> test_outputList = new List<int[]>();
        private NeuralNetwork nn;
        private const string mainPath = @"txt_file_sets\teach\saved_txt\";
        private const string pathToImages = @"teach_set_images\";
        public void addNeuralNetwork(int NeuronsCount, int InputsCount)
        {
            nn = new NeuralNetwork(NeuronsCount, InputsCount);
            //readInputVectors(mainPath + "teach_set.txt", mainPath + "teach_result_set.txt");
            //readSet(mainPath + "teach_set_program.txt", inputList, outputList);
        }
        private void readSet(string path, List<int[]> inputL, List<int[]> outputL)
        {
            int[] input = new int[INPUTS_COUNT];
            int[] output = new int[NEURONS_COUNT];
            string line = "";
            string[] words;

            StreamReader file;
            try
            {
                file =  new StreamReader(path);
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
        private void readInputVectors(string path_input, string path_output)
        {
            string line;
            char[] buffer;
            int[] input = new int[INPUTS_COUNT];
            int[] output = new int[NEURONS_COUNT];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = 0;
            }

            System.IO.StreamReader file =
                new System.IO.StreamReader(path_input);
            while ((line = file.ReadLine()) != null)
            {
                buffer = line.ToCharArray();
                for (int i = 0; i < buffer.Length; i++)
                {
                    input[i] = (int)buffer[i] - 48;
                }
                inputList.Add((int[])input.Clone());
            }

            file =
                new System.IO.StreamReader(path_output);
            while ((line = file.ReadLine()) != null)
            {
                buffer = line.ToCharArray();
                for (int i = 0; i < buffer.Length; i++)
                {
                    output[i] = (int)buffer[i] - 48;
                }
                outputList.Add((int[])output.Clone());
            }
        }
        private int[] convertToTXT(Image<Gray, Byte> img)
        {
            double averageBrightness = 0;

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    averageBrightness += img.Bitmap.GetPixel(x, y).R;
                }
            }
            averageBrightness /= (img.Width * img.Height);
            int[] result = new int[img.Width * img.Height];
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    if (img.Bitmap.GetPixel(x, y).R < averageBrightness)
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
        private string getOutputVector(char symbol)
        {
            String result = "";
            int pos = 0;
            switch (symbol)
            {
                case 'а': pos = 0; break;
                case 'б': pos = 1; break;
                case 'в': pos = 2; break;
                case 'г': pos = 3; break;
                case 'д': pos = 4; break;
                case 'е': pos = 5; break;
                case 'ж': pos = 6; break;
                case 'з': pos = 7; break;
                case 'и': pos = 8; break;
                case 'й': pos = 9; break;
                case 'к': pos = 10; break;
                case 'л': pos = 11; break;
                case 'м': pos = 12; break;
                case 'н': pos = 13; break;
                case 'о': pos = 14; break;
                case 'п': pos = 15; break;
                case 'р': pos = 16; break;
                case 'с': pos = 17; break;
                case 'т': pos = 18; break;
                case 'у': pos = 19; break;
                case 'ф': pos = 20; break;
                case 'х': pos = 21; break;
                case 'ц': pos = 22; break;
                case 'ч': pos = 23; break;
                case 'ш': pos = 24; break;
                case 'щ': pos = 25; break;
                case 'ъ': pos = 26; break;
                case 'ы': pos = 27; break;
                case 'ь': pos = 28; break;
                case 'э': pos = 29; break;
                case 'ю': pos = 30; break;
                case 'я': pos = 31; break;
            }
            for (int i = 0; i < SYMBOLS_COUNT; i++)
            {
                if (i == pos)
                    result += '1';
                else
                    result += '0';
            }
            return result + "\r\n";
        }
        private string getSymbol(int[] output)
        {
            string result;
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] != 0)
                {
                    switch (i)
                    {
                        case 0: result = "а"; break;
                        case 1: result = "б"; break;
                        case 2: result = "в"; break;
                        case 3: result = "г"; break;
                        case 4: result = "д"; break;
                        case 5: result = "е"; break;
                        case 6: result = "ж"; break;
                        case 7: result = "з"; break;
                        case 8: result = "и"; break;
                        case 9: result = "й"; break;
                        case 10: result = "к"; break;
                        case 11: result = "л"; break;
                        case 12: result = "м"; break;
                        case 13: result = "н"; break;
                        case 14: result = "о"; break;
                        case 15: result = "п"; break;
                        case 16: result = "р"; break;
                        case 17: result = "с"; break;
                        case 18: result = "т"; break;
                        case 19: result = "у"; break;
                        case 20: result = "ф"; break;
                        case 21: result = "х"; break;
                        case 22: result = "ц"; break;
                        case 23: result = "ч"; break;
                        case 24: result = "ш"; break;
                        case 25: result = "щ"; break;
                        case 26: result = "ъ"; break;
                        case 27: result = "ы"; break;
                        case 28: result = "ь"; break;
                        case 29: result = "э"; break;
                        case 30: result = "ю"; break;
                        case 31: result = "я"; break;
                        default: result = "херня какая-то"; break;
                    }
                    return result;
                }
            }
            return "херня какая-то";
        }
        private void moveFile(string pathFrom, string pathTo, string fileName)
        {

            while (File.Exists(pathTo + fileName))
            {
                fileName = getNewID(fileName);
                if (fileName == null)
                    return;
            }
            File.Copy(pathFrom, pathTo + fileName);
        }
        private string getNewID(string oldID)
        {
            int id = Convert.ToInt32(oldID.ElementAt(oldID.LastIndexOf('.') - 2)) - 48;
            string buffer = "000" + Convert.ToString(id + 1);
            if (buffer.Length > 4)
            {
                buffer = buffer.Substring(buffer.Length - 4); // удаляем ненужные разряды
                if (buffer.Length > 4)
                {
                    return null;
                }
            }
            return buffer + Convert.ToString(id + 1) + oldID.Substring(oldID.LastIndexOf('.') - 1);
        }
        private double test(bool reteach)
        {
            if (test_inputList.Count() == 0)
                readSet(mainPath + "test_set_program.txt", test_inputList, test_outputList);

            int[] result = new int[NEURONS_COUNT];
            int success = 0;
            int pos_result = 0, pos_output = 0;

            for (int i = 0; i < test_inputList.Count(); i++)
            {
                result = nn.Raspozn(test_inputList[i]);
                int[] buffer = test_outputList[i];
                for (int j = 0; j < result.Length; j++)
                {
                    if (result[j] != 0)
                    {
                        pos_result = j;
                    }
                    if (buffer[j] != 0)
                    {
                        pos_output = j;
                    }
                }
                if (pos_output == pos_result)
                {
                    success++;
                    Console.WriteLine("Успешно распознанный символ номер " + i + ": " + getSymbol(result));
                }
                else
                {
                    Console.WriteLine("Символ номер " + i + ": " +
                        getSymbol(test_outputList[i]) + " распознан ошибочно");
                    if (reteach)
                    {
                        Console.WriteLine("Переобучение");
                        nn.teach(test_inputList[i], test_outputList[i]);
                        i--;
                    }
                }
            }
            double successRate = Math.Round(((success * 1.0) / test_inputList.Count() * 100.0), 2);
            Console.WriteLine("количество успешно распознанных сиволов: " + success);
            Console.WriteLine("success rate = " + Convert.ToString(successRate));
            return successRate;
        }

        //ИНС СОБЫТИЯ
        private void createISN_btn_Click(object sender, EventArgs e)
        {
            addNeuralNetwork(NEURONS_COUNT, INPUTS_COUNT);
            toolStripStatusLabel1.Text = "ИНС создана, количество нейронов " + NEURONS_COUNT.ToString() + ", количество входов " + INPUTS_COUNT.ToString();
            teachISN_btn.Enabled = true;
        }
        private void teachISN_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < inputList.Count() - 1; i++)
            {
                nn.teach(inputList[i], outputList[i]);
            }
            toolStripStatusLabel1.Text = "ИНС обучена";
            testwith_btn.Enabled = true;
            testwithout_btn.Enabled = true;
            loadImg_btn.Enabled = true;
            recImg_btn.Enabled = true;

        }
        private void testwith_btn_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (test(false) < 80 && i < 10)
            {
                test(true);
                toolStripStatusLabel1.Text = "Переобучение сети. Итерация: " + i++;
                Console.WriteLine("Переобучение сети. Итерация: " + i++);
            }
            Console.WriteLine("Количество итераций переобучения: " + i);
            toolStripStatusLabel1.Text = "Количество итераций переобучения: " + i;
        }
        private void testwithout_btn_Click(object sender, EventArgs e)
        {
            test(false);
        }
        private Image<Gray, Byte> img;
        private void loadImg_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pathToImages;
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.TIF)|*.BMP;*.JPG;*.TIF|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            string path_to_current_image;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path_to_current_image = openFileDialog1.FileName;
                    img = new Image<Gray, byte>(path_to_current_image);
                    imageBox.Image = img;
                    convertToTXT(img);
                    Console.WriteLine("Изображение загружено: " + path_to_current_image);
                    toolStripStatusLabel1.Text = "Изображение загружено: " + path_to_current_image;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не могу прочитать файл с диска: \r\n" + ex.Message);
                }
            }

        }
        private void recImg_btn_Click(object sender, EventArgs e)
        {
            if ((nn != null) && (img != null))
            {
                int[] result = new int[NEURONS_COUNT];
                int[] buffer = convertToTXT(img);
                result = nn.Raspozn(buffer);
                
                label1.Text = getSymbol(result);
            }
            else
                MessageBox.Show("Не найдена ИНС и/или изображение");
        }
        private void createsample_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = pathToImages;
            string path_to_directory;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path_to_directory = fbd.SelectedPath;
                DirectoryInfo dir = new DirectoryInfo(path_to_directory);
                FileInfo[] fileList = dir.GetFiles();
                Image<Gray, byte> img;
                string line;
                string teach_set = "", test_set = "";
                for (int i = 0; i < fileList.Length; i++)
                {
                    if (fileList[i].FullName.Contains("Thumbs.db")) continue;
                    img = new Image<Gray, byte>(fileList[i].FullName);
                    line = IntArrayToString(convertToTXT(img));
                    line += ' ' + getOutputVector(fileList[i].FullName.ElementAt(fileList[i].FullName.LastIndexOf('.') - 1));
                    if (fileList[i].Name.ElementAt(0) == '0')
                    {
                        teach_set += line;
                    }
                    else
                    {
                        test_set += line;
                    }
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(mainPath + "teach_set_program.txt"))
                {
                    file.WriteLine(teach_set);
                    file.Close();
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(mainPath + "test_set_program.txt"))
                {
                    file.WriteLine(test_set);
                    file.Close();
                }
                Console.WriteLine("Создана выборка");
            }
            
        }
        private void segm_btn_Click(object sender, EventArgs e)
        {
            Segment_Form sf = new Segment_Form();
            sf.Show();
        }
        private void edit_btn_Click(object sender, EventArgs e)
        {
            Editor_Form ef = new Editor_Form();
            ef.ShowDialog();
            if (ef.DialogResult == DialogResult.OK)
            {
                img = new Image<Gray, byte>(ef.return_data());
                imageBox.Image = img;
                convertToTXT(img);
                recImg_btn.Enabled = true;
            }
        }
        private void samp_btn_Click(object sender, EventArgs e)
        {
            Sampletor_Form sf = new Sampletor_Form();
            sf.Show();
        }
        private void db_btn_Click(object sender, EventArgs e)
        {
            Data_Form df = new Data_Form();
            df.Show();
        }

        private void Main_Form_Resize(object sender, EventArgs e)
        {
            graphProc = pictureBox1.CreateGraphics();
            if (an != null)
            {
                graphProc.Clear(Color.White);
                List<int> newanlistlayer = new List<int>();
                newanlistlayer = an.layer_capacity;
                an = new AnimateNetwork(graphProc);
                an.create_layer(0,0);
                an.layer_capacity.Add(1);
                newanlistlayer.RemoveAt(0);
                foreach (int i in newanlistlayer)
                {
                    an.create_layer(1, i);
                    an.layer_capacity.Add(i);
                }
                an.create_layer(2, 0);
            }
        }








        //рисовалко нейронок

        //Анимация ИНС
        AnimateNetwork an;
        Graphics graphProc;
        List<Element> le = new List<Element>();
        List<Relation> lr = new List<Relation>();

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element el in ocr.GetElements())
            {
                el.Paint(e.Graphics);
            }
            foreach (Relation re in ocr.GetRelations())
            {
                re.Paint(e.Graphics);
            }
        }
        private void tick_tack_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (an != null)
                an.StopAllPulsar();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            graphProc = pictureBox1.CreateGraphics();
            if (an == null)
            {
                graphProc.Clear(Color.White);
                an = new AnimateNetwork(graphProc);
                an.create_layer(0, 0);
                an.layer_capacity.Add(1);
                an.create_layer(1, 8);
                an.layer_capacity.Add(8);
                an.create_layer(1, 8);
                an.layer_capacity.Add(8);
                an.create_layer(2, 0);
            }
            else
            {
                an = null;
                graphProc.Clear(Color.White);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            an.Pulsar_Layer(0, 1);
            an.Pulsar_Layer(1, 2);
            an.Pulsar_Layer(2, 3);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            an.StopAllPulsar();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ocr.AddElement(new Element(current_click_point.X, current_click_point.Y));
        }

        int number_of_first_element=-1;
        int number_of_second_element=-1;
        int number_of_relation = -1;
        Point current_click_point;
        int current_chosen_element=-1;
        int current_chosen_relation=-1;
        bool mouse_down = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                current_click_point = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                int res = check_in_circle_el(new Point(e.X,e.Y));
                if (res > -1)
                {
                    if (number_of_first_element == -1)
                        number_of_first_element = res;
                    else
                        number_of_second_element = res;
                    ocr.GetElement(res).Was_chosen = true;
                }
                else
                {
                    res = check_in_circle_rel(new Point(e.X, e.Y));
                    if (res > -1)
                    {
                        number_of_relation = res;
                        ocr.GetRelation(res).Was_chosen = true;
                    }
                }
            }
            if (e.Button==MouseButtons.Middle)
            {
                mouse_down = true;
                int res = check_in_circle_el(new Point(e.X, e.Y));
                if (res > -1)
                {
                    current_chosen_element = res;
                }
                else
                {
                    res = check_in_circle_rel(new Point(e.X, e.Y));
                    if (res > -1)
                    {
                        current_chosen_relation = res;
                    }
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
            le.Clear();
            lr.Clear();
        }


        private void pai_btn_Click(object sender, EventArgs e)
        {
            graphProc = pictureBox1.CreateGraphics();
            if (an == null)
            {
                graphProc.Clear(Color.White);
                an = new AnimateNetwork(graphProc);
            }
            else
            {
                an = null;
                graphProc.Clear(Color.White);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Structure s = new Structure();
            s.list_of_elements = le;
            s.list_of_relations = lr;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save_to_xml_file(s, saveFileDialog1.FileName);
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
                    s = Read_from_xml_file(openFileDialog1.FileName);
                    le = s.list_of_elements;
                    lr = s.list_of_relations;
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




        


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }







        //TEST
        OCR_System ocr = new OCR_System();
        private void button5_Click(object sender, EventArgs e)
        {
            ocr = new OCR_System();
            ocr.teachFirstLayer(@"C:\Users\Никита\Documents\GitHub\controlPrg\controlPrg\bin\Debug\elements");
            Console.WriteLine("Первый слой обучен");

            

            /*
            MultiagentSystem mas = new MultiagentSystem();
            // задаем шаблоны
            Element template1 = new Element(0, new Point(0, 0), new Point(0, 10), Math.PI * 5 * 0.5, 5); // первая дуга буквы х
            mas.AddTemplate(template1);
            Element template2 = new Element(1, new Point(10, 0), new Point(10, 10), Math.PI * 5 * 0.5, 5); // вторая дуга буквы х
            mas.AddTemplate(template2);
            Element template3 = new Element(2, new Point(5, 0), new Point(5, 10), 10, 0); // палка буквы ж
            mas.AddTemplate(template3);

            // задаем отношения между шаблонами буквы х
            mas.AddRelation(new Relation(template1, template2, 'х', true));// отношение дуг буквы х, финальный
            // буквы ж
            Relation first = new Relation(template1, template3, 'ж', false); // отношение первой дуги и палки буквы ж
            mas.AddRelation(first);
            mas.AddRelation(new Relation(first, template2, 'ж', true)); // отношение отношения первой дуги и палки и второй дуги буквы ж

            Element[] input = new Element[3];
            input[0] = new Element(0, new Point(2, 2), new Point(2, 12), Math.PI * 6 * 0.5, 6); // первая дуга буквы х (ж)
            input[1] = new Element(2, new Point(7, 2), new Point(7, 12), 12, 2); // палка буквы ж
            input[2] = new Element(1, new Point(12, 2), new Point(12, 12), Math.PI * 6 * 0.5, 6); // первая дуга буквы х (ж)
            

            Console.WriteLine(mas.getOut(input));
            //*/
        }

        private void oCRModulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OCR_Form ocr_form = new OCR_Form();
            ocr_form.Show();
        }

        private void createsample_btn_Click_1(object sender, EventArgs e)
        {

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

        

        
    }









}
