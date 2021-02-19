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
                Filter = "Image Files|*.png,*.jpg,*.jpeg",
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\alexi\Desktop\Objector",
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp",
                Multiselect = true
            };
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               ImageDep derp =  new ImageDep(open.FileNames);

                derp.ShowDialog();



            }
        }

        public void ExecuteCommandSync(object command)
        {
           
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
               
            
        }
    }
}
