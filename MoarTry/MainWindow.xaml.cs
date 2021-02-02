using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TryImage;
using WMPLib;


namespace MoarTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// s
    /// </summary>
    public partial class MainWindow : Window
    {
        String[] ListFile;
        String SourceFolder = null;
        bool SFolderOk;
        int file;
    

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            FolderAsk rab = new FolderAsk(0, SourceFolder);
            rab.ShowDialog();
            SourceFolder = rab.keepstr;
            rab.Close();
            SFolderOk = Directory.Exists(SourceFolder);
                if (SFolderOk)
                {

                   
                var allFiles = Directory.GetFiles(SourceFolder);
                var filesToExclude = Directory.GetFiles(SourceFolder, "*.ini");
                var WantedFile = allFiles.Except(filesToExclude);
                ListFile = WantedFile.ToArray();
                

                file = 0;
                 Dab.Text = System.IO.Path.GetFileName(ListFile[0]);

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@ListFile[file]);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();


                Image1.Source = bitmap;



            }
            Directory.CreateDirectory(SourceFolder + @"\Normal");
            Directory.CreateDirectory(SourceFolder + @"\Futa");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (SFolderOk)
                if (file < ListFile.Length)
                {
                   
                        if (SourceFolder != null)
                        {

                            File.Move(ListFile[file], SourceFolder + @"\Normal\" + System.IO.Path.GetFileName(ListFile[file]) + System.IO.Path.GetExtension(ListFile[file]));
                        }
                        else
                        { System.Windows.Forms.MessageBox.Show("No image to rename", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


                    file++;
                    if (file == ListFile.Length)
                    { System.Windows.Forms.MessageBox.Show(" End of image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@ListFile[file]);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                   
                    Image1.Source = bitmap; 
                    Dab.Text = System.IO.Path.GetFileName(ListFile[file]);
                    

                }
                else
                    System.Windows.Forms.MessageBox.Show("no more image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                System.Windows.Forms.MessageBox.Show("You're not going trought a folder! -> Open Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SFolderOk)
                if (file < ListFile.Length)
                {

                    if (SourceFolder != null)
                    {
                        File.Move(ListFile[file], SourceFolder + @"\Futa\" + System.IO.Path.GetFileName(ListFile[file]) + System.IO.Path.GetExtension(ListFile[file]));
                    }
                    else
                    { System.Windows.Forms.MessageBox.Show("No image to rename", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


                    file++;
                    if (file == ListFile.Length)
                    { System.Windows.Forms.MessageBox.Show(" End of image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }



                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@ListFile[file]);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();


                    Image1.Source = bitmap;

                    Dab.Text = System.IO.Path.GetFileName(ListFile[file]);
                    

                }
                else
                    System.Windows.Forms.MessageBox.Show("no more image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                System.Windows.Forms.MessageBox.Show("You're not going trought a folder! -> Open Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (SFolderOk)
                if (file < ListFile.Length)
                {

                    if (SourceFolder != null)
                    {
                    }
                    else
                    { System.Windows.Forms.MessageBox.Show("No image to rename", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


                    file++;
                    if (file == ListFile.Length)
                    { System.Windows.Forms.MessageBox.Show(" End of image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                    


                     Dab.Text = System.IO.Path.GetFileName(@ListFile[file]);

                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@ListFile[file]);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();


                    Image1.Source = bitmap;
                }
                else
                    System.Windows.Forms.MessageBox.Show("no more image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                System.Windows.Forms.MessageBox.Show("You're not going trought a folder! -> Open Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
 }
   