using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Domain
{
   public class Order
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public ICollection<HealthyFoodOrderItem> Healthyfood { get; set; }
      
       
      
       

        public Order() { }
        public Order(string firstName, string lastName, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Healthyfood = new List<HealthyFoodOrderItem>();
          
           
        }
        
      

        public void Update(OrderViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            Address = model.Address;
        }

      
    }
}
