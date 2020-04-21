## AWS에 양산 배포 과정

테스트 환경 
- AWS EC2
- Springboot
- MariaDB

배포 과정
1. EC2에 프로젝트를 클론 받기
   - git 설치 필요
2. 배포 스크립트 만들기
   - git 최신 버전 가져오기
   - 빌드
   - 기존 프로세스가 있으면 종료
   - 실행
3. Srping 환경 설정 파일 등록하기
   - 중요한 파일은 환경 설정에서 분리가 필요하며, 이런 파일은 EC2에 직접 생성하고 jar 파일을 실행할 때 경로를 지정해준다 (배포 스크립트에서)
   ~~~sh
   nohup java -jar \
    -Dspring.config.location=classpath:/application.properties,/home/ec2-user/app/application-oauth.properties,/home/ec2-user/app/application-real-db.properties \
    -Dspring.profiles.active=real \
    $REPOSITORY/$JAR_NAME 2>&1 &
   ~~~
4. RDS에 테이블 생성
   - 관리 테이블
   - Session Table: 'schema-mysql.sql' 파일 (command + shift + O로 검색)
5. 프로젝트 설정
   - build.gradle에 mariadb 의존성 추가
   