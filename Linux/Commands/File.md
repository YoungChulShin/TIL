## 파일
### ls - 파일 목록 출력 (list directory contents)
~~~
$ ls 
$ ls 옵션 파일경로|기타옵션
~~~
옵션
- t: 시간 순
- r; recursive

기타 옵션
- grep *.jar: jar 확장자의 파일을 검색
- tail -n 1: 뒤에서 1개를 선택

### ln (링크 파일 생성)
커맨드: ln -[option] [원본 파일] [링크 파일]

옵션
- 심볼릭 링크 (Symbolic Link): 원본을 가리키는 파일을 생성. 바로가기 개념
- 하드 링크 (Hard Link): 원본파일과 다른이름으로 존재하는 동일한 파일. 다른 파일이라고 봐야 함

사용
~~~
$ ln -s /usr/share/zoneinfo/Asia/Seoul /etc/localtime
~~~

### rm 파일 삭제
커맨드: rm + 옵션
옵션
- r: 폴더 삭제
- f: 강제 삭제

