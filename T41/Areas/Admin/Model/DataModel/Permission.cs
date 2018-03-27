using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T41.Areas.Admin.Model.DataModel
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [Required(ErrorMessage ="Hãy nhập tên phân quyền")]
        [Display(Name ="Phân quyền")]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        public string PermissionName { get; set; }

        [Required(ErrorMessage = "Hãy nhập mô tả")]
        [Display(Name = "Mô tả")]        
        [MaxLength(256)]
        public string Description { get; set; }

        [Required()]
        [MaxLength(64)]
        [Display(Name = "Mã nghiệp vụ")]
        [ForeignKey("Businesses")]
        [Column(TypeName ="varchar")]
        public string BusinessId { get; set; }

        public virtual Business Businesses { get; set; }
        public virtual ICollection<GrantPermission> GrantPermissions { get; set; }
    }
}