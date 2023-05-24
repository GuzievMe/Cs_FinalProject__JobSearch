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
    public class Employee : AboutMeOrUs 
    {
        [XmlAttribute ]
        public string _name { get; set; }
        [XmlAttribute]
        public string _surname { get; set; }
        [XmlAttribute]
        public short _age { get; set; }
        [XmlAttribute]
        public string _about { get; set; }
        [XmlAttribute ]
        public string _skills;

        public Employee(Guid id, string email, string phone, string category, string position, string city, string sex, string education,
            string workExperience, int minSalary, string name, string surname, short age,  string about, string skills, DateOnly date, bool isAccept = false) :
            base(id, email,  phone,  category,  position,  city,  sex,  education,  workExperience,  minSalary, date, isAccept  )
        {
            _name = name;   _surname = surname;  _age = age;  _about = about;   _skills = skills;
            _aktiv = true;
        }

        public Employee( ) { _aktiv = true; }

        public override string ToString()
        {
            return $" \n ID : {_id } \n{_category } \n {_position  } { _minSalary  } {_name  } { _surname  } City : {_city}  \nAge  : {_age } yash\n  Cins : {_sex } " +
                $" \nElanin tarixi : {_date.Year } - {_date.Month } - {_date .Day } \nBitme tarixi : {_date.AddMonths(1).Year} - {_date.AddMonths(1).Month} - {_date.AddMonths(1).Day} \nPhone : {_phone } \t\t Email : {_email } " +
                $"Bacariglar : {_skills } \n Tehsil : {_education } \nIsh tecrubesi : {_workExperience } \n Elave Melumat : {_about }  ";
        }
       


        



        // CV yerleshdirerken Mainde yerleshdirilme butonu da achilmalidir ...
    }
}
