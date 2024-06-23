using E_CommerceApi.Domain.Entities.Common;

namespace E_CommerceApi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        public int CustomerId {  get; set; } 

        public string Description {  get; set; }

        public string Adress {  get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    } 
}
