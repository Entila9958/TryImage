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
using System.Windows.Shapes;
using System.IO;


namespace Objection
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class ImageDep : Window
    {
        private string[] ListOfPath;
        private int v ;

        public ImageDep(string[] ListPath)
        {
            InitializeComponent();
            ListOfPath = ListPath;
            ImaAff.Source = new BitmapImage(new Uri(ListOfPath[0]));
            v = 0;
        }


       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExecuteCommandSync("magick convert \"" + ListOfPath[v] + "\"   \"" + System.IO.Path.GetDirectoryName(ListOfPath[v]) + @"\" + System.IO.Path.GetFileNameWithoutExtension(ListOfPath[v]) + ".png\"");

            MessageBox.Show("magick convert \"" + ListOfPath[v] + "\"   \"" + System.IO.Path.GetDirectoryName(ListOfPath[v]) + @"\" + System.IO.Path.GetFileNameWithoutExtension(ListOfPath[v]) + ".png\"");



            v++;
            if (ListOfPath.Length == v)
                Close();
            ImaAff.Source = new BitmapImage(new Uri(ListOfPath[0]));
        }

        public void ExecuteCommandSync(object command)
        {

            // create the ProcessStartInfo using "cmd" as the program to be run,
            // and "/c " as the parameters.
            // Incidentally, /c tells cmd that we want it to execute the command that follows,
            // and then exit.
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

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

            TextBox.Text = result;

        }
    }
}
