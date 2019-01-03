### 이벤트 종류
1. Delegation Event Model: View에서 발생하는 Event를 처리하기 위한 모델
2. Hierachy Event Model: Activity에서 발생하는 사용자의 터치나 키 입력을 처리하기 위한 모델

### 이벤트 구조
Event Source  <----> Listener <----> Event Handler의 구조

   ```java
   // 예시
   vibrateCheckView.setOnCheckedChangeListener(new MyEventHandler());
   // 해석
   // 1. vibrateCheckView 객체(=Event Source)에서
   // 2. CheckedChangeEvent가 발생하면
   // 3. MyEventHandler 객체를 실행해서 이벤트를 처리하라
   ```