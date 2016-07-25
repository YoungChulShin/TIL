using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LamdaTest
{
    class Program
    {
        #region 생성된 Delegate를 이용
        // 1.0  문법: Delegate를 이용한 표현
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(ThreadFunc);
        //    thread.Start();
        //    thread.Join();

        //    Console.ReadLine();
        //}

        //private static void ThreadFunc(object a)
        //{
        //    Console.WriteLine("Test Function called");
        //}


        // 2.0 문법: 익명 함수를 이용한 표현
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(
        //        delegate (object a)
        //        {
        //            Console.WriteLine("Test Function called");
        //        });
        //    thread.Start();
        //    thread.Join();

        //    Console.ReadLine();
        //}

        // 3.0 문법: 람다식을 이용한 표현
        //static void Main(string[] args)
        //{
        //    Thread thread = new Thread(() => Console.WriteLine("Test Function called"));
        //    thread.Start();
        //    thread.Join();

        //    Console.ReadLine();
        //}

        #endregion

        #region Delegate를 생성
        //delegate int AddFuncDelegate(int a, int b);
        // 1.0  문법: Delegate를 이용한 표현
        //static void Main(string[] args)
        //{
        //    AddFuncDelegate AddFunc = new AddFuncDelegate(Add);

        //    Console.WriteLine(AddFunc(1, 2));
        //    Console.WriteLine(AddFunc(4, 5));

        //    Console.ReadLine();
        //}

        //private static int Add(int a, int b)
        //{
        //    return a + b;
        //}


        // 2.0 문법: 익명 함수를 이용한 표현
        //static void Main(string[] args)
        //{
        //    AddFuncDelegate AddFunc = delegate (int a, int b)
        //     {
        //         return a + b;
        //     };

        //    Console.WriteLine(AddFunc(1, 2));
        //    Console.WriteLine(AddFunc(4, 5));

        //    Console.ReadLine();
        //}

        // 3.0 문법: 람다식을 이용한 표현
        //static void Main(string[] args)
        //{
        //    AddFuncDelegate AddFunc = (x, y) => x + y;

        //    Console.WriteLine(AddFunc(1, 2));
        //    Console.WriteLine(AddFunc(4, 5));

        //    Console.ReadLine();
        //}

        #endregion

        #region 조금 더 간단히 표시
        // Delegate 구현하는게 너무 귀찮타. 
        static void Main(string[] args)
        {
            Func<int, int, int> AddFunc = (x, y) => x + y;

            Console.WriteLine(AddFunc(1, 2));
            Console.WriteLine(AddFunc(4, 5));

            Console.ReadLine();
        }

        #endregion
    }
}
