using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T41.Areas.Admin.Model.DataModel
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [Display(Name ="Mã số")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Display(Name = "Mã số")]
        [StringLength(512)]
        [Required(ErrorMessage ="Hãy nhập mã số")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]        
        [Required(ErrorMessage = "Hãy nhập nội dung")]
        [Column(TypeName ="ntext")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Hãy nhập mô tả")]
        [StringLength(1024)]
        public string Brief { get; set; }

        [Display(Name = "Ảnh")]        
        [StringLength(256)]
        public string Picture { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Thẻ tìm kiếm")]
        [StringLength(128)]
        public string Tags { get; set; }


        [Display(Name = "Mã chủ đề")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Số lần xem")]
        public int ViewNo { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(32)]
        public string Status { get; set; }

        [Display(Name = "Mã người dùng")]
        public int? UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Administrator Administrator { get; set; }
    }
}