using System;
namespace GIFTed.Models
{
    public class Receivers
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Receivers()
        {
        }

        public Receivers(string name)
        {
            Name = name;
        }
    }
}
