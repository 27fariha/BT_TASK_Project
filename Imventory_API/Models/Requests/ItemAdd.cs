namespace Imventory_API.Models.Requests
{
    public class ItemAdd
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public string amount { get; set; }
        public string category { get; set; }
        public int status { get; set; }

    }
}
