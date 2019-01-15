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