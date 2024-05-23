using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TakGhahDataLayer.Entites.Users;



namespace GhorfeDar.DataLayer.Entities.Users
{
    public class User
    {

        #region UserEntite
        [Key]
        public int UserID { get; set; }
    
        public string? Email { get; set; }
      
        public string? Code { get; set; }

        public DateTime RegisterUserDate { get; set; }

        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }
   
   
        public DateTimeOffset? BirthDate { get; set; }

        public string? ProfileImageName { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Relation

        public virtual List<UserRole>? UserRoles { get; set; }
        #endregion

    }
}
