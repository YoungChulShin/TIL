## 배경
- 자바 프로그램의 메모리 누수나 세부적인 디버깅이 필요할 때 덤프를 떠서 확인할 수 있다.

## jattach
- https://github.com/apangin/jattach
- 메모리 덤프를 할 수 있도록 해주는 도구. 'jmap + jstack + jcmd + jinfo' 를 한번에 할 수 있는 올인원 프로그램
- 실행 방법 (힙 메모리 덤프)
   - `jattach <ps id> <option> <output path>`
   - 예:`jattach 1 dumpheap /dump/dump_log_1` 을 하면 'dump/dump_log_1' 로 메모리 덤프 파일이 생성
 
## jmap 을 이용한 힙덤프 
https://github.com/YoungChulShin/study_spring/tree/master/heap-dump-test

## JVM에서 힙덤프 설정
`-XX:+HeapDumpOnOutOfMemoryError` 옵션을 이용해서 OutOfMemory로 애플리케이션이 종료될 때, 힙덤프를 기록할 수 있다. 
- `java_pod{pid}.hprof` 로 파일이 생성된다
- 실행 명령어 예시: `java -XX:+HeapDumpOnOutOfMemoryError -Xmx1G -jar heapdump-0.0.1-SNAPSHOT.jar`