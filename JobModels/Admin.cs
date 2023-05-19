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
    public  class Admin
    {
        [XmlAttribute]
        public string Name;
        [XmlAttribute]  public string Surname;
        [XmlAttribute] public  string Email;
        [XmlAttribute] public string Phone;  

        public Admin (string name, string surname, string email, string phone)
        {
            Name = name;   Surname = surname;    Email = email;    Phone = phone;
        }
        public Admin() { }
        public void showAllVacancies()
        {
           // for(var a in )
           // {

           // }
        }

        public List<Employee> Employees = new();
        public List<Employee> GozleyenCVler = new() { };
        public void showWaitCVler()
        {
            bool qebul;
            foreach(var a in GozleyenCVler)
            {
                qebul = false;
                Console.WriteLine(a._email );
                Console.WriteLine("Are U apply it ? ");
                dynamic apply = Console.ReadKey();
                if(apply.Key == ConsoleKey .Enter) { Employees.Add(a);   GozleyenCVler.Remove(a); }
            }
        }

        public List<Employer> Employers = new();
        public List<Employer> GozleyenVakansiyalar = new();
        public void showWaitVacancies()
        {
            bool qebul;
            foreach(var a in GozleyenVakansiyalar)
            {
                Console.WriteLine(a._email);
                Console.WriteLine("Are U apply it ? ");
                dynamic apply = Console.ReadKey();
                if (apply.Key == ConsoleKey.Enter) { Employers.Add(a); GozleyenVakansiyalar.Remove(a); }
            }
        }


        ///////////////////////////////////////////////////
        ///HAKKIMIZDAAAAA

        public void Hakkimizda()
        {
            string Qaydalar = "Layihə haqqında:\r\n\r\nJobSearh.Az - əmək bazarının bütün iştirakçılarının faydalana biləcəyi, dəqiq və sürətli iş və ya işçi axtarışı üçün nəzərdə tutulmuş onlayn platformadır." +
                         " Layihə istifadəçilərə geniş iş elanı və CV bazasından rahat istifadə imkanı yaradır.\r\n\r\n" +
                         "Layihə fəaliyyətinə 2008-ci ildə başlayıb və hal-hazırda Azərbaycanın əmək bazarında aparıcı onlayn resuslarından biridir.\r\n\r\n" +
                         "Boss.Az - işədüzəltmə şirkəti deyil. Layihənin məqsədi işə götürən ilə potensial işçi arasında vasitəçisiz və operativ əlaqə imkanı yaratmaqdır.\r\n\r\n" +
                         "Elanların yerləşdirilməsi:\r\n\r\nJobSearch.Az - istifadəçilərə sayta iş elanı və CV yerləşdirmək imkanı yaradır. " +
                         "Hər istifadəçi ay ərzində ödənişsiz olaraq bir iş elanı və bir CV yerləşdirə bilər.\r\n\r\nBizimlə əlaqə:\r\n\r\n" +
                         "Biz layihənin inkişafı və təkmilləşdirilməsi üçün əlimizdən gələni edirik və sizin bu haqda olan fikirlərinizi və təkliflərinizi dinləməyə hazırıq. " +
                         "Bizimlə əlaqə yaratmaq üçün boss@boss.az e-mail ünvanına yaza və ya (050) 528-44-97 telefon nömrəsinə zəng edə bilərsiniz.";
            foreach (var el in Qaydalar) { Console.Write(el); Thread.Sleep(10); }
            Console.WriteLine("\n\nEnter any key to go Back");
                        Console.ReadKey(true);
        }












        ///////////////////////////////// CV yerleshdirilmesi zamani ve ya Vakansiya paylashilmasi zamani Aid QAYDALAR PRINT
        public void QaydalarCout()
        {
            string Qaydalar = "Bir vakansiyanın 30 gün müddətinə yerləşdirilməsi pulsuz həyata keçirilir.\r\n" +
                                "Vakansiya yalnız Azərbaycan daxilində olan işləri əhatə etməlidir.\r\n" +
                                "Vakansiya haqqında elanın ən qısa müddətdə dərc olunması üçün formanın doldurulmasına dair bütün təlimatlara ciddi riayət olunmalıdır." +
                                " Səliqəsiz doldurulmuş formalar redaktəyə məruz qalacaq və dərhal dərc olunmayacaq.\r\n" +
                                "Elanların yalnız baş (BÖYÜK) hərflərlə və ya başqa əlifba ilə (translitlə) yazılması qadağandır. Elan bütünlüklə bir dildə olmalıdır.\r\n" +
                                "Şirkətin adı olan sütunda şirkətin rəsmi, hüquqi adı, həmin müəssisə holdinq tərkibindədirsə, holdinqin adı və şirkətin fəaliyyət istiqaməti (növü) qeyd olunmalıdır.\r\n" +
                                "Əlaqələr yazılan sütunda aktiv şəhər telefonlarının nömrələri və şirkətin korporativ elektron ünvanları qeyd olunmalıdır.\r\n" +
                                "İstifadəçi 5 və 6-cı bəndlərə riayət etmədikdə, elan ödənişli əsaslarla qəbul edilir.\r\n" +
                                "Tibb müəssisələrinin elanları və ya tibbi tərkibli, alış-veriş haqqında, o cümlədən saytda onlayn-satışlı elanlar pulludur.\r\n" +
                                "«Əmək haqqı» sütununun doldurulması mütləqdir, məbləğ AZN-lə göstərilməlidir. " +
                                "Əgər əmək haqqı 500 AZN-ə qədərdirsə, əmək haqqı diapazonu 200 AZN-i; 1000 AZN-ə qədərdirsə 300 AZN-i; 2000 AZN-ə qədərdirsə, 500 AZN-i aşmamalıdır.\r\n" +
                                "Dərc olunmuş elanda əlaqə nömrələrinin, vakansiyanın adının dəyişdirilməsi qadağandır.";
            foreach (var el in Qaydalar) { Console.Write(el); Thread.Sleep(10); }
        }

    }
    
}
