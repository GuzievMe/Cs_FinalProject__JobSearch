using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;

namespace jobsearch.az.JobModels
{
    public partial class CiteDataBase : IDeaktifEdenInterface
    {
        //[XmlElement("Item")]
        public  List<Employee> Employees = new();
        //[XmlElement("Item")]
        public  List<Employer> Employers = new() ;


        private List<Employer> GozleyenVakasiyalar = new();
        private List<Employee> GozleyenCVler = new() { };


        public CiteDataBase()
        {
            
        }

        public void JSaxronit () {
            File.WriteAllText("Emplyees.json", System.Text.Json.JsonSerializer.Serialize(Employees));

            var xml = new XmlSerializer(typeof(List<Employer>));
            using FileStream Fs = new FileStream("Employers.xml", FileMode.OpenOrCreate, FileAccess.Write);
            xml.Serialize(Fs, Employers);

            //
        }
            public List<Employee> GetEmployees() { return this.Employees; }
            public List<Employer> GetEmployers() { return this.Employers; }
   
        


        public void AddEmployees(Employee worker) {
            Employees.Add(worker);

            // JsonSerializerOptions Op = new();
            // Op.WriteIndented = true;
            // File.WriteAllText("Emplyees1.json", JsonSerializer.Serialize(Employees));

            var xml = new XmlSerializer(typeof(List<Employee>));    //xml.Formatting = new Formatting.Indented;
            using FileStream Fs = new FileStream("Employees1.xml", FileMode.Append, FileAccess.Write);
            xml.Serialize(Fs, Employees);
        }

        public void AddEmployers(Employer worker) {
            Employers.Add(worker);

            var xml = new XmlSerializer(typeof(List<Employer>));    //xml.Formatting = new Formatting.Indented;
            using FileStream Fs = new FileStream("Employers1.xml", FileMode.Append, FileAccess.Write);
            xml.Serialize(Fs, Employers);

           

        }
        


        //======================================================================================================//

        //DELETE

        public partial void DeleteVacancy();



        public partial void DeleteCV();

        /////////////////////////////////////////////////////////////////////////////////////
        ///  Print

        public partial void ShowAllVacancies();


        public partial void ShowAllCVler();


        //public partial void CVRequests();

        //public partial void VacanciesRequests();




        ////////////////////////////////////
        /// kategoriye gore vakansiya ve ya CVlerin print olunmasi :
        public partial void ShowVacAboutThisCat(string category);



        public partial void ShowCVAboutThisCat(string category);


        //////////////////////////////////////////////////////////////////////////////////////////////
        ///   Sechilmish City-e gore vakansiya ve CVlerin goruntulenmesi

        //public void showVacancietCurrentCity(Cities city)
        public partial void showVacancietCurrentCity(string city);


        public partial void showCvCurrentCity(string city);

        ////////////////////////////////////////////////////////////////////////////////////////

        /// Shirketin vakansiyalarini siralamak

        public partial void ShowVacanciesCurrentCompany(string company);
        


        /////////////////////////////////////////////////////////////////////////
        ///Vakansiyalari maashi vermekle sechmek
        public partial void showVacanciesWithThisSalary(int minsalary);

        public partial void showCVlerWithThisSalary(int minsalary);



        ////////////////////////////////////////////////////////////////////////////////////////

        //================================== Requestlerin Admin terefinden qebul olunmasi =======================

        public void ShowRequests()
        {
            Console.Clear();
            Console.WriteLine("\n\n \t\t\tCVleR \n\n");
            foreach (var a in Employees)
                {
                    if(a._isAccept == false)Console.WriteLine(a);
                    for (int n = 1; n < 50; n++)
                    {
                        Console.Write("=");
                    } 
                    Console.WriteLine();
                }
            Console.WriteLine("\n\n \t\t\tVAKANSIYALAR \n\n");



            foreach (var a in Employers)
                {
                    if (a._isAccept == false) Console.WriteLine(a);
                    for (int n = 1; n < 50; n++)
                    {
                        Console.Write("=");
                    }
                    Console.WriteLine();
                }

        }

        ///
        public void Accept()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\tTESDIG GOZLEYEN VAKANSIYALAR\n\n");
            foreach (var el in Employers )
            {
                if (el._isAccept == false && el._aktiv == true)
                {
                    Console.WriteLine(el);
                    Console.Write("Qebul edirsinizse 'y' ve ya 'Y'  daxil edin, Otherwise enter 'N' or 'n' .");
                    dynamic a = Console.ReadKey();
                    if (a.Key == ConsoleKey.Y) { el._isAccept = true; }
                    else if (a.Key == ConsoleKey.N) { el._aktiv = false ; }
                }
                Console.WriteLine();
            }
            Console.WriteLine("=======================================================================================\n\n");

