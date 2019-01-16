### 기본 개념
- 안드로이드 컴포넌트는 똑같이 클래스로 작성되었더라도 각 클래스가 독립적으로 실행되어 직접 결합이 발행하지 않는 구조<br>
A, B 액티비티가 있고 A에서 B를 실행하면 A는 시스템을 통해서 B를 실행
- 인텐트를 한마디로 표현하면 '컴포넌트를 실행하기 위해 시스템에 넘기는 정보'<br>
컴포넌트를 직접 자바 코드로 생성해서 실행하지 못하고 실행하고자 하는 컴포넌트 정보를 담은 인텐트를 구성해서 시스템에 넘기면 시스템에서 인텐트 정보를 분석해 맞는 컴포넌트를 실행해주는 구조

### 종류
명시적 Intent
- 호출할 Intent를 직접 명시해주는 것
   ```java
   Intent intent = new Intent(this, XXXX.class);
   startActivity(intent);
   ```
암시적 Intent
- 주로 외부 앱을 연동할 때 해당 클래스를 할 수 없기 때문에 사용
- AndroidManifest.xml에 등록된 IntentFilter를 활용
   ```java
   Intent intent = new Intent();
   intent.setAction("XXXXXXX");
   startActivity(intent);
   ```

### Intent Filter
인텐트를 암시적으로 호출할 때 인텐트의 정보를 명기
- action
- category
- data

### 결과 되돌리기
startActivityForResult 함수 이용
```java
// 호출 
Intent intent = new Intent(this, XXX.class);
startActivityForResult(intent, 10);

// 피 호출
Intent intent = getIntent();
setResult(RESULT_OK, intent);
finish();

// 호출
//onActivityResult 이벤트 실행
```


### 외부 앱 연동
```java
// 카메라 연동
Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

/* 주소록 연동
Intent intent = new Intent(Intent.ACTION_PICK);
intent.setData(ContactsContract.CommonDataKinds.Email.CONTENT_URI);*/

/* 명시적 실행
Intent intent = new Intent(this, DetailActivity.class);
intent.putExtra("category", ((TextView)view).getText().toString());
startActivityForResult(intent, 10);*/

// 지도
// Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("geo:37.34452323,126.4332332"));

// 브라우저
// Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("http://www.naver.com"));

// 전화
//if (ContextCompat.checkSelfPermission(this, Manifest.permission.CALL_PHONE) ==
//        PackageManager.PERMISSION_GRANTED) {
//    Intent intent = new Intent(Intent.ACTION_CALL, Uri.parse("tel:02-120"));
//    startActivity(intent);
//} else {
//    ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.CALL_PHONE}, 100);
//}

startActivityForResult(intent, 10);
```

### 서비스가 있는지 확인
```java
PackageManager pm = getPackageManager();
List<ResolveInfo> activities = pm.queryIntentActivities(intent, 0);
if (activities.size() > 0) {
// do
} else {
// do
}
```


### 생명 주기
상태
- activity running
  - 화면을 점유하고 출력되고 있으며 이벤트 처리가 정상적으로 되는 상태
  1. onCreate()
  2. onStart()
  3. onResume()

  - setContentView()와의 관계
     - onResume() 함수가 호출될 때까지 setContentView()를 호출해주면 화면에 표시된다
     - 여러번 호출해도 마지막에 호출된 것을 기준으로 표시
- pause
  - 현재 액티비티가 일시적으로 사용이 불가능한 상태. (예: 다른 액티비티가 전체 화면을 가리지 않고 실행되었을 때)
  - 대부분 정지 상태(onStop)로 전환되기 전에 호출되어 곧 정지될 것임을 나타내기 위해서 사용
- stop
  - 현재 액티비티가 다른 액티비티로 인해 화면이 완벽하게 가려진 상태
  - 화면이 바뀌었다가 다시 돌아오면 아래 순서가 진행
     1. onPause()
     2. onStop() -> 화면 전화
     3. onRestart()
     4. onStart()
     5. onResume()
   

- 화면 회전
   - 화면 회전을 하면 액티비티가 종료되었다가 다시 실행
   - 순서
      1. onPause()
      2. onStop()
      3. onDestroy() -> 종료
      4. onCreate()
      5. onStart()
      6. onResume()


상태 저장
- onSaveInstanceState
   - 종료되는 상황에 데이터를 저장시 사용
   - onPause() 함수 호출 후 자동 호출
   - 파라미터 1개
      - onPause() 호출 후 자동 호출
      - 회전이 아니라 다른 액티비티 전환애도 호출
   - 파라미터 2개
      - 시스템 내부적으로 구분해서 화면이 전환될 때는 호출되지 않음
- onRestoreInstanceState
   - onCreate()가 호출되면서 같이 실행
   - 파라미터 1개
      - 회전 하여 액티비티가 다시 시작될 때 무조건 호출
   - 파라미터 2개
      - 번들에 저장된 데이터가 없으면 호출되지 않음

   
