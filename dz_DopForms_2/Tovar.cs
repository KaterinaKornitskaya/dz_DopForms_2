using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_DopForms_2
{
    public class Tovar
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Tovar()
        {
            Name = "unknown";
            Price = 0;
            Description = "unknown";
        }
        public Tovar(string name, string description, int price)
        {
            Name=name;
            Description=description;
            Price=price;
        }
        public override string ToString()
        {
            return $"{Name}, {Description}, {Price}";
        }
    }
}
