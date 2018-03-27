using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T41.Areas.Admin.Model.DataModel
{
    [Table("Business")]
    public class Business
    {
        [Key]
        [MaxLength(64)]
        [Display(Name ="Mã nghiệp vụ")]
        [Column(TypeName ="varchar")]
        public string BusinessId { get; set; }

        [MaxLength(256)]
        [Display(Name = "Tên nghiệp vụ")]
        [Required(ErrorMessage ="Hãy nhập tên nghiệp vụ")]
        public string BusinessName { get; set; }


        public virtual ICollection<Permission> Permissions { get; set; }
    }
}