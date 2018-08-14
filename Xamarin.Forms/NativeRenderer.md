### 참고 페이지
[Link](https://docs.microsoft.com/ko-kr/xamarin/xamarin-forms/app-fundamentals/custom-renderer/)

### 소개
- Xamarin.Forms에서 제공하는 기본 UI가 있지만, Xamarin.Forms에서 제공하는 기능 외에 플랫폼에 특화된 기능을 사용하려면 Custom Renderer를 이용해야 한다
- Custom Renderer는 대상이 되는 Control을 상속하면서 구현할 수도 있고,<br>
Native Control을 상속하는 Class를 구현해서 사용할 수도 있다. 

### Render Base Class and Native Controls
- Xamarin 컨트롤과 Native 컨트롤 맵핑: [Link](https://docs.microsoft.com/ko-kr/xamarin/xamarin-forms/app-fundamentals/custom-renderer/renderers)
- Xamarin University Video: [Link](https://developer.xamarin.com/videos/cross-platform/xamarinforms-custom-renderers/)

###Entry Customizing
- Xamarin.Forms의 컨트롤은 Renderer를 통해서 Native Control로 변경된다
- Entry [Android]: EntryRenderer에 의해서 EditText로 변경
- Entry [iOS]: EntryRenderer에 의해서 UITextField로 변경

- 생성 순서
 1) Entry Renderer의 하위 클래스 생성
 2) OnElementChanged 함수 Override
 3) ExportRenderer 추가
 -> Custom Render의 구현은 옵션이기 때문에, 등록되지 않으면 기본 Control이 사용

 