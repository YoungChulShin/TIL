
### 리소스 종류
- drawable: 이미지, 이미지와 관련된 XML
- layout: 화면 UI
- values: 문자열, 색상, 크기 등 
   - string: 문자열. 'string' 태그 사용
   - colors: 색상 리소스. 'cololr' 태그 사용
   - styles: 스타일. 'style'태그 사용
   - arrays: 배열 리소스. 'string-array', 'integer-array' 태그 사용
   - dimens: 크기 리소스. 'dimen' 태그 사용
- menu: 액티비티의 메뉴를 구성하기 위한 XML
- xml: 특정 폴더가 지정되어 있지 않은 기타 XML
- anim: 애니메이션을 위한 XML
- raw: 바이트 단위로 직접 이용되는 이진 파일
- mipmap: 앱 아이콘 이미지


### App Theme
- Style리소스에서 'AppTheme'에서 확인 가능
- 적용은 AndroidManifest.xml에서 설정 

### 다국어 처리
- strings.xml 을 추가하는데, locale을 변경해서 등록

### 국가별 이미지 처리
1. drawable 폴더를 추가. 이때 Locale 설정을 추가
2. drawable 폴더에 이미지를 복사하면, 폴더를 선택하는 창이 뜨는데 원하는 Locale 정보를 선택해서 복사