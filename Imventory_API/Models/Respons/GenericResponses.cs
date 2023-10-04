namespace Imventory_API.Models.Respons
{
    public class Generic<T>
    {
        public string error { get; set; }
        public bool success { get; set; }
        public T data { get; set; }
    }

    public class PaginatedResponse<T>
    {
        public uint page { get; set; }
        public uint total { get; set; }
        public uint per_page { get; set; }
        public List<T> items { get; set; }
    }
    public class PaginatedModel
    {
        public uint page { get; set; }
        public uint total { get; set; }
        public uint per_page { get; set; }
    }
    public class ServerStatus
    {
        public string tag { get; set; }
        public string timestamp { get; set; }
    }
}
