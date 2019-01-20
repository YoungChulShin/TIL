## Thread
정의
- 명령어를 실행하기 위한 스케줄링 단위
- 프로세스 내부에서 생성할 수 있다

용어
- main thread, primary thread
   - 윈도우는 프로세스를 생성할 때 기본적으로 한개의 스레드를 함께 생성하며 이를 주 스레드라고 한다
- 스레드 문맥(thread context)
   - 스레드는 CPU의 명령어 실행과 관련된 정보를 보관하고 있는데, 이를 스레드 문맥이라고 한다
   - 현재 실행중인 스레드를 다음에 다시 이어서 실행할 수 있도록 CPU>의 환경정보를 스레드 문맥에 저장
   - 운영체제로부터 할당받은 스레드의 문맥 정보를 다시 CPU 내부로 로드해서 마치 스레드가 실행되고 있었던 상태인 것처럼 복원한 다음 일정시간 동안 실행을 계속한다
- 전경 스레드(foreground thread)
   - 프로그램의 종료에 영향을 미치는 스레드
    ```c#
        static void Main(string[] args)
        {
            Thread t = new Thread(ThreadTest.ThreadFunc);
            t.IsBackground = true;  // 배경 스레드로 변경
            t.Start();
            Console.WriteLine("주 스레드 종료");

            //Console.ReadLine();
        }
    ```
- 배경 스레드(background thread)
   - 실행 종료에 영향을 미치지 않는다 


명령어
- Thread.CurrentThread : 실행중인 스레드 자원에 접근
- Join: 주 스레드가 join된 스레드의 실행이 종료될 때까지 대기

공유 스레드
- 기본 상태로 다중 스레드의 실행 순서가 불규칙 하다.<br>
그리고 CPU 1개가 여러개의 스레드를 실행하기 때문에 잘못된 값이 업데이트 될 수도 있다. 
   - 예: 힙 영역 값에 1을 더하는 함수가 2개가 실행되고 있으면, a함수에서 값을 가져와서 1을 더한 값을 힙에 저장하기 전에 b함수가 힙 값을 가져와서 1을 더하고 저장하면 2번의 덧셈이 이루어졌지만 결과적으로는 1만 추가된다
- 이를 위해서는 동기화 작업이 필요하다
- 동기화를 위해서는 Monitor 또는 Lock 기능을 사용
   ```c#
   PrimeNumberTest target = (PrimeNumberTest)inst;
    for (int i = 0; i < 10000; i++)
    {
        // Monitor 이용
        Monitor.Enter(target);
        try
        {
            target.number = target.number + 1;
        }
        finally
        {
            Monitor.Exit(target);
        }

        // Lock 이용
        lock (target)
        {
            target.number++;
        }

        // Interlocked 사용
        Interlocked.Increment(ref target.number);
    }
   ```

Interlocked
- 정의: 원자적 연산(atomic operation)을 할 수 있도록 지원

ThreadPool
- 일회성으로 Thread가 필요할 때 ThreadPool을 이용하면 Thread를 생성해서 실행할 수 있다
- ThreadPool의 경우 Thread가 종료되어도 바로 사라지지 않고 일정 시간이 지나면 사라진다. 이 기간 동안 ThreadPool에 생성 요청이 들어오면 대기중인 Thread를 재 사용할 수 있다
- Thread를 생성/종료하는데는 CPU의 사용량이 크며, 이를 줄일 수 있다면 당연히 도움이 된다
- 사용 예시
   ```c#
   ThreadPool.QueueUserWorkItem(function, data);
   ```
- Waiting Control을 할 수 없기 때문에 Sleep을 임시로 주었다. EventWaitHandle을 이용하면 처리 가능