            Console.WriteLine("\n\n\t\t\tTESDIG GOZLEYEN CV ler\n\n");
            foreach (var el in Employees)
            {
                if (el._isAccept == false && el._aktiv == true )
                {
                    Console.WriteLine(el);
                    Console.Write("Qebul edirsinizse 'y' ve ya 'Y'  daxil edin, Otherwise enter 'N' or 'n' .");
                    dynamic a = Console.ReadKey();
                    if (a.Key == ConsoleKey.Y) { el._isAccept = true; }
                    else if (a.Key == ConsoleKey.N) { el._aktiv = false ;
                         }
                }
            }
            Console.Write("Enter any key for go back : ");    Console.ReadKey(true);
                 
        }
























        /////Appply edmek Vakansiyaya ve ya CV ye (Yani musahibeye cagirmak)

        public void ApplyVacancy(string id, Employee cv)
        {
            foreach (var vac in Employers)
            {
                if (vac._id.ToString() == id)
                {
                    Console.Clear();
                    string sms = "Bu vakansiyaya Muraciet edildi .    ";
                    foreach (var let in sms) { Console.Write(let); Thread.Sleep(15); }


                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Random rnd = new Random();
                    int random_code = rnd.Next(100000, 999999);

                    var fromAddress = new MailAddress("mahamguziyev@gmail.com", "maham1902");
                    var toAddress = new MailAddress(vac._email, vac._nameOfCompany );
                    const string fromPassword = "wlfejqccuyomzrpp";
                     string subject = $"{vac._position }";
                    string  body = $"\n\n{cv}\n\n ";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential("mahamguziyev@gmail.com", fromPassword),
                        Timeout = 20000
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    break;
                }
            }
        }



