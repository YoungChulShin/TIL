##초기화 
- $git init
- $git config --global user.name "Your Name"
- $git config --global user.email my@email.com

##Git에 파일 추가
1. $git status
2. $git add --all
3. $git commit -m "commit message"
4. Github에서 Repository 만들기 -> 생성된 주소 복사
5. git remote add origin '복사한 주소'
6. git push -u origin master
7. Github에서 push된 내용 확인하기s 

##Git에서 파일을 업데이트 하지 않도록 하는 방법
1. 상위폴더에 '.gitignore' 파일 추가
2. 해당 파일 안에 내용 추가<br>
    - 