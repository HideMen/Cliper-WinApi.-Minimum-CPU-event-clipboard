using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClipboardHelper;

namespace Clip
{
    class Program
    {
        static void Main(string[] args)
        {
            ClipboardMonitor.OnClipboardChange += Clip;
            ClipboardMonitor.Start();
        }
        
        static void Clip(ClipboardFormat sormat, object data)
        {
            //Функция выполняется когда получаем событие о изменении буфера обмена

        }
    }
}
