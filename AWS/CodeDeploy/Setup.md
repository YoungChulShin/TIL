## Code deploy 연동 과정
### EC2에 권한 추가하기
1. EC2에서 IAM 사용자 역할 추가하기
   - 정책: AmazonEC2RoleforAWSCodeDeploy
2. EC2 인스턴스에서 '인스턴스 설정' -> '역할 연결/바꾸기' 통해서 IAM 역할을 새로 생성한 것으로 변경
3. EC2 인스턴스 재부팅
4. 아래 명령어로 파일 다운 받기 
   ~~~
   aws s3 cp s3://aws-codedeploy-ap-northeast-2/latest/install . --region ap-northeast-2
   ~~~

### EC2에 설치
5. 'install' 파일 권한 추가 및 실행
   ~~~
   chmod +x ./install
   sudo ./install auto
   ~~~
6. 서비스 정상 실행 체크
   ~~~
   sudo service codedeploy-agent status
   ~~~

### CodeDeploy 생성



