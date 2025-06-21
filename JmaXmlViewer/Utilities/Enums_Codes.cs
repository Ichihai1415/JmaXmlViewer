using System.ComponentModel;

namespace JmaXmlViewer.Utilities
{
    public partial class Enums
    {
        //https://xml.kishou.go.jp/xmllist.pdf
        //https://xml.kishou.go.jp/jmaxml_20250318_format_v1_3_hyo1_1.pdf


        /// <summary>
        /// データ種類コード一覧
        /// </summary>
        /// <remarks>
        /// 名前はデータ種類コード。複数あるものはすべて。<br/>
        /// XMLコメント、Descriptionは{[(XMLのみ補足があれば入る)]「気象庁防災情報XML一覧表」の資料（情報）名[(情報名と異なる場合)管理部：情報名称]}<br/>
        /// 数字は4または6桁で{フィード区分[定時=1,随時=2,地震火山=3,その他=4,HP上不公開、不明=9],「気象庁ホームページを通じて公開するXML電文一覧（2025/5/22現在）」
        /// におけるフィード別の順番[01~99],一覧の情報名の中の異なるもの[1~9](,複数コードあるもので、その番号[01~99])}
        /// ※気象警報・注意報（Ｒ０６）については、暫定としてVPWWiiと複数コード(仮)にする。集約通報(VPWS50)もそのまま50とする。
        /// </remarks>
        public enum Codes
        {
            /// <summary>
            /// [未設定]
            /// </summary>
            [Description("[未設定]")]
            Null = -1,


            /// <summary>
            /// 天気概況[府県天気概況]
            /// </summary>
            [Description("天気概況[府県天気概況]")]
            VPFG50 = 1011,

            /// <summary>
            /// [廃止済み？]府県天気予報／地域時系列予報[府県天気予報]
            /// </summary>
            [Description("府県天気予報／地域時系列予報[府県天気予報]")]
            VPFD50 = 1021,

            /// <summary>
            /// 府県天気予報／地域時系列予報[府県天気予報（Ｒ１）]
            /// </summary>
            [Description("府県天気予報／地域時系列予報[府県天気予報（Ｒ１）]")]
            VPFD51 = 1022,

            /// <summary>
            /// [廃止済み？]全般週間天気予報
            /// </summary>
            [Description("全般週間天気予報")]
            VPZW50 = 1031,

            /// <summary>
            /// [廃止済み？]地方週間天気予報
            /// </summary>
            [Description("地方週間天気予報")]
            VPCW50 = 1041,

            /// <summary>
            /// 府県週間天気予報
            /// </summary>
            [Description("府県週間天気予報")]
            VPFW50 = 1051,

            /// <summary>
            /// 全般季節予報[全般季節予報（2週間気温予報）]
            /// </summary>
            [Description("全般季節予報[全般季節予報（2週間気温予報）]")]
            VPZK50 = 1061,

            /// <summary>
            /// 地方季節予報[地方季節予報（2週間気温予報）]
            /// </summary>
            [Description("地方季節予報[地方季節予報（2週間気温予報）]")]
            VPCK50 = 1071,

            /// <summary>
            /// 警報級の可能性（明日まで）
            /// </summary>
            [Description("警報級の可能性（明日まで）")]
            VPFD60 = 1081,

            /// <summary>
            /// 警報級の可能性（明後日以降）
            /// </summary>
            [Description("警報級の可能性（明後日以降）")]
            VPFW60 = 1091,

            /// <summary>
            /// 地上実況図
            /// </summary>
            [Description("地上実況図")]
            VZSA50 = 1101,

            /// <summary>
            /// 地上２４時間予想図
            /// </summary>
            [Description("地上２４時間予想図")]
            VZSF50 = 1111,

            /// <summary>
            /// 地上４８時間予想図
            /// </summary>
            [Description("地上４８時間予想図")]
            VZSF51 = 1121,

            /// <summary>
            /// アジア太平洋地上実況図
            /// </summary>
            [Description("アジア太平洋地上実況図")]
            VZSA60 = 1131,

            /// <summary>
            /// アジア太平洋海上悪天24時間予想図
            /// </summary>
            [Description("アジア太平洋海上悪天24時間予想図")]
            VZSF60 = 1141,

            /// <summary>
            /// アジア太平洋海上悪天48時間予想図
            /// </summary>
            [Description("アジア太平洋海上悪天48時間予想図")]
            VZSF61 = 1151,

