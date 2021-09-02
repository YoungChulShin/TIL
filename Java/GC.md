## Java GC

### 힙 메모리 구조
구성
- YoungGeneration
   - Eden
   - SurvivorSpace 
      - From Space
      - To Space
- OldGeneration

YoungGeneration
- 객체가 생성되면 먼저 YoungGeneration에 생성
- 생명주기가 짧은 객체가 저장
- Minor GC이라 부른다

Old Generation
- 생명주기가 긴 오래된 객체
- YoungGeneration에서 생성된 객체가 오래 살아있으면 Old Generation으로 이동한다
- Major GC라고 부른다. (Minor에 비해서 속도가 느리다)

Stop The World
- Thread가 GC을 위해서 GC을 수행하는 Thread를 제외하고는 모두 멈추는 현상
- GC튜닝은 이 시간을 최소화 하는 것이다
- Major GC을 수행할 때 발생

Old Generation에서 Young Generation 참조
- card Table에 Young Generation을 참조하면 정보를 기록하고, 이후에 이 Table을 확인해서 GC 대상인지 확인한다

### Young Generation의 GC
과정
1. 객체가 생성되면 eden에 쌓인다
2. GC가 일어나면 eden에서 사용되지 않는 객체는 제거되고, 남은 객체는 survivor 영역중 한곳으로 이동한다. 
3. GC 과정에서 survivor 객체가 다 차게되면, 사용되지 않는 객체는 제거되고 나머지 survivor 영역으로 이동한다.
4. 이 과정을 반복하다가 계속 살아남은 객체는 Old Generation 으로 이동한다. 

### Old 영역의 GC
종류
- Serial GC
- Parallel GC
- Parallel Old GC
- Concurrent Mark & Sweep GC
- G1(Garbage First) GC

Java9 버전부터는 G1 GC를 기본으로 사용한다.

### 참고 자료
Java Garbage Collection: https://d2.naver.com/helloworld/1329