        public void ApplyCv(string id, Employer Vakansiya )
        {
            foreach (var vac in Employees)
            {
                if (vac._id.ToString() == id)
                {
                    Console.Clear();
                    string sms = "Bu CV sahibi musahibeye cagirildi .    ";
                    foreach (var let in sms) { Console.Write(let); Thread.Sleep(15); }
                    

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Random rnd = new Random();
                    int random_code = rnd.Next(100000, 999999);

                    var fromAddress = new MailAddress("mahamguziyev@gmail.com", "maham1902");
                    var toAddress = new MailAddress(vac._email , vac._name );
                    const string fromPassword = "wlfejqccuyomzrpp";
                    const string subject = "Davet";
                    string  body = $"{Vakansiya._nameOfCompany } shirketi terefinden {Vakansiya ._position } sahesi uzre Musahibeye devet olunursunuz";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential("mahamguziyev@gmail.com", fromPassword),
                        Timeout = 20000
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                    break;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////
        ///           CV yerleshdirilmesi sehifeye 
        public void CreateCv()
        {
            Employee Re = new();
            Re._id = Guid.NewGuid();
            Console.Write("Email : "); Re._email = Console.ReadLine();
            Console.Write("Phone : "); Re._phone = Console.ReadLine();
            Console.Write("Kategory : "); Re._category = Console.ReadLine();
            Console.Write("Position : "); Re._position = Console.ReadLine();
            Console.Write("City : "); Re._city = Console.ReadLine();
            Console.Write("Sex : "); Re._sex = Console.ReadLine();
            Console.Write("Tehsil : "); Re._education = Console.ReadLine();
            Console.Write("Ish Tecrubesi : "); Re._workExperience = Console.ReadLine();
            Console.Write("Minimum salary : "); Re._minSalary = int.Parse(Console.ReadLine());
            Console.Write("Name : "); Re._name = Console.ReadLine();
            Console.Write("Surname : "); Re._surname = Console.ReadLine();
            Console.Write("Yash : "); Re._age = short.Parse(Console.ReadLine());
            Console.Write("Ozum haqqinda : "); Re._about = Console.ReadLine();
            Console.Write("Bacariglar : "); Re._skills = Console.ReadLine();
            //Console.Write("Elanin tarixi : ");
            Re._date = new();
            //Console.Write("Bitme tarixi : ");
            Re._dateToEnd = Re._date.AddMonths(1);


            while (true)
            {
                if (VarifationCode(Re._email))
                {
                    Employees.Add(Re); break;
                }
                else
                {
                    Console.Write("Kodu yeniden gondermemizchun yeniden daxil edin Email : "); Re._email = Console.ReadLine(); VarifationCode(Re._email);
                }

            }

            var xml = new XmlSerializer(typeof(List<Employee>));   
            using FileStream Fs = new FileStream("Employees1.xml", FileMode.Append, FileAccess.Write);
            xml.Serialize(Fs, Employees);
        }



        /////////// VAKANSIYA YERLESHDIRILMESI 

        
        public void CreateVacancy()
        {
            Employer Ve = new();

            Ve._id = Guid.NewGuid();
            Console.Write("Email : "); Ve._email = Console.ReadLine();
            Console.Write("Phone : "); Ve._phone = Console.ReadLine();
            Console.Write("Kategory : "); Ve._category = Console.ReadLine();
            Console.Write("Position : "); Ve._position = Console.ReadLine();
            Console.Write("City : ");
            List<Cities> a = new();
            Ve._city = Console.ReadLine();
            Console.Write("Sex : "); Ve._sex = Console.ReadLine();
            Console.Write("Tehsil : "); Ve._education = Console.ReadLine();
            Console.Write("Ish Tecrubesi : "); Ve._workExperience = Console.ReadLine();
            Console.Write("Minimum salary : "); Ve._minSalary = int.Parse(Console.ReadLine());
            Console.Write("Maximum salary : "); Ve._maxSalary = int.Parse(Console.ReadLine());
            Console.Write("Minimum Yash : "); Ve._minAge = short.Parse(Console.ReadLine());
            Console.Write("Maximum Yash : "); Ve._maxAge = short.Parse(Console.ReadLine());
            Console.Write("Telebler : "); Ve._requirements = Console.ReadLine();

            Console.Write("Ish Haqqinda : "); Ve._aboutWork = Console.ReadLine();

            Console.Write("Shirket Adi : "); Ve._nameOfCompany = Console.ReadLine();
            Console.Write("Elaqedar Shexs : "); Ve._elaqedarShexs = Console.ReadLine();


            Ve._date = new();
            Ve._dateToEnd = Ve._date.AddMonths(1);

            while (true)
            {
                if (VarifationCode(Ve._email))
                {
                    Employers.Add(Ve); break;
                }
                else
                {
                    Console.Write("Email : "); Ve._email = Console.ReadLine(); VarifationCode(Ve._email);
                }

            }

            var xml = new XmlSerializer(typeof(List<Employer>));    
            using FileStream Fs = new FileStream("Employers1.xml", FileMode.Append, FileAccess.Write);
            xml.Serialize(Fs, Employers);
        }

        




        ///////// Log in zamani  VARIFATION CODE Gonderilmesi ...........


        public bool VarifationCode(string email)
        {
            //bool check3 = true;
            while (true)
            {
                Console.Clear();
                string sms = "Please , Include the varification code that We just will send your Email address .    ";
                foreach (var let in sms) { Console.Write(let); Thread.Sleep(15); }


                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Random rnd = new Random();
                int random_code = rnd.Next(100000, 999999);

                var fromAddress = new MailAddress("mahamguziyev@gmail.com", "maham1902");
                var toAddress = new MailAddress(email);
                const string fromPassword = "wlfejqccuyomzrpp";
                const string subject = "JobSearch.az Code ";
                string body = random_code.ToString();

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                while (true)
                {
                    int verifcation_code;
                    Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\n\n\t\t\tVerification Code: ");
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                    verifcation_code = int.Parse(Console.ReadLine());
                    if (verifcation_code == random_code)
                    {
                        Console.Clear();
                        //check3 = false;
                        return true;
                        //Employees.Add(a);


                        //break;
                    }
                    else
                    {
                        return false;
                        Console.Write("\n /* Error Warning :   \n");
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Verification Code is Wrong !!!");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("=========================================");
                            Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); //continue;
                        }
                    }

                
            }
        }
















    }
    //=================================================================================================
    //============================================PARTIAL CLASSSSSSSSS=================================
    //=================================================================================================

    public partial class CiteDataBase : IDeaktifEdenInterface 
    {

        public partial void DeleteVacancy()
        {
            ShowAllVacancies(); 
            Console.Write("\n\n\nSileceyiniz vakansiyanin ID sini daxil edin : ");
            string sil = Console.ReadLine();    
            foreach (var vak in Employers)
            {
                if (vak._id.ToString()  == sil) { Employers.Remove(vak); return; }
            }
            Console.Write("\n\n\nEnter any key for go back : "); Console.ReadKey(true);
        }


        public partial void DeleteCV()
        {
            ShowAllCVler();
            Console.Write("\n\n\nSileceyiniz CV nin ID sini daxil edin : ");
            string sil = Console.ReadLine();
            foreach (var cv in Employees)
            {
                if (cv._id.ToString()  == sil) { Employees.Remove(cv); return; }
            }
            Console.Write("\n\n\nEnter any key for go back : ");     Console.ReadKey(true);
        }

        ///>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
        ///  Print

        public partial void ShowAllVacancies()
        {
            Console.Clear();
            foreach (var a in Employers)
            {
                if (a._aktiv == true && a._isAccept == true) Console.WriteLine(a);
                for (int n = 1; n < 50; n++)
                {
                    Console.Write("=");
                }
                Console.WriteLine();
            }


        }

        public partial void ShowAllCVler()
        {
            Console.Clear();
            foreach (var a in Employees)
            {
                if (a._aktiv == true && a._isAccept == true) Console.WriteLine(a);
                for (int n = 1; n < 50; n++)
                {
                    Console.Write("=");
                }
                Console.WriteLine();
            }

        }

       


        ///>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// kategoriye gore vakansiya ve ya CVlerin print olunmasi :
        public partial void ShowVacAboutThisCat(string category)
        {
            foreach (var vac in Employers)
            {
                if (vac._category == category) { if (vac._aktiv == true) Console.WriteLine(vac); }
            }
        }


        public partial void ShowCVAboutThisCat(string category)
        {
            foreach (var vac in Employees)
            {
                if (vac._category == category) { if (vac._aktiv == true) Console.WriteLine(vac); }
            }
        }




        ///>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///   Sechilmish City-e gore vakansiya ve CVlerin goruntulenmesi

        //public void showVacancietCurrentCity(Cities city)
        public partial void showVacancietCurrentCity(string city)
        {
            foreach (var vac in Employers)
            {
                if (vac._city == city) { if (vac._aktiv == true) Console.WriteLine(vac); }
            }
        }

        public partial void showCvCurrentCity(string city)
        {
            foreach (var vac in Employees)
            {
                if (vac._city == city)
                {
                    if (vac._aktiv == true) Console.WriteLine(vac);
                }
            }
        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// Shirketin vakansiyalarini siralamak

        public partial void ShowVacanciesCurrentCompany(string company)
        {
            foreach (var vac in Employers)
            {
                if (vac._nameOfCompany == company)
                {
                    { if (vac._aktiv == true) Console.WriteLine(vac); }
                }
            }
        }


        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>...

        public partial void showVacanciesWithThisSalary(int minsalary)
        {
            foreach (var vac in Employers)
            {
                if (vac._minSalary > minsalary)
                {
                    { if (vac._aktiv == true) Console.WriteLine(vac); }
                }
            }
        }
        public partial void showCVlerWithThisSalary(int minsalary)
        {
            foreach (var vac in Employees)
            {
                if (vac._minSalary > minsalary)
                {
                    { if (vac._aktiv == true) Console.WriteLine(vac); }
                }
            }
        }
    }

}








































//
/*
 
 public void VarifationCode (Employee a)
        {
            bool check3 = true;
            while (check3)
            {
                Console.Clear();
                string sms = "Please , Include the varification code that We just will send your Email address .    ";
                foreach (var let in sms) { Console.Write(let); Thread.Sleep(15); }


                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                Random rnd = new Random();
                int random_code = rnd.Next(100000, 999999);

                var fromAddress = new MailAddress("mahamguziyev@gmail.com", "maham1902");
                var toAddress = new MailAddress(a._email);
                const string fromPassword = "ynxwoxlhgjpwcjsc";
                const string subject = "JobSearch.az Code ";
                string body = random_code.ToString();

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                while (true)
                {
                    int verifcation_code;
                    Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\n\n\t\t\tVerification Code: ");
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                    verifcation_code = int.Parse(Console.ReadLine());
                    if (verifcation_code == random_code)
                    {
                        Console.Clear();
                        check3 = false;
                        Employees.Add(a);
                        

                        break;
                    }
                    else
                    {
                        Console.Write("\n /* Error Warning :   \n");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Verification Code is Wrong !!!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================");
                        Console.WriteLine("Enter any char for Go Back..."); Console.ReadKey(true); continue;
                    }

                }
            }
        } 
 */