//Copyright (C) 2014 AlexVictorne, Nikita_blackbeard

using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace controlPrg
{
    public partial class Segment_Form : Form
    {
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcessed;
        string path_to_current_image = @"test_image.jpg";
        List<Bitmap> contour_bitmap_list = new List<Bitmap>();

        public Segment_Form()
        {
            InitializeComponent();
            imgOriginal = new Image<Bgr, byte>(path_to_current_image);
            ibOriginal.Image = imgOriginal;
            Segm_Process();
        }

        bool equalizeHist = false;
        bool noiseFilter = true;
        bool blur = false;
        bool blackandwhite = true;
        int maxContourLength = 418;
        int minContourLength = 50;
        int minContourArea = 0;
        double thresVal = 20;
        int nfVal = 100;
        List<Contour<Point>> contours;

        void Segm_Process()
        {
            //преобразование изображения в чб
            imgProcessed = imgOriginal.Convert<Gray, Byte>();
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
            imgProcessed._Not();
            try
            {
                if (cannyFrame != null)
                    imgProcessed._Or(cannyFrame);
            }
            catch { }
            if (cannyFrame != null)
                cannyFrame = cannyFrame.Dilate(3);
            //поиск контуров 
            var sourceContours = imgProcessed.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST);
            //фильтруем контуры
            contours = FilterContours(sourceContours, cannyFrame, imgProcessed.Width, imgProcessed.Height);
            ibOriginal.Image = imgProcessed;
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
                if (con.Total < minContourLength || con.Total > maxContourLength ||
                        con.Area < minContourArea || con.Area > maxArea ||
                        con.Area / con.Total <= 0.5)
                    goto next;
                if (noiseFilter)
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

        private void ibOriginal_Paint(object sender, PaintEventArgs e)
        {
            //очистить список с готовыми контурами
            contour_bitmap_list.Clear();
            if (contours != null)
                foreach (var contour in contours)
                {
                    //прямоугольник описывающий контур
                    Rectangle newrect = Contour(contour, 0, contour.Total);
                    //добавляем часть изображения в список с контурами
                    contour_bitmap_list.Add(new Bitmap(newrect.Width, newrect.Height));
                    contour_bitmap_list[contour_bitmap_list.Count - 1] = CopyBitmap(ibOriginal.Image.Bitmap, newrect); 
                    //обводим контур
                    if (contour.Total > 1)
                        e.Graphics.DrawLines(Pens.Red, contour.ToArray());
                    //рисуем прямоугольник вокруг контура
                    e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), newrect);
                }
        }
       
        //копируем часть изображения в битмап
        int bitmapformat = 64;
        Bitmap CopyBitmap(Image src, Rectangle rect)
        {
            var ret = new Bitmap(rect.Width, rect.Height);
            using (var g = Graphics.FromImage(ret))
            {
                g.DrawImage(src, 0, 0, rect, GraphicsUnit.Pixel);
            }
            var res = new Bitmap(bitmapformat, bitmapformat);
            using (var g = Graphics.FromImage(res))
            {
                //выбираем качество масштабирования
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //масштабируем битмап в 16*16
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

        bool result_format = true;
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



        void saveToFolder_btn_Click(object sender, EventArgs e)
        {
            string folderName = @"images";
            try { System.IO.Directory.Delete(folderName,true); }
            catch { }
            System.IO.Directory.CreateDirectory(folderName);
            string f_ext;
            if (result_format)
                f_ext = ".jpg";
            else
                f_ext =  ".bmp";
            int i = 0;
            foreach (Bitmap bit in contour_bitmap_list)
            {
                string fileName = i.ToString() + f_ext;
                string pathString = System.IO.Path.Combine(folderName, fileName);
                Bitmap bm = bit;
                if (blackandwhite)
                    bm = BlachAndWhite(bm, 120);
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
            string format;
            if (result_format) format = ".jpg";
            else format = ".bmp";
            MessageBox.Show(contour_bitmap_list.Count.ToString()+", "+bitmapformat.ToString()+"*"+bitmapformat.ToString()+", "+format+" сохранено");
        }
        private void loadImage_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "BMP files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path_to_current_image = openFileDialog1.FileName;
                    imgOriginal = new Image<Bgr, byte>(path_to_current_image);
                    ibOriginal.Image = imgOriginal;
                    Segm_Process();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void minContLen_tb_Scroll(object sender, EventArgs e)
        {
            minContourLength = minContLen_tb.Value;
            minContLenVal_label.Text = minContourLength.ToString();
            Segm_Process();
        }
        private void minContAr_tb_Scroll(object sender, EventArgs e)
        {
            minContourArea = minContAr_tb.Value;
            minContArVal_label.Text = minContourArea.ToString();
            Segm_Process();
        }
        private void maxContLen_tb_Scroll(object sender, EventArgs e)
        {
            maxContourLength = maxContLen_tb.Value;
            maxContLenVal_label.Text = maxContourLength.ToString();
            Segm_Process();
        }
        private void thres_tb_Scroll(object sender, EventArgs e)
        {
            thresVal = (double)thres_tb.Value / 100;
            thresVal_label.Text = thresVal.ToString();
            Segm_Process();
        }
        private void nf_tb_Scroll(object sender, EventArgs e)
        {
            nfVal = nf_tb.Value;
            nfVal_label.Text = nfVal.ToString();
            Segm_Process();
        }

        private void autocont_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (equalizeHist)
                equalizeHist = false;
            else
                equalizeHist = true;
            Segm_Process();
        }
        private void blur_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (blur)
                blur = false;
            else
                blur = true;
            Segm_Process();
        }
        private void nf_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (noiseFilter)
                noiseFilter = false;
            else
                noiseFilter = true;
            Segm_Process();
        }
        private void bmp_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (bmp_chb.Checked)
                result_format = false;
            else
                result_format = true;
        }

        private void bitmapformat_tb_TextChanged(object sender, EventArgs e)
        {
            bitmapformat = Convert.ToInt32(bitmapformat_tb.Text);
        }

    }
}
