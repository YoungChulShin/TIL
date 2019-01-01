## Text 표시 View
### TextView
- Text를 표시할 때 사용
### EditText
- 데이터를 입력 받을 때 사용
- 속성 값
   - lines: 화면에 표시되는 라인 수
   - inputType
      1. 키보드 표시 형식
      2. 사용자에게 한줄 혹은 여러줄 입력을 강제
   - hint: 힌드 키워드(placehold)
   - gravity: 글의 위치 지정

## Text 리소스
### string.xml
- 긴 문자열은 string.xml에 내용을 작성하고 사용 가능
- 사용할 때에는 아래와 같이 사용
   ```xml
   android:text="@string/long_text"
   ```