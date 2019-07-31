using System;

namespace WebApi.Models
{
    public class Processor
    {
        public int Id {get; set;}
        public float Value {get; set;}
        public TimeSpan Time { get; set;}

        public int HostId { get; set; }
        public Host Host { get; set; }
    }
}
