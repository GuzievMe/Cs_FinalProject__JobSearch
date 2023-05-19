using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jobsearch.az.JobModels
{
    [Serializable ]
    public class AboutMeOrUs
    {
        [XmlAttribute ]
        public bool _aktiv { get; set; }
        [XmlAttribute]
        public Guid _id { get; set; }
        [XmlAttribute]
        public string _email { get; set; }
        [XmlAttribute]
        public string _phone { get; set; }
        [XmlAttribute]
        public string _category { get; set; }
        [XmlAttribute]
        public string _position { get; set; }
        [XmlAttribute]
        public string _city { get; set; }
        [XmlAttribute]
        public string _sex { get; set; }
        [XmlAttribute]
        public string _education { get; set; }
        [XmlAttribute]
        public string _workExperience { get; set; }
        [XmlAttribute]
        public int _minSalary { get; set; }
        //[XmlAttribute]
        [XmlIgnore ]
        // [XmlArray ]
        //[XmlElement("Item")]
        public DateOnly _date { get; set; }
        //[XmlAttribute]
        [XmlIgnore ]
        //[XmlArray ]
        //[XmlAnyAttribute ]
        //[XmlElement("Item")]
        public DateOnly _dateToEnd { get; set; }
        [XmlAttribute]
        public bool _isAccept { get; set; }

        public AboutMeOrUs (Guid id, string email, string phone, string category, string position, string city, string sex, string education, string workExperience, int minSalary, DateOnly date,bool isAccept)
        {
            _email = email;   _phone = phone;  _category = category;   _position = position;   _city = city;  _sex = sex;
            _education = education;  _workExperience = workExperience;  _minSalary = minSalary;   _date = date;  _dateToEnd = _date.AddMonths(1);
            _isAccept = isAccept;
        }
        public AboutMeOrUs () { _isAccept = false; _isAccept = false; }
    }
}
