### 여러 스레드를 사용해야 하는 이유
응답성 (GUI)

성능

### 스레드 스케줄링과 우선순위
윈도우는 실시간 운영체제가 아닌 선점형(preemptive) 운영체제이다. 모든 스레드들은 커널 객체 내부에 컨텍스트 구조체를 포함하고 있고, 여기에는 스레드가 마지막으로 수행되었던 CPU 레지스터 상태 정보를 가지고 있다. 

모든 스레드는 0(가장 낮은)에서 31(가장 높은)까지의 우선순위 레벨을 할당받게 된다. 31 우선순위의 스레드가 스케줄 가능상태에 있는 동안, 시스템은 0부터 30의 우선순위를 가진 스레드에게 CPU를 전혀 할당하지 않는다. 

# Thread Pool
스레드를 생성하고 파괴하는 일은 상당한 시간을 소비하는 작업일 뿐 아니라, 메모리 소비, 잦은 컨텍스트 전환을 통한 성능저하 등을 유발한다

## 스레드 풀
정의
- 응용 프로그램에서 활용할 수 있는 일련의 스레드 집합
- CLR 별로 하나씩 생성된다
- 여유 스레드가 없을 경우에는 새로운 스레드를 생성하기 때문에 성능에 안좋은 영향을 줄 수 있지만, 생성된 스레드는 반납되면 유휴상태를 유지하기 때문에 추가적인 성능에 영향을 미치지는 않는다

사용 예시
```c#
static void Main(string[] args)
{
    Console.WriteLine("Main thread: queuing an asynchronous operation");
    ThreadPool.QueueUserWorkItem(ComputeBoundOP, 5);
    Console.WriteLine("Main thread: Doing other work here...");
    Thread.Sleep(1000);
    Console.WriteLine("Hit <Enter> to end this program...");
    Console.ReadLine();
}

private static void ComputeBoundOP(object state)
{
    Console.WriteLine("In ComputeBoundOP: state={0}", state);
    Thread.Sleep(1000);
}
```

## CancellationTokenSource
- ThreadPool의 작업을 취소할 때 사용
- CancellationTokenSource의 Token을 통해서 취소하려는 작업을 수행하면 된다
- 작업을 취소하지 못하게하려면 CancellationToken의 None을 매개변수로 전달해주면 된다
- CancellationToken의 Register함수를 이용하면, 취소되었을 때 실행 될 콜백 함수도 등록 가능하다

예시
```c#
static void Main(string[] args)
{
    CancellationTokenSource cts = new CancellationTokenSource();
    ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

    Console.WriteLine("Press endter to cancel operation");
    Console.ReadKey();
    cts.Cancel();
    Console.ReadLine();
}

private static void Count(CancellationToken token, int countTo)
{
    for (int count = 0; count < countTo; count++)
    {
        if (token.IsCancellationRequested)
        {
            Console.WriteLine("Count is cancelled");
            break;
        }

        Console.WriteLine(count);
        Thread.Sleep(200);
    }

    Console.WriteLine("Count is done");
}
```

# tasks
### 등장 배경
- ThreadPool의 경우 작업완료시점과 작업수행결과를 얻을 수 있는 방법을 기본적으로 제공하고 있지 않다

### 사용 방법
```c#
ThreadPool.QueUserWorkItem(Test, 5);    // ThreadPool을 이용한 방식
new Task(Test, 5).Start();  // Task를 이용해서 동일한 작업 수행
Task.Run(() => Test(6));    // Task의 정적메서드 이용
```

### Task 작업 대기
- Wait() : Task Object에 대한 대기
- WaitAll()
   - Task Array에 대해서 모두 완료될 때까지 대기
   - bool의 timeout을 리턴으로 받을 수도 있다
   - CancellationToken을 통해 취소가 되면 'OperationCancelledException' 발생
- WaitAny()
   - Task Array에 대해서 하나라도 완료되면 리턴
   - int 값을 리턴으로 받으며, 완료되면 Task의 index 값. timeout은 -1
   - CancellationToken을 통해 취소가 되면 'OperationCancelledException' 발생

### Task 수행 중 예외 발생
- System.AggregateExcetpion 예외를 발생시킨다. 이 예외는 내부에 InnerExceptions 속성을 가지는데 여기서 실제 발생한 에러를 확인 가능하다

- Exception의 handle 함수
   - AggregateException이 발생했을 때 해당 예외의 처리 여부를 Callback 함수로 확인가능
   - false일 경우는 새로운 AggregateException을 만들어서 예외를 다시 던진다
   ```c#
    try
    {
        // Task 작업
    }
    catch(AggregateException ex)
    {
        // OperationCanceledException 일 경우에만 예외를 처리
        // 그 외 Case는 Aggregate Exception을 다시 호출
        ex.Handle(e => e is OperationCanceledException);

        Console.WriteLine("Sum was cancelled");
    }
   ```

### Task 취소
CancellationTokenSource를 이용해서 취소 가능하다
```c#
CancellationTokenSource cts = new CancellationTokenSource();
Task<int> t1 = new Task<int>(n => Sum(cts.Token, (int)n), 10000);

try
{
    t1.Start();
    cts.Cancel();
    Console.WriteLine(t1.Result);
}
catch(AggregateException ex)
{
    // OperationCanceledException 일 경우에만 예외를 처리
    // 그 외 Case는 Aggregate Exception을 다시 호출
    ex.Handle(e => e is OperationCanceledException);

    Console.WriteLine("Sum was cancelled");
}
```

### Task 연속 작업
ContinueWith 함수를 이용해서 Task가 완료되었을 때 다음작업을 수행 가능하다. ContinueWith는 내부적으로 Task Collection을 저장하고 있기 때문에 단일 Task 객체에 대해서 n번 ContinueWith를 등록할 수 있다. 이 경우 Task가 완료되면 Collection 내의 Task들을 ThreadPool에 큐잉하게 된다

```c#
Task<int> t = new Task<int>(() => Sum(cts.Token, 100000));
t.ContinueWith(task => Console.WriteLine("Sum is : " + task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
t.ContinueWith(task => Console.WriteLine("Sum threw : " + task.Exception.InnerException), TaskContinuationOptions.OnlyOnFaulted);
t.ContinueWith(task => Console.WriteLine("Sum was cancelled"), TaskContinuationOptions.OnlyOnCanceled);

Console.WriteLine("End");
Console.ReadLine();
```