
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GhorfeDar.Core.DTOs.UserModel
{
    public class UserViewModel
    {
        #region UserViewModel      
        public int UserID { get; set; }
     
        public string? Email { get; set; }
      
        public string? Code { get; set; }
        public DateTime RegisterUserDate { get; set; }

        //[PersonalData]
        //public string? UserName { get; set; }

        //[PersonalData]
        //public string? FullName { get; set; }

        //public Gender? Gender { get; set; }

        //public DateTimeOffset? BirthDate { get; set; }

        //public string? ProfileImageName { get; set; }

        //public string? Phone { get; set; }

        //[PersonalData]
        //public string? Description { get; set; }
        #endregion
    }
}
