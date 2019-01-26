namespace Portal.API.ViewModels
{
    public class ProductView
    {
        public int Id { get; set; }
        public string ProductCategory { get; set; }
        public string ProductName { get; set; }
        public decimal StartFrom { get; set; }
        public string Description { get; set; }
    }
}