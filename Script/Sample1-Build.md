~~~sh
#!/bin/bash

REPOSITORY=/home/ec2-user/app/step1 #변수 설정
PROJECT_NAME=freelec-springboot2-webservice2 #변수 설정

echo "> $REPOSITORY/$PROJECT_NAME/" #echo: 디스플레이에 출력

cd $REPOSITORY/$PROJECT_NAME/   # 경로 이동

echo "> Git Pull"

git pull    # 경로 이동 이후에 Git 최신 버전 가져오기

echo "> 프로젝트 Build 시작"

./gradlew build     # 빌드 하기

echo "> step1 디렉토리로 이동"

cd $REPOSITORY  

echo "> Build 파일 복사"

cp $REPOSITORY/$PROJECT_NAME/build/libs/*.jar $REPOSITORY/  # 빌드된 파일을 특정 경로로 복사하기

echo "> 현재 구동중인 애플리케이션 pid 확인"

CURRENT_PID=$(pgrep -f ${PROJECT_NAME}*.jar)    #pgrep 는 ps와 grep의 합성어. 실행중인 PID 확인

echo "> 현재 구동 중인 애플리케이션 pid: $CURRENT_PID"

if [ -z "$CURRENT_PID" ]; then
    echo "> 현재 구동중인 애플리케이션이 없으므로 종료하지 않습니다"
else
    echo "> kill -15 $CURRENT_PID"
    kill -15 $CURRENT_PID   # 실행중인 프로세스가 있으면 종료
    sleep 5
fi

echo "> 새 애플리케이션 배포"

JAR_NAME=$(ls -tr $REPOSITORY/|grep *.jar|tail -n 1)    # REPOSITORY 경로에서 jar 파일을 가장 나중에 JAR 파일, 시간의 역순으로(가장 최신 파일 부터 정랼

echo "> JAR Name: $JAR_NAME"

nohup java -jar \
    -Dspring.config.location=classpath:/application.properties,classpath:/application.properties,/home/ec2-user/app/application-oauth.properties \
    $REPOSITORY/$JAR_NAME 2>&1 &
    # nohup은 백그라운드에서 실행하기 위해서 사용. nohup.out에서 결과 확인 가능
    # Dspring.config.location: 스프링 설정 파일 위치를 지정. 
~~~