ViewGroups
- View의 집합
- View Group도 하나의 View

Linear Layout
- Vertial, Horizontal 방식에 따라 View를 순차적으로 배치

Relative Layout
- 상대적으로 기준을 잡고, 배치할 수 있다

XmlNamespace
- xmlns:android="http://schemas.android.com/apk/res/android"

ViewSize
- Hard coding
- wrap_conent: 컨텐츠의 크기와 동일하게
- match_parent: 부모의 사이즈와 동일하게

LinearLayout에서 content의 길이 또는 폭을 일정하게 배열
- android:layout_weight 값을 1로 설정
   - 1은 비율이기 때문에 비율을 다르게 하고 싶으면 1의 값을 변경하면 된다
- View를 이용해서 ParentView를 채울 때, 특정 View가 나머지 전체를 채우기 위해서는 weight를 이용해서 채워ㅏ준다

RelaytiveLayout에서 정렬
- 문서: [Link](https://developer.android.com/reference/android/widget/RelativeLayout.LayoutParams?utm_source=udacity&utm_medium=course&utm_campaign=android_basics)

ID 이름
- 예: androdi:id="@+id/btn_test"
- @: 아이디를 선언
- +: 처음 선언 시 사용
- /: 타입과 이름의 구분자

Padding
- 밀어내는 것

Margin 
- 부모 View로부터 설정한 값 만큼 깎이는 것

