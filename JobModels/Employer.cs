using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jobsearch.az.JobModels;

namespace jobsearch.az.JobModels
{
    [Serializable ]
    public class Employer : AboutMeOrUs 
    {
        [XmlAttribute]
        public int _maxSalary { get; set; }
        [XmlAttribute]
        public short _minAge { get; set; }
        [XmlAttribute]
        public short _maxAge { get; set; }
        [XmlAttribute]
        public string _requirements { get; set; }
        [XmlAttribute]
        public string _aboutWork { get; set; }
        [XmlAttribute]
        public string _nameOfCompany { get; set; }
        [XmlAttribute]
        public string _elaqedarShexs { get; set; }
       


        public  Employer(Guid id, string email, string phone, string category, string position, string city, string sex, string education, string workExperience,
             int minSalary, int maxSalary, short  minAge, short maxAge, string requirements, string aboutWork, string nameOfCompany, string elaqedarShexs,DateOnly date, bool isAccept = false )
            : base(id, email, phone, category, position, city, sex, education, workExperience, minSalary, date, isAccept)
        {
            _maxSalary = maxSalary;    _minAge = minAge;  maxAge = maxAge;   _requirements = requirements;   _aboutWork = aboutWork;
            _nameOfCompany = nameOfCompany;    _elaqedarShexs = elaqedarShexs;
            _aktiv = true;
        }
        public Employer() {  _aktiv = true; }

        public override string ToString()
        {
            return $"\nID : {_id } \n{_category } \n{_position} \n {_minSalary } - {_maxSalary } \t\t {_nameOfCompany } \nCity : {_city } \nAge : {_minAge } - {_maxAge } yash\n Cins : {_sex }" +
            $"Tehsil : {_education } \nIsh Tecrubesi : {_workExperience }\n Elanin tarixi :  {_date}  \t\t Bitme tarixi : {_date.AddMonths(1)}\n Elaqedar shexs : {_elaqedarShexs }\n" +
            $"About Work : {_aboutWork } \n Telebler : {_requirements } \nElaqe nomresi : {_phone } \t\t Email : {_email }";
        }

    }
}  
