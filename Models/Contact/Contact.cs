using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Csharp.Models.Contact
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Phải nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string? FullName { get; set; }
        [Required(ErrorMessage ="Phải nhập email")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Địa chỉ mail khong phù hợp")]
        [Display(Name = "Địa chỉ email")]
        public string Email { get; set; }
        [Display(Name = "Ngày gửi")]
        public DateTime DateDenst { get; set; }
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage ="Cần nhập nội dung")]
        public string Message { get; set; }
        [StringLength(50)]
        [Phone(ErrorMessage ="Số điện thoại không phù hợp")]
        [Display(Name ="Số điện thoại")]
        public string? Phone { get; set; }
    }
}
