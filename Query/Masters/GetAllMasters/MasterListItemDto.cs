using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetAllMasters
{
    public class MasterListItemDto
    {
        public int Id { get; set; }
        public double Rating { get; set; }
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
