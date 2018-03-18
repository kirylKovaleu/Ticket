using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcInternetApplication.Models
{
    [Table("Seats")]
    public class Seat
    {
        [Key]
        [Display(Name = "НомерМеста", ResourceType = typeof(App_LocalResources.GlobalRes)) ]
        public int SeatId { get; set; }
        
        [Display(Name ="ОбластьЗала", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Name { get; set; }
        
        [Display(Name = "Цена", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public int Price { get; set; }
    }
}