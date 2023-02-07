using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetMasterHistory
{
    public class MasterHistoryDto
    {
        public string CarInfo { get; set; }
        public string Services { get; set; }
        public string ClientName { get; set; }
        public string ClientAvatar { get; set; }
        public bool Done { get; set; }
        public int Stars { get; set; }
    }
}
