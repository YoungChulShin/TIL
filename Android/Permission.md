### Persmission
정의
- 자신의 앱을 외부에서 이용할 때 권한을 부여하여 해당 권한을 가지고 들어올 때만 실행되게 하기 위한 설정

사용
- Target App: 앱의 컴포넌트를 보호하고 싶을 때 Permission 선언
- Test App: Target App의 컴포넌트를 사용하기 위해서 'uses-permission' 선언
   ```xml
   <activity android:name=".SomeActivity"
        android:permisiion="com.test.permission.SOME_PERMISSION"
        ... />

   <maniftest ...
        <uses-permission andorid:name="com.test.permission.SOME_PERMISSION" />
   >
   ```

Permission Level
- normal : 사용자에게 위험부담이 적다
- dangerous : 보호되는 기능이 사용자에게 위험 부담이 크다
- signature : 외부 앱이 같은 키로 서명되어 있어야 한다

System Permission: 특정 기능을 시스템에서 보고하고 있어서 'uses-permission'을 선언해야 하는 것
- ACCESS_FILE_LOCATION: 위치 정보 엑세스
- ACESS_NETWORK_STATE: 네트워크에 대한 정보 액세스
- ACESS_WIFI_STATE: 와이파이 네트워크에 대한 정보 액세스
- BATTERY_STATS: 배터리 통계 수집
- BLUETOOTH: 연결된 블루투스 장치에 연결
- BLUETOOTH_ADMIN: 블루투스 장치를 검색하고 페어링
- CALL_PHONE: 다이얼 UI를 거치지 않고 전화를 시작
- CAMERA: 카메라 장치에 액세스
- INTERNET: 네트워크 연결
- READ_CONTACTS: 사용자의 연락처 데이터 읽기
- READ_EXTERNAL_STORAGE: 외부 저장소에서 파일 읽기
- READ_PHONE_STATE: 장치의 전화번호, 네트워크 정보, 진행 중인 통화 상태 등 전화 상태에 대한 읽기
- READ_SMS: SMS 메시지 읽기
- RECEIVE_BOOT_COMPLETED: 부팅 완료 시 수행
- RECEIVE_SMS: SMS 메시지 수신
- RECORD_AUDIO: 오디오 녹음
- SEND_SMS: SMS 메시지 발신
- VIBRATE: 진동 울리기
- WRITE_CONTRACT: 사용자의 연락처 데이터 쓰기
- WRITE_EXTERNAL_STORAGE: 외부 저장소에 파일 쓰기

안드로이드 6.0 (API Level 23) 변경 사항
- 사용자가 permission을 거부할 수 있다
- 프로그램에서는 permission을 확인하는 코드를 넣어야 한다. checkSelfPermission() 함수 통해서 확인 가능
   - PERMISSION_GRANTED: 권한 부여
   - PERMISSION_DENIED: 권한 미 부여
- requestPermissions로 권한 요청


### 권한 샘플 코드
1. 권한 추가
   ```xml
   <manifest xmlns:android="http://schemas.android.com/apk/res/android" 
   package="com.example.go1323.part3_9">

    <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
    <uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
   ```

2. 권한 체크
   ```java
   if (ContextCompat.checkSelfPermission(this, Manifest.permission.READ_EXTERNAL_STORAGE)
                == PackageManager.PERMISSION_GRANTED) {
            fileReadPermission = true;
        }

   if (ContextCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE)
            == PackageManager.PERMISSION_GRANTED) {
      fileWritePermission = true;
   }
   ```
3. 권한 요청
   ```java
    ActivityCompat.requestPermissions(this, new String[]{
                    Manifest.permission.READ_EXTERNAL_STORAGE,
                    Manifest.permission.WRITE_EXTERNAL_STORAGE}, 200);


   @Override
    public  void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);

        if (requestCode == 200 && grantResults.length > 0) {
            if (grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                fileReadPermission = true;
            }
            if (grantResults[1] == PackageManager.PERMISSION_GRANTED) {
                fileWritePermission = true;
            }
        }
    }
   ```