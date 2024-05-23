using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakGhahCore.DTOs.UserModel
{
    public class LoginViewModel
    {
        #region LoginViewModel
        [Required(ErrorMessage ="ایمیل را وارد نمایید")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "پسورد را وارد نمایید")]
        public string? Code { get; set; }
        #endregion
    }
}
