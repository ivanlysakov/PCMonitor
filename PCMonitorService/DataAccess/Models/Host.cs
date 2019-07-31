using System.Collections.Generic;

namespace WebApi.Models
{
    public class Host
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Manufacturer {get; set;}
       
        
        public ICollection<Cpu> CpuLoad { get; set;}
               
        public ICollection<Memory> MemoryLoad  {get; set; }
        
        public IList<User>  Users {get; set;}
    }
}
