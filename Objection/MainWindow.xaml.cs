using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
namespace Objection
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
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\alexi\Desktop\Objector",
                Filter = "Image Files|*.png",
                Multiselect = true
            };
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach(string a in open.FileNames)
                {
                    Directory.CreateDirectory(@"F:\Steam\steamapps\common\Team Fortress 2\tf\custom\" + System.IO.Path.GetFileNameWithoutExtension(a) + @"\scripts\items\custom_texture_blend_layers");
                    File.Move(a, @"F:\Steam\steamapps\common\Team Fortress 2\tf\custom\" + System.IO.Path.GetFileNameWithoutExtension(a) + @"\scripts\items\custom_texture_blend_layers\paper_overlay.png");
                }



            }
        }
    }
}
