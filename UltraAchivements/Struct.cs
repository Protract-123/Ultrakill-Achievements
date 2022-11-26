using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ultrakill_Achivements.UltraAchivements
{
    public struct AchStruct
    {
        public AchStruct(string name, string description, string mod)
        {

            achName = name;
            achDescrip = description;
            achMod = mod;
        }
        public string achName;
        public string achDescrip;
        public string achMod; 

    }
}
