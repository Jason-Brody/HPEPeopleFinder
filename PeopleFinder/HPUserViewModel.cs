using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Utils;

namespace PeopleFinder
{
    public class HPUserViewModel
    {
        public HPUserViewModel()
        { }

        public HPUserViewModel(HPUserDetail d)
        {
            this.DisplayNameExtension = d.hpDisplayNameExtension;
            this.PhotoUrl = d.hpPictureOneHpURI;
            this.EmployeeId = d.employeeNumber;
            this.Uid = d.uid;
            this.Manager = d.manager.Split(new string[] { "," }, StringSplitOptions.None).First().Replace("uid=", "");
            this.JobFunction = $"{d.hpJobFunction} ({d.hpJobFunctionCode})";
            this.JobFamily = $"{d.hpJobFamily} ({d.hpJobFamilyCode})";
            this.CompanyName = d.o;
            this.TenantCompanyName = d.hpSplitCompany;
            this.HRMRU = d.hpMRUCode;
            this.OrganizationUnit = d.ou;
            this.BusinessUnit = $"{d.hpBusinessUnit} ({d.hpBusinessUnitAcronym})";
            this.BusinessGroup = $"{d.hpBusinessGroup} ({d.hpBusinessGroupCode})" ;
            this.BusinessRegion = $"{d.hpBusinessRegion} ({d.hpBusinessRegionAcronym})";
            this.CountryCode = d.c.ToLower();
            this.Country = d.co;
            
            this.NTUserId = d.ntUserDomainId.Replace(":", @"\");
            this.EmployeeType = d.employeeType;
            this.LegalName = d.hpLegalName;
            this.FirstName = d.givenName;
            this.LastName = d.sn;
            this.Telephone = d.telephoneNumber;
            this.Mobile = d.mobile;
            this.Region = d.l;
            this.BuildingName = d.buildingName;
        }
        
        [PropSkip]
        public string DisplayNameExtension { get; set; }

        [PropSkip]
        public string LegalName { get; set; }

        [PropSkip]
        public string PhotoUrl { get; set; }

        public string EmployeeId { get; set; }

        [PropSkip]
        public string Uid { get; set; }


        [PropSkip]
        public string Manager { get; set; }

        public string JobFunction { get; set; }

        public string JobFamily { get; set; }

        public string CompanyName { get; set; }

        public string TenantCompanyName { get; set; }

        public string HRMRU { get; set; }

        public string OrganizationUnit { get; set; }

        public string BusinessUnit { get; set; }

        public string BusinessGroup { get; set; }

        public string BusinessRegion { get; set; }

        public string CountryCode { get; set; }

        public string Country { get; set; }

        public string NTUserId { get; set; }

        public string EmployeeType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Region { get; set; }

        public string BuildingName { get; set; }
    }
}
