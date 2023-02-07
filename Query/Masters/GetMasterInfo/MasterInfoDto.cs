using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetMasterInfo
{
    public class MasterInfoDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }
        public string Experience { get; set; }
        public string Services { get; set; }
        public string Description { get; set; }
    }
}
