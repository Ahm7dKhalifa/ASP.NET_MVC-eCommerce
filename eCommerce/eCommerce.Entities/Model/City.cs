using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Model
{
    [DataContract(IsReference = true)]
    public class City
    {
        [DataMember]
        [Key]
        public int CityID { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public List<Restaurant> Restaurants { get; set; }
    }
}
