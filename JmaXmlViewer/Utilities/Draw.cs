using static JmaXmlViewer.Utilities.Functions;
using static JmaXmlViewer.Utilities.Enums;

namespace JmaXmlViewer.Utilities
{
    internal class Draw
    {
        internal static Bitmap DrawData<T>(T data)
        {
            var bitmap = new Bitmap(1920, 1080);
            using var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(30, 60, 90));

            ExeLog("[DrawData<" + nameof(T) + ">] ", ConsoleColor.Green);





            return bitmap;
        }


        internal static Bitmap DrawMap<T>(T data, Bitmap bitmap, Config_Draw_Internal config)
        {
            using var graphics = Graphics.FromImage(bitmap);




            return bitmap;
        }
    }
}
