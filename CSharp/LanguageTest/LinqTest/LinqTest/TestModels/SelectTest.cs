using LinqTest.DataModels;
using LinqTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest.TestModels
{
    public class SelectTest
    {
        List<Person> mPeople;
        List<MainLanguage> mLanguages;
        public SelectTest()
        {
            mPeople = DataGenerateHelper.MakePersonTemplateData();
            mLanguages = DataGenerateHelper.MakeLanguageTemplateData();
        }

        public void DataSelectTest()
        {
            Console.WriteLine("LINQ를 이용한 SelectCode");
            // Test0: 전통적인 테스트
            for (int i = 0; i < mPeople.Count(); i++)
            {
                Console.WriteLine(mPeople[i].ToString());
            }

            foreach (var person in mPeople)
            {
                Console.WriteLine(person.ToString());
            }

            // Test1: LINQ를 이용한 SelectCode
            var result = from person in mPeople
                         select person;

            result.ToList().ForEach((elem) => Console.WriteLine(elem.ToString()));

            // 동일한 코드를 Extention Method로도 구현 가능
            // LINQ Code역시 컴파일 시점에서는 Extention Method로 변경된다. 
            //mPeople.Select((elem) => elem).ToList().ForEach((elem) => Console.WriteLine(elem.ToString()));


            Console.WriteLine("컬렉션 내의 특정 변수 선택");
            // Test2: 컬렉션 내의 특정 변수를 가져오는 것도 가능하다. 
            var nameResult = from person in mPeople
                             select person.Name;

            nameResult.ToList().ForEach(elem => Console.WriteLine(elem));
            
            // 동일한 코드를 Extention Method로 구현 가능
            //mPeople.Select((elem) => elem.Name).ToList().ForEach(elem => Console.WriteLine(elem));

            // 동일한 코드를 익명함수를 이용해서도 사용 가능하다. 
            //var nameResult2 = from person in mPeople
            //                  select new { Name = person.Name, Year = DateTime.Now.AddYears(-person.Age).Year };
            //foreach (var item in nameResult2)
            //{
            //    Console.WriteLine(item.Name + "-" + item.Year);
            //}

            // 동일한 코드를 Exteion Method로 구현 가능하다
            //mPeople.Select((elem) => new { Name = elem.Name, Year = DateTime.Now.AddYears(-elem.Age).Year }).ToList().ForEach(
            //    (elem) => Console.WriteLine(elem.Name + "-" + elem.Year));
        }
        public void DataSelectWhereTest()
        {
            Console.WriteLine("LINQ를 이용한 조건부 Select Code");
            // Test1: LINQ를 이용한 Where SelectCode
            var ageOver30 = from person in mPeople
                            where person.Age > 30
                            select person;
            foreach (var item in ageOver30)
            {
                Console.WriteLine(item);
            }

            //동일한 코드를 Extention Method로 구현 가능
            //mPeople.Where((elem) => elem.Age > 30).ToList().ForEach((elem) => Console.WriteLine(elem));
        }

        public void DataSelectOrderByTest()
        {
            Console.WriteLine("LINQ를 이용한 Orderby Select Code");
            // Test1: LINQ를 이용한 OrderBy SelectCode
            var ageSort = from personData in mPeople
                         orderby personData.Age
                         select personData;

            ageSort.ToList().ForEach(elem => Console.WriteLine(elem));

            //동일한 코드를 Extention Method로 구현 가능
            //mPeople.OrderBy(elem => elem.Age).ToList().ForEach(elem => Console.WriteLine(elem));


            //Descending Code
            var ageSortDesc = from personData in mPeople
                              orderby personData.Age descending
                              select personData;
            ageSortDesc.ToList().ForEach(elem => Console.WriteLine(elem));
            //mPeople.OrderByDescending(elem => elem.Age).ToList().ForEach(elem => Console.WriteLine(elem));
        }

        public void DataSelectGroupByTest()
        {
            Console.WriteLine("LINQ를 이용한 Groupby Select Code");
            // Test1: LINQ를 이용한 Groupby Select Code
            //var addGroup = from person in mPeople
            //               group person by person.
        }
    }
}
