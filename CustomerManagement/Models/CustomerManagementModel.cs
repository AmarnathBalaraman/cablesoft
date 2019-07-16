using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagement.Models
{
    public class CustomerManagementModel
    {
    }

    public class AddCustomerModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        [Required]
        [Display(Name = "Customer Street")]
        public int CustomerStreet { get; set; }
        [Required]
        [Display(Name = "Pincode")]
        public string CustomerPincode { get; set; }
        [Required]
        [Display(Name = "Customer City")]
        public int CustomerCity { get; set; }
        [Required]
        [Display(Name = "Customer State")]
        public int CustomerState { get; set; }

        [Required]
        [Display(Name = "Customer Country")]
        public int CustomerCountry { get; set; }

        public string CustomerEmailId { get; set; }
        [Required]
        [Display(Name = "Customer Mobile No")]
        public string CustomerMobileNo { get; set; }
        [Required]
        [Display(Name = "Customer Box Type")]
        public int CustomerBoxType { get; set; }
        [Required]
        [Display(Name = "Customer Box Serial no")]
        public string CustomerBoxSerialNo { get; set; }
        [Required]
        [Display(Name = "Customer Package Detail")]
        public int CustomerPackageId { get; set; }
        public IEnumerable<StreetModel> Street { get; set; }
        public IEnumerable<CityModel> City { get; set; }
        public IEnumerable<StateModel> State { get; set; }
        public IEnumerable<CountryModel> Country { get; set; }
        public IEnumerable<BoxModel> Box { get; set; }
        public IEnumerable<PackageModel> Package { get; set; }
    }

    public class CustomerListModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobileNo { get; set; }
        public int IsActive { get; set; }
        public int IsArchived { get; set; }
        public string Operation { get; set; }
    }

    public class EditCustomerModel
    {
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        [Required]
        [Display(Name = "Customer Street")]
        public int CustomerStreet { get; set; }
        [Required]
        [Display(Name = "Pincode")]
        public string CustomerPincode { get; set; }
        [Required]
        [Display(Name = "Customer City")]
        public int CustomerCity { get; set; }
        [Required]
        [Display(Name = "Customer State")]
        public int CustomerState { get; set; }

        [Required]
        [Display(Name = "Customer Country")]
        public int CustomerCountry { get; set; }

        public string CustomerEmailId { get; set; }
        [Required]
        [Display(Name = "Customer Mobile No")]
        public string CustomerMobileNo { get; set; }
        [Required]
        [Display(Name = "Customer Box Type")]
        public int CustomerBoxType { get; set; }
        [Required]
        [Display(Name = "Customer Box Serial no")]
        public string CustomerBoxSerialNo { get; set; }
        [Required]
        [Display(Name = "Customer Package Detail")]
        public int CustomerPackageId { get; set; }
        public IEnumerable<StreetModel> Street { get; set; }
        public IEnumerable<CityModel> City { get; set; }
        public IEnumerable<StateModel> State { get; set; }
        public IEnumerable<CountryModel> Country { get; set; }
        public IEnumerable<BoxModel> Box { get; set; }
        public IEnumerable<PackageModel> Package { get; set; }

    }

    public class StreetModel
    {
        public int StreetId { get; set; }
        public int StreetAreaCode { get; set; }
        [Required]
        public string StreetName { get; set; }
        public string OperatorName { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class EditStreetModel
    {
        [HiddenInput(DisplayValue=false)]
        public int StreetId { get; set; }
        [Required]
        public string StreetName { get; set; }
        }
    public class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }

    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

    public class CountryModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class PackageModel
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
    }

    public class BoxModel
    {
        public int BoxId { get; set; }
        public string BoxName { get; set; }
    }


}