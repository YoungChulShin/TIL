### 기본 개념
- Winform의 User Control 같은 개념
- 액티비티 처럼 사용할 수 있는 뷰

### 사용 방법
1. Fragment class를 생성
   - class는 Fragement를 상속한다
2. 생성된 Fragment는 사용할 Activity에서 추가해 준다
   - FragmentManager를 만들어 준다
   - FragmentManager를 이용해서 FragmentTransaction을 만들어 준다
      1. beginTransaction: Transaction 시작
      2. add: XML 레이아웃에 Fragment 등록
      3. replace: id 영역에 추가된 Fragment를 대체
      4. remove: 추가된 fragment 제거
      5. commit: 화면 적용

### 적용 코드
구현
```java
manager = getSupportFragmentManager();
oneFragment = new OneFragment();
twoFragment = new TwoFragment();
threeFragment = new ThreeFragment();

FragmentTransaction ft = manager.beginTransaction();
ft.addToBackStack(null);
ft.add(R.id.main_container, oneFragment);
ft.commit();
```

미리 정의된 Fragment
- 미리 정의된 Fragment를 이용하면 디자인을 위한 XML 파일을 만들지 않아도 된다
1. ListFragment
2. WebViewFragment
3. DialogFragment
4. PreferenceFragment`

사용
```java
if (v == btn1) {
    if (!oneFragment.isVisible()) {
        FragmentTransaction ft = manager.beginTransaction();
        ft.addToBackStack(null);
        ft.replace(R.id.main_container, oneFragment);
        ft.commit();
    }
} else if (v == btn2) {
    if (twoFragment.isVisible() == false) {
        twoFragment.show(manager, null);
    }
} else if (v == btn3) {
    if (threeFragment.isVisible() == false) {
        FragmentTransaction ft = manager.beginTransaction();
        ft.addToBackStack(null);
        ft.replace(R.id.main_container, threeFragment);
        ft.commit();
    }
}
```