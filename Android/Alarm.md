## 진동 알람
Vibrator Class를 통해서 지원
```java
    Vibrator vib = (Vibrator)getSystemService(VIBRATOR_SERVICE);
    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
        vib.vibrate(VibrationEffect.createOneShot(1000, VibrationEffect.DEFAULT_AMPLITUDE));
    } else {
        vib.vibrate(1000);
    }
```

사용 전 권한 할당 필요
- 할당 방법
   1. AndroidManifest.xml
   2. \<uses-permission android:name="android.permission.VIBRATE"/> 권한 추가

## 소리 알람
### Beep 사운드
샘플 코드
```java
    Uri notification = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
    Ringtone ringtone = RingtoneManager.getRingtone(getApplicationContext(), notification);
    ringtone.play();
```

### 임의의 효과음
샘플 코드
```java
    MediaPlayer player = MediaPlayer.create(this, R.raw.kakaotalk);
    player.start();
```

## 다이얼로그
### 토스트(Toast)
잠깐 화면에 띄웠다가 사라지는 메시지<br>

샘풀 코드
   ```java
    Toast toast = Toast.makeText(this, "메시지 테스트", Toast.LENGTH_SHORT);
    toast.show();
   ```

### 알람 다이얼로그
다이얼로그 형식으로 알람창을 알리고 싶을 때 사용<br>

샘플 코드
   ```java
    AlertDialog.Builder builder = new AlertDialog.Builder(this);
    builder.setMessage(R.string.mssage_test);
    builder.setTitle("알림");
    builder.setIcon(R.drawable.alert_icon);
    builder.setPositiveButton("OK", null);
    builder.setNegativeButton("OK", null);
    alertDialog = builder.create();

    alertDialog.show();
   ```