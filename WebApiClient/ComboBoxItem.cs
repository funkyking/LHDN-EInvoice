using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ComboBoxItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Override ToString to display the item name
        public override string ToString()
        {
            return Name;
        }
    }

}
