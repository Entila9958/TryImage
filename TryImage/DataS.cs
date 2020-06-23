using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryImage
{
    [Serializable()]
    public class DataS
    {
        private string nom;
        public List<DataS> SousLevel;

        public DataS()
        {
            Nom = "";
            SousLevel = new List<DataS>();
        }
        public DataS(string name)
        {
            Nom = name;
            SousLevel = new List<DataS>();
        }
        public void Remove(string StrToRm)
        {
            for (int x = 0; x < SousLevel.Count(); x++)
            {
                if (SousLevel[x].Nom == StrToRm)
                {
                    SousLevel.Remove(SousLevel[x]);
                    break;
                }
            }
        }
        public void Add(DataS dataS)
        {
            SousLevel.Add(dataS);

        }
        public string Nom { get => nom; set => nom = value; }
    }
}
