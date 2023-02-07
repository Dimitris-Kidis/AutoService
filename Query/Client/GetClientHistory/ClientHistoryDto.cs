using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Client.GetClientHistory
{
    public class ClientHistoryDto
    {
        public string CarInfo { get; set; }
        public string Services { get; set; }
        public string MasterName { get; set; }
        public string MasterAvatar { get; set; }
        public bool Done { get; set; }
        public int Stars { get; set; }
    }
}
