### Custom Font 적용
- typeface 옵션을 통해서 적용 가능
- assets 폴더에 폰트를 복사하고 코드에서 호출
- 호출 예시
   ```java
   targetTextView = (TextView)findViewById(R.id.text_visible_tartget);
   Typeface typeface = Typeface.createFromAsset(getAssets(), "BMDOHYEON_ttf.ttf");
   targetTextView.setTypeface(typeface);
   ```