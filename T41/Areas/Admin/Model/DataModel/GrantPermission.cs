using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T41.Areas.Admin.Model.DataModel
{
    [Table("GrantPermission")]
    public class GrantPermission
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Permission")]
        [Display(Name = "Mã quyền hạn")]
        [Required]
        public int PermissionId { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Mã người dùng")]
        [Required]
        [ForeignKey("Administrator")]
        public int UserId { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(256)]
        public string Description { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Administrator Administrator { get; set; }
    }
}