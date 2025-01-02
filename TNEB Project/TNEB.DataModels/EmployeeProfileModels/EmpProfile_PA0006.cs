using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA0006 : EmpProfile_SuperSets
    {
        public string addresstype { get; set; }
        public string addresstype_description { get; set; }
        public string careof { get; set; }
        public string streethouse { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string pcodecity { get; set; }
        public string country { get; set; }
        public string country_description { get; set; }
        public string telephoneno { get; set; }
        public string distanceinkm1 { get; set; }
        public string companyhousing { get; set; }
        public string busroute { get; set; }
        public string secondaddline { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string region { get; set; }
        public string region_description { get; set; }
        public string housenumber { get; set; }
        public string apartmentid { get; set; }
        public string buildingcode { get; set; }
        public string floor { get; set; }
        public string streetabbrev { get; set; }
        public string distanceinkm2 { get; set; }
        public string type1 { get; set; }
        public string number1 { get; set; }
        public string type2 { get; set; }
        public string number2 { get; set; }
        public string type3 { get; set; }
        public string number3 { get; set; }
        public string type4 { get; set; }
        public string number4 { get; set; }
        public string type5 { get; set; }
        public string number5 { get; set; }
        public string type6 { get; set; }
        public string number6 { get; set; }
        public string relationship { get; set; }
        public string countycode { get; set; }
        public string municipalcitycode { get; set; }
        public string citydistrKana { get; set; }
        public string contactkana { get; set; }
        public string cityKatakana { get; set; }
        public string socialsubscrailw { get; set; }
    }
    public class AddressDetailsResponse
    {
        public AD d { get; set; }
    }

    public class AD
    {
        public List<EmpProfile_PA0006> results { get; set; }
    }
}
