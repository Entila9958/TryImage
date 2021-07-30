using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Threading;
namespace TheGhost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoWork();
        }
        public void Eventhendler(String a)
        {
            
            TheLabal.Content = a;
            

        }

        public static void DoWork()
        {
           
           
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Image Files(*.png)|*.png";
            Dialog.InitialDirectory = @"C:\Users\alexi\Desktop\Objector";
            Dialog.Multiselect = true;
            
            if (Dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            System.Drawing.Bitmap A = new System.Drawing.Bitmap(Dialog.FileNames[0]);
            System.Drawing.Bitmap B = new System.Drawing.Bitmap(Dialog.FileNames[1]);
            System.Drawing.Color Transluscent = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            
            for (int g = -254; g < 255; g++)
            {
                System.Drawing.Bitmap C = new System.Drawing.Bitmap(A);
                System.Drawing.Bitmap D = new System.Drawing.Bitmap(B);
                for (int x = 0; x < A.Width; x++)
                    for (int y = 0; y < A.Height; y++)
                    {
                        if (A.GetPixel(x, y) == B.GetPixel(x, y))
                        {
                            C.SetPixel(x, y, Transluscent);
                            D.SetPixel(x, y, Transluscent);
                        }
                        else
                        {
                            System.Drawing.Color Apixel = A.GetPixel(x, y);
                            System.Drawing.Color Bpixel = B.GetPixel(x, y);
                            C.SetPixel(x, y, System.Drawing.Color.FromArgb(255, TheCalculs(Apixel.R, Bpixel.R, g), TheCalculs(Apixel.G, Bpixel.G, g), TheCalculs(Apixel.B, Bpixel.B, g)));
                            D.SetPixel(x, y, System.Drawing.Color.FromArgb(255, TheCalculs(Bpixel.R, Apixel.R, g), TheCalculs(Bpixel.G, Apixel.G, g), TheCalculs(Bpixel.B, Apixel.B, g)));

                        }
                    }
                C.Save(@"C:\Users\alexi\Desktop\Objector\Heeeeeeelp\A\" + g.ToString() + ".png");
                D.Save(@"C:\Users\alexi\Desktop\Objector\Heeeeeeelp\B\" + g.ToString() + ".png");

                C.Dispose();
                D.Dispose();
            }
      
        }


        private static int TheCalculs(int a, int b, int alpha)
        {
            int g = (int)(a + ((b - a) / ((float)alpha / 255)));
            if (g > 255)
                return 255;
            if (g < 0)
                return 0;

            return g;


        }
        public delegate void StartOfEvent(string a);
        public event StartOfEvent TheEvent;


    }
}
