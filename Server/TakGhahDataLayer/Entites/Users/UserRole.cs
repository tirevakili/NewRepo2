using GhorfeDar.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakGhahDataLayer.Entites.Users
{
    public class UserRole
    {
        #region UserEntite
        [Key]
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public string? RoleName { get; set; }
        #endregion

        #region Relation
        public virtual User? Users { get; set; }
        #endregion
    }
}
