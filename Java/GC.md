# Java GC

## 힙 메모리 구조
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

## Young Generation의 GC
과정
1. 객체가 생성되면 eden에 쌓인다
2. GC가 일어나면 eden에서 사용되지 않는 객체는 제거되고, 남은 객체는 survivor 영역중 한곳으로 이동한다. 
3. GC 과정에서 survivor 객체가 다 차게되면, 사용되지 않는 객체는 제거되고 나머지 survivor 영역으로 이동한다.
4. 이 과정을 반복하다가 계속 살아남은 객체는 Old Generation 으로 이동한다. 

## Old 영역의 GC
종류
- Serial GC
- Parallel GC
- Parallel Compacting GC
- Concurrent Mark & Sweep GC
- G1(Garbage First) GC

Java9 버전부터는 G1 GC를 기본으로 사용한다.

Serial GC
- Young 영역과 Old 영역이 연속적으로 처리되며 하나의 CPU를 사용한다
- GC가 수행될 때 애플리케이션이 중지되며, stop the world라고 부른다
- 클라이언트(=대기 시간이 많아도 크게 문제가 되지 않는 시스템)에서 사용된다
- `-XX:+UseSerialGC` 를 옵션으로 지정한다
- Young Generation 동작
   1. Eden 영역이 꽉 차면 ToSurvivor 영역으로 이동한다. Survivor으로 가기에 너무 큰 객체는 Old 영역으로 바로 이동한다. FromSurvivor 영역의 살아있는 객체로 ToSurvior 영역으로 이동한다
   2. ToSurvivor이 가득차면 Enden이나 FromSurvivor 영역의 객체는 Old 영역으로 이동한다
- Old Generation 동작: Mark-sweep-compact 컬렉션 알고리즘을 따른다. 
   1. Old 영역으로 이동된 객체들 중 살아있는 객체를 식별한다 (Mark)
   2. Old 영역의 객체들을 훑는 작업을 수행해서 쓰레기 객체를 식별한다 (Sweep)
   3. 필요없는 객체를 지우고 살아있는 객체를 한곳으로 모은다 (Compact)

Parallel GC
- Young Generation의 GC를 수행할 때 multi thread를 이용해서 병렬로 처리한다. 
- 다른 CPU가 대기 상태로 남아있는 것을 최소화 하기 위한 목적
- Old Generation은 Serial GC와 동일한 Mark-sweep-compact 알고리즘을 사용한다
- `-XX:+UseParallelGC` 옵션 지정

Parallel Compacting GC
- Old Generation의 GC 방식이 다르다. 
- Parallel에서는 Sweep 단계가 있었다면(싱글 스레드), Compacing 에서는 Summary 단계(멀티 스레드)가 있다

CMS(Concurrent Mark & Sweep) GC
- row-latency collector로도 불린다
- young generation은 parallel과 동일하다. old generation은 아래의 단계를 거친다. 
   ![cms_collector](/Java/image/CMS_Collector.jpg)
- `-XX:+UseConcMarkSweepGC` 옵션 지정

[G1(Garage First) GC](https://docs.oracle.com/en/java/javase/11/gctuning/garbage-first-g1-garbage-collector1.html#GUID-ED3AB6D3-FD9B-4447-9EDF-983ED2F7A573)
- 소개글
   ```
   The Garbage-First (G1) garbage collector is targeted for multiprocessor machines with a large amount of memory. It attempts to meet garbage collection pause-time goals with high probability while achieving high throughput with little need for configuration. G1 aims to provide the best balance between latency and throughput using current target applications and environments whose features include:
   ```
- 바둑판 모양의 구역으로 나뉘어저 있고, 각 구역이 Young, Old 구역의 역할을 한다. 다른 GC와 다르게 Young, Old 영역의 주소가 물리적으로 Linear 하지 않다
- Old 영역의 GC는 CMS GC 방식과 비슷한데 여섯단계로 수행된다
- `-XX:+UseG1GC` 옵션 지정

## 참고 자료
참고자료
- Java Garbage Collection: https://d2.naver.com/helloworld/1329
- 기계인간 블로그: https://johngrib.github.io/wiki/java-g1gc/
- 오라클 GC 튜닝 가이드: https://docs.oracle.com/en/java/javase/11/gctuning/index.html

