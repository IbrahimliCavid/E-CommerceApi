using E_CommerceApi.Domain.Entities.Common;

namespace E_CommerceApi.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string Name{ get; set; }  
        public ICollection<Order> Orders { get; set; }
    }
}
