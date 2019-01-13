### 안드로이드 런타임(ART)
- 안드로이드 VM은 ART(Android Runtime)을 이용한다
- 실행 순서
   1. Java Source (*.java)
   2. Compile - Java Compiler
   3. Java Byte Code (*.class)
   4. Compile - Dex Compiler
   5. Dalvik Byte Code (*.dex)
   6. Dex 파일
   7. ART (런타임에 ART가 Dex파일을 해석해서 수행)

### 컴포넌트
- 앱의 구성 단위. 여러개의 컴포넌트가 모여서 1개의 앱을 구성
- 클래스이지만 일반 클래스와 달리 생명주기를 시스템이 관리
- 독립적으로 실행 된다
   - SMS목록과 SMS수신 컴포넌트가 있다고 하면, SMS 목록은 프로그램을 시작했을 때 확인 가능한 항목이다.<br>
   SMS수신은 프로그램을 직접 실행하지 않더라도 SMS를 받으면 실행되는 항목이다

### Context
- Activity, Service는 Context의 하위 클래스
- 안드로이드 시스템의 글로벌 정보나 애플리케이션 환경 등에 접근하는 방법을 제공
- Application Level에서 Context를 통해서 System Level로 접근

### 버전 호환성
minSdkVersion보다 상위 버전의 API를 사용할 경우가 있고 이 경우에 대한 대응
- Google에서 제공하는 Support 라이브러리 이용
   - 기본 생성되는 Activity는 AppCompatActivity를 상속
   - AppTheme를 'Theme.AppCompat.Light.DarkActionBar'를 이용해야 한다
- 개발자 코드로 확인 및 처리
   ```java
   if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP){
            
   } else {
      
   }
   ```

### 네임스페이스
표준이 아닌 별도의 네임스페이스
- xmlns:app="http://schemas.android.com/apk/res-auto"