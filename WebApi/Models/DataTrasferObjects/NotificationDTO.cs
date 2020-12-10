namespace WebApi.Models.DataTransferObjects
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}