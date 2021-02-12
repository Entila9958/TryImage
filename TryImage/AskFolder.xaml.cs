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

namespace TryImage
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class FolderAsk : Window
    {
        public string keepstr;
        public FolderAsk(int g,string str)
        {
            InitializeComponent();
            if (g == 0)
                TheText.Text = "Please insert a source folder";
            else
                TheText.Text = "Please insert a destination folder";
            TheFolder.Text = str; 
            keepstr = str;
            
        }

        private void ButOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            keepstr = TheFolder.Text;
        }

        private void ButFold_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
           
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                keepstr = dialog.SelectedPath;
                TheFolder.Text = keepstr;
            }
        }
    }
}
