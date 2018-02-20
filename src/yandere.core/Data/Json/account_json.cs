using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    internal sealed class account_json
    {
        public string name { get; set; }
        public string[] blacklisted_tags { get; set; }
        public uint id { get; set; }
    }
}
