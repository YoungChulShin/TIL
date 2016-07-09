##사이트
- <https://www.pythonanywhere.com/user/ShinYoungChul/consoles/>

##가입 정보
- 사이트 가입은 비기너로 가입한다. (무료 계정)
- 계정을 생성할 때 입력한 사용자 이름이 블로그 계정으로 생성된다. 
    - 'UserName'.pythonanywhere.com

##사용 정보
- 사이트에 로그인 하면 배쉬(Bash)로 콘솔창에서 실행할 수 있다. 

##Virtual Environment 설치
1. 설치: $virtualenv --python=python3.4 myvenv
2. 실행: $source myvenv/bin/activate
3. Django 설치: $pip install django whitenoise
3. 정적파일 모으기: $python manage.py collectstatic
4. DB생성
    - #python manage.py migrate
    - #python manage.py createsuperuser
5. 가상환경 설정: $home/ShinYoungChul(UserName)/ProgrammingFunc(=BlogSite)/myvenv/
6. WSGI 설정
    >import os<br>
    >import sys<br>
    >path = '/home/<your-username>/my-first-blog'  # 여러분의 유저네임을 여기에 적어주세요. <br>
    >if path not in sys.path:<br>
    >     sys.path.append(path)
    >
    >os.environ['DJANGO_SETTINGS_MODULE'] = 'mysite.settings'
    >
    >from django.core.wsgi import get_wsgi_application
    >from whitenoise.django import DjangoWhiteNoise
    >application = DjangoWhiteNoise(get_wsgi_application())

##WSGI 프로토콜
- 파이썬을 이용한 웹 사이트를 서비스하기 위한 표준

##정적파일 (백색소움)