            /// <summary>
            /// 全般２週間気温予報[全般季節予報（2週間気温予報）]
            /// </summary>
            [Description("全般2週間気温予報[全般季節予報（2週間気温予報）]")]
            VPZK70 = 1161,

            /// <summary>
            /// 地方2週間気温予報[地方季節予報（2週間気温予報）]
            /// </summary>
            [Description("地方2週間気温予報[地方季節予報（2週間気温予報）]")]
            VPCK70 = 1171,

            /// <summary>
            /// 大雨危険度通知
            /// </summary>
            [Description("大雨危険度通知")]
            VPRN50 = 1181,


            /// <summary>
            /// 全般台風情報（総合情報、上陸等情報）[全般台風情報]
            /// </summary>
            [Description("全般台風情報（総合情報、上陸等情報）[全般台風情報]")]
            VPTI50 = 2011,

            /// <summary>
            /// 全般台風情報（位置、発生情報）、発達する熱帯低気圧に関する情報[全般台風情報（定型）]
            /// </summary>
            [Description("全般台風情報（位置、発生情報）、発達する熱帯低気圧に関する情報[全般台風情報（定型）]")]
            VPTI51 = 2021,

            /// <summary>
            /// 全般台風情報（位置詳細）[全般台風情報（詳細）]
            /// </summary>
            [Description("全般台風情報（位置詳細）[全般台風情報（詳細）]")]
            VPTI52 = 2031,

