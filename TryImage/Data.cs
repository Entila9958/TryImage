using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryImage
{

    [Serializable()]
    public class Data
    {
        private List<DataS> @base;

        public Data()
        {
            Base = new List<DataS>();
        }

        public List<DataS> Base { get => @base; set => @base = value; }

        public void  Add(DataS dataS)
        {
            Base.Add(dataS);
            
        }

   
        public void Remove(string StrToRm)
        {
             for(int x=0;x<Base.Count();x++)
            {
                if (Base[x].Nom == StrToRm)
                { 
                    Base.Remove(Base[x]);
                    break;
                }
            }
        }
    }
}