EventWaitHandle
- 예시
    ```c#

    // 호출자
    PrimeNumberTest pnt = new PrimeNumberTest();
            
    var eventDic = new Dictionary<PrimeNumberTest, EventWaitHandle>();
    eventDic.Add(pnt, new EventWaitHandle(false, EventResetMode.ManualReset));

    var eventDic2 = new Dictionary<PrimeNumberTest, EventWaitHandle>();
    eventDic2.Add(pnt, new EventWaitHandle(false, EventResetMode.ManualReset));

    ThreadPool.QueueUserWorkItem(pnt.threadFunc, eventDic);
    ThreadPool.QueueUserWorkItem(pnt.threadFunc, eventDic2);

    eventDic[eventDic.Keys.First()].WaitOne();
    eventDic2[eventDic.Keys.First()].WaitOne();


    // 피 호출자
    public void threadFunc(Object inst)
    {
        var data = (Dictionary<PrimeNumberTest, EventWaitHandle>)inst;
        PrimeNumberTest target = data.Keys.First();
        EventWaitHandle ewh = data[target];

        for (int i = 0; i < 10000; i++)
        {
            // Lock 이용
            lock (target)
            {
                target.number++;
            }
        }

        ewh.Set();  // Event의 상태를 변경
    }
    ```
   
비동기 호출
- BeginInvoke, EndInvoke : Delegate의 비동기 호출을 위한 함수
   - 스레드풀을 실행
- 호출 예시1 : 주스레드가 스레드 풀이 완료될 때까지 대기
   ```c#
    static Func<int, int, long> func;

    static void Main(string[] args)
    {
        func = DelegateAsyncTest.Cumsm;

        IAsyncResult ar = func.BeginInvoke(1, 100, null, null); // Thread Pool에서 진행
        ar.AsyncWaitHandle.WaitOne();   // Async 작업이 완료될 때까지 현재 Thread를 대기
        var result = func.EndInvoke(ar);  // 반환 값을 위해서 EndInvoke 호출
        Console.WriteLine(result);

        Console.ReadLine();
    }
   ```
- 호출 예시2: 주 스레드가 스레드 풀을 실행하고, 다음코드를 계속 실행
   ```c#
    static void Main(string[] args)
    {
        func = DelegateAsyncTest.Cumsm;
        func.BeginInvoke(1, 100, CalcCompled, func);

        Console.ReadLine();
    }

    static void CalcCompled(IAsyncResult ar)
    {
        Func<int, int, long> calc = ar.AsyncState as Func<int, int, long>;
        long result = calc.EndInvoke(ar);
        Console.WriteLine(result);
    }
   ```


## Async, Await (C# 5.0)
### Await 동작
File의 ReadAsync 예시
1. Main Thread에서 작업 진행
2. ReadAsync를 호출하고 바로 이후 작업을 진행 
   - Async 함수를 호출하기 전까지 진행이 됨
   - Async 함수를 호출하고 바로 다음 라인을 진행
3. File을 읽는 작업을 DISK IO에서 별도의 스레드로 진행
4. File읽기가 완료되면 ThreadPool에서 ReadAsync가 있는 동일 함수에서 다음 라인에 있는 작업을 진행
- 코드 예시
   ```c#
   public async void FileReadAsync()
   {
        using (FileStream fs = new FileStream(FILE_PATH, FileMode.Open))
        {
            byte[] buff = new byte[fs.Length];

            Console.WriteLine("Before read : " + Thread.CurrentThread.ManagedThreadId);
            await fs.ReadAsync(buff, 0, buff.Length);
            Console.WriteLine("After read : " + Thread.CurrentThread.ManagedThreadId);

            string txt = Encoding.UTF8.GetString(buff);
            Console.WriteLine(txt);
        }
   }
   ```


Web Client 예시
   ```c#
   // 정상 동작
    public void WebClientNormal()
    {
        WebClient webClient = new WebClient();
        string text = webClient.DownloadString("http://www.microsoft.com");
        Console.WriteLine(text);
    }

    // 4.0 비동기
    public void WebClientAsync1()
    {
        WebClient webClient = new WebClient();
        webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
        webClient.DownloadStringAsync(new Uri("http://www.google.com"));
    }
    private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        Console.WriteLine("After result : " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine(e.Result);
    }

    // 5.0 비동기
    public async void WebClientAsync2()
    {
        WebClient webClient = new WebClient();
        string text = await webClient.DownloadStringTaskAsync("http://www.google.com");
        Console.WriteLine(text);
    }
   ```

