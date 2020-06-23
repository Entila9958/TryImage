using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Windows.Forms;

using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Net.Http;
using System.Windows.Controls;

namespace TryImage
{
    /// <summary>
    /// Image Rennamer : Might be horrible, don't care.
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<String> StateEvent = new ObservableCollection<String>();
        ObservableCollection<String> EventToDo = new ObservableCollection<String>();
        ObservableCollection<String> BaseEvent = new ObservableCollection<String>();
        Data donnee;
        DataS Actuel;
        DataS Final;
        String SourceFolder =null;
        String DestinationFolder=null;
        String[] ListFile;
        bool SFolderOk;
        int file;
        bool IsAboutOpen = false;
        About fen = null;
        public MainWindow()
        {
            InitializeComponent();
            BaseEventCheck.ItemsSource = BaseEvent;
            SupEventCheck.ItemsSource = EventToDo;
            StateCheckBox.ItemsSource = StateEvent;
            if (File.Exists("Data.xml"))
            {
                Stream stream = File.Open("Data.xml", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                donnee = (Data)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {

                // DataS inprogress;
                donnee = new Data();
                //All Event
                donnee.Add(new DataS("Sex Act"));
                donnee.Add(new DataS("Chore"));
                donnee.Add(new DataS("Job"));
                donnee.Add(new DataS("School"));
                donnee.Add(new DataS("Tired"));
                donnee.Add(new DataS("Contest"));
                donnee.Add(new DataS("Event"));
                donnee.Add(new DataS("Tentacle Sex"));
                donnee.Add(new DataS("Item"));

                // All Sex Act
                donnee.Base[0].Add(new DataS("Fuck"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Threesome"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Plug"));
                donnee.Base[0].Add(new DataS("Strip Tease"));
                donnee.Base[0].Add(new DataS("Naked"));
                donnee.Base[0].Add(new DataS("Masturbate"));
                donnee.Base[0].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Dildo"));
                donnee.Base[0].Add(new DataS("Anal"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Tits Fuck"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Nothing"));
                donnee.Base[0].Add(new DataS("Lick"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Orgy"));
                donnee.Base[0].Add(new DataS("Bondage"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Naked"));
                donnee.Base[0].Add(new DataS("Kiss Female"));
                donnee.Base[0].Add(new DataS("Kiss Male"));
                donnee.Base[0].Add(new DataS("Blowjob"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Handjob"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Gang-Bang"));
                donnee.Base[0].Add(new DataS("Cum Bath"));
                donnee.Base[0].Add(new DataS("Footjob"));
                donnee.Base[0].SousLevel[donnee.Base[0].SousLevel.Count - 1].Add(new DataS("Lesbian"));
                donnee.Base[0].Add(new DataS("Touch"));
                donnee.Base[0].Add(new DataS("Spanking"));


                foreach (DataS item in donnee.Base[0].SousLevel)
                    item.Add(new DataS("As Dickgirl"));
                foreach (DataS item in donnee.Base[0].SousLevel)
                    item.Add(new DataS("Catgirl"));

                // All chore 
                donnee.Base[1].Add(new DataS("Cooking"));
                donnee.Base[1].Add(new DataS("Cleaning"));
                donnee.Base[1].Add(new DataS("Expose Themself"));
                donnee.Base[1].Add(new DataS("Fitness"));
                donnee.Base[1].Add(new DataS("Discuss"));
                donnee.Base[1].Add(new DataS("Make Up"));

                foreach (DataS item in donnee.Base[1].SousLevel)
                    item.Add(new DataS("Naked"));

                // All job
                donnee.Base[2].Add(new DataS("Acolyte"));
                donnee.Base[2].Add(new DataS("Bar"));
                donnee.Base[2].Add(new DataS("Restaurant"));
                donnee.Base[2].Add(new DataS("Onsen"));
                donnee.Base[2].Add(new DataS("Library"));
                donnee.Base[2].Add(new DataS("Sleazy Bar"));
                donnee.Base[2].Add(new DataS("Brothel"));
                donnee.Base[2].SousLevel[donnee.Base[2].SousLevel.Count - 1].Add(new DataS("Lesbian"));

                foreach (DataS item in donnee.Base[2].SousLevel)
                    item.Add(new DataS("Naked"));

                //All school
                donnee.Base[3].Add(new DataS("XXX"));
                donnee.Base[3].Add(new DataS("Refinement"));
                donnee.Base[3].Add(new DataS("Theology"));
                donnee.Base[3].Add(new DataS("Dance"));
                donnee.Base[3].Add(new DataS("Sciences"));
                donnee.Base[3].Add(new DataS("Swimming"));
                donnee.Base[3].Add(new DataS("Singing"));
                foreach (DataS item in donnee.Base[4].SousLevel)
                    item.Add(new DataS("Naked"));
                //All Contest
                donnee.Base[5].Add(new DataS("Advanced Housework"));
                donnee.Base[5].Add(new DataS("Housework"));
                donnee.Base[5].Add(new DataS("Dance"));
                donnee.Base[5].Add(new DataS("Ponygirl"));
                donnee.Base[5].Add(new DataS("Beauty"));
                donnee.Base[5].Add(new DataS("Court"));
                donnee.Base[5].Add(new DataS("General Knownledge"));
                donnee.Base[5].Add(new DataS("XXX"));
                foreach (DataS item in donnee.Base[3].SousLevel)
                    item.Add(new DataS("Naked"));

                //All Event
                donnee.Base[6].Add(new DataS("Ambush"));
                donnee.Base[6].Add(new DataS("Town Ambush"));
                donnee.Base[6].Add(new DataS("Ambush Slum"));
                donnee.Base[6].Add(new DataS("Beach"));
                donnee.Base[6].Add(new DataS("Giga BE"));
                donnee.Base[6].Add(new DataS("Milk"));
                donnee.Base[6].SousLevel[donnee.Base[6].SousLevel.Count - 1].Add(new DataS("End"));
                donnee.Base[6].SousLevel[donnee.Base[6].SousLevel.Count - 1].Add(new DataS("Milk"));
                donnee.Base[6].SousLevel[donnee.Base[6].SousLevel.Count - 1].Add(new DataS("Accident"));
                donnee.Base[6].Add(new DataS("Naked Apron"));
                donnee.Base[6].Add(new DataS("Pocket Watch"));
                donnee.Base[6].Add(new DataS("Raped"));
                donnee.Base[6].Add(new DataS("Visitation"));
                donnee.Base[6].Add(new DataS("Wounded"));
                donnee.Base[6].Add(new DataS("Onsen"));
                
            }
           
            RadCp.IsChecked = true;
            foreach (DataS item in donnee.Base)
            {
                BaseEvent.Add(item.Nom);
            }
        }

        private void ButOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

               
                SourceFolder = open.FileName;









                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(open.FileName);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                
                Image1.Source = bitmap;












                SFolderOk = false;
                file = 0;
            }

        }

        private void ButAdd_Click(object sender, RoutedEventArgs e)
        {
            if (BaseEvent.Contains(NomAct.Text))
                System.Windows.Forms.MessageBox.Show("Already there", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                donnee.Add(new DataS(NomAct.Text));
                BaseEvent.Add(NomAct.Text);
            }

        }

        private void ButSave_Click(object sender, RoutedEventArgs e)
        {
            Stream stream = File.Open("data.xml", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, donnee);
            stream.Close();
        }

        private void ButRemove_Click(object sender, RoutedEventArgs e)
        {
            if (!BaseEvent.Contains(NomAct.Text))
                System.Windows.Forms.MessageBox.Show("Not there", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                BaseEvent.Remove(NomAct.Text);
                donnee.Remove(NomAct.Text);
            }

        }
        
        
        private void BaseEventCheck_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
            for (int x = 0; x < donnee.Base.Count; x++)
            {
                if (donnee.Base[x].Nom == (string)BaseEventCheck.SelectedItem)
                {
                    Actuel = donnee.Base[x];
                    StateEvent.Clear();
                    EventToDo.Clear();
                    for (int y = 0; y < Actuel.SousLevel.Count; y++)
                    {
                        EventToDo.Add(Actuel.SousLevel[y].Nom);
                    }

                    break;
                }
            }

        }

        private void ButRemoveEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!EventToDo.Contains(NomActEvent.Text))
                System.Windows.Forms.MessageBox.Show("Not there", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                EventToDo.Remove(NomActEvent.Text);
                Actuel.Remove(NomActEvent.Text);
            }
        }

        private void ButAddEvent_Click(object sender, RoutedEventArgs e)
        {

            if (EventToDo.Contains(NomActEvent.Text))
                System.Windows.Forms.MessageBox.Show("Already there", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Actuel.Add(new DataS(NomActEvent.Text));
                EventToDo.Add(NomActEvent.Text);
            }


        }

        private void ButRemoveState_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!StateEvent.Contains(NomActEvent.Text))
                    System.Windows.Forms.MessageBox.Show("Not there", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    StateEvent.Remove(NomActEvent.Text);
                    Final.Remove(NomActEvent.Text);
                }
            }
        }

        private void ButAddState_Click(object sender, RoutedEventArgs e)
        {
            if (StateEvent.Contains(NomActState.Text))
                System.Windows.Forms.MessageBox.Show("Already there", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Final.Add(new DataS(NomActState.Text));
                StateEvent.Add(NomActState.Text);
            }


        }

        private void SupEventCheck_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            for (int x = 0; x < Actuel.SousLevel.Count; x++)
            {
                if (Actuel.SousLevel[x].Nom == (string)SupEventCheck.SelectedItem)
                {
                    Final = Actuel.SousLevel[x];
                    string save = null;
                    if (StateCheckBox.SelectedIndex >= 0)
                        save = (string)StateCheckBox.SelectedItem;
                    StateEvent.Clear();
                    for (int y = 0; y < Final.SousLevel.Count; y++)
                    {
                        StateEvent.Add(Final.SousLevel[y].Nom);
                    }
                    for (int y = 0; y < Final.SousLevel.Count; y++)
                    {
                        if (save != null && Final.SousLevel[y].Nom == save)
                        {
                            StateCheckBox.SelectedIndex = y;
                        }
                    }

                    break;
                }

            }

        }

        private void ButOpenFolder_Click(object sender, RoutedEventArgs e)
        {

            FolderAsk rab = new FolderAsk(0, SourceFolder);
            rab.ShowDialog();
            SourceFolder = rab.keepstr;
            rab.Close();
            SFolderOk = Directory.Exists(SourceFolder);
            if (SFolderOk)
            {

                ListFile = Directory.GetFiles(SourceFolder);


                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@ListFile[0]);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                var imgBrush = new ImageBrush();


                Image1.Source = bitmap;
            }
        }

        private void ButOpenFolderDest_Click(object sender, RoutedEventArgs e)
        {
            FolderAsk rab = new FolderAsk(1, DestinationFolder);
            rab.ShowDialog();
            DestinationFolder = rab.keepstr;
            rab.Close();
        }

        private void ButRename_Click(object sender, RoutedEventArgs e)
        {
            if (DestinationFolder != null && Directory.Exists(DestinationFolder))
                if(SourceFolder != null )
                    Rename();
                else
                    System.Windows.Forms.MessageBox.Show("No image to rename", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                System.Windows.Forms.MessageBox.Show("Destionation folder is null or don't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // If unselected, StateCheckBox.SelectedIndex = -1 //BaseEventCheck SupEventCheck StateCheckBox
        }

        private bool Rename()
        {

            string newname;
            bool special = false;
            string extension;

            if (SFolderOk)
            {
                if (ListFile[file] == "Already Move")
                {
                    System.Windows.Forms.MessageBox.Show("Image already moved. Please go to next or choose another folder/image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                    extension = new FileInfo(ListFile[file]).Extension;
            }
            else
                extension = new FileInfo(SourceFolder).Extension;

            if (BaseEventCheck.SelectedIndex == -1)
            { System.Windows.Forms.MessageBox.Show("No base event", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            if (StateCheckBox.SelectedIndex == -1)
                if (SupEventCheck.SelectedIndex == -1)
                    newname = (string)BaseEventCheck.SelectedItem;
                else
                    newname = (string)BaseEventCheck.SelectedItem + " - " + (string)SupEventCheck.SelectedItem;
            else
            {
                if ((string)BaseEventCheck.SelectedItem == "Event")
                {
                    newname = (string)BaseEventCheck.SelectedItem + " - " + (string)SupEventCheck.SelectedItem + " - " + (string)StateCheckBox.SelectedItem;
                }
                else
                {
                    newname = (string)BaseEventCheck.SelectedItem + " - " + (string)SupEventCheck.SelectedItem + " (" + (string)StateCheckBox.SelectedItem;


                    special = true;
                }
               
            }
            int x = 1;
            if (special)
            {

                while (Directory.GetFiles(DestinationFolder, newname + " " + x + ")*").Length > 0)
                    x++;
                newname = newname + " " + x + ")";
            }
            else
            {

                while (Directory.GetFiles(DestinationFolder, newname + " " + x + "*").Length > 0)
                    x++;
                newname = newname + " " + x;
            }
            if (RadCp.IsChecked == true)
                if (SFolderOk)
                    File.Copy(ListFile[file], DestinationFolder + @"\" + newname + extension);
                else
                    File.Copy(SourceFolder, DestinationFolder + @"\" + newname + extension);
            else
            {


                Image1.Source = null;
                if (SFolderOk)
                { 
                    File.Move(ListFile[file], DestinationFolder + @"\" + newname + extension);
                    ListFile[file] = "Already Move";
                }
               
                else
                {
                    File.Move(SourceFolder, DestinationFolder + @"\" + newname + extension);
                    SourceFolder = null;
                }
            }




            return true;
        }
        private void ButNext_Click(object sender, RoutedEventArgs e)
        {
            if (SFolderOk)
                if (file < ListFile.Length)
                {
                    file++;
                    if(file == ListFile.Length)
                    { System.Windows.Forms.MessageBox.Show("You're not going trought a folder! -> Open Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                        
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

        private void ButUnselect_Click(object sender, RoutedEventArgs e)
        {
            StateCheckBox.SelectedIndex = -1;
        }

        private void ButNextRename_Click(object sender, RoutedEventArgs e)
        {
            if (SFolderOk)
                if (file < ListFile.Length)
                {
                    if (DestinationFolder != null && Directory.Exists(DestinationFolder))
                        if (SourceFolder != null)
                        { 
                            if(!Rename())
                            {
                                return;
                            }
                        }
                        else
                        { System.Windows.Forms.MessageBox.Show("No image to rename", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);return; }
                           
                    else
                    { System.Windows.Forms.MessageBox.Show("Destionation folder is null or don't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                     file++;
                    if (file == ListFile.Length)
                    { System.Windows.Forms.MessageBox.Show(" End of image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

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

        private void ButAbout_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsAboutOpen) { fen.Activate();return;};
            this.fen = new About();
            this.fen.ContentRendered += delegate { this.IsAboutOpen = true; };
            this.fen.Closed += delegate { this.IsAboutOpen = false; };
            this.fen.Show();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {


          MainGrid.Width = ActualWidth;
          MainGrid.Height = ActualHeight;


        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            
        }

        private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        
    }

}
