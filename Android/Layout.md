### LinearLayuout
View를 순서대로 가로나 세로 방향으로 나열하는 Layout

속성
- gravity: View의 내용을 View 영역 내에서 어디에 포시할 지 
- layout_gravity: View를 Layout 영역 내에서 어디서 나타낼지를 설정
- weight: 비율로 가로, 세로 길이를 설정
   ```xml
   android:layout_height="0dp"
   android:layout_weight="1"

   android:layout_height="0dp"
   android:layout_weight="2"

   android:layout_height="0dp"
   android:layout_weight="2"
   ```

### RelativeLayout
배치된 View를 기준으로 다른 View의 위치를 지정하는 레이아웃

Layout: 위치를 지정하는 속성
- above, below, toLeftOf, toRightOf

Align: 정렬을 지정하는 속성
- top, bottom, left, right, baseLine

AlignParent: RelativeLayout을 기준으로 상하좌우로 정렬할 수 있는 속성

### FrameLayout
레이아웃에 포함된 뷰들을 같은 영역에 배치할 때 사용
- 같은 영역에 뷰를 겹치게 한 다음 하나의 뷰만 보이기 위한 목적으로 많이 사용

### TableLayout

### GridLayout

### ConstraintLayout
