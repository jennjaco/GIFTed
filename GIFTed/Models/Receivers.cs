using System;
namespace GIFTed.Models
{
    public class Receivers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }

        public Receivers()
        {
        }

        public Receivers(string name, string address, string contactemail)
        {
            Name = name;
            Address = address;
            ContactEmail = contactemail;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
