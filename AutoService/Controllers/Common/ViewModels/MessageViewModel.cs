namespace AutoService.Controllers.Common.ViewModels
{
    public class MessageViewModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
