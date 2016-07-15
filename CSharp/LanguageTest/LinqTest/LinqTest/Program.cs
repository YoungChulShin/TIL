using LinqTest.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectTest selectTest = new SelectTest();
            //selectTest.DataSelectTest();
            //selectTest.DataSelectWhereTest();
            selectTest.DataSelectOrderByTest();
            Console.ReadLine();
        }
    }
}
