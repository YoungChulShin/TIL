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

### Action Bar에 메뉴 추가 - Code
함수 정보
- onCreateOptionsMenu(Menu menu): 메뉴가 만들어질 때 한번 호출
- onPrepareOptionsMenu(Menu menu): 메뉴가 화면에 보일 때마다 반복 호출
   ```java
   @Override
   public boolean onCreateOptionsMenu(Menu menu) {
      MenuItem item1 = menu.add(0, 0, 0, "테스트1");
      MenuItem item2 = menu.add(0, 0, 0, "테스트2");
      return true;
   }
   ```
클릭 이벤트
- onOptionsItemSelected

### Action Bar에 메뉴 추가 - XML
XML 파일을 생성해서 코드에서 호출 및 활용
- 파일 위치: res -> menu
   ```xml
   <menu xmlns:android="http://schemas.android.com/apk/res/android">
      <item
         android:id="@+id/menu1"
         android:icon="@drawable/settings"
         android:title="선택"/>
      <item
         android:id="@+id/menu2"
         android:icon="@drawable/icon"
         android:title="선택2"/>
      <item
         android:id="@+id/menu3"
         android:title="Sub Menu">
         <menu>
            <item android:id="@+id/sub1"
                  android:title="Sub1">
            </item>
            <item android:id="@+id/sub2"
                  android:title="Sub2">
            </item>
         </menu>
      </item>
   </menu>
   ```
- 코드 호출
   ```java
   MenuInflater inflater = getMenuInflater();
   inflater.inflate(R.menu.menuitem, menu);
   ```

메뉴 아이콘 표시
- showAsAction을 always로 설정

### ActionView
```xml
 <item
        android:id="@+id/menu3"
        app:showAsAction="ifRoom|collapseActionView"
        android:title="Check"
        android:icon="@drawable/ic_menu_2"
        android:actionLayout="@layout/actionview_check"/>
```

### Context 메뉴
특정 View를 누르고 있을 때 이벤트 처리
```java
ImageView imageView = (ImageView)findViewById(R.id.imageView);
registerForContextMenu(imageView);  // Context Menu 등록

// 할당 및 이벤트 처리
@Override
public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
   super.onCreateContextMenu(menu, v, menuInfo);

   menu.add(0, 0, 0, "서버 전송");
   menu.add(0, 1, 0, "보관함에 보관");
   menu.add(0, 2, 0, "삭제");
}

@Override
public boolean onContextItemSelected(MenuItem item) {
   switch (item.getItemId()) {
      case 0:
            showToast("서버 전송이 완료되었습니다");
            break;
      case 1:
            showToast("보관함에 보관이 선택되었습니다");
            break;
      case 2:
            showToast("서버 전송이 완료되었습니다");
            break;
      case 3:
            showToast("서버 전송이 완료되었습니다");
            break;
   }

   return true;
}
```

### Search View
```xml
<item
      android:id="@+id/menu_main_search"
      app:actionViewClass="android.widget.SearchView"
      app:showAsAction="always"
      android:title="Search"/>
```
```java
@SuppressLint("RestrictedApi")
@Override
public boolean onCreateOptionsMenu(Menu menu) {
   MenuInflater inflater = getMenuInflater();
   inflater.inflate(R.menu.menu_lab2, menu);
   if (menu instanceof MenuBuilder) {
      MenuBuilder m = (MenuBuilder) menu;
      m.setOptionalIconsVisible(true);
   }

   MenuItem menuItem = menu.findItem(R.id.menu_main_search);
   searchView = (SearchView)menuItem.getActionView();
   searchView.setQueryHint(getResources().getString(R.string.query_hint));
   searchView.setOnQueryTextListener(queryTextListener);
   return true;
}


private SearchView.OnQueryTextListener queryTextListener = new SearchView.OnQueryTextListener() {
   @Override
   public boolean onQueryTextSubmit(String query) {
      searchView.setQuery("", false);
      searchView.setIconified(true);
      showToast(query);
      return false;
   }

   @Override
   public boolean onQueryTextChange(String newText) {
      return false;
   }
};
```