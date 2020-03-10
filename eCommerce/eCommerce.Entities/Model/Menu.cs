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
    public class Menu
    {
        [DataMember]
        [Key]
        public int MenuID { get; set; }
        [DataMember]
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        [DataMember]
        public virtual Restaurant Restaurant { get; set; }
        [DataMember]
        public string MenuTitle { get; set; }
        [DataMember]
        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
