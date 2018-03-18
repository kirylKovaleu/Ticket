using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MvcInternetApplication.Models
{
    [Table("Performances")]
    public class Performance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes),
                  ErrorMessageResourceName = "АЭтуСтрочечкуЗаполнятьНеНужно")]
        [StringLength(35, ErrorMessage = "НуИКудаЭтоПисатьСократиНазвание")]
        [Display(Name = "НазваниеПьесы", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes),
            ErrorMessageResourceName = "ТыНеПоверишьНоИЭтоПолеЖелательноЗаполнить")]
        [Display(Name = "Дата", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public DateTime Date { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes),
            ErrorMessageResourceName = "ОнаСамаСебяСнимает")]
        [StringLength(20, ErrorMessage = "АЧтоПокорочеИмечкаНету")]
        [Display(Name = "Режиссер", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Autor { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes),
            ErrorMessageResourceName = "ЗамечательнаяПьесаБезАктеровЗаТоНиКтоНеНадоест")]
        [StringLength(25, ErrorMessage = "АЧтоПокорочеИмечкаНету")]
        [Display(Name = "Актеры", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Actors { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes),
            ErrorMessageResourceName = "ТоестьОнаНиКогдаНеЗакончится")]
        [Display(Name = "Продолжительность", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Duration { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_LocalResources.GlobalRes),
            ErrorMessageResourceName = "НеНуЛюдиДолжныЗнатьОЧемРечь")]
        [StringLength(60, ErrorMessage = "ТыТакВсюПьесуРасскажешьКорочеНужно")]
        [Display(Name = "Описание", ResourceType = typeof(App_LocalResources.GlobalRes))]
        public string Description { get; set; }
    }
    
}