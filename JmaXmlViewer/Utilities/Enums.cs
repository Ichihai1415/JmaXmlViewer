namespace JmaXmlViewer.Utilities
{
    public partial class Enums
    {
        /// <summary>
        /// マップの種類
        /// </summary>
        /// <remarks>名前の数字はJSON化データのmapshaper簡素化率、enumの数字は2~3桁で{アルファベット順[1~15],簡素化率[1(0.1%),2(1%)]}</remarks>
        public enum MapType
        {
            /// <summary>
            /// 全国・地方予報区[簡素化率0.1%]
            /// </summary>
            AreaForecast_01 = 11,

            /// <summary>
            /// 全国・地方予報区[簡素化率1%]
            /// </summary>
            AreaForecast_1 = 12,

            /// <summary>
            /// 緊急地震速報／地方予報区[簡素化率0.1%]
            /// </summary>
            AreaForecastEEW_01 = 21,

            /// <summary>
            /// 緊急地震速報／地方予報区[簡素化率1%]
            /// </summary>
            AreaForecastEEW_1 = 22,

            /// <summary>
            /// 地震情報／細分区域[簡素化率0.1%]
            /// </summary>
            AreaForecastLocalE_01 = 31,

            /// <summary>
            /// 地震情報／細分区域[簡素化率1%]
            /// </summary>
            AreaForecastLocalE_1 = 32,

            /// <summary>
            /// 緊急地震速報／府県予報区[簡素化率0.1%]
            /// </summary>
            AreaForecastLocalEEW_01 = 41,

            /// <summary>
            /// 緊急地震速報／府県予報区[簡素化率1%]
            /// </summary>
            AreaForecastLocalEEW_1 = 42,

            /// <summary>
            /// 一次細分区域等[簡素化率0.1%]
            /// </summary>
            AreaForecastLocalM_1saibun_01 = 51,

            /// <summary>
            /// 一次細分区域等[簡素化率1%]
            /// </summary>
            AreaForecastLocalM_1saibun_1 = 52,

            /// <summary>
            /// 市町村等をまとめた地域等[簡素化率0.1%]
            /// </summary>
            AreaForecastLocalM_matome_01 = 61,

            /// <summary>
            /// 市町村等をまとめた地域等[簡素化率1%]
            /// </summary>
            AreaForecastLocalM_matome_1 = 62,

            /// <summary>
            /// 府県予報区等[簡素化率0.1%]
            /// </summary>
            AreaForecastLocalM_prefecture_01 = 71,

            /// <summary>
            /// 府県予報区等[簡素化率1%]
            /// </summary>
            AreaForecastLocalM_prefecture_1 = 72,

            /// <summary>
            /// 市町村等（土砂災害警戒情報）[簡素化率0.1%]
            /// </summary>
            AreaInformationCity_landslide_01 = 81,

            /// <summary>
            /// 市町村等（土砂災害警戒情報）[簡素化率1%]
            /// </summary>
            AreaInformationCity_landslide_1 = 82,

            /// <summary>
            /// 市町村等（地震津波関係）[簡素化率0.1%]
            /// </summary>
            AreaInformationCity_quake_01 = 91,

            /// <summary>
            /// 市町村等（地震津波関係）[簡素化率1%]
            /// </summary>
            AreaInformationCity_quake_1 = 92,

            /// <summary>
            /// 市町村等（大雨危険度）[簡素化率0.1%]
            /// </summary>
            AreaInformationCity_risk_01 = 101,

            /// <summary>
            /// 市町村等（大雨危険度）[簡素化率1%]
            /// </summary>
            AreaInformationCity_risk_1 = 102,

            /// <summary>
            /// 市町村等（指定河川洪水予報）[簡素化率0.1%]
            /// </summary>
            AreaInformationCity_river_01 = 111,

            /// <summary>
            /// 市町村等（指定河川洪水予報）[簡素化率1%]
            /// </summary>
            AreaInformationCity_river_1 = 112,

            /// <summary>
            /// 市町村等（火山関係）[簡素化率0.1%]
            /// </summary>
            AreaInformationCity_volcano_01 = 121,

            /// <summary>
            /// 市町村等（火山関係）[簡素化率1%]
            /// </summary>
            AreaInformationCity_volcano_1 = 122,

            /// <summary>
            /// 市町村等（気象警報等）[簡素化率0.1%]
            /// </summary>
            AreaInformationCity_weather_01 = 131,

            /// <summary>
            /// 市町村等（気象警報等）[簡素化率1%]
            /// </summary>
            AreaInformationCity_weather_1 = 132,

            /// <summary>
            /// 地震情報／都道府県等[簡素化率0.1%]
            /// </summary>
            AreaInformationPrefectureEarthquake_01 = 141,

            /// <summary>
            /// 地震情報／都道府県等[簡素化率1%]
            /// </summary>
            AreaInformationPrefectureEarthquake_1 = 142,

            /// <summary>
            /// 地方海上予報区[簡素化率0.1%]
            /// </summary>
            AreaMarineAJ_01 = 151,

            /// <summary>
            /// 地方海上予報区[簡素化率1%]
            /// </summary>
            AreaMarineAJ_1 = 152,

            /// <summary>
            /// 津波予報区[簡素化率0.1%]
            /// </summary>
            AreaTsunami_01 = 161,

            /// <summary>
            /// 津波予報区[簡素化率1%]
            /// </summary>
            AreaTsunami_1 = 162
        }
    }
}
