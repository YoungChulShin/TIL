##파이썬 설치
- 설치 링크: [Link](https://www.python.org/downloads/release/python-343/)

##Django Girls
- Site: [Link](http://tutorial.djangogirls.org/ko/python_introduction/)

##Python
- Version 확인: $python3 --version

##django 설치
1. 가상환경 설치
<br>- $python3 -m vevn myvenv
2. 가상환경 실행
<br>- $source myvevn/bin/activate
3. django 설치
<br>- $pip install django==1.8

##프로젝트 시작
- $django-admin startproject mysite .
    - mysite뒤에 한칸 띄우고 '.'을 찍어야 한다. 
    - 이렇게 하면 폴더 내에 특정 구조의 파일이 생긴다.
- 폴더 구조
    >djangogirls<br>
    ├───manage.py : 사이트 관리를 도와주는 파일<br>
    └───mysite <br>
    settings.py : 웹사이트 설정<br>
    urls.py : 주소관리<br>
    wsgi.py<br>
    __init__.py<br>
- 데이터 베이스 생성
    - $python manage.py migrate
- 서버 실행
    - $python manage.py runserver
- 접속
    - 웹브라우져에서 http://127.0.0.1:8000 