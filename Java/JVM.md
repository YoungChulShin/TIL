# JVM
## 코드의 실행
자바 코드 실행
1. 컴파일러에 의해서 *.java 파일이 *.class(bytecode) 파일로 변경
2. 'class loader'에 의해서 bytecode를 JVM 내의 'runtime data area'에 배치
   - runtime data area: JVM 프로세스 수행을 위해서 OS로 부터 할당 받은 메모리 공간
3. 'execution engine'에 의해서 byte code를 해석해서 실행

byte code 해석
- byte code를 기계어로 변경한다
- 방법
   1. interpreter: 명령어를 하나씩 '읽고', '실행'하는 과정을 반복한다
   2. JIT: interpreter 방식으로 동작하다가 적절한 시점에 바이트 코드 전체를 기계어로 변환한다. 변환 이후에는 재 호출 시 캐시에 있는 네이티브 코드를 실행한다. 

runtime data area 구조
- Thread
   - stack
   - pc register: 현재 실행중인 JVM 명령의 주소값 저장
   - native method stack: 다른 언어의 메서드 호출을 위해서 할당되는 영역
- Heap
   - Instance
   - Array
- Method area
   - Method n 
      - runtime constant pool
      - method code
      - attribute and field value

## HotSpot VM
개념
- 1999년 발표한 JVM
- SUN에 인수되었으며 1.3 버전부터 기본 VM으로 사용

컴포넌트
- VM 런타임
- JIT 컴파일러
- 메모리 관리자

바이트코드 컴파일 시점
- 애플리케이션에서 각각의 메서드를 컴파일 할 만큼의 시간적 여유가 없기 때문에 처음에는 인터프리터에 의해서 시작된다
- 시간이 지나면서 아래 2개의 카운터에 설정된 값을 넘어가면 컴파일 대상이 된다
   1. 수행 카운터(invocation counter): 메서드를 실행할 때마다 증가
      ```
      XX:CompileThreshold=35000
      ```
   2. 백에지 카운터(backedge counter): 높은 바이트코드 인덱스에서 낮은 인덱스로 컨트롤 흐림이 변경될 때마다 증가
      ```
      CompileThreshold * OnStackReplacePercentage / 100
      XX:OnStackReplacePercentage=80
      ```

Hotspot VM troubleshooting guide
- https://docs.oracle.com/javase/7/docs/webnotes/tsg/TSG-VM/html/clopts.html

## JVM이 시작되는 절차
java 명령으로 HelloWorld 클래스를 실행할 때, 
1. java 명령줄에 있는 옵션 파싱
2. 힙 크기 할당 및 JIT 컴파일러 타입 지정
3. CLASSPATH 및 LD_LIBRARY_PATH 같은 환경변수 지정
   - LD_LIBRARY_PATH: 자바 애플리케이션이 라이브러리를 참조할 때 사용하는 경로
4. Main 클래스가 지정되지 않았으면, Jar 파일의 manifest 파일에서 Main 클래스를 확인
5. JNI의 표준 API인 'JNI_CreateJavaVM'을 사용해서 새로 생성한 non-primordinal 이라는 스레드에서 HotSpot VM 생성
6. HotSpot VM이 생성 및 초기화되면, main 메서드의 속성 정보를 읽는다
7. 'CallStaticVoidMethod'는 네이티브 인터페이스를 불러 HotSpot VM에 있는 main 메서드가 수행된다

## JVM이 종료될 때
종료 절차
1. HotSpot VM이 작동중인 상황에서는 데몬 스레드가 아닌 스레드가 종료될 때까지 대기한다
2. java.lang 패키지에 있는 Shutdown 클래스의 shutdown 메서드가 수행된다. 
3. 메서드가 수행되면 java level의 finalizer가 수행된다. 
4. VM level의 shutdown hook이 동작한다
5. HotSpot VM 스레드를 종료
6. HotSpot의 "vm exited" 값을 설정한다
7. VM 종료 후 호출자로 복귀한다

SIGKILL(-9)로 종료가 되면 위 과정을 따르지 않는다

## 클래스 로딩 절차
로딩 절차
1. 주어진 클래스의 이름으로 클래스패스에 바이너리로 된 자바 클래스를 찾는다
2. 자바 클래스를 정의한다
3. 해당 클래스를 나타내는 java.lang 패키지의 Class 클래스의 객체를 생성한다
4. 링크 작업이 수행된다. static 필드를 생성 및 초기화하고 메서드 테이블을 할당한다
5. 클래스의 초기화 진행. (부모 클래스가 있다면 먼저 초기화 진행)

## JVM Options
`-` 옵션
- standard 옵션. 대부분의 jvm에서 동작
- 예: -server

`-X` 옵션
- non-standard 옵션. 모든 jvm에서 동작할 것이라는 보장이 없다. 
- 예: -Xmx

`-XX` 옵션
- developer option

오라클 문서
- https://openjdk.org/groups/hotspot/docs/RuntimeOverview.html