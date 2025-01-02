using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNEB.DataModels.EmployeeProfileModels
{
    public class EmpProfile_PA005 : EmpProfile_SuperSets
    {
        public string familymember { get; set; }
        public DateTime? birthdate { get; set; }
        public string ctryobirth { get; set; }
        public string ctryobirth_description { get; set; }
        public string nationality { get; set; }
        public string familymember_description { get; set; }
        public string nationality_description { get; set; }
        public string gender_description { get; set; }
        public string gender { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string birthplace { get; set; }
        public string state { get; set; }
        public string refpersno { get; set; }
        public string nameatbirth { get; set; }
        public string secondname { get; set; }
        public string fullname { get; set; }
        public string nameformat { get; set; }
        public string initials { get; set; }
        public string nameprefix1 { get; set; }
        public string nameprefix2 { get; set; }
        public string othertitle { get; set; }
        public string avnumber { get; set; }
        public string relchild { get; set; }
        public string authoriztn { get; set; }
        public string childsaddress { get; set; }
        public string caentitle { get; set; }
        public string childtype { get; set; }
        public string childbonuses { get; set; }
        public string sickcertauth { get; set; }
        public string authorityno { get; set; }
        public string sinumber1 { get; set; }
        public string sinumber2 { get; set; }
        public string confirmto { get; set; }
        public string eductraining { get; set; }
        public string institute { get; set; }
        public string eraddress { get; set; }
        public string othernat { get; set; }
        public string secondthirdnat { get; set; }
        public string amount { get; set; }
        public string title { get; set; }
        public string emergencycontact { get; set; }
    }
    public class FamilyDetailsResponse
    {
        public D d { get; set; }
    }

    public class D
    {
        public List<EmpProfile_PA005> results { get; set; }
    }
}