            /// <summary>
            /// [共通][廃止済み][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]")]
            VPTWii2 = 2041,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]")]
            VPTW50 = 204150,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]")]
            VPTW51 = 204151,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]")]
            VPTW52 = 204152,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]")]
            VPTW53 = 204153,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]")]
            VPTW54 = 204154,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）]")]
            VPTW55 = 204155,

            /// <summary>
            /// [共通][複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]")]
            VPTWii3 = 2042,

            /// <summary>
            /// [複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]")]
            VPTW60 = 204260,

            /// <summary>
            /// [複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]")]
            VPTW61 = 204261,

            /// <summary>
            /// [複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]")]
            VPTW62 = 204262,

            /// <summary>
            /// [複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]")]
            VPTW63 = 204263,

            /// <summary>
            /// [複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]")]
            VPTW64 = 204264,

            /// <summary>
            /// [複数コード]台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]
            /// </summary>
            [Description("台風解析・予報情報（延長予報）電文（新形式）[台風解析・予報情報（５日予報）（Ｈ３０）]")]
            VPTW65 = 204265,

            /// <summary>
            /// [共通][複数コード]台風の暴風域に入る確率
            /// </summary>
            [Description("台風の暴風域に入る確率")]
            VPTAii = 2051,

            /// <summary>
            /// [複数コード]台風の暴風域に入る確率
            /// </summary>
            [Description("台風の暴風域に入る確率")]
            VPTA50 = 205150,

            /// <summary>
            /// [複数コード]台風の暴風域に入る確率
            /// </summary>
            [Description("台風の暴風域に入る確率")]
            VPTA51 = 205151,

            /// <summary>
            /// [複数コード]台風の暴風域に入る確率
            /// </summary>
            [Description("台風の暴風域に入る確率")]
            VPTA52 = 205152,

            /// <summary>
            /// [複数コード]台風の暴風域に入る確率
            /// </summary>
            [Description("台風の暴風域に入る確率")]
            VPTA53 = 205153,

            /// <summary>
            /// [複数コード]台風の暴風域に入る確率
            /// </summary>
            [Description("台風の暴風域に入る確率")]
            VPTA54 = 205154,

            /// <summary>
            /// [複数コード]台風の暴風域に入る確率
            /// </summary>
            [Description("台風の暴風域に入る確率")]
            VPTA55 = 205155,

            /// <summary>
            /// [廃止済み]気象特別警報・警報・注意報[気象警報・注意報]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報]")]
            VPWW50 = 2061,

            /// <summary>
            /// 気象特別警報・警報・注意報
            /// </summary>
            [Description("気象特別警報・警報・注意報")]
            VPWW53 = 2062,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｈ２７）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｈ２７）]")]
            VPWW54 = 2063,

            /// <summary>
            /// [複数コード(仮)]気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（大雨）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）]")]//R8~予定
            VPWWii = 2064,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（大雨）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（大雨）]")]//R8~予定
            VPWW55 = 206455,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（土砂）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（土砂）]")]//R8~予定
            VPWW56 = 206456,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（高潮）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（高潮）]")]//R8~予定
            VPWW57 = 206457,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（暴風）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（暴風）]")]//R8~予定
            VPWW58 = 206458,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（波浪）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（波浪）]")]//R8~予定
            VPWW59 = 206459,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（大雪）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（大雪）]")]//R8~予定
            VPWW60 = 206460,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（その他注意報）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（その他注意報）]")]//R8~予定
            VPWW61 = 206461,

            /// <summary>
            /// 気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（集約通報）]
            /// </summary>
            [Description("気象特別警報・警報・注意報[気象警報・注意報（Ｒ０６）（集約通報）]")]//R8~予定
            VPWS50 = 206450,

            /// <summary>
            /// 気象特別警報報知
            /// </summary>
            [Description("気象特別警報報知")]
            VPNO50 = 2071,

            /// <summary>
            /// [共通][複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKOii = 2081,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO50 = 208150,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO51 = 208151,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO52 = 208152,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO53 = 208153,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO54 = 208154,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO55 = 208155,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO56 = 208156,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO57 = 208157,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO58 = 208158,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO59 = 208159,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO60 = 208160,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO61 = 208161,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO62 = 208162,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO63 = 208163,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO64 = 208164,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO65 = 208165,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO66 = 208166,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO67 = 208167,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO68 = 208168,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO69 = 208169,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO70 = 208170,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO71 = 208171,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO72 = 208172,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO73 = 208173,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO74 = 208174,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO75 = 208175,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO76 = 208176,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO77 = 208177,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO78 = 208178,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO79 = 208179,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO80 = 208180,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO81 = 208181,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO82 = 208182,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO83 = 208183,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO84 = 208184,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO85 = 208185,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO86 = 208186,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO87 = 208187,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO88 = 208188,

            /// <summary>
            /// [複数コード]指定河川洪水予報
            /// </summary>
            [Description("指定河川洪水予報")]
            VXKO89 = 208189,

            /// <summary>
            /// 土砂災害警戒情報
            /// </summary>
            [Description("土砂災害警戒情報")]
            VXWW50 = 2091,

            /// <summary>
            /// 記録的短時間大雨情報
            /// </summary>
            [Description("記録的短時間大雨情報")]
            VPOA50 = 2101,

            /// <summary>
            /// 竜巻注意情報
            /// </summary>
            [Description("竜巻注意情報")]
            VPHW50 = 2111,

            /// <summary>
            /// 竜巻注意情報[竜巻注意情報（目撃情報付き）]
            /// </summary>
            [Description("竜巻注意情報[竜巻注意情報（目撃情報付き）]")]
            VPHW51 = 2112,

            /// <summary>
            /// 全般気象情報
            /// </summary>
            [Description("全般気象情報")]
            VPZJ50 = 2121,

            /// <summary>
            /// 地方気象情報
            /// </summary>
            [Description("地方気象情報")]
            VPCJ50 = 2131,

            /// <summary>
            /// 府県気象情報
            /// </summary>
            [Description("府県気象情報")]
            VPFJ50 = 2141,

            /// <summary>
            /// 全般気象情報（社会的に影響の大きい天候に関する情報）[全般天候情報]
            /// </summary>
            [Description("全般気象情報（社会的に影響の大きい天候に関する情報）[全般天候情報]")]
            VPZI50 = 2151,

            /// <summary>
            /// 地方気象情報（社会的に影響の大きい天候に関する情報）[地方天候情報]
            /// </summary>
            [Description("地方気象情報（社会的に影響の大きい天候に関する情報）[地方天候情報]")]
            VPCI50 = 2161,

            /// <summary>
            /// 熱中症警戒アラート
            /// </summary>
            [Description("熱中症警戒アラート")]
            VPFT50 = 2171,

            /// <summary>
            /// 早期天候情報
            /// </summary>
            [Description("早期天候情報")]
            VPAW51 = 2181,


            /// <summary>
            /// 震度速報
            /// </summary>
            [Description("震度速報")]
            VXSE51 = 3011,

            /// <summary>
            /// 地震情報（震源に関する情報）[震源に関する情報]
            /// </summary>
            [Description("地震情報（震源に関する情報）[震源に関する情報]")]
            VXSE52 = 3021,

            /// <summary>
            /// 地震情報（震源・震度に関する情報）[震源・震度に関する情報]
            /// </summary>
            [Description("地震情報（震源・震度に関する情報）[震源・震度に関する情報]")]
            VXSE53 = 3031,

            /// <summary>
            /// 地震情報（地震の活動状況等に関する情報）[地震の活動状況等に関する情報]
            /// </summary>
            [Description("地震情報（地震の活動状況等に関する情報）[地震の活動状況等に関する情報]")]
            VXSE56 = 3041,

            /// <summary>
            /// 地震情報（地震回数に関する情報）[地震回数に関する情報]
            /// </summary>
            [Description("地震情報（地震回数に関する情報）[地震回数に関する情報]")]
            VXSE60 = 3051,

            /// <summary>
            /// 地震情報（顕著な地震の震源要素更新のお知らせ）[顕著な地震の震源要素更新のお知らせ]
            /// </summary>
            [Description("地震情報（顕著な地震の震源要素更新のお知らせ）[顕著な地震の震源要素更新のお知らせ]")]
            VXSE61 = 3061,

            /// <summary>
            /// 長周期地震動に関する観測情報
            /// </summary>
            [Description("長周期地震動に関する観測情報 ")]
            VXSE62 = 3071,

            /// <summary>
            /// 津波警報・注意報・予報[津波警報・注意報・予報a]
            /// </summary>
            [Description("津波警報・注意報・予報[津波警報・注意報・予報a]")]
            VTSE41 = 3081,

            /// <summary>
            /// 津波情報[津波情報a]
            /// </summary>
            [Description("津波情報[津波情報a]")]
            VTSE51 = 3091,

            /// <summary>
            /// 沖合の津波観測に関する情報
            /// </summary>
            [Description("沖合の津波観測に関する情報")]
            VTSE52 = 3101,

            /// <summary>
            /// 南海トラフ地震臨時情報
            /// </summary>
            [Description("南海トラフ地震臨時情報")]
            VYSE50 = 3111,

            /// <summary>
            /// [共通][複数コード]南海トラフ地震関連解説情報
            /// </summary>
            /// <remarks>このiiは非公式表記。51と52について:<see href="https://www.data.jma.go.jp/suishin/jyouhou/pdf/526.pdf">配信資料に関する技術情報第526号 ～ 新たな形式の電文による「南海トラフ地震臨時情報」及び「南海トラフ地震関連解説情報」の配信について ～</see></remarks>
            [Description("南海トラフ地震関連解説情報")]
            VYSEii = 3121,

            /// <summary>
            /// [複数コード]南海トラフ地震関連解説情報
            /// </summary>
            /// <remarks>観測された異常な現象の調査結果を発表した後の状況等を発表する場合の情報（定例以外の解説情報）</remarks>
            [Description("南海トラフ地震関連解説情報")]
            VYSE51 = 312151,

            /// <summary>
            /// [複数コード]南海トラフ地震関連解説情報
            /// </summary>
            /// <remarks>南海トラフ沿いの地震に関する評価検討会」の定例会合における調査結果を発表する場合の情報（定例の解説情報）</remarks>
            [Description("南海トラフ地震関連解説情報")]
            VYSE52 = 312152,

            /// <summary>
            /// 噴火警報・予報
            /// </summary>
            [Description("噴火警報・予報")]
            VFVO50 = 3131,

            /// <summary>
            /// 火山の状況に関する解説情報
            /// </summary>
            [Description("火山の状況に関する解説情報")]
            VFVO51 = 3141,

            /// <summary>
            /// 噴火に関する火山観測報
            /// </summary>
            [Description("噴火に関する火山観測報")]
            VFVO52 = 3151,

            /// <summary>
            /// 降灰予報[降灰予報（定時）]
            /// </summary>
            [Description("降灰予報[降灰予報（定時）]")]
            VFVO53 = 3161,

            /// <summary>
            /// 降灰予報[降灰予報（速報）]
            /// </summary>
            [Description("降灰予報[降灰予報（速報）]")]
            VFVO54 = 3162,

            /// <summary>
            /// 降灰予報[降灰予報（詳細）]
            /// </summary>
            [Description("降灰予報[降灰予報（詳細）]")]
            VFVO55 = 3163,

            /// <summary>
            /// 噴火速報
            /// </summary>
            [Description("噴火速報")]
            VFVO56 = 3171,

            /// <summary>
            /// 推定噴煙流向報
            /// </summary>
            [Description("推定噴煙流向報")]
            VFVO60 = 3181,

            /// <summary>
            /// 北海道・三陸沖後発地震注意情報
            /// </summary>
            [Description("北海道・三陸沖後発地震注意情報")]
            VYSE60 = 3191,


            /// <summary>
            /// 特殊気象報[季節観測]
            /// </summary>
            [Description("特殊気象報[季節観測]")]
            VGSK50 = 4011,

            /// <summary>
            /// 特殊気象報（トクシユ）[特殊気象報]
            /// </summary>
            [Description("特殊気象報（トクシユ）[特殊気象報]")]
            VGSK60 = 4021,

            /// <summary>
            /// 生物季節観測報告気象報[生物季節観測]
            /// </summary>
            [Description("生物季節観測報告気象報[生物季節観測]")]
            VGSK55 = 4031,

            /// <summary>
            /// [廃止済み]全般海上警報（定時）
            /// </summary>
            [Description("全般海上警報（定時）")]
            VPZU50 = 4041,

            /// <summary>
            /// 全般海上警報（定時）（Ｈ２９）
            /// </summary>
            [Description("全般海上警報（定時）（Ｈ２９）")]
            VPZU52 = 4042,

            /// <summary>
            /// [廃止済み]全般海上警報（臨時）
            /// </summary>
            [Description("全般海上警報（臨時）")]
            VPZU51 = 4051,

            /// <summary>
            /// 全般海上警報（臨時）（Ｈ２９）
            /// </summary>
            [Description("全般海上警報（臨時）（Ｈ２９）")]
            VPZU53 = 4052,

            /// <summary>
            /// [廃止済み]地方海上警報
            /// </summary>
            [Description("地方海上警報")]
            VPCU50 = 4061,

            /// <summary>
            /// 地方海上警報（Ｈ２８）
            /// </summary>
            [Description("地方海上警報（Ｈ２８）")]
            VPCU51 = 4062,

            /// <summary>
            /// [廃止済み]地方海上予報
            /// </summary>
            [Description("地方海上予報")]
            VPCY50 = 4071,

            /// <summary>
            /// 地方海上予報（Ｈ２８）
            /// </summary>
            [Description("地方海上予報（Ｈ２８）")]
            VPCY51 = 4072,

            /// <summary>
            /// [共通][複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSVii = 4081,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV50 = 408150,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV51 = 408151,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV52 = 408152,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV53 = 408153,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV54 = 408154,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV55 = 408155,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV56 = 408156,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV57 = 408157,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV58 = 408158,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV59 = 408159,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV60 = 408160,

            /// <summary>
            /// [複数コード]火山現象に関する海上警報・海上予報
            /// </summary>
            [Description("火山現象に関する海上警報・海上予報")]
            VFSV61 = 408161,

            /// <summary>
            /// 全般潮位情報
            /// </summary>
            [Description("全般潮位情報")]
            VMCJ50 = 4091,

            /// <summary>
            /// 地方潮位情報
            /// </summary>
            [Description("地方潮位情報")]
            VMCJ51 = 4101,

            /// <summary>
            /// 府県潮位情報
            /// </summary>
            [Description("府県潮位情報")]
            VMCJ52 = 4111,



            /// <summary>
            /// [共通][廃止済み][複数コード]台風解析・予報情報（３日予報）
            /// </summary>
            [Description("台風解析・予報情報電文（新形式）[台風解析・予報情報（３日予報）]")]
            VPTWii = 9011,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（３日予報）
            /// </summary>
            [Description("台風解析・予報情報電文（新形式）[台風解析・予報情報（３日予報）]")]
            VPTW40 = 901140,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（３日予報）
            /// </summary>
            [Description("台風解析・予報情報電文（新形式）[台風解析・予報情報（３日予報）]")]
            VPTW41 = 901141,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（３日予報）
            /// </summary>
            [Description("台風解析・予報情報電文（新形式）[台風解析・予報情報（３日予報）]")]
            VPTW42 = 901142,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（３日予報）
            /// </summary>
            [Description("台風解析・予報情報電文（新形式）[台風解析・予報情報（３日予報）]")]
            VPTW43 = 901143,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（３日予報）
            /// </summary>
            [Description("台風解析・予報情報電文（新形式）[台風解析・予報情報（３日予報）]")]
            VPTW44 = 901144,

            /// <summary>
            /// [廃止済み][複数コード]台風解析・予報情報（３日予報）
            /// </summary>
            [Description("台風解析・予報情報電文（新形式）[台風解析・予報情報（３日予報）]")]
            VPTW45 = 901145,

            /// <summary>
            /// [HP上で公開無し？]府県天候情報
            /// </summary>
            [Description("府県天候情報")]
            VPFI50 = 9012,

            /// <summary>
            /// [HP上で公開無し]緊急地震速報（予報）
            /// </summary>
            [Description("緊急地震速報（予報）")]
            VXSE44 = 9021,

            /// <summary>
            /// [HP上で公開無し]緊急地震速報（警報）
            /// </summary>
            [Description("緊急地震速報（警報）")]
            VXSE43 = 9031,

            /// <summary>
            /// [HP上で公開無し？]地震・津波に関するお知らせ
            /// </summary>
            [Description("地震・津波に関するお知らせ")]
            VZSE40 = 9041,

            /// <summary>
            /// [HP上で公開無し？]火山に関するお知らせ
            /// </summary>
            [Description("火山に関するお知らせ")]
            VZVO40 = 9051,

            /// <summary>
            /// 異常天候早期警戒情報
            /// </summary>
            [Description("異常天候早期警戒情報")]
            VPAW50 = 9061,

            /// <summary>
            /// 緊急地震速報配信テスト
            /// </summary>
            [Description("緊急地震速報配信テスト")]
            VXSE42 = 9071,

            /// <summary>
            /// 緊急地震速報（地震動予報）（新形式）[緊急地震速報（地震動予報）]
            /// </summary>
            [Description("緊急地震速報（地震動予報）（新形式）[緊急地震速報（地震動予報）]")]
            VXSE45 = 9081,

            /// <summary>
            /// 警戒・注意事項時系列情報気象警報・注意報時系列情報（Ｒ０６）]
            /// </summary>
            [Description("警戒・注意事項時系列情報[気象警報・注意報時系列情報（Ｒ０６）]")]//R8以降
            VPWP50 = 9091,

            /// <summary>
            /// 府県気象防災速報
            /// </summary>
            [Description("府県気象防災速報")]//R8以降
            VPBS50 = 9101,

            /// <summary>
            /// 全般気象解説情報
            /// </summary>
            [Description("全般気象解説情報")]//R8以降
            VPZJ51 = 9111,

            /// <summary>
            /// 地方気象解説情報
            /// </summary>
            [Description("地方気象解説情報")]//R8以降
            VPCJ51 = 9121,

            /// <summary>
            /// 府県気象解説情報
            /// </summary>
            [Description("府県気象解説情報")]//R8以降
            VPFJ51 = 9131,

            /// <summary>
            /// 気象防災速報（潮位）[府県気象防災速報（潮位）]
            /// </summary>
            [Description("気象防災速報（潮位）[府県気象防災速報（潮位）]")]//R8以降
            VPBS51 = 9141,

            /// <summary>
            /// 全般気象解説情報（潮位）
            /// </summary>
            [Description("全般気象解説情報（潮位）")]//R8以降
            VMCJ53 = 9151,

            /// <summary>
            /// 地方気象解説情報（潮位）
            /// </summary>
            [Description("地方気象解説情報（潮位）")]//R8以降
            VMCJ54 = 9161,

            /// <summary>
            /// 府県気象解説情報（潮位）
            /// </summary>
            [Description("府県気象解説情報（潮位）")]//R8以降
            VMCJ55 = 9171,

            /// <summary>
            /// 早期注意情報（明後日まで）
            /// </summary>
            [Description("早期注意情報（明後日まで）")]//R8以降
            VPFD61 = 9181,

            /// <summary>
            /// [共通][複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSUii = 9191,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU50 = 919150,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU51 = 919151,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU52 = 919152,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU53 = 919153,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU54 = 919154,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU55 = 919155,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU56 = 919156,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU57 = 919157,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU58 = 919158,

            /// <summary>
            /// [複数コード]水位周知河川に関する情報
            /// </summary>
            [Description("水位周知河川に関する情報")]//R8以降
            VXSU59 = 919159
        }
    }
}