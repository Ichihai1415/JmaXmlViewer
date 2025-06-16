using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JmaXmlViewer.Utilities.CodesList;

namespace JmaXmlViewer.Utilities
{
    public class Config
    {


        public class C_Datas
        {
            public C_Data[] Datas { get; set; } = [];

            public class C_Data
            {
                public Codes Codes { get; set; } = Codes.None;

                public bool IsEnable { get; set; } = true;

                public bool IsGetDetail { get; set; } = true;

            }
        }
    }
}
