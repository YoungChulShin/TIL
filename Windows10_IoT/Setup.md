##셋업 방법
1. Windows 10 IoT Core Dashboard 설치<br>
    - [Link](https://developer.microsoft.com/ko-kr/windows/iot/Docs/GetStarted/rpi3/sdcard/insider/GetStartedStep1.htm)

2. IoT Dashboard의 '새 단말기 설정'에서 Windows 10 설치 
    - USB Device 필요

3. IoT Dashboard의 '내 장치'에서 장비 등록 확인
4. Device Portal을 이용해서 장비 설정 접속
    - 초기 ID: Administrator
    - 초기 비밀번호: p@ssw0rd (또는 설정 가능)

5. Device Portal에 접속하면 'Home' 탭에서 비밀번호나 기타 접속 정보를 변경해 준다. 


##원격 접속 허용
- Device Portal에 'Remote' 항목에서 활성화를 시켜준다. 

##원격 장치 배포
- 라즈베리파이는 Arm으로 빌드해야 함
- 프로젝트 -> 속성 -> 디버그 -> 시작 옵션 -> 대상 장치에 '원격 컴퓨터'로 설정하고 원격 정보를 입력
