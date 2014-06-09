using controlPrg.Classes;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace controlPrg
{
    public partial class Vectorizer_Form : Form
    {


        public Vectorizer_Form()
        {
            InitializeComponent();
        }





        Image<Bgr, Byte> OriginalImage;
        List<Contour<Point>> contours = new List<Contour<Point>>();




        void Segm_Process()
        {
            bool equalizeHist =  autocont_chb.Checked;
            bool noiseFilter = nf_chb.Checked;
            bool blur = blur_chb.Checked;
            double thresVal = (double)thres_tb.Value / 100;
            int nfVal = (int)nf_tb.Value;

            //преобразование изображения в чб

            Image<Gray, Byte> imgProcessed = OriginalImage.Convert<Gray, Byte>();
            //автоконтраст
            if (equalizeHist)
                imgProcessed._EqualizeHist();
            //фильтр шума
            Image<Gray, byte> smoothedGrayFrame = imgProcessed.PyrDown();
            smoothedGrayFrame = smoothedGrayFrame.PyrUp();
            Image<Gray, byte> cannyFrame = null;
            //поиск контуров, если работает с фильтром шума
            if (noiseFilter)
                cannyFrame = smoothedGrayFrame.Canny(nfVal, nfVal);
            //затемнение
            if (blur)
                imgProcessed = smoothedGrayFrame;
            //пороговое преобразование
            CvInvoke.cvAdaptiveThreshold(imgProcessed, imgProcessed, 255, Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY, 4 + 4 % 2 + 1, thresVal);
            //белое в черное 
            //imgProcessed._Not();
            try
            {
                if (cannyFrame != null)
                    imgProcessed._Or(cannyFrame);
            }
            catch { }
            if (cannyFrame != null)
                cannyFrame = cannyFrame.Dilate(3);
            //поиск контуров 
            var sourceContours = imgProcessed.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_TC89_KCOS, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST);
            //фильтруем контуры
            contours = FilterContours(sourceContours, cannyFrame, imgProcessed.Width, imgProcessed.Height);
            ibOriginal.Image = imgProcessed;
            toolStripStatusLabel1.Text= "Найдено "+contours.Count.ToString()+" контура(-ов).";
        }

        private List<Contour<Point>> FilterContours(Contour<Point> contours, Image<Gray, byte> canny, int Width, int Height)
        {
            //максимальная площадь
            int maxArea = Width * Height;
            var con = contours;
            List<Contour<Point>> results = new List<Contour<Point>>();
            while (con != null)
            {
                //фильтруем по размеру
                if (con.Total < (int)minContLen_tb.Value || con.Total > (int)maxContLen_tb.Value ||
                        con.Area < (int)minContAr_tb.Value || con.Area > maxArea ||
                        con.Area / con.Total <= 0.5)
                    goto next;
                if (nf_chb.Checked)
                {
                    //проверяем интенсивность если включен фильтр шума
                    Point p1 = con[0];
                    Point p2 = con[(con.Total / 2) % con.Total];
                    if (canny[p1].Intensity <= double.Epsilon && canny[p2].Intensity <= double.Epsilon)
                        goto next;
                }
                results.Add(con);
            next:
                con = con.HNext;
            }
            return results;
        }

        public static void FloodFill(Bitmap bitmap, int x, int y, Color color)
        {
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var bits = new int[data.Stride / 4 * data.Height];
            Marshal.Copy(data.Scan0, bits, 0, bits.Length);

            var check = new LinkedList<Point>();
            int floodTo = color.ToArgb();
            int floodFrom = bits[x + y * data.Stride / 4];
            bits[x + y * data.Stride / 4] = floodTo;

            if (floodFrom != floodTo)
            {
                check.AddLast(new Point(x, y));
                while (check.Count > 0)
                {
                    Point cur = check.First.Value;
                    check.RemoveFirst();

                    foreach (Point off in new[] {
                new Point(0, -1), new Point(0, 1), 
                new Point(-1, 0), new Point(1, 0)})
                    {
                        var next = new Point(cur.X + off.X, cur.Y + off.Y);
                        if (next.X < 0 || next.Y < 0 || next.X >= data.Width || next.Y >= data.Height) continue;
                        if (bits[next.X + next.Y * data.Stride / 4] != floodFrom) continue;
                        check.AddLast(next);
                        bits[next.X + next.Y * data.Stride / 4] = floodTo;
                    }
                }
            }

            Marshal.Copy(bits, 0, data.Scan0, bits.Length);
            bitmap.UnlockBits(data);
        }

        
        Bitmap CopyBitmap(Image src, Rectangle rect,int bitmapformat)
        {
            var ret = new Bitmap(rect.Width, rect.Height);
            using (var g = Graphics.FromImage(ret))
            {
                g.DrawImage(src, 0, 0, rect, GraphicsUnit.Pixel);
            }
            var res = new Bitmap(bitmapformat, bitmapformat);
            using (var g = Graphics.FromImage(res))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(ret, new Rectangle(0, 0, bitmapformat, bitmapformat), new Rectangle(0, 0, rect.Width, rect.Height), GraphicsUnit.Pixel);
            }
            return res;
        }

        //процедура поиска описывающего прямоугольника
        Rectangle Contour(Contour<Point> points, int startIndex, int count)
        {
            int minX = points[startIndex].X;
            int minY = points[startIndex].Y;
            int maxX = minX;
            int maxY = minY;
            int endIndex = startIndex + count;

            for (int i = startIndex; i < endIndex; i++)
            {
                var p1 = points[i];
                //тернарный оператор заменяет if
                var p2 = i == endIndex - 1 ? points[startIndex] : points[i + 1];

                if (p1.X > maxX) maxX = p1.X;
                if (p1.X < minX) minX = p1.X;
                if (p1.Y > maxY) maxY = p1.Y;
                if (p1.Y < minY) minY = p1.Y;
            }
            return new Rectangle(minX, minY, maxX - minX + 1, maxY - minY + 1);
        }

        private Bitmap BlachAndWhite(Bitmap bmpImg, int P)
        {
            Bitmap result = new Bitmap(bmpImg.Width, bmpImg.Height);
            Color color = new Color();
            try
            {
                for (int j = 0; j < bmpImg.Height; j++)
                {
                    for (int i = 0; i < bmpImg.Width; i++)
                    {
                        color = bmpImg.GetPixel(i, j);
                        int K = ((color.R + color.G + color.B) / 3);
                        result.SetPixel(i, j, (K <= P ? Color.White : Color.Black));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }


        //заливочные функции
        private Bitmap createnewpolygon()
        {
            Bitmap bmm = new Bitmap(ibOriginal.Image.Bitmap.Width, ibOriginal.Image.Bitmap.Height);
            foreach (var contour in contours)
                if (contour.Total > 1)
                    Graphics.FromImage((Image)bmm).DrawPolygon(Pens.Red, contour.ToArray());
            return bmm;
        }
        Bitmap bm;
        bool fill_is_started = false;
        private void FloodyFill(int x, int y)
        {
            if (!fill_is_started)
            {
                bm = createnewpolygon();
                fill_is_started = true;
            }
            contours.Clear();
            int coordX = Convert.ToInt32(x / ibOriginal.ZoomScale + ibOriginal.HorizontalScrollBar.Value); ;// -ibOriginal.Location.X;
            int coordY = Convert.ToInt32(y / ibOriginal.ZoomScale + ibOriginal.VerticalScrollBar.Value);// -ibOriginal.Location.Y;
            toolStripStatusLabel1.Text = "Точка " + coordX.ToString() + ", " + coordY.ToString() + " выбрана для заливки.";
            FloodFill(bm, coordX, coordY, Color.White);
            Graphics.FromImage((Image)bm).DrawEllipse(Pens.White, coordX - 1, coordY - 1, 2, 2);
            ibOriginal.Image = new Image<Gray, byte>(bm);
        }

        private void GetSkelet()
        {
            int[,] bit = new int[ibOriginal.Image.Bitmap.Height, ibOriginal.Image.Bitmap.Width];
            for (int i = 0; i < ibOriginal.Image.Bitmap.Height; i++)
                for (int j = 0; j < ibOriginal.Image.Bitmap.Width; j++)
                {
                    if (ibOriginal.Image.Bitmap.GetPixel(j, i).ToArgb() == -1)
                        bit[i, j] = 1;
                    else
                        bit[i, j] = 0;
                }
            Bitmap bm = new Bitmap(ibOriginal.Image.Bitmap.Width, ibOriginal.Image.Bitmap.Height);
            Skeletonizator s = new Skeletonizator(bit);
            int[,] sk = new int[ibOriginal.Image.Bitmap.Height, ibOriginal.Image.Bitmap.Width];
            sk = s.SkeletonZhangSuen();
            for (int i = 0; i < ibOriginal.Image.Bitmap.Height; i++)
                for (int j = 0; j < ibOriginal.Image.Bitmap.Width; j++)
                {
                    if (sk[i, j] == 1)
                        bm.SetPixel(j, i, Color.Red);
                    else
                        bm.SetPixel(j, i, Color.White);
                }
            ibProcessed.Image = new Image<Bgr, byte>(bm);
            toolStripStatusLabel1.Text = "Скелет изображения построен.";
        }

        private void LoadImage()
        {
            contours.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "BMP files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OriginalImage = new Image<Bgr, byte>(openFileDialog1.FileName);
                    ibOriginal.Image = OriginalImage;
                    toolStripStatusLabel1.Text = "Загружено изображение: " + openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void SaveImages(int bitmapformat,string format)
        {
            bool result_format = true;
            if (format == ".jpg")
                result_format = true;
            else
                result_format = false;
            List<Bitmap> contour_bitmap_list = new List<Bitmap>();
            foreach (var contour in contours)
            {
                //прямоугольник описывающий контур
                Rectangle newrect = Contour(contour, 0, contour.Total);
                //добавляем часть изображения в список с контурами
                contour_bitmap_list.Add(new Bitmap(newrect.Width, newrect.Height));
                contour_bitmap_list[contour_bitmap_list.Count - 1] = CopyBitmap(ibOriginal.Image.Bitmap, newrect, bitmapformat);
            }
            string folderName = @"images";
            try { System.IO.Directory.Delete(folderName, true); }
            catch { }
            System.IO.Directory.CreateDirectory(folderName);
            int i = 0;
            foreach (Bitmap bit in contour_bitmap_list)
            {
                string fileName = i.ToString() + format;
                string pathString = System.IO.Path.Combine(folderName, fileName);
                Bitmap bm = bit;
                try
                {
                    if (result_format)
                        bm.Save(pathString, ImageFormat.Jpeg);
                    else
                        bm.Save(pathString, ImageFormat.Bmp);
                }
                catch { }
                i++;
            }
            toolStripStatusLabel1.Text = "Сохранено " + i.ToString() + " изображений формата " + format + " , размером " + bitmapformat.ToString() + "*" + bitmapformat.ToString() + ".";
        }



        private void Resize_to_contour_rectangle()
        {
            int max_x=0,max_y=0,min_x=ibOriginal.Image.Bitmap.Width,min_y=ibOriginal.Image.Bitmap.Height;
            for (int i = 0; i < ibOriginal.Image.Bitmap.Height; i++)
                for (int j = 0; j < ibOriginal.Image.Bitmap.Width; j++)
                {
                    int c = ibOriginal.Image.Bitmap.GetPixel(j, i).ToArgb();
                    if (c == -1)
                    {
                        if (min_x > j)
                            min_x = j;
                        if (max_x < j)
                            max_x = j;
                        if (min_y > i)
                            min_y = i;
                        if (max_y < i)
                            max_y = i;
                    }
                }
            var ret = new Bitmap(max_x - min_x+2, max_y - min_y+2);
            using (var g = Graphics.FromImage(ret))
            {
                g.DrawImage(ibOriginal.Image.Bitmap, 1, 1, new Rectangle(min_x, min_y, max_x - min_x, max_y - min_y), GraphicsUnit.Pixel);
            }
            ibOriginal.Image = new Image<Gray, byte>(ret);
            toolStripStatusLabel1.Text = "Изображение обрезано до размера контуров ("+ret.Width.ToString()+", "+ret.Height.ToString()+").";
        }
        
        public static Bitmap Resizez(Bitmap original_bm)
        {
            int max_x = 0, max_y = 0, min_x = original_bm.Width, min_y = original_bm.Height;
            for (int i = 0; i < original_bm.Height; i++)
                for (int j = 0; j < original_bm.Width; j++)
                {
                    int c = original_bm.GetPixel(j, i).ToArgb();
                    if (c == -1)
                    {
                        if (min_x > j)
                            min_x = j;
                        if (max_x < j)
                            max_x = j;
                        if (min_y > i)
                            min_y = i;
                        if (max_y < i)
                            max_y = i;
                    }
                }
            var ret = new Bitmap(max_x - min_x + 3, max_y - min_y + 3);
            using (var g = Graphics.FromImage(ret))
            {
                g.DrawImage(original_bm, 1, 1, new Rectangle(min_x, min_y, max_x - min_x+2, max_y - min_y+2), GraphicsUnit.Pixel);
            }
            return ret;
        }




        //xml функции
        private void Save_to_xml_file(Skeleton sk,string filename)
        {
            XmlTextWriter xw = new XmlTextWriter(filename, Encoding.UTF8);
            xw.Formatting = Formatting.Indented;
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(xw);
            DataContractSerializer ser = new DataContractSerializer(typeof(Skeleton));
            ser.WriteObject(writer, sk);
            writer.Close();
            xw.Close();
        }

        private string Save_to_xml_string(Skeleton sk)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(Skeleton));
            StringWriter output = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(output);
            ser.WriteObject(writer,sk);
            return output.GetStringBuilder().ToString();
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
        public Skeleton Read_from_string(string str)
        {
            Skeleton sk = new Skeleton();
            DataContractSerializer ser = new DataContractSerializer(typeof(Skeleton));
            StringReader input = new StringReader(str);
            XmlTextReader reader = new XmlTextReader(input);
            sk = (Skeleton)ser.ReadObject(reader);
            reader.Close();
            input.Close();
            return sk;
        }
        //векторизация
        private void Set_path()
        {
            Image<Gray, Byte> imgProcessed = new Image<Gray, byte>(ibProcessed.Image.Bitmap);
            int max_var_path = 100;
            int x = 0, y = 0;
            for (int i = 0; i < imgProcessed.Bitmap.Height; i++)
                for (int j = 0; j < imgProcessed.Bitmap.Width; j++)
                {

                    int c = imgProcessed.Bitmap.GetPixel(j, i).ToArgb();
                    if (c == -11776948)
                    {
                        int current_variable_path = 0;
                        current_variable_path = Look_around(imgProcessed.Bitmap, j, i, -11776948).Count;
                        if (current_variable_path < max_var_path)
                        {
                            max_var_path = current_variable_path;
                            x = j; y = i;
                        }
                    }
                }
            Skeleton sk = new Skeleton();
            sk.Size = new Point(imgProcessed.Bitmap.Width, imgProcessed.Bitmap.Height);
            sk.list_of_cell = new List<Skeleton.cell>();
            sk.list_of_cell.Add(new Skeleton.cell());
            List<Point> list_of_intersection = new List<Point>();
            list_of_intersection.Add(new Point(x, y));
            Bitmap bitmap = new Bitmap(imgProcessed.Bitmap);
            while (list_of_intersection.Count != 0)
            {
                sk.list_of_cell[sk.list_of_cell.Count - 1].add_node(x, y);
                sk.length++; // добавлено для вычисления общей длины скелета
                bitmap.SetPixel(x, y, Color.Blue);
                List<Point> lp = Look_around(bitmap, x, y,-11776948);
                if (lp.Count>1)
                {
                    foreach (Point p in lp)
                    {
                        bitmap.SetPixel(p.X, p.Y, Color.Blue);
                        int k = bitmap.GetPixel(p.X, p.Y).ToArgb();
                    }
                    list_of_intersection.RemoveAt(0);
                    List<Point> buff_list = new List<Point>();
                    buff_list.AddRange(lp);
                    buff_list.AddRange(list_of_intersection);
                    list_of_intersection = buff_list;
                    sk.list_of_cell.Add(new Skeleton.cell());
                    x = list_of_intersection[0].X;
                    y = list_of_intersection[0].Y;
                }
                else
                if (lp.Count==1)
                {
                    x = lp[0].X;
                    y = lp[0].Y;
                }
                else
                {
                    // последний элемент в замкнутых цепочках
                    if (Look_around(bitmap, x, y, -16776961).Count > 1)
                    {
                        List<Point> pe = new List<Point>();
                        pe = Look_around(bitmap, x, y, -16776961);
                        if (Look_around(bitmap, pe[0].X, pe[0].Y,-11776948).Count==0)
                        {
                            list_of_intersection.Remove(new Point(pe[0].X, pe[0].Y));
                            x = pe[0].X;
                            y = pe[0].Y;
                            sk.list_of_cell[sk.list_of_cell.Count - 1].add_node(x, y);
                            bitmap.SetPixel(x, y, Color.Green);
                        }
                    }
                    //
                    list_of_intersection.RemoveAt(0);
                    if (list_of_intersection.Count>0)
                    {
                        sk.list_of_cell.Add(new Skeleton.cell());
                        x = list_of_intersection[0].X;
                        y = list_of_intersection[0].Y;
                    }
                }
            }
            ibProcessed.Image = new Image<Gray, byte>(bitmap);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save_to_xml_file(sk, saveFileDialog1.FileName);
                toolStripStatusLabel1.Text = "Найдено " + sk.list_of_cell.Count + " цепочек. Сохранено в " + saveFileDialog1.FileName;
            }
            else
                toolStripStatusLabel1.Text = "Найдено " + sk.list_of_cell.Count + " цепочек.";
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
                    Bitmap bm = new Bitmap(sk.Size.X,sk.Size.Y);
                    foreach (Skeleton.cell sc in sk.list_of_cell)
                    {
                        foreach (Skeleton.node sn in sc.list_of_node)
                        {
                            bm.SetPixel(sn.x, sn.y, Color.White);
                        }
                    }
                    ibReader.Image = new Image<Gray, byte>(bm);
                    toolStripStatusLabel1.Text = "Прочитан XML файл: " + openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return sk;
        }

        //color red         -11776948
        //color green 		-11842741	
        //color blue 	    -16776961

        private List<Point> Look_around(Bitmap bitmap, int x, int y, int color)
        {
            List<Point> list_of_var_point = new List<Point>();
            if ((x + 1 < bitmap.Width) && (bitmap.GetPixel(x + 1, y).ToArgb() == color))
                list_of_var_point.Add(new Point(x + 1, y));
            if ((x + 1 < bitmap.Width) && (y + 1 < bitmap.Height) && (bitmap.GetPixel(x + 1, y + 1).ToArgb() == color))
                list_of_var_point.Add(new Point(x + 1, y + 1));
            if ((x + 1 < bitmap.Width) && (y - 1 > 0) && (bitmap.GetPixel(x + 1, y - 1).ToArgb() == color))
                list_of_var_point.Add(new Point(x + 1, y - 1));
            if ((y + 1 < bitmap.Height) && (bitmap.GetPixel(x, y + 1).ToArgb() == color))
                list_of_var_point.Add(new Point(x, y + 1));
            if ((y - 1 > 0) && (bitmap.GetPixel(x, y - 1).ToArgb() == color))
                list_of_var_point.Add(new Point(x, y - 1));
            if ((x - 1 > 0) && (bitmap.GetPixel(x - 1, y).ToArgb() == color))
                list_of_var_point.Add(new Point(x - 1, y));
            if ((x - 1 > 0) && (y + 1 < bitmap.Height) && (bitmap.GetPixel(x - 1, y + 1).ToArgb() == color))
                list_of_var_point.Add(new Point(x - 1, y + 1));
            if ((x - 1 > 0) && (y - 1 > 0) && (bitmap.GetPixel(x - 1, y - 1).ToArgb() == color))
                list_of_var_point.Add(new Point(x - 1, y - 1));
            return list_of_var_point;
        }


        private void change(object sender, EventArgs e)
        {
            Segm_Process();
        }
  
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (contours.Count != 0)
            {
                Save_contours_Form scf = new Save_contours_Form();
                scf.ShowDialog();
                if (scf.DialogResult == DialogResult.OK)
                {
                    string format = scf.comboBox1.Text;
                    int size = Convert.ToInt32(scf.comboBox2.Text);
                    SaveImages(size, format);
                }
            }
            else
            {
                MessageBox.Show("Контуров нет! Cохранять нечего!");
            }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ibOriginal.Image = new Image<Gray, byte>(Resizez(ibOriginal.Image.Bitmap));
            toolStripStatusLabel1.Text = "Изображение обрезано до размера контуров (" + ibOriginal.Image.Bitmap.Width.ToString() + ", " + ibOriginal.Image.Bitmap.Height.ToString() + ").";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Буфер заливки очищен.";
            fill_is_started = false;
            Segm_Process();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GetSkelet();
        }

        private void ibOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left))
            {
                FloodyFill(e.X, e.Y);
            }
        }
        private void ibOriginal_Paint(object sender, PaintEventArgs e)
        {
            if (contours != null)
                foreach (var contour in contours)
                    if (contour.Total > 1)
                        e.Graphics.DrawPolygon(Pens.Red, contour.ToArray());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Set_path();
        }






        Skeleton current_skelet_loaded;
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            current_skelet_loaded = Read_path();
            int i = 0;
            foreach (Skeleton.cell c in current_skelet_loaded.list_of_cell)
            {
                i++;
                listBox1.Items.Add(i);
            }
        }
        private void Paint_element(Skeleton.cell sc,int width,int height)
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




        private void Save_parts_of_ckeleton(int serial)
        {
            Save_contours_Form scf = new Save_contours_Form();
            scf.ShowDialog();
            if (scf.DialogResult == DialogResult.OK)
            {
                
                string format = scf.comboBox1.Text;
                int size = Convert.ToInt32(scf.comboBox2.Text);
                string folderName = @"elements";
                int files_count = 0;
                if (!Directory.Exists(folderName))
                    System.IO.Directory.CreateDirectory(folderName);
                else
                    files_count = Directory.GetFiles(folderName).Length;

                bool result_format = true;
                if (format == ".jpg")
                    result_format = true;
                else
                    result_format = false;
                for (int i = 0; i < current_skelet_loaded.list_of_cell.Count; i++)
                {
                    Bitmap bm = new Bitmap(current_skelet_loaded.Size.X, current_skelet_loaded.Size.Y);
                    foreach (Skeleton.node sn in current_skelet_loaded.list_of_cell[i].list_of_node)
                    {
                        bm.SetPixel(sn.x, sn.y, Color.White);
                    }
                    bm = Resizez(bm);
                    bm = CopyBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height),size);
                    string bitmap_name = files_count++.ToString() + "_" + serial.ToString() + " " + listBox1.Items[i].ToString() + format;
                    string pathString = System.IO.Path.Combine(folderName, bitmap_name);
                    if (result_format)
                        bm.Save(pathString, ImageFormat.Jpeg);
                    else
                        bm.Save(pathString, ImageFormat.Bmp);
                }
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count>0)
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

        private void button9_Click(object sender, EventArgs e)
        {
            Entry_Form ef = new Entry_Form("Ввод: номер блока");
            ef.ShowDialog();
            if (ef.DialogResult == DialogResult.OK)
                Save_parts_of_ckeleton(Convert.ToInt32(ef.textBox1.Text));
        }


        int k = 0;
        private void button8_Click_1(object sender, EventArgs e)
        {
            string xml_data = Save_to_xml_string(current_skelet_loaded);
            Console.WriteLine(xml_data);
            DBWorker dbw = new DBWorker();
            dbw.saveXml_to_database("Поц","Drost",xml_data);
            k++;
            dbw.Save_to_DataBase(1, 0.33, "Поц");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DBWorker dbw = new DBWorker();
            string new_xml = dbw.ReadXml_from_DataBase("1");
            Skeleton sk = Read_from_string(new_xml);
        }



  
    }




    //Жанг Суен скелетонизация
    public class Skeletonizator
    {
        private int[,] bitmap;

        public Skeletonizator(int[,] bitmap)
        {
            this.bitmap = bitmap;
        }

        public int[,] SkeletonZhangSuen()
        {
            int i, j, w, h, b, a, p1, p2, p3, p4;
            int[] p = new int[8];
            bool flag = true;

            w = bitmap.GetLength(0);
            h = bitmap.GetLength(1);
            int[,] markMap = new int[w, h];

            while (flag)
            {
                flag = false;

                /*  Подытерация 1: */
                for (i = 1; i < w - 1; i++)
                {
                    for (j = 1; j < h - 1; j++)
                    {
                        if (bitmap[i, j] == 0)
                        {
                            markMap[i, j] = 0;
                            continue;
                        }

                        a = Tla(bitmap, i, j, ref p, out b);   /* Функция A */
                        p1 = p[0] * p[2] * p[4];
                        p2 = p[2] * p[4] * p[6];

                        if ((a == 1) && ((b >= 2) && (b <= 6)) &&
                                (p1 == 0) && (p2 == 0))
                        {
                            markMap[i, j] = 1;
                            flag = true;
                        }
                        else
                            markMap[i, j] = 0;
                    }
                }
                DeleteMarked(markMap, ref bitmap);

                /* Подытерация 2: */
                for (i = 1; i < w - 1; i++)
                {
                    for (j = 1; j < h - 1; j++)
                    {
                        if (bitmap[i, j] == 0)
                        {
                            markMap[i, j] = 0;
                            continue;
                        }

                        a = Tla(bitmap, i, j, ref p, out b);   /* Функция A */
                        p1 = p[0] * p[2] * p[6];
                        p2 = p[0] * p[4] * p[6];

                        if ((a == 1) && ((b >= 2) && (b <= 6)) &&
                                (p1 == 0) && (p2 == 0))
                        {
                            markMap[i, j] = 1;
                            flag = true;
                        }
                        else
                            markMap[i, j] = 0;
                    }
                }
                DeleteMarked(markMap, ref bitmap);
            }

            /* Доролнительая итерация, устраняющая некоторые недочеты */
            for (i = 1; i < w - 1; i++)
            {
                for (j = 1; j < h - 1; j++)
                {
                    if (bitmap[i, j] == 0)
                    {
                        markMap[i, j] = 0;
                        continue;
                    }

                    Tla(bitmap, i, j, ref p, out b);   /* Функция A */

                    p1 = ((p[7] == 1) ? 0 : 1) * p[2] * p[4];
                    p2 = ((p[3] == 1) ? 0 : 1) * p[6] * p[0];
                    p3 = ((p[1] == 1) ? 0 : 1) * p[4] * p[6];
                    p4 = ((p[5] == 1) ? 0 : 1) * p[0] * p[2];

                    if (p1 == 1 || p2 == 1 || p3 == 1 || p4 == 1)
                        bitmap[i, j] = 0;
                }
            }

            return bitmap;
        }

        private int Tla(int[,] image, int i, int j, ref int[] p, out int b)
        {
            int m = 0, n = 0;

            p[0] = image[i - 1, j];
            p[1] = image[i - 1, j + 1];
            p[2] = image[i, j + 1];
            p[3] = image[i + 1, j + 1];
            p[4] = image[i + 1, j];
            p[5] = image[i + 1, j - 1];
            p[6] = image[i, j - 1];
            p[7] = image[i - 1, j - 1];

            for (int k = 0; k < 7; k++)
            {
                if ((p[k] == 0) && (p[k + 1] == 1))
                    m++;
                n += p[k];
            }

            if ((p[7] == 0) && (p[0] == 1))
                m++;

            n += p[7];
            b = n;

            return m;
        }

        private void DeleteMarked(int[,] markBmp, ref int[,] bitMap)
        {
            int w = bitMap.GetLength(0);
            int h = bitMap.GetLength(1);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    bitMap[i, j] -= markBmp[i, j];
        }
    }

}
