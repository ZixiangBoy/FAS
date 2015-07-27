using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Ultra.Common
{
    [Serializable]
    public class T_ProdTemp
    {
        public string OuterId { get; set; }
        public string SkuOuterId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessGuid { get; set; }
        public string ListSequence { get; set; }
    }

    [Serializable]
    public class UpProcess
    {
        public string Sequence { get; set; }
    }
}
