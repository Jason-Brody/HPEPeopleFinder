using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDataLoaderAgent
{
    public class SingleInfo
    {
        public HPUserDetail result { get; set; }
    }

    public class SearchInfo
    {
        public List<HPUserDetail> result { get; set; }
    }

    public class MgrInfo
    {
        public List<List<HPUserDetail>> result { get; set; }
    }

    public class UserPatch
    {
        public int Level { get; set; }

        public HPUserDetail People { get; set; }

        public List<HPUserDetail> Employees { get; set; }
    }

    public class HPUserDetail
    {
        public int Level { get; set; }

        public string co { get; set; }
        public string cn { get; set; }

        public string objectClass { get; set; }
        public string hpJobFamilyCode { get; set; }
        public string hpRadiusID { get; set; }
        public string hpActionDate { get; set; }
        public string hpBusinessRegion { get; set; }
        public string hpOrganizationChartAcronym { get; set; }
        public string hpBusinessRegionAcronym { get; set; }
        public string street { get; set; }
        public string hpDisplayNameExtension { get; set; }
        public string hpGlobalID { get; set; }
        public string mailRoutingAddress { get; set; }
        public string uid { get; set; }
        public string hpPost { get; set; }
        public string hpBusinessUnit { get; set; }
        public string employeeType { get; set; }
        public string hpPictureOneHpURI { get; set; } = "https://writetarget.files.wordpress.com/2015/04/person11.jpg";
        public string hpCrossCompanyManagerID { get; set; }
        public string hpFloor { get; set; }
        public string hpCrossCompanyManager { get; set; }
        public string hpPayrollCountryCode { get; set; }

        public string hpJobFamily { get; set; }
        public string hpBusinessUnitAcronym { get; set; }
        public string buildingName { get; set; }
        public List<string> mail { get; set; }
        public string postalAddress { get; set; }
        public string dn { get; set; }
        public string hpBusinessGroupCode { get; set; }
        public string hpSourceSystem { get; set; }
        public string hpStatus { get; set; }
        public string krbName { get; set; }
        public string hpStartDate { get; set; }
        public string mailStop { get; set; }
        public string postalCode { get; set; }
        public string imapURL { get; set; }
        public string hpJobFunction { get; set; }

        [Key]
        public string employeeNumber { get; set; }
        public string hpAltLegalName { get; set; }
        public string hpOrganizationChart { get; set; }
        public string hpWorkLocation { get; set; }
        public string ntUserDomainId { get; set; }
        public string hpLHCostCenter { get; set; }
        public string l { get; set; }
        public string telephoneNumber { get; set; }
        public string c { get; set; }
        public string hpSourceCompany { get; set; }
        public string hpBusinessGroup { get; set; }
        public string hpPictureThumbnailURI { get; set; }
        public string hpSplitCompany { get; set; }
        public string manager { get; set; }
        public string o { get; set; }
        public string st { get; set; }
        public string hpMRUCode { get; set; }
        public string mobile { get; set; }
        public string hpLocationCode { get; set; }
        public string sn { get; set; }
        public string hpPictureURI { get; set; }
        public string hpJobFunctionCode { get; set; }
        public string hpExchangeMail { get; set; }
        public string ou { get; set; }
        public string givenName { get; set; }
        public string hpLegalName { get; set; }
        public string managerEmployeeNumber { get; set; }
    }
}
