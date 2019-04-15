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