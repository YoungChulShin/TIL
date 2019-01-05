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

### KeyDown Event
Event 종류
- onKeyDown
- onKeyUp
- onKeyLongPress

예시 코드
   ```java
    long initTime;
    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        if (keyCode == KeyEvent.KEYCODE_BACK) {
            if (System.currentTimeMillis() - initTime > 3000) {
                showToast("종료할려면 한번 더 누르세요");
                initTime = System.currentTimeMillis();
            } else {
                finish();
            }

            return true;
        }

        return super.onKeyDown(keyCode, event);
    }
   ```

### Touch Event
사용
- onTouchEvent를 override해서 사용 가능

Touch Event 종류
- ACITON_DOWN: 터치된 순간의 이벤트
- ACITON_UP: 터치를 떼는 순간의 이벤트
- ACTION_MOVE: 터치한 후 이동하는 순간의 이벤트

X, Y 좌표 정보
- getX(), getY(): 이벤트가 발생한 View에서의 좌표 값
- getRawX(), getRawY(): 화면에서의 좌표 값

예시 코드
   ``` java
    float initX;
    @Override
    public  boolean onTouchEvent(MotionEvent event){
        if (event.getAction() == MotionEvent.ACTION_DOWN){
            initX = event.getRawX();
        }
        else if (event.getAction() == MotionEvent.ACTION_UP){
            float diff = initX - event.getRawX();
            if (diff > 30) {
                showToast("왼쪽으로 화면을 밀었습니다");
            } else if (diff <= 30) {
                showToast("화면을 오른쪽으로 밀었습니다");
            }
        }

        return true;
    }
   ```

### Animation
간단한 Animation은 XML로 처리 가능

샘플 코드
   ```java
   Animation anim = AnimationUtils.loadAnimation(this, R.anim.in);
   imageView.startAnimation(anim);

   // 애니메이션에 대한 이벤트 처리
   anim.setAnimationListener(new Animation.AnimationListener(){

   });
   ```