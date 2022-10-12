# Thread
### 종류
User Thread
- High priority
- JVM은 Main Thread가 종료되어도 User Thread가 종료될 때까지 기다린다

Daemon Thread
- Low Priority
- User Thread를 serve 하기 위한 Thread
- Main Thread가 종료되면 종료된다
- 사용 예시: GC, Memory Release 등 

모든 Thread는 해당 스레드를 생성하는 스레드의 데몬 상태를 상속한다. 그래서 메인 스레드(=유저 스레드)에서 스레드를 생성하면, 기본 상태는 유저스레드이다.