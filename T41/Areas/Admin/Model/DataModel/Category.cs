using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T41.Areas.Admin.Model.DataModel
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã chủ đề")]
        public int CategoryId { get; set; }

        [Display(Name = "Tên chủ đề")]
        [Required(ErrorMessage ="Hãy nhập tên chủ đề")]
        [StringLength(256)]
        public string CategoryName { get; set; }

        [Display(Name = "Thứ tự xuất hiện")]
        [Required(ErrorMessage = "Hãy nhập thứ tự xuất hiện")]
        public int OrderNo { get; set; }   


        [Display(Name = "Trạng thái")]        
        [StringLength(32)]
        public string Status { get; set; }

        public int? UserId { get; set; }
        public virtual Administrator Administrator { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}