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
    public class MenuItem
    {
        [DataMember]
        [Key]
        public int MenuItemID { get; set; }
        [DataMember]
        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        [DataMember]
        public virtual Menu Menu { get; set; }
        [DataMember]
        public string MenuItemTitle { get; set; }
        [DataMember]
        public string MenuItemDescription { get; set; }
        [DataMember]
        public double MenuItemPrice { get; set; }
    }
}
