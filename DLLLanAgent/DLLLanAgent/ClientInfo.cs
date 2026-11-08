using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DLLLanAgent
{
    [Serializable]
    public class ClientInfo
    {
        public string UserName, NetName;
        public IPAddress[] IPAddrs;
        public DriveInfo[] AllDrives;//массив логических дисков 
        public List<string> Proc = new List<string>();
        public Image Scr;
        public DateTime DtReport;
    }
}
