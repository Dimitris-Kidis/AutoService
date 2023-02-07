﻿namespace AutoService.Controllers.Common.ViewModels
{
    public class MasterReviewViewModel
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
