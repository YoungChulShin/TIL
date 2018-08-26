## 초기화 
- $git init
- $git config --global user.name "Your Name"
- $git config --global user.email my@email.com

## Git에 파일 추가
1. $git status
2. $git add --all
3. $git commit -m "commit message"
4. Github에서 Repository 만들기 -> 생성된 주소 복사
5. git remote add origin '복사한 주소'
6. git push -u origin master
7. Github에서 push된 내용 확인하기s 

## Git에서 파일을 업데이트 하지 않도록 하는 방법
1. 상위폴더에 '.gitignore' 파일 추가
2. 해당 파일 안에 내용 추가<br>

## Git에서 파일을 업데이트 하는 방법
1. #git clone "원격 저장소 주소"
2. #git pull

## Git Remote repository check & change
1. $git remote -v
2. $git remote set-url origin "repository url"

## Git에서 파일 롤백하는 방법
1. $git checkout -- "파일명"

## Git Push Error
1. Permission denied error
    - 에러 메시지: remote: Permission to ShinYN/DayByDay.git denied to go1323. <br>fatal: unable to access 'https://github.com/ShinYN/DayByDay.git/': The requested URL returned error: 403
    - 에러 문제: remote url이 https로 설정되어 있어서 발생
    - 해결 방법: remote url을 ssh로 변경
2. Permission denied error 403
    - 에러 문제: ssh 키가 없어서 발생
    - 해결 방법: ssh 키를 생성하여, github에 등록
    - 해결 방법 Link: [Link](http://uiandwe.tistory.com/992)

## Git Commit 취소
1. git reset

## Git Bash에서 파일 추가
1. $touch '파일 명"
