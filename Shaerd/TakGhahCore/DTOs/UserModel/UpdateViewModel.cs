
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhorfeDar.Core.DTOs.UserModel
{
    public class UpdateViewModel
    {
        #region UpdateViewModel
        public string? FullName { get; set; }
     
        public string? UserName { get; set; }
    
        //public Gender? Gender { get; set; }
   
        public DateTimeOffset? BirthDate { get; set; }

        public string? ProfileImageName { get; set; }

        public string? Description { get; set; }

        #endregion
    }
}
