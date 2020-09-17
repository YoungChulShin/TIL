## 프로세스
### ps - 프로세스 확인
~~~
$ ps
$ ps -f
~~~

### kill - 프로세스 죽이기
~~~
$ kill -15 $PID
~~~
- 15: 종료
- 9: 강제 종료

## 서비스
### service - 서비스 시작/종료/재시작
~~~
$ service httpd start
~~~
- `/etc/init.d` 경로에 있는 링크 파일의 실행/종지를 관리

## 시작 프로그램 설정
### chkconfig - 부팅될 때 프로그램 설정
~~~
$ chkconfig httpd on    # 실행 설정
$ chkconfig httpd off   # 실행 안되게 설정
$ chkconfig --list  # 리스트 조회
~~~
- Linux Runlevel 표
   - 0 : poweroff.target 
   - 1 : rescue.target 
   - 2, 3, 4 : multi-user.target 
   - 5 : graphical.target 
   - 6  : reboot.target 