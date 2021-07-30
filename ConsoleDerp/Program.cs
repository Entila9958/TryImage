using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace ConsoleDerp
{
    class Program
    {
        static void Main(string[] args)
        {

            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\alexi\Desktop\Objector",
                Filter = "Image Files|*.png;*.jpg;*.jpeg",
                Multiselect = true
            };
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string a in open.FileNames)
                {
                    Directory.CreateDirectory(@"F:\Steam\steamapps\common\Team Fortress 2\tf\custom\" + System.IO.Path.GetFileNameWithoutExtension(a) + @"\scripts\items\custom_texture_blend_layers");
                    File.Move(a, @"F:\Steam\steamapps\common\Team Fortress 2\tf\custom\" + System.IO.Path.GetFileNameWithoutExtension(a) + @"\scripts\items\custom_texture_blend_layers\paper_overlay.png");
                }




            }
        }
    }
}
