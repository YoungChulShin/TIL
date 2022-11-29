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
- Method area: 클래스, 메서드, static 변수, 상수 정보 등이 저장되는 영역

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