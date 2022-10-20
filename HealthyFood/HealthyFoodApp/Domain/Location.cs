using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Domain
{
   public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int OpensAt { get; set; }
        public int ClosesAt { get; set; }
        public Location()
        {

        }
        public Location(string name, string address, int opensAt, int closesAt)
        {
            Name = name;
            Address = address;
            OpensAt = opensAt;
            ClosesAt = closesAt;
        }
        
           public void Update(LocationViewModel model)
        {
            Name = model.Name;
            Address = model.Address;
            OpensAt = model.OpensAt;
            ClosesAt = model.ClosesAt;
        }

       
    }
}
