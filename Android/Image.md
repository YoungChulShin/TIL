### 이미지 표시 View
ImageView
- 이미지는 res -> drawable 폴더에 넣어서 관리. (파일명은 소문자)
   ```xml
    <ImageView
       android:layout_width="wrap_content"
       android:layout_height="wrap_content"
       android:src="@drawable/sample"/>
   ```
- 속성 값
   - src: 이미지 경로
   - adjustViewBounds: 비율 유지 여부
      - maxWidth, minWidth와 함께 사용
   - tint: 이미지위에 다른 색을 입힐 때 사용
- 이미지 설정
   ```java
   typeImageView.setImageDrawable(ResourcesCompat.getDrawable(
                    context.getResources(), R.drawable.ic_type_doc, null));
   ```