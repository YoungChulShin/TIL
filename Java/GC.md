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
- Java GC: https://d2.naver.com/helloworld/1329
- Java GC 모니터링: https://d2.naver.com/helloworld/6043
- 기계인간 블로그: https://johngrib.github.io/wiki/java-g1gc/
- 오라클 GC 튜닝 가이드: https://docs.oracle.com/en/java/javase/11/gctuning/index.html
- VM performance: https://www.oracle.com/java/technologies/javase/vmoptions-jsp.html

## 모니터링
### jps
java process를 확인할 때 사용. '`jps -h`'를 통해서 매뉴얼을 확인 가능하다. -v 옵션을 주면 JVM에 전달된 자바 옵션 목록을 볼 수 있다. 

### jstat
GC가 수행되는 정보를 확인하기 위한 명령어.

예시
- `jstat -gcutil <<psid>> 1s`: 1초당 입력한 프로세스에 대한 gc 정보를 출력. 저장공간에서 % 비율로 값을 표시한다
   ```
   ❯ jstat -gcutil 50241 1s
   S0     S1     E      O      M     CCS    YGC     YGCT     FGC    FGCT     CGC    CGCT       GCT
   0.00  86.14  37.50  16.54  98.85  96.65      4     0.010     0     0.000     2     0.001     0.011
   0.00  86.14  37.50  16.54  98.85  96.65      4     0.010     0     0.000     2     0.001     0.011
   0.00  86.14  37.50  16.54  98.85  96.65      4     0.010     0     0.000     2     0.001     0.011
   0.00  86.14  37.50  16.54  98.85  96.65      4     0.010     0     0.000     2     0.001     0.011
   0.00  86.14  37.50  16.54  98.85  96.65      4     0.010     0     0.000     2     0.001     0.011
   0.00  86.14  37.50  16.54  98.85  96.65      4     0.010     0     0.000     2     0.001     0.011
   0.00 100.00  18.71  31.75  99.11  97.06     17     0.190     0     0.000     7     0.039     0.229
   0.00 100.00  74.42  60.34  99.11  97.06     22     0.503     0     0.000     9     0.040     0.544
   0.00 100.00  12.33  82.62  99.11  97.06     28     0.925     0     0.000     9     0.040     0.966
   0.00 100.00  38.36  99.96  99.11  97.06     38     1.282     0     0.000    10     0.040     1.323
   0.00 100.00   0.00 100.00  99.11  97.06     69     1.615     1     0.000    10     0.040     1.656
   0.00  94.77   0.00  99.96  98.93  96.75     75     1.800     1     0.957    10     0.040     2.798
   ```
- `jstat -gccapacity <<psid>>`: 입력한 프로세스에 대한 gc capacity 정보 출력

기타 옵션: `jstat -gcnew -t -h10 2624 1000 20 > test.log`
- `-t`: 수행 시간 표시
- `-h10`: 10줄에 한번씩 열의 설명을 표시
- `2624`: psid
- `1000`: 1초에 한번씩 출력
- `20`: 20번 반복
- `test.log`: test.log 파일에 결과를 저장한다


### verbosegc 옵션
java를 실행할 때 `-verbosegc` 옵션을 주면 GC가 발생할 때 내용을 콘솔에서 확인할 수 있다. 
```
[6.675s][info][gc] GC(2450) To-space exhausted
[6.675s][info][gc] GC(2450) Pause Young (Normal) (G1 Preventive Collection) 13M->14M(16M) 2.833ms
[6.685s][info][gc] GC(2451) Pause Full (G1 Compaction Pause) 14M->13M(16M) 9.694ms
[6.685s][info][gc] GC(2448) Concurrent Mark Cycle 14.887ms
```

### 로깅 플래그
```
-XLoggc:gc.log -XX:+PrintGCDetails -XX:+PrintTenuringDistribution -XX:+PrintGCTimeStamps -XX:+PrintGCDateStamps
```
- `-XLoggc:gc.log`: GC 이벤트를 로깅할 파일을 지정한다
- `-XX:+PrintGCDetails`: GC 이벤트 세부 정보를 로깅한다
- `-XX:+PrintTenuringDistribution`: 툴링에 꼭 필요한, 부가적인 GC 이벤트 세부 정보를 추가한다. 이 플래그가 제공하는 정보를 사람이 이용하기는 어렵다.
- `-XX:+PrintGCTimeStamps`: GC 이벤트 발생 시간을 (VM 시작 이후 경과한 시간을 초 단위로) 출력한다.
- `-XX:+PrintGCDateStamps`: GC 이벤트 발생 시간을 출력한다

로그 순환 플래그
- `-XX:+UseGCLogFileRotation`: 로그 순환 기능을 켠다
- `-XX:+NumberOfGCLogFiles=<n>`: 보관 가능한 최대 로그파일 개수를 설정한다
- `-XX+GCLogFileSize=<size>`: 순환 직전 각 파일의 최대 크기를 설정한다

### visualVM
GUI 도구. visualGC 플러그인을 설치하면 GC 정보를 모니터링할 수 있다

## GC 튜닝
기본으로 설정되어 있어야하는 옵션
- `-Xms`, `-Xmx` : 힙 메모리 크기 지정
- `-XX:NewRatio`: new 영역과 old 영역의 비율
- `-server`: 서버 모드