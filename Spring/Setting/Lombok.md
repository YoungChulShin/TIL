## 롬복 설정 방법 (Intellij)

1. Plugin에서 Lombok 설치
   - ctrl + shift + a 를 이용해서 action 창 진입
   - plugin 검색
   - plugin 창으로 들어가서 설치
2. 환경 설정에 annotion enable 설정
   - ctrl + , 를 이용해서 preference 진입
   - build, execution, deployment -> Compiler -> Annotation Processors 로 이동
   - 'Enable annotation procession' 활성화
3. Gradle 라이브러리에 추가
   - 아래 2가지 코드 추가
      ~~~
      compile('org.projectlombok:lombok')
      annotationProcessor 'org.projectlombok:lombok'
      ~~~