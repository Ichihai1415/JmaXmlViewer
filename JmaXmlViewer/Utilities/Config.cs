using static JmaXmlViewer.Utilities.CodesList;

namespace JmaXmlViewer.Utilities
{
    public class Config
    {
        public string Version { get; set; } = JmaXmlViewer.ControlForm.VERSION;

        public C_Enables Enables { get; set; } = new C_Enables();
        public class C_Enables
        {
            public Codes[] Detail { get; set; } = [];

            public Codes[] Bouyomi { get; set; } = [];

            public Codes[] Sound { get; set; } = [];

            public Codes[] Telop { get; set; } = [];

            public Codes[] Socket { get; set; } = [];

            public Codes[] WebSocket { get; set; } = [];
        }


        public C_Data Datas { get; set; } = new();

        public class C_Data
        {

        }
    }
}
