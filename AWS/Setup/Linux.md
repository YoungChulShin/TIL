## Java8 설치
기본 버전 확인 (default 7버전 설치)
~~~
$ java -version
~~~

Java 8 설치
~~~
$ sudo yum install -y java-1.8.0-openjdk-devel.x86_64
~~~

Java 8으로 변경
~~~
$ sudo /usr/sbin/alternatives --config java
~~~

## Timezone 변경
Timezone 확인
~~~
$ date
~~~

Timezone 변경
~~~
$ sudo rm /etc/localtime
$ sudo ln -s /usr/share/zoneinfo/Asia/Seoul /etc/localtime
~~~

## HostName 변경
~~~
# sudo vim /etc/sysconfig/network
~~~
위 파일에서 'HOSTNAME' 값을 원하는 값으로 변경. 변경 이후에 서버 리부팅(sudo reboot) 필요.

