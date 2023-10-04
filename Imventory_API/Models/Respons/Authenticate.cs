using Imventory_API.Models.Requests;

namespace Imventory_API.Models.Respons
{
    public class Profile
    {
      
        public string name { get; set; }
        public string uuid { get; set; }
        public string email { get; set; }
        public TokenResponse token { get; set; }
    }
}
