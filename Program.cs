using jobsearch.az.JobModels;
using System.Runtime.Intrinsics;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace jobsearch.az
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /////////////////////////////////////Sheherler uchun Enum qi hiziruben seriya numberzda reqqirsa
            ///umumiyyetle staj ve ya diger meseleleri de Enumda qura bilerem
            int row1 = 0;
            DateOnly a;
            Admin U = new Admin() { };
            Employee E1 = new(Guid.NewGuid(), "mahamguziyev@gmail.com", "0505284497", "Maliyye", "Muhasibatlig", "Zaqatala", "kishi", "tam ali",
                "3-5 il", 900, "maham", "guziyev", 23, "Dun vuqudaa", "coxli bacariglar", a, true);
            Employee E2 = new(Guid.NewGuid(), "maqaquziyev@gmail.com", "0505284497", "Informasiya", "IT", "baki", "kishi", "ali",
               "5 ilden cox", 1500, "Justin", "Poirer", 23, "haqqimdaozumem", "IT", a, true);

            Employer ER1 = new()
            {
                _aboutWork = "ishlemelisen",
                _category = "Kateqoriyaa",
                _education = "ali",
                _city = "baki",
                _elaqedarShexs = "yene ozum",
                _workExperience = "1-3 il",
                _email = "mahamguziyev@gmail.com",
                _maxAge = 34,
                _minAge = 20,
                _maxSalary = 1500,
                _minSalary = 800,
                _phone = "0502222222",
                _nameOfCompany = "MahamTelecom",
                _position = "Chilinger",
                _requirements = "agilli olsun",
                _sex = "kishi",
                _isAccept = true
            };
            Employer ER2 = new()
            {
                _aboutWork = "Haldi haldi",
                _category = "Kateqoriyalari da bir enuma yiga bilerem",
                _education = "ali",
                _city = "baki",
                _elaqedarShexs = "jeqi dun",
                _workExperience = "3-5 il",
                _email = "mahamguziyev@gmail.com",
                _maxAge = 55,
                _minAge = 22,
                _maxSalary = 1000,
                _minSalary = 6000,
                _phone = "0502222222",
                _nameOfCompany = "KonsisGroup",
                _position = "Mechanic",
                _requirements = "be clever",
                _sex = "kishi",
                _isAccept = true
            };


            Employee E3 = new(); E2._education = "ama";
            CiteDataBase C = new(); C.AddEmployees(E1); C.AddEmployers(ER1);
            C.AddEmployees(E2); C.AddEmployees(E3); C.AddEmployers(ER2);

            Admin A = new();

            // C.JSaxronit();

            //XmlSerializer serializer = new XmlSerializer(typeof(Employee));

            // XML dosyasını oluşturmak için StreamWriter kullanıyoruz
            //using (StreamWriter writer = new StreamWriter("dataEmployees.xml"))
            //{
            //    serializer.Serialize(writer, C.Employees );
            //}

            var xml = new XmlSerializer(typeof(List<Employer>));
            using FileStream Fs = new FileStream("Employers.xml", FileMode.OpenOrCreate, FileAccess.Write);
            xml.Serialize(Fs, C.Employers);



            //var U2 = new User(Guid.NewGuid(), "Evgeny", "Tiersen", "Evgeny@gmail.com", "Maham9999", 1999, 5, 14);

            //Post P = new Post(Guid.NewGuid(), "Hi I m Maham", "Mamed");
            ///Post P1 = new(Guid.NewGuid(), "Hay loremipsumdolorset", "IamMosh");
            //var P2 = new Post(Guid.NewGuid(), "Mariam itsFoggy day today", "IamEvgeny");

            //Admin A1 = new Admin(Guid.NewGuid(), "xxtentacion", "Levy", "Tentacion@gmail.com", "Yasmin9999", 1999, 5, 14);


            //DataBase D1 = new DataBase(); D1.AddUser(U); D1.AddUser(U1); D1.AddUser(U2);

            //D1.AddPost(P); D1.AddPost(P1); D1.AddPost(P2);

            //D1.AddAdmin(A1); D1.AddAdmin(A1);







            short choose1 = 0; bool isTrue1 = true;
            while (isTrue1)
            {

                Console.Clear();
                Console.WriteLine("Maham's Jobseeker \n");
                if (choose1 == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Blue; }
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                Console.Write("Is Elanlari \t");
                if (choose1 == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Blue; }
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                Console.Write("Is Axtaranlar \t");
                if (choose1 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Blue; }
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                Console.Write("Haqqimizda \t");
                if (choose1 == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Blue; }
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                Console.Write("Login \t");
                //if (choose1 == 4) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Blue; }
                //else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                //Console.WriteLine("ELan Yerleshdir");

                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

                dynamic one = Console.ReadKey();
                if ((one.Key == ConsoleKey.UpArrow || one.Key == ConsoleKey.LeftArrow) && choose1 != 0) { choose1--; }
                else if ((one.Key == ConsoleKey.DownArrow || one.Key == ConsoleKey.RightArrow) && choose1 != 3) { choose1++; }

                else if (one.Key == ConsoleKey.Enter)
                {
                    if (choose1 == 0)
                    {                          // Burada ish elanlari siralanacah
                        bool davam2 = true;
                        short choose2 = 0;
                        while (davam2)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\t\t\t\t\tISH ELANLARI ....\n\n");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

                            if (choose2 == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine("Tum vakansiyalar ....");
                            if (choose2 == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine("Her hansi mesele uzre axtarish ed....");
                            if (choose2 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine("Go Back....\n\n");

                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                            // if (choose2 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            // else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            // Console.WriteLine(" ....");
                            dynamic sec = Console.ReadKey();
                            if (sec.Key == ConsoleKey.UpArrow && choose2 != 0) { choose2--; }
                            else if (sec.Key == ConsoleKey.DownArrow && choose2 != 2) { choose2++; }
                            else if (sec.Key == ConsoleKey.Enter)
                            {
                                if (choose2 == 0)
                                {
                                    C.ShowAllVacancies();
                                    Console.WriteLine("Her hansi vakansiyaya muraciet etmek isterseniz onun 'A' ve ya 'a' , " +
                                                "\n  geri donmek isterseniz istenilen diger synmbol  daxil ede bilersiniz");
                                    dynamic ide = Console.ReadKey();

                                    if (ide.Key == ConsoleKey.A)
                                    {
                                        Console.Write("\nMuraciet edeceyiniz vakansiyanin Id kodunu daxil edin : ");
                                        string ID = Console.ReadLine();
                                        //C.ApplyVacancy(ID);
                                        C.ApplyCv(ID, C.Employers[1]);
                                    }
                                    else { continue; }

                                }

                                else if (choose2 == 1)
                                {
                                    short choose3 = 0;
                                    bool davam3 = true;
                                    while (davam3)
                                    {
                                        Console.Clear();
                                        Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("\t\t\t\t\tNeye esasen sechim edeceyinizi sechin ....\n\n");
                                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

                                        if (choose3 == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Kategoriyaya gore ....");
                                        if (choose3 == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Shehere gore....");
                                        if (choose3 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Maasha esasen....");
                                        if (choose3 == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Go Back....");

                                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                                        dynamic sec1 = Console.ReadKey();
                                        if (sec1.Key == ConsoleKey.UpArrow && choose3 != 0) { choose3--; }
                                        else if (sec1.Key == ConsoleKey.DownArrow && choose3 != 3) { choose3++; }
                                        else if (sec1.Key == ConsoleKey.Enter)
                                        {
                                            if (choose3 == 0)
                                            {
                                                Console.Write("Category daxil ed :"); string Cat = Console.ReadLine();
                                                C.ShowVacAboutThisCat(Cat);
                                                Console.WriteLine("Her hansi vakansiyaya muraciet etmek isterseniz onun 'A' ve ya 'a' , " +
                                                "\n  geri donmek isterseniz istenilen diger synmbol  daxil ede bilersiniz");
                                                dynamic ide = Console.ReadKey();

                                                if (ide.Key == ConsoleKey.A)
                                                {
                                                    Console.Write("\nMuraciet edeceyiniz vakansiyanin Id kodunu daxil edin : ");
                                                    string ID = Console.ReadLine();
                                                    //C.ApplyVacancy(ID);
                                                    C.ApplyCv(ID, C.Employers[1]);
                                                }
                                                else { continue; }


                                            }
                                            else if (choose3 == 1)
                                            {
                                                Console.Write("Sheheri daxil ed : "); string City = Console.ReadLine();
                                                C.showVacancietCurrentCity(City);
                                                Console.WriteLine("Her hansi vakansiyaya muraciet etmek isterseniz onun 'A' ve ya 'a' , " +
                                                "\n  geri donmek isterseniz istenilen diger synmbol  daxil ede bilersiniz");
                                                dynamic ide = Console.ReadKey();

                                                if (ide.Key == ConsoleKey.A)
                                                {
                                                    Console.Write("\nMuraciet edeceyiniz vakansiyanin Id kodunu daxil edin : ");
                                                    string ID = Console.ReadLine();
                                                    //C.ApplyVacancy(ID);
                                                    C.ApplyCv(ID, C.Employers[1]);
                                                }
                                                else { continue; }


                                                //Console.Write("Cixmaqchun her hansi bir symbol daxil edin : "); Console.ReadKey(true);
                                            }

                                            else if (choose3 == 2)
                                            {
                                                Console.Write("ENter min maash : "); int minMaash = int.Parse(Console.ReadLine());

                                                C.showVacanciesWithThisSalary(minMaash);
                                                Console.WriteLine("Her hansi vakansiyaya muraciet etmek isterseniz onun 'A' ve ya 'a' , " +
                                                "\n  geri donmek isterseniz istenilen diger synmbol  daxil ede bilersiniz");
                                                dynamic ide = Console.ReadKey();

                                                if (ide.Key == ConsoleKey.A)
                                                {
                                                    Console.Write("Muraciet edeceyiniz vakansiyanin Id kodunu daxil edin : ");
                                                    string ID = Console.ReadLine();
                                                    //C.ApplyVacancy(ID);
                                                    C.ApplyCv(ID, C.Employers[1]);
                                                }
                                                else { continue; }

                                                //Console.Write("Cixmaqchun her hansi bir symbol daxil edin : "); Console.ReadKey(true);
                                            }
                                            else break;
                                        }
                                        else continue;
                                    }
                                }
                                else break;
                            }
                            else { continue; }





                            //Console.WriteLine("");



                            //Console.WriteLine(" \n\nKategoriyaya gore sechim edmek istediyiniz halda 'C' ve ya 'c' daxil ede," +
                            // "Beyendiyiniz vakansiyaya muraciet etmek uchun onun id kodunu daxil ede, ve ya " +
                            // "Cixmaq istediyiniz halda 'E'  ve ya 'e' daxil ede bilersiniz... ");




                            // Bundan sonra hemin Funksiya cagirilacag

                            // Console.WriteLine("\n\nEnter any key to go Back");
                            // Console.ReadKey(true);
                        }

                    }
                    else if (choose1 == 1)
                    {
                        // Burada ish axtaranlar siralanacah
                        Console.WriteLine("\t\t\t\t\tISH Arayanlar ....\n\n\n");
                        //C.ShowAllCVler();
                        bool davam2 = true;
                        short choose2 = 0;
                        while (davam2)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\t\t\t\t\tISH Axtaranlar ....\n\n");
                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

                            if (choose2 == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine("Tum CV ler ....");
                            if (choose2 == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine("Her hansi mesele uzre CV ishchi axtar....");
                            if (choose2 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            Console.WriteLine("Go Back....\n\n");

                            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                            // if (choose2 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                            // else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                            // Console.WriteLine(" ....");
                            dynamic sec = Console.ReadKey();
                            if (sec.Key == ConsoleKey.UpArrow && choose2 != 0) { choose2--; }
                            else if (sec.Key == ConsoleKey.DownArrow && choose2 != 2) { choose2++; }
                            else if (sec.Key == ConsoleKey.Enter)
                            {
                                if (choose2 == 0)
                                {
                                    C.ShowAllCVler();
                                    Console.WriteLine("Her hansi CV sahibine muraciet etmek isterseniz 'A' ve ya 'a' giriniz" +
                                              "\n geri donmekchin istenilen symbol daxil ede bilersiniz");
                                    dynamic ide = Console.ReadKey();

                                    if (ide.Key == ConsoleKey.A)
                                    {
                                        Console.Write("\nHansi namizedi devet etmek isterseniz ID sini daxil edin : ");
                                        string ID = Console.ReadLine();

                                        C.ApplyVacancy(ID, C.Employees[0]);
                                    }
                                    else { continue; }
                                }

                                else if (choose2 == 1)
                                {
                                    short choose3 = 0;
                                    bool davam3 = true;
                                    while (davam3)
                                    {
                                        Console.Clear();
                                        Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("\t\t\t\t\tNeye esasen sechim edeceyinizi sechin ....\n\n");
                                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;

                                        if (choose3 == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Kategoriyaya gore ....");
                                        if (choose3 == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Shehere gore....");
                                        if (choose3 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Maasha esasen....");
                                        if (choose3 == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                        else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                        Console.WriteLine("Go Back....");

                                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                                        dynamic sec1 = Console.ReadKey();
                                        if (sec1.Key == ConsoleKey.UpArrow && choose3 != 0) { choose3--; }
                                        else if (sec1.Key == ConsoleKey.DownArrow && choose3 != 3) { choose3++; }
                                        else if (sec1.Key == ConsoleKey.Enter)
                                        {
                                            if (choose3 == 0)
                                            {
                                                Console.Write("Category daxil ed :"); string Cat = Console.ReadLine();
                                                C.ShowCVAboutThisCat(Cat);
                                                Console.WriteLine("Her hansi CV sahibine muraciet etmek isterseniz 'A' ve ya 'a' giriniz" +
                                              "\n geri donmekchin istenilen symbol daxil ede bilersiniz");
                                                dynamic ide = Console.ReadKey();

                                                if (ide.Key == ConsoleKey.A)
                                                {
                                                    Console.Write("\nHansi namizedi devet etmek isterseniz ID sini daxil edin : ");
                                                    string ID = Console.ReadLine();
                                                    C.ApplyVacancy(ID, C.Employees[0]);
                                                }
                                                else { continue; }

                                            }
                                            else if (choose3 == 1)
                                            {
                                                Console.Write("Sheheri daxil ed : "); string City = Console.ReadLine();
                                                C.showCvCurrentCity(City);
                                                Console.WriteLine("Her hansi CV sahibine muraciet etmek isterseniz 'A' ve ya 'a' giriniz" +
                                              "\n geri donmekchin istenilen symbol daxil ede bilersiniz");
                                                dynamic ide = Console.ReadKey();

                                                if (ide.Key == ConsoleKey.A)
                                                {
                                                    Console.Write("\nHansi namizedi devet etmek isterseniz ID sini daxil edin : ");
                                                    string ID = Console.ReadLine();
                                                    C.ApplyVacancy(ID, C.Employees[0]);
                                                }
                                                else { continue; }


                                                //Console.Write("Cixmaqchun her hansi bir symbol daxil edin : "); Console.ReadKey(true);
                                            }

                                            else if (choose3 == 2)
                                            {
                                                Console.Write("ENter min maash : "); int minMaash = int.Parse(Console.ReadLine());

                                                C.showCVlerWithThisSalary(minMaash);
                                                Console.WriteLine("Her hansi CV sahibine muraciet etmek isterseniz 'A' ve ya 'a' giriniz" +
                                               "\n geri donmekchin istenilen symbol daxil ede bilersiniz");
                                                dynamic ide = Console.ReadKey();

                                                if (ide.Key == ConsoleKey.A)
                                                {
                                                    Console.Write("\nHansi namizedi devet etmek isterseniz ID sini daxil edin : ");
                                                    string ID = Console.ReadLine();
                                                    C.ApplyVacancy(ID, C.Employees[0]);
                                                }
                                                else { continue; }

                                                //Console.Write("Cixmaqchun her hansi bir symbol daxil edin : "); Console.ReadKey(true);
                                            }
                                            else break;
                                        }
                                        else continue;
                                    }
                                }
                                else break;
                            }
                            else { continue; }





                            //Console.WriteLine("");



                            //Console.WriteLine(" \n\nKategoriyaya gore sechim edmek istediyiniz halda 'C' ve ya 'c' daxil ede," +
                            // "Beyendiyiniz vakansiyaya muraciet etmek uchun onun id kodunu daxil ede, ve ya " +
                            // "Cixmaq istediyiniz halda 'E'  ve ya 'e' daxil ede bilersiniz... ");




                            // Bundan sonra hemin Funksiya cagirilacag

                            // Console.WriteLine("\n\nEnter any key to go Back");
                            // Console.ReadKey(true);
                        }







                        //Console.WriteLine("Enter any key to go Back");
                        //    Console.ReadKey(true);
                    }
                    else if (choose1 == 2)
                    {
                        A.Hakkimizda();
                    }



                    else if (choose1 == 3)
                    {
                        while (true)
                        {
                            Console.Write("\n\nAdminsiniz yoxsa User (A ve ya U daxil edin)    : ");
                            dynamic AU = Console.ReadKey();
                            if (AU.Key == ConsoleKey.A)
                            {
                                int chooseA = 0;

                                while (true)
                                {
                                    Console.Clear();

                                    if (chooseA == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                    Console.WriteLine("Tum Requestleri goruntule ....");
                                    if (chooseA == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                    Console.WriteLine("Requestleri cavablandir....");
                                    if (chooseA == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                    Console.WriteLine("Vakansiya sil....\n\n");
                                    if (chooseA == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                    Console.WriteLine("Go Back....\n\n");

                                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                                    // if (choose2 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                    // else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                    // Console.WriteLine(" ....");
                                    dynamic sec = Console.ReadKey();
                                    if (sec.Key == ConsoleKey.UpArrow && chooseA != 0) { chooseA--; }
                                    else if (sec.Key == ConsoleKey.DownArrow && chooseA != 3) { chooseA++; }
                                    else if (sec.Key == ConsoleKey.Enter)
                                    {
                                        if (chooseA == 0) { C.ShowRequests(); Console.Write("Enter any key for go back : "); Console.ReadKey(true); }
                                        else if (chooseA == 1) C.Accept();
                                        else if (chooseA == 2)
                                        {
                                            ///
                                            int silSechimi = 0;
                                            while (true)
                                            {
                                                Console.Clear();

                                                if (silSechimi == 0) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                                Console.WriteLine("CV silecem ....");
                                                if (silSechimi == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                                Console.WriteLine("Vakansiya silecem....");
                                                if (silSechimi == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                                Console.WriteLine("Go Back....\n\n");


                                                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                                                // if (choose2 == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.DarkBlue; }
                                                // else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; }
                                                // Console.WriteLine(" ....");
                                                dynamic secim = Console.ReadKey();
                                                if (secim.Key == ConsoleKey.UpArrow && silSechimi != 0) { silSechimi--; }
                                                else if (secim.Key == ConsoleKey.DownArrow && silSechimi != 2) { silSechimi++; }
                                                else if (secim.Key == ConsoleKey.Enter)
                                                {
                                                    if (silSechimi == 0) C.DeleteCV();
                                                    else if (silSechimi == 1) C.DeleteVacancy();
                                                    else break;
                                                }
                                                else continue;
                                            }
                                        }
                                        else break;

                                    }
                                    else continue;
                                }
                                break;
                            }
                            else if (AU.Key == ConsoleKey.U)
                            {

                                //Ilk once qaydalar Haqqinda behs olunacag  ve sonda YERLESHdirin butonu olacag

                                A.QaydalarCout();
                                while (true)
                                {
                                    Console.WriteLine("\n\nVakansiya paylashacahsiniz yoxsa CV yerleshdirilecek (muvafiq sahe uchun V ve ya C daxil edin");
                                    dynamic Set = Console.ReadKey();
                                    if (Set.Key == ConsoleKey.V)
                                    {
                                        C.CreateVacancy(); break;
                                    }
                                    else if (Set.Key == ConsoleKey.C)
                                    {
                                        C.CreateCv(); break;
                                    }
                                    else { continue; }
                                }
                                Console.WriteLine("\n\nEnter any key for go back");
                                Console.ReadKey(true);
                                break;
                            }
                            else continue;
                            
                            // ilk once sechim qoyulacagdir ki, Vakansiya paylashacag yoxda CV yerleshdirecey ...  
                            //Burada elan yerleshdirilmesi prosesi bash verecek ve yerleshdirilen elan request olaraq admine gedecey. Qebul ederse vakasiyalara elave olunacah
                            //Admine hemin mesaj gmail olaraq gondermerem belke, gmaili Userler arasindaki ilishkide kullanmam daha mentigli olar mence ...
                            



                            Console.WriteLine("Enter any key to go Back");
                            Console.ReadKey(true); break;
                        }
                    }
                    else if (choose1 == 4)
                    {


                    }
                }
                else { continue; }

            }
        }
    }
}