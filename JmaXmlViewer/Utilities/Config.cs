using System.Runtime.CompilerServices;
using static JmaXmlViewer.Utilities.Enums;

namespace JmaXmlViewer.Utilities
{
    public class Config
    {
        public string Version { get; set; } = ControlForm.VERSION;

        /// <summary>
        /// 毎回マップデータを読み込むか
        /// </summary>
        /// <remarks><see cref="false"/>の場合初回ですべて読み込むためメモリ使用量が多くなりますが処理は早くなります。</remarks>
        public bool MapLoadEachTime { get; set; } = true;

        /// <summary>
        /// 毎回マップデータをアンロードするか
        /// </summary>
        /// <remarks><see cref="true"/>にする場合<see cref="MapLoadEachTime"/>も<see cref="true"/>にすることを推奨します。</remarks>
        public bool MapUnloadEachTime { get; set; } = false;

        public bool Enable_AntiAlias { get; set; } = true;

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

    public class Config_Draw_Internal//内部のみ使用
    {
        public required int Width { get; set; }
        public required int Height { get; set; }

        public required float LatSta { get; set; }
        public required float LonSta { get; set; }
        public required float LatEnd { get; set; }
        public required float LonEnd { get; set; }

        public required float Zoom { get; set; }

        public required MapType MapType { get; set; }

        public required Dictionary<string, Color> DrawCodeColor_Fill { get; set; }
        public required Color DefaultColor_Fill { get; set; }

        public required Dictionary<string, Color> DrawCodeColor_Line { get; set; }
        public required Color DefaultColor_Line { get; set; }

        public required float LineWidth { get; set; }

    }
}
