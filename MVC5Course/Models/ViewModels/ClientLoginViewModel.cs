using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientLoginViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0}最大不得超過{1}個字元")]
        [DisplayName("名")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("中間名")]
        [DataType(DataType.Password)]
        [StringLength(5, ErrorMessage = "{0}最大不得超過{1}個字元")]
        public string MiddleName { get; set; }
        [DisplayName("姓")]
        [Required]
        [StringLength(5, ErrorMessage = "{0}最大不得超過{1}個字元")]
        public string LastName { get; set; }
        [DisplayName("生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

    }
}