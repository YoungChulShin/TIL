### 2.1.1. 안드로이드 특징
안드로이드 런타임(ART)
- 안드로이드 VM은 ART(Android Runtime)을 이용한다
- 실행 순서
   1. Java Source (*.java)
   2. Compile - Java Compiler
   3. Java Byte Code (*.class)
   4. Compile - Dex Compiler
   5. Dalvik Byte Code (*.dex)
   6. Dex 파일
   7. ART (런타임에 ART가 Dex파일을 해석해서 수행)

### 2.1.3 컴포턴트 개발
컴포넌트
- 앱의 구성 단위. 여러개의 컴포넌트가 모여서 1개의 앱을 구성
- 클래스이지만 일반 클래스와 달리 생명주기를 시스템이 관리
- 독립적으로 실행 된다
   - SMS목록과 SMS수신 컴포넌트가 있다고 하면, SMS 목록은 프로그램을 시작했을 때 확인 가능한 항목이다.<br>
   SMS수신은 프로그램을 직접 실행하지 않더라도 SMS를 받으면 실행되는 항목이다
