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
namespace Dif
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
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp ; *.png)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            Dialog.InitialDirectory = @"C:\Users\alexi\Desktop\Objector";
            Dialog.Multiselect = true;
            if (Dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            
            System.Drawing.Bitmap A = new System.Drawing.Bitmap(Dialog.FileNames[0]);
            System.Drawing.Bitmap B = new System.Drawing.Bitmap(Dialog.FileNames[1]);
            System.Drawing.Bitmap C = new Bitmap(A);
            System.Drawing.Bitmap D = new Bitmap(B);
            System.Drawing.Color Transluscent = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            

            for (int x= 0; x < A.Width; x++)
                for (int y = 0; y < A.Height; y++)
                {
                    if(A.GetPixel(x,y) == B.GetPixel(x,y))
                    {
                        C.SetPixel(x, y, Transluscent);
                        D.SetPixel(x, y, Transluscent);
                    }

                }
            C.Save(@"C:\Users\alexi\Desktop\Objector\a.jpeg");
            D.Save(@"C:\Users\alexi\Desktop\Objector\B.jpeg");
        }
    }
}
