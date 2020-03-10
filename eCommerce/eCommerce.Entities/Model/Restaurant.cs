using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Model
{
    [DataContract(IsReference = true)]
    public class Restaurant
    {
        [DataMember]
        [Key]
        public int RestaurantId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string imgURL { get; set; }
        
        [DataMember]
        [ForeignKey("City")]
        public int CityID { get; set; }
        [DataMember]
        public virtual City City { get; set; }
    }
}
