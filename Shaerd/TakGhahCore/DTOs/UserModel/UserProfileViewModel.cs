using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhorfeDar.Core.DTOs.UserModel
{
    public class UserProfileViewModel
    {
        #region UserProfileViewModel
        public int UserProfileID { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public string? UserAvatar { get; set; }
        public DateTime CreateProfileDate { get; set; }
        public int UserID { get; set; }
        #endregion

    }
}
