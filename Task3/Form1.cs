using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        private Point PreviousPoint, point;
        private Bitmap bmp, bmp_copy;
        private Pen blackPen;
        private Graphics g;
        

        public Form1()
        {
            InitializeComponent();
        }      

        private void Form_Load(object sender, EventArgs e)
        {
            blackPen = new Pen(Color.Black, 2);
            panel1.Hide();
            panel2.Hide();
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            PreviousPoint.X = e.X;
            PreviousPoint.Y = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPEG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)| *.bmp; *.jpeg; *.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                string filename = dialog.FileName;

                int width = pictureBox1.Width;
                int height = pictureBox1.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                pictureBox2.Width = width;
                pictureBox2.Height = height;

                bmp = new Bitmap(image, width, height);
                bmp_copy = new Bitmap(image, width, height);


                pictureBox1.Image = bmp;
                pictureBox2.Image = bmp_copy;

                g = Graphics.FromImage(pictureBox1.Image);
                g = Graphics.FromImage(pictureBox2.Image);

            }

        }
        
           
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Minimum = -100;
            trackBar1.Maximum = 100;
            trackBar1.SmallChange = 10;
            trackBar1.TickFrequency = 10;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {

                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    int Red = R + trackBar1.Value * 128 / 100;
                    int Green = G;
                    int Blue = B;

                    if (Red < 0)
                    {
                        Red = 0;
                    }
                    else if (Red > 255)
                    {
                        Red = 255;
                    }

                    Color p = Color.FromArgb(255, Red, Green, Blue);
                    bmp_copy.SetPixel(i, j, p);
                }
            Refresh();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackBar2.Minimum = -100;
            trackBar2.Maximum = 100;
            trackBar2.SmallChange = 10;
            trackBar2.TickFrequency = 10;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {

                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    int Red = R;
                    int Green = G + trackBar2.Value * 128 / 100;
                    int Blue = B;

                    if (Green < 0)
                    {
                        Green = 0;
                    }
                    else if (Green > 255)
                    {
                        Green = 255;
                    }

                    Color p = Color.FromArgb(255, Red, Green, Blue);
                    bmp_copy.SetPixel(i, j, p);
                }
            Refresh();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            trackBar3.Minimum = -100;
            trackBar3.Maximum = 100;
            trackBar3.SmallChange = 10;
            trackBar3.TickFrequency = 10;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {

                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    int Red = R;
                    int Green = G;
                    int Blue = B + trackBar3.Value * 128 / 100;

                    if (Blue < 0)
                    {
                        Blue = 0;
                    }
                    else if (Blue > 255)
                    {
                        Blue = 255;
                    }
                    
                    Color p = Color.FromArgb(255, Red, Green, Blue);
                    bmp_copy.SetPixel(i, j, p);
                }
            Refresh();
        }       
        private void trackBar4_Scroll(object sender, EventArgs e)
        {          
            trackBar4.Minimum = -100;
            trackBar4.Maximum = 100;
            trackBar4.SmallChange = 10;
            trackBar4.TickFrequency = 10;
            
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {

                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    int Red = R + trackBar4.Value * 128/100;
                    int Green = G + trackBar4.Value * 128 / 100;
                    int Blue = B + trackBar4.Value * 128 / 100;   
                                      
                    if(Red < 0)
                    {
                        Red = 0;
                    } else if (Red > 255)
                    {
                        Red = 255;
                    }
                    if (Green < 0)
                    {
                        Green = 0;
                    }
                    else if (Green > 255)
                    {
                        Green = 255;
                    }
                    if (Blue < 0)
                    {
                        Blue = 0;
                    }
                    else if (Blue > 255)
                    {
                        Blue = 255;
                    }
                    Color p = Color.FromArgb(255, Red, Green, Blue);
                    bmp_copy.SetPixel(i, j, p);
                }
            Refresh();
        }


        private void label1_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = String.Format("Текущее значение яркости красного: {0} %", trackBar1.Value);
        }
      

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            label2.Text = String.Format("Текущее значение яркости зеленого: {0} %", trackBar2.Value);
        }
       

        private void label3_Paint(object sender, PaintEventArgs e)
        {
            label3.Text = String.Format("Текущее значение яркости синего: {0} %", trackBar3.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                panel2.Hide();
            }
            panel1.Show();         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Hide();
            }
            panel2.Show();
        }

        private void label5_Paint(object sender, PaintEventArgs e)
        {
            label5.Text = String.Format("Текущее значение контрастности красного: {0} %", trackBar5.Value);
        }

        private void label6_Paint(object sender, PaintEventArgs e)
        {
            label6.Text = String.Format("Текущее значение контрастности зеленого: {0} %", trackBar6.Value);
        }

        private void label7_Paint(object sender, PaintEventArgs e)
        {
            label7.Text = String.Format("Текущее значение контрастности синего: {0} %", trackBar7.Value);
        }

        private void label8_Paint(object sender, PaintEventArgs e)
        {
            label8.Text = String.Format("Текущее значение общей контрастности: {0} %", trackBar8.Value);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            trackBar4.Minimum = -100;
            trackBar4.Maximum = 100;
            trackBar4.SmallChange = 10;
            trackBar4.TickFrequency = 10;


            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    
                    if (trackBar5.Value > 0)
                    {
                        func_trackBar_plus(i, j, trackBar5.Value, 0, 0);
                    }
                    else if (trackBar5.Value < 0)
                    {
                        func_trackBar_minus(i, j, trackBar5.Value, 0, 0);
                    }

                }

            Refresh();
        }       
        private void func_trackBar_plus(int i, int j, int valueR, int valueG, int valueB)
        {
            int R = bmp.GetPixel(i, j).R;
            int G = bmp.GetPixel(i, j).G;
            int B = bmp.GetPixel(i, j).B;
            int Red = (R * 100 - 128 * valueR) / (100 - valueR);
            int Green = (G * 100 - 128 * valueG) / (100 - valueG); ;
            int Blue = (B * 100 - 128 * valueB) / (100 - valueB); ;
            if (Red < 0)
            {
                Red = 0;
            }
            else if (Red > 255)
            {
                Red = 255;
            }
            if (Green < 0)
            {
                Green = 0;
            }
            else if (Green > 255)
            {
                Green = 255;
            }
            if (Blue < 0)
            {
                Blue = 0;
            }
            else if (Blue > 255)
            {
                Blue = 255;
            }

            Color p = Color.FromArgb(255, Red, Green, Blue);
            bmp_copy.SetPixel(i, j, p);
        }
        private void func_trackBar_minus(int i, int j, int valueR, int valueG, int valueB)
        {
            int R = bmp.GetPixel(i, j).R;
            int G = bmp.GetPixel(i, j).G;
            int B = bmp.GetPixel(i, j).B;
            int Red = (R * 100 - 128 * valueR) / (100 - valueR);
            int Green = (G * 100 - 128 * valueG) / (100 - valueG);
            int Blue = (B * 100 - 128 * valueB) / (100 - valueB);
            if (Red < 0)
            {
                Red = 0;
            }
            else if (Red > 255)
            {
                Red = 255;
            }
            if (Green < 0)
            {
                Green = 0;
            }
            else if (Green > 255)
            {
                Green = 255;
            }
            if (Blue < 0)
            {
                Blue = 0;
            }
            else if (Blue > 255)
            {
                Blue = 255;
            }
            Color p = Color.FromArgb(255, Red, Green, Blue);
            bmp_copy.SetPixel(i, j, p);           
        }


        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            trackBar4.Minimum = -100;
            trackBar4.Maximum = 100;
            trackBar4.SmallChange = 10;
            trackBar4.TickFrequency = 10;


            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {                  
                    if (trackBar8.Value > 0)
                    {
                        func_trackBar_plus(i,j, trackBar8.Value, trackBar8.Value, trackBar8.Value);
                    } else if (trackBar8.Value < 0)
                    {
                        func_trackBar_minus(i, j, trackBar8.Value, trackBar8.Value, trackBar8.Value);
                    }
                    
                }
            Refresh();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                point.X = e.X;
                point.Y = e.Y;

                g.DrawLine(blackPen, PreviousPoint, point);

                PreviousPoint.X = point.X;
                PreviousPoint.Y = point.Y;
                pictureBox2.Invalidate();
            }
            
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            PreviousPoint.X = e.X;
            PreviousPoint.Y = e.Y;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            trackBar4.Minimum = -100;
            trackBar4.Maximum = 100;
            trackBar4.SmallChange = 10;
            trackBar4.TickFrequency = 10;


            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    
                    if (trackBar6.Value > 0)
                    {
                        func_trackBar_plus(i, j, 0, trackBar6.Value, 0);
                    }
                    else if (trackBar6.Value < 0)
                    {
                        func_trackBar_minus(i, j, 0, trackBar6.Value, 0);
                    }

                }
            Refresh();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            trackBar4.Minimum = -100;
            trackBar4.Maximum = 100;
            trackBar4.SmallChange = 10;
            trackBar4.TickFrequency = 10;


            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    
                    if (trackBar7.Value > 0)
                    {
                        func_trackBar_plus(i, j, 0, 0, trackBar7.Value);
                    }
                    else if (trackBar7.Value < 0)
                    {
                        func_trackBar_minus(i, j, 0, 0, trackBar7.Value);
                    }

                }
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            label1.Text = String.Format("Текущее значение яркости красного: {0} %", trackBar1.Value);
            trackBar2.Value = 0;
            label2.Text = String.Format("Текущее значение яркости зеленого: {0} %", trackBar2.Value);
            trackBar3.Value = 0;
            label3.Text = String.Format("Текущее значение яркости синего: {0} %", trackBar3.Value);
            trackBar4.Value = 0;
            label4.Text = String.Format("Текущее значение общей яркости: {0} %", trackBar4.Value);
            trackBar5.Value = 0;
            label5.Text = String.Format("Текущее значение контрастности красного: {0} %", trackBar5.Value);
            trackBar6.Value = 0;
            label6.Text = String.Format("Текущее значение контрастности зеленого: {0} %", trackBar6.Value);
            trackBar7.Value = 0;
            label7.Text = String.Format("Текущее значение контрастности синего: {0} %", trackBar7.Value);
            trackBar8.Value = 0;
            label8.Text = String.Format("Текущее значение общей контрастности: {0} %", trackBar8.Value);

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {

                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    int Red = R;
                    int Green = G;
                    int Blue = B;

                    if (Red < 0)
                    {
                        Red = 0;
                    }
                    else if (Red > 255)
                    {
                        Red = 255;
                    }
                    if (Green < 0)
                    {
                        Green = 0;
                    }
                    else if (Green > 255)
                    {
                        Green = 255;
                    }
                    if (Blue < 0)
                    {
                        Blue = 0;
                    }
                    else if (Blue > 255)
                    {
                        Blue = 255;
                    }

                    Color p = Color.FromArgb(255, Red, Green, Blue);
                    bmp_copy.SetPixel(i, j, p);
                }
            Refresh();

        }

        private void label4_Paint(object sender, PaintEventArgs e)
        {
            label4.Text = String.Format("Текущее значение общей яркости: {0} %", trackBar4.Value);
        }

       
      
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();

            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = 
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpeg)|*.jpeg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                 string fileName = savedialog.FileName;

                string strExtn = fileName.Remove(0, fileName.Length - 3);

                switch(strExtn)
                {
                    case "bmp":
                        bmp_copy.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpeg":
                        bmp_copy.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp_copy.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp_copy.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp_copy.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;

                }
            }

        }
     
    }
}
