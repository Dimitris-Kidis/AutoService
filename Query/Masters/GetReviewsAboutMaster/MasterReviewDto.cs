using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Masters.GetReviewsAboutMaster
{
    public class MasterReviewDto
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
