## 자바 Concurrent 프로그래밍
자바에서 지원
- 멀티프로세싱
- 멀티쓰레드

멀티쓰레드
- 자바의 기본은 main 쓰레드
   ~~~java
   public static void main(String[] args) {
        System.out.println(Thread.currentThread().getName());
    }
   ~~~
- main 쓰레드에서 다른 쓰레드를 구동 방법
   1. Thread를 상속받은 클래스를 구현
   2. Runnable을 이용
      ~~~java
      Thread thread = new Thread(() -> System.out.println("Thread: " + Thread.currentThread().getName()));
        thread.run();
      ~~~
- Thread 관련 명령어
   1. sleep: 재우는 것
   2. interrupt(): 깨우는 것
      - sleep중이라면 InterruptedException이 발생
   3. join(): 스레드가 끝날 때까지 대기

## Executors
개념
- Thread를 만들고 관리하는 일을 고수준의 API에 위임하는 것

구조
1. Executor
2. ExecutorService
3. SchduledExecutorService

ExecuterService
- 구조
   - ThreadPool (with nThread)
      - Thread를 생성하는 비용이 줄어든다
   - BlockingQueue
      - Thread Pool을 넘어서면 Queue에서 대기한다
- 샘플 코드
   ~~~java
   // 선언 - 생성 시점에 threadpool의 수를 정의한다
   ExecutorService executorService = Executors.newFixedThreadPool(4);

   // 기본 사용 샘플 코드
    ExecutorService executorService = Executors.newSingleThreadExecutor();
        executorService.execute(() -> {
            System.out.println("Thread " + Thread.currentThread().getName());
        });

   executorService.shutdown();
   ~~~

## Runnable, Callbable, Future
특징
- ExecutorService 에서 사용할 수 있는 동작을 정의한다
- Runnable은 실행에 대한 동작을 가지고, Callable은 리턴 값을 가진다
- Future는 이러한 비동기 작업에 대한 응답 값

## CompletableFuture
특징
- Excutor의 구현체
- Future가 가지고 있는 단점을 더 개선시켰다
   - callback에 대한 동작을 사저 정의할 수 있다
   - ExecutorService 없이 CompletableFuture에서 바로 실행시킬 수 있다

ForkJoinPool
- CompletableFuture는 기본 값으로는 ForkJoinPool을 사용한다
- 별도의 Thread를 사용하려면 Executors를 이용해서 ExecutorService를 정의하고 CompletablFuture를 정의할 때, Executor 값을 세팅해주면 된다

코드
- 샘플 코드
   ~~~java
   // 명시적 리턴
   CompletableFuture<String> future = new CompletableFuture<>();
   future.complete("test");

   System.out.println(future.get());

   // 리턴이 없 비동기
   CompletableFuture<Void> asyncFuture = CompletableFuture.runAsync(() -> {
      System.out.println("asyncFuture " + Thread.currentThread().getName());
   });

   asyncFuture.get();  // 이 문장이 없어도 실행은되나 get을 통해서 명시적으로 결과를 대기한다
   
   // 리턴이 있는 비동기
   CompletableFuture<String> supplierFuture = CompletableFuture.supplyAsync(() -> {
      System.out.println("supplierFuture " + Thread.currentThread().getName());
      return "done";
   });

   System.out.println(supplierFuture.get());

   // 콜백을 사전 정의 (Future만 썼을 때는 불가능했던 작업)
   CompletableFuture<String> supplierFutureCallback = CompletableFuture.supplyAsync(() -> {
      System.out.println("supplierFutureCallback " + Thread.currentThread().getName());
      return "done";
   }).thenApply((s) -> {
      System.out.println(s.toUpperCase());
      return "done2";
   });

   supplierFutureCallback.get();

   // 응답없는 콜백을 사전 정의 (Future만 썼을 때는 불가능했던 작업)
   CompletableFuture<Void> voidCompletableFuture = CompletableFuture.supplyAsync(() -> {
      System.out.println("voidCompletableFuture " + Thread.currentThread().getName());
      return "done!";
   }).thenAccept(s -> {
      System.out.println(s.toUpperCase());
   });

   voidCompletableFuture.get();

   // 결과 값에 대한 참고 없이 단순히 실행만 하려면 thenRun() 을 사용하면 된다


   // ForkJoinPool 외에 별도로 정의한 ThreadPool을 이용해도 할 수 있다
   ExecutorService executorService = Executors.newFixedThreadPool(4);

   CompletableFuture<Void> voidCompletableFutureWithThreadPool = CompletableFuture.supplyAsync(() -> {
      System.out.println("voidCompletableFuture " + Thread.currentThread().getName());
      return "done!";
   }, executorService).thenAccept(s -> {
      System.out.println(s.toUpperCase());
   });

   voidCompletableFutureWithThreadPool.get();
   executorService.shutdown();
   ~~~