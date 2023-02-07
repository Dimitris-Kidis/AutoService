using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Client.GetClientsForChat
{
    public class ClientsForChatDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public bool HasNewMessage { get; set; }
        public string CarInfo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
