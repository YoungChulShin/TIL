using LinqTest.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest.Helpers
{
    public static class DataGenerateHelper
    {
        public static List<Person> MakePersonTemplateData()
        {
            return new List<Person>
                {
                    new Person { Name = "Tom", Age = 63},
                    new Person { Name = "Winnie", Age = 40},
                    new Person { Name = "Anders", Age = 47},
                    new Person { Name = "Hans", Age = 25},
                    new Person { Name = "Eureka", Age = 32},
                    new Person { Name = "Hawk", Age = 15}
                };
        }

        public static List<MainLanguage> MakeLanguageTemplateData()
        {
            return new List<MainLanguage>
                {
                    new MainLanguage { Name = "Anders", Language = "Delphi"},
                    new MainLanguage { Name = "Anders", Language = "C#"},
                    new MainLanguage { Name = "Tom", Language = "C++"},
                    new MainLanguage { Name = "Hans", Language = "Java"},
                    new MainLanguage { Name = "Winnie", Language = "Python"},
                    new MainLanguage { Name = "Anders", Language = "Delphi"}
                };
        }
    }
}
