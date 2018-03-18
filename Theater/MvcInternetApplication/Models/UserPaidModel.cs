using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MvcInternetApplication.Models
{
    [Table("UserPaid")]
    public class UserPaid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserPaidId { get; set; }
        public int UserProfileId { get; set; }
        public int PerformanceId { get; set; }
        public int SeatId { get; set; }
        public bool Payment { get; set; }
    }

    public class UserPaidShow
    {
        public int UserPaidId { get; set; }
        
        [Display(Name = "Имя", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Name { get; set; }
        
        [Display(Name = "НазваниеПьесы", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Performance { get; set; }
        
        [Display(Name = "Дата", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public DateTime Date { get; set; }
        
        [Display(Name = "НомерМеста", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public int SeatId { get; set; }
        
        [Display(Name = "РезультатОплаты", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public bool Payment { get; set; }
    }
}