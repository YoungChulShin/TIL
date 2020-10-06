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
    ExecutorService executorService = Executors.newSingleThreadExecutor();
        executorService.execute(() -> {
            System.out.println("Thread " + Thread.currentThread().getName());
        });

   executorService.shutdown();
   ~~~