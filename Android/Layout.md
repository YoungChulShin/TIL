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

### Tab 
탭 레이아웃 구성

Xml 구조
- TabHost를 구현하고 하위에 ViewGroup이 생성
- ViewGroup 하위에는 TabWidget과 FrameLayout이 들어감
1. TabHost
2. ViewGroup(ex. LinearLayout)
3. TabWidget
   - Tab을 구성하는 위젯
   - id: @android:id/tabs
4. FrameLayout
   - 각 Tab을 선택할 때 표시되는 항목
   - id: @android:id/tabcontent

Java 코드
- TabHost에 TabSpec을 추가해서 버튼과 결합하는 방식
   ```java
   TabHost host = (TabHost)findViewById(R.id.host);
   host.setup();

   TabHost.TabSpec spec = host.newTabSpec("tab1");
   spec.setIndicator(null, null);
   spec.setContent(R.id.tab_content1);
   host.addTab(spec);
   ```

### TableLayout

### GridLayout
Oriendation과 Column(또는 Row)의 수를 지정해주면, 추가되는 Item에 대해서 Grid형식의 Layout을 제공

속성
- orientation: 방향
- columnCount, rowCount: 몇개를 나열할 것인지 수량
- layout_row: row index
- layout_column: column index
- layout_columnSpan, layout_rowSpan: View의 크기 
- 

### ConstraintLayout
RelativeLayout과 비슷하나 더 많은 기능이 제공<br>
2016년 Google I/O 행사에서 발표<br>

위치 지정
- layout_constraintLeft_toLeftOf: View의 왼쪽을 다른 View의 왼쪽에 위치
- layout_constraintLeft_toRightOf: View의 왼쪽을 다른 View의 오른쪽에 위치
- parent를 대상으로 할 수 있음

여백(margin) : View와 View 사이의 간격을 표현하기 위해서 사용
- layout_marginLeft
- layout_marginTop

View가 Gone상태일 때 Margin 설정: 위치 지정된 View가 Gone상태가 되었을 때 margin값 설정
- layout_gonearginLeft

bias: 치우침 설정
- layout_constraintHorizontal_bias: 가로 치우침 조절
- layout_constraintVertical_bias: 세로 치우침 조절
- 0.2로 값 설정: 20% 해당하는 곳에 위치
   ```xml
   <Button
      android:id="@+id/btn1"
      android:layout_width="wrap_content"
      android:layout_height="wrap_content"
      android:text="A"
      android:visibility="visible"
      app:layout_constraintLeft_toLeftOf="parent"
      app:layout_constraintRight_toRightOf="parent"
      app:layout_constraintHorizontal_bias="0.1"/>
   ```

ratio: 비율
- 한쪽 크기를 0dp로 설정한 상태에서 비율을 조절 가능
