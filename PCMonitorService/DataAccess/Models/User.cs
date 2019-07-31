
namespace WebApi.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public Status Status {get; set;}
        public int HostId { get; set; }
        public Host Host { get; set; }
    }
}