### Task
배경
- 닷넷 4.0부터 추가된 병렬 처리 라이브러리(TPL: Task Parallel Library)

기능
- ThreadPool의 자유 스레드를 이용해서 Action Delegate로 전달된 코드를 수행한다
- QueueUserWorkItem과 차이점이라면 더 세밀하게 제어가 가능하다
   - Result 값에 대해서 처리가 가능하다
   - wait도 간단히 처리 할 수 있다. (QueueUserWorkItem에서는 EventWaitHandle을 이용해서 set, waitone을 설정해줘야 했다)
      ```c#
        Task task1 = new Task(
            () =>
            {
                Console.WriteLine("process task item");
            }
        );
        task1.Start();
        task1.Wait();
      ```
- TaskFactory를 통해서 간단히 생성 가능
   ```c#
   Task.Factory.StartNew(   
        () =>
        {
            Console.WriteLine("process task item");
        }
    );
   ```

Task<'TResult>
- 예시 코드
    ```c#
    Task<int> taskResult = Task.Factory.StartNew<int>(() => 1);
    taskResult.Wait();
    Console.WriteLine(taskResult.Result);
    ```

### 일반 함수의 비동기 처리
기존에는 일반 함수를 비동기로 처리하기 위해서는 Delegate의 BegineInvoke를 이용해서 처리했다
   - 예시
   ```c#
    public delegate string ReadAllTextDelegate(string path);
    private readonly string FILE_PATH = "d:\\test.txt";

    public void FileReadAsync()
    {
        ReadAllTextDelegate func = FileRead;
        func.BeginInvoke(FILE_PATH, readFileCompleted, func);
    }

    private string FileRead(string aFilePath)
    {
        return File.ReadAllText(aFilePath);
    }

    private void readFileCompleted(IAsyncResult ar)
    {
        ReadAllTextDelegate func = ar.AsyncState as ReadAllTextDelegate;
        string fileText = func.EndInvoke(ar);

        Console.WriteLine(fileText);
    }
   ```

Task를 이용해서 함수를 감싸면 비동기로 처리 가능하다
- 예시
   ```c#
   private readonly string FILE_PATH = "d:\\test.txt";
   
   public async void FileReadAsync()
   {
       Console.WriteLine("Function Start - " +    Thread.CurrentThread.ManagedThreadId);
       string fileText = await FileReadAsync(FILE_PATH);
       Console.WriteLine("Function End - " +    Thread.CurrentThread.ManagedThreadId);
       Console.WriteLine(fileText);
   }
   
   private Task<string> FileReadAsync(string aFilePath)
   {
       return Task.Factory.StartNew(
           () =>
           {
               Console.WriteLine("Async Function Start - " +    Thread.CurrentThread.ManagedThreadId);
               return File.ReadAllText(aFilePath);
           }
       );
   }
   ```

### 병렬 처리
Thread를 이용한 병렬 처리
   ```c#
      Thread thread = new Thread(delegate()
      {
          Thread.Sleep(3000);
      });
      
      Thread thread2 = new Thread(() =>
      {
          Thread.Sleep(5000);
      });
      
      thread.Start();
      thread2.Start();
      
      thread.Join();
      thread2.Join();
   ```

Task를 이용한 병렬 처리 - 1 : WaitAll
- WaitAll 사용
- Main 메서드를 실행중인 스레드가 아무 일도 못하고 기다리는 문제가 발생
   ```c#
   var task1 = Method3Async();
   var task2 = Method5Async();
   Task.WaitAll(task1, task2);

   private static Task<int> Method3Async()
   {
       return Task.Factory.StartNew(() =>
       {
           Thread.Sleep(3000);
           return 3;
       });
   }
   ```

Task를 이용한 병렬 처리 - 2 : WhenAll
   ```c#
   private static async void DoAsync()
      
      var task1 = Method3Async();
      var task2 = Method5Async();
         await Task.WhenAll(task1, task2);
      Console.WriteLine("완료");
   }
   ```