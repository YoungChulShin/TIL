## ActionBar
Activity 구성
- Window하위에 ActionBar와 Conent 영역이 구성

ActionBar 구성
- App Icon
- View Control
- Action Button
- Overflow Menu

ActionBar를 보이지 않도록 구성
- res/values/styles.xml 파일에서 하위 테마 적용
   ```xml
   <item name="windowNoTitle">true</item>
   <item name="windowActionBar">false</item>
   ```

ActionBar 컨트롤
   ```java
   actionBar = getSupportActionBar();
   actionBar.show();
   actionBar.hide();
   ```

### Action Bar 디자인
- Content 영역위에 떠 있는 것처럼 보이고 싶을 때는 style 속성에서 overlay 옵션 추가
   ```xml
    <item name="colorPrimary">#00000000</item>
    <item name="windowActionBarOverlay">true</item>
   ```
- Home Icon 표시
   ```java
    actionBar.setDisplayShowHomeEnabled(true);
    actionBar.setDisplayHomeAsUpEnabled(true);

   // 이벤트 처리
   @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            Toast toast = Toast.makeText(this, "Home as up click", Toast.LENGTH_SHORT);
            toast.show();
            return true;
        }

        return super.onContextItemSelected(item);
    }
   ```