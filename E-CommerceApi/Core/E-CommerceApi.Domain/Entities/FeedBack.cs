using E_CommerceApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Domain.Entities
{
    public class FeedBack : BaseEntity
    {
        public string Name {  get; set; }
        public string Surname {  get; set; }
        public string Description { get; set; }
    }
}
