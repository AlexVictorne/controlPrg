//Copyright (C) 2014 AlexVictorne, Nikita_blackbeard

using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace controlPrg
{
    public partial class Sampletor_Form : Form
    {
        public Sampletor_Form()
        {
            InitializeComponent();
        }

        private const string mainPath = @"txt_file_sets\teach\saved_txt\";
        private const int SYMBOLS_COUNT = 32;
        private const int ELEMETS_TYPES_COUNT = 3;
        bool convertSample_btn_pressed = false;




        string text1;
        private bool continue_flag = false;
        private bool cancel_flag = false;

        public void XML_Images_From_Directory_To_TXT(string path_to_directory)
        {
            DirectoryInfo dir = new DirectoryInfo(path_to_directory);
            FileInfo[] fileList = dir.GetFiles();
            Image<Gray, byte> img;
            string pathToRenamedFiles = @"renamed_files_from_xml\";
            string line;
            string text = "";
            for (int i = 0; i < fileList.Length; i++)
            {
                toolStripStatusLabel1.Text = "Введите тип элемента c изображения " + i.ToString();
                if (fileList[i].FullName.Contains("Thumbs.db")) continue;
                img = new Image<Gray, byte>(fileList[i].FullName);
                imageBox.Image = img;
                while (!continue_flag)
                {
                    if (cancel_flag)
                    {
                        break;
                    }
                }
                if (cancel_flag)
                {
                    cancel_flag = false;
                    continue;
                }
                continue_flag = false;
                Console.WriteLine("textbox: " + textBox1.Text);
                string fuck = toolStripStatusLabel1.Text;
                string g = text1;//
                line = IntArrayToString(convertToTXT(img)) + " " + getOutputVector(g[0]);
                Directory.CreateDirectory(pathToRenamedFiles);
                moveFile(fileList[i].FullName, pathToRenamedFiles, "0000" + g[0] + fileList[i].Extension); // последний символ будет типом элемента
                text += line;
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(mainPath + "teach_set_program_from_xml.txt"))
            {
                file.WriteLine(text);
            }
        }
        public void ImagesFromDirectoryToTXT(string path_to_directory)
        {
            DirectoryInfo dir = new DirectoryInfo(path_to_directory);
            FileInfo[] fileList = dir.GetFiles();
            Image<Gray, byte> img;
            string pathToRenamedFiles = @"renamed_files\";
            string line;
            string text = "";
            for (int i = 0; i < fileList.Length; i++)
            {
                toolStripStatusLabel1.Text = "Введите букву c изображения " + i.ToString();
                if (fileList[i].FullName.Contains("Thumbs.db")) continue;
                img = new Image<Gray, byte>(fileList[i].FullName);
                imageBox.Image = img;
                while (!continue_flag)
                {
                    if (cancel_flag)
                    {
                        break;
                    }
                }
                if (cancel_flag)
                {
                    cancel_flag = false;
                    continue;
                }
                continue_flag = false;
                Console.WriteLine("textbox: " + textBox1.Text);
                string fuck = toolStripStatusLabel1.Text;
                string g = text1;//
                line = IntArrayToString(convertToTXT(img)) + " " + getOutputVector(g[0]);
                Directory.CreateDirectory(pathToRenamedFiles);
                moveFile(fileList[i].FullName, pathToRenamedFiles, "0000" + g[0] + fileList[i].Extension);
                text += line;
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(mainPath + "teach_set_program.txt"))
            {
                file.WriteLine(text);
            }
        }

        public static string GetTextBoxText(TextBox box)
        {
            if (box.InvokeRequired)
            {
                Func<TextBox, string> deleg = new Func<TextBox, string>(GetTextBoxText);
                return box.Invoke(deleg, new object[] { box }).ToString();
            }
            else
            {
                return box.Text;
            }
        }

        private void convertSample_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"";
            string path_to_directory;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path_to_directory = fbd.SelectedPath;
                myThread t = new myThread(path_to_directory, 1, this);
            }
        }

        private void nxt_btn_Click(object sender, EventArgs e)
        {
            continue_flag = true;
            convertSample_btn_pressed = true;
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void skip_btn_Click(object sender, EventArgs e)
        {
            cancel_flag = true;
            textBox1.Focus();
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

        private string getOutputVectorForXML(int e_type)
        {
            string result = "";
            for (int i = 0; i < ELEMETS_TYPES_COUNT; i++)
            {
                if (i == e_type)
                {
                    result += '1';
                }
                else
                {
                    result += '0'; // -1 ?
                }
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

        private int[] convertToTXT(Image<Gray, Byte> img) // возможно придется переписывать (бать среднее из квадрата, а не по отдельности)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (convertSample_btn_pressed)
                convertSample_btn_pressed = false;
            else
                text1 = (string)textBox1.Text.Clone();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"teach_set_images\";
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
                    //File.AppendAllText(mainPath + "teach_set_program.txt", line, Encoding.UTF8);
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
            }
            Console.WriteLine("Создана выборка");
        }





    }
}