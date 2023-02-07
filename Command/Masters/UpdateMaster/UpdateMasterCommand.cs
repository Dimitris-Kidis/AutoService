using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Masters.UpdateMaster
{
    public class UpdateMasterCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string? Experience { get; set; }
        public string? Services { get; set; }
        public string? Description { get; set; }
    }
}
