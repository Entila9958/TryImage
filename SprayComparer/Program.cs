using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vtf = Directory.GetFiles(@"F:\Steam\steamapps\common\Team Fortress 2\tf\materials\vgui\logos", "*.vtf");
            string[] vmt = Directory.GetFiles(@"F:\Steam\steamapps\common\Team Fortress 2\tf\materials\vgui\logos", "*.vmt");
            for (int i = 0; i < vmt.Length; i++)
            {
                vmt[i] = Path.GetFileNameWithoutExtension(vmt[i]);
            }
            Console.WriteLine("Nbr VTF : {0}, Nbr VMT {1}", vtf.Length, vmt.Length);
            foreach(string btfe in vtf)
            {
                if (vmt.Contains(Path.GetFileNameWithoutExtension(btfe)) == false)
                {
                    StreamWriter ecriture = File.CreateText(@"F:\Steam\steamapps\common\Team Fortress 2\tf\materials\vgui\logos\" + Path.GetFileNameWithoutExtension(btfe) + ".vmt");
                    ecriture.WriteLine("\"UnlitGeneric\"");
                    ecriture.WriteLine("{");
                    ecriture.WriteLine("\"$basetexture\" \"" + @"vgui\logos\{0}\"+"\"" );
                    ecriture.WriteLine("\"$translucent\"   \"1\"");
                    ecriture.WriteLine("\"ignorez\"   \"1\"");
                    ecriture.WriteLine("\"vertexcolor\"   \"1\"");

                    Console.WriteLine("Created :" + @"F:\Steam\steamapps\common\Team Fortress 2\tf\materials\vgui\logos\" + Path.GetFileNameWithoutExtension(btfe) + ".vmt");

                }
            }
            Console.ReadLine();

            
        }

        public static  void AssignmentAction(string x, string y)
        {
            x = y;
        }
    }
}
