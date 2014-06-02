using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlPrg
{
    public partial class Vectorizer_Form : Form
    {


        public Vectorizer_Form()
        {
            InitializeComponent();
        }

       
        List<Bitmap> contour_bitmap_list = new List<Bitmap>();

        string path_to_current_image;
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcessed;
        private void button1_Click(object sender, EventArgs e)
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
                    path_to_current_image = openFileDialog1.FileName;
                    imgOriginal = new Image<Bgr, byte>(path_to_current_image);
                    ibOriginal.Image = imgOriginal;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,] bit = new int[imgOriginal.Bitmap.Height, imgOriginal.Bitmap.Width];
            imgProcessed.Bitmap = ibOriginal.Image.Bitmap;
            for (int i = 0; i < imgOriginal.Bitmap.Height; i++)
                for (int j = 0; j < imgOriginal.Bitmap.Width;j++ )
                {
                    if (imgProcessed.Bitmap.GetPixel(j,i).ToArgb() == -1)
                        bit[i, j] = 1;
                    else
                        bit[i, j] = 0;
                }

            Bitmap bm = new Bitmap(imgOriginal.Bitmap.Width, imgOriginal.Bitmap.Height);
            ibProcessed.Image = new Image<Bgr, byte>(bm);
            Skeletonizator s = new Skeletonizator(bit);
            int[,] sk = new int[imgOriginal.Bitmap.Height, imgOriginal.Bitmap.Width];
            sk = s.SkeletonZhangSuen();
            for (int i = 0; i < imgOriginal.Bitmap.Height; i++)
                for (int j = 0; j < imgOriginal.Bitmap.Width; j++)
                {
                    if (sk[i,j] == 1)
                        bm.SetPixel(j, i, Color.Red);
                    else
                        bm.SetPixel(j, i, Color.White);
                }
            ibProcessed.Image = new Image<Bgr, byte>(bm);

            

        }

        bool equalizeHist = false;
        bool noiseFilter = true;
        bool blur = false;
        bool blackandwhite = true;
        int maxContourLength = 418;
        int minContourLength = 50;
        int minContourArea = 0;
        double thresVal = 0;
        int nfVal = 100;
        List<Contour<Point>> contours = new List<Contour<Point>>();

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
                    if (contour.Total > 1)
                        e.Graphics.DrawPolygon(Pens.Red, contour.ToArray());
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

        private Bitmap createnewpolygon()
        {
            Bitmap bm = new Bitmap(imgOriginal.Width, imgOriginal.Height);
            foreach (var contour in contours)
            {
                if (contour.Total > 1)
                {
                    Graphics.FromImage((Image)bm).DrawPolygon(Pens.White, contour.ToArray());
                }
            }
            contours.Clear();
            return bm;
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

        private void minContLen_tb_Scroll(object sender, EventArgs e)
        {
            minContourLength = (int)minContLen_tb.Value;
            Segm_Process();
        }
        private void minContAr_tb_Scroll(object sender, EventArgs e)
        {
            minContourArea = (int)minContAr_tb.Value;
            Segm_Process();
        }
        private void maxContLen_tb_Scroll(object sender, EventArgs e)
        {
            maxContourLength = (int)maxContLen_tb.Value;
            Segm_Process();
        }
        private void thres_tb_Scroll(object sender, EventArgs e)
        {
            thresVal = (double)thres_tb.Value / 100;
            Segm_Process();
        }
        private void nf_tb_Scroll(object sender, EventArgs e)
        {
            nfVal = (int)nf_tb.Value;
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

        }





        







        
        private void button3_Click_1(object sender, EventArgs e)
        {
            Segm_Process();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ibOriginal.Image = new Image<Gray, byte>(createnewpolygon());
        }


        bool mouse_fill = true;
        private void ibOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left))
            {
                Bitmap bm = createnewpolygon();
                int coordX = Convert.ToInt32(e.X / ibOriginal.ZoomScale + ibOriginal.HorizontalScrollBar.Value); ;// -ibOriginal.Location.X;
                int coordY = Convert.ToInt32(e.Y / ibOriginal.ZoomScale + ibOriginal.VerticalScrollBar.Value);// -ibOriginal.Location.Y;
                FloodFill(bm, coordX, coordY, Color.White);
                Graphics.FromImage((Image)bm).DrawEllipse(Pens.White, coordX - 1, coordY - 1, 2, 2);
                ibOriginal.Image = new Image<Gray, byte>(bm);
            }
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
