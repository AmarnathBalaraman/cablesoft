using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagement.Models
{
    public class UserManagementModel
    {
    }

    public class AddUserModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email")]
        //Using Remote validation attribute
        //[Remote("IsUserExists", "UsersManagement", HttpMethod = "POST", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }

        public string Phone { get; set; }
        [Required]
        [Display(Name = "Select Position")]
        public int PositionId { get; set; }
        [Required]
        [Display(Name = "Select Area")]
        public int AreaId { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password confirmation must match password.")]
        public string CPassword { get; set; }

        public byte[] Image { get; set; }

        public IEnumerable<PositionModel> Position { get; set; }
        public IEnumerable<AreaModel> Area { get; set; }
        public IEnumerable<GenderModel> sex { get; set; }
    }

    public class AddCollectionUserModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email")]
        //Using Remote validation attribute
        //[Remote("IsUserExists", "UsersManagement", HttpMethod = "POST", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }

        public string Phone { get; set; }
        [Required]
        [Display(Name = "Select Position")]
        public int PositionId { get; set; }
        [Required]
        [Display(Name = "Select Street")]
        public int StreetId { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password confirmation must match password.")]
        public string CPassword { get; set; }

        public byte[] Image { get; set; }

        public IEnumerable<PositionModel> Position { get; set; }
        public IEnumerable<StreetModel> Street { get; set; }
        public IEnumerable<GenderModel> sex { get; set; }
    }


    public class PositionModel
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
    }

    public class AreaModel
    {
        public int AreaCode { get; set; }
        public string AreaName { get; set; }
    }

    public class Streetmodel
    {
        public int StreetId { get; set; }
        public int StreetAreaCode { get; set; }
        public string StreetName { get; set; }
        public string OperatorName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }

    //public class GenderModel
    //{
    //    public string GenderID { get; set; }
    //    public string Description { get; set; }
    //}

    public class UsersListModel
    {
        public string UserID { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string PositionName { get; set; }
        public string DateCreated { get; set; }
        public int IsActive { get; set; }
        public int IsArchived { get; set; }

        public string Operation { get; set; }
    }

    public class EditUserModel
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PositionId { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password confirmation must match password.")]
        public string CPassword { get; set; }

        public IEnumerable<GenderModel> sex { get; set; }
        public IEnumerable<PositionModel> Position { get; set; }

    }

}