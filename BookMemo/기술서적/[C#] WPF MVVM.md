# 3장. WPF 애플리케이션 생성
## 3.4 단순 컨트롤
### 기본 컨트롤
종류
- TextBlock
- TextBox
- ProgressBar
- Slider
- PasswordBox
### 멀티미디어 컨트롤
종류
- Image: 그림 표시
- MediaElement: 동영상 표시
   ```c#
   <Image Source="Images/main.PNG" Height="200" Stretch="Uniform"/>
   ```

WPF는 장치 독립적 픽셀로 제공된다. 하나의 픽셀은 약 0.5밀리미터다. 즉 50은 화면에서 2.5센티를 나타낸다. 

### 그리기 컨트롤
종류
- Ellipse: 타원
- Rectangle: 사각형
- Path: 경로?

### 콘텐츠 컨트롤
종류
- Button
   - Button
   - ToggleButton
   - CheckBox
   - RadioButton 
- Border
- ScrollViewer
- ViewBox
   - ViewBox에 들어가는 Control의 크기를 조절 가능하다. (Stretch 속성 이용)

복잡한 콘텐츠를 지정해야 하는 경우에는 Content 요소를 사용하는 대신 하위 요소를 콘텐츠 컨트롤에 제공할 수 있다. 
   ```xml
   <Button>
      <CheckBox IsChecked="True">
         <TextBlock Text="test"/>
      </CheckBox>
   </Button>
   ```

## 3.5 탐색
각 화면은 Page이고, Page는 Frame 내부에 표시된다. 

1. 코드에서 탐색
   ```c#
   NavigationService.Navigate(new Uri("Location", UriKind.Relative));
   ```

2. XAML에서 탐색
   ```xml
   <Label>
      <Hyperlink NavigateUri="Location">
         Pay Now
      </Hyperlink>
   </Label>
   ```

## 3.9 XAML 이해
### XAML Namespace
- c#코드에서 using과 비슷한 개념
- WPF 컨트롤: http://schemas.microsoft.com/winfx/2006/xaml/presentation
- XAML 키워드: http://schemas.microsoft.com/winfx/2006/xaml 

### 객체 생성
네임스페이스 맵핑
- xmlns:접두어="clr-namespace:네임스페이스명;assembly:어셈블리명"
- 예시: xmlns:local="clr-namespace:BikeShop.Pages"

### 속성 정의
C# Code에서 Object를 생성하고 속성을 정의하는 것 처럼, XAML에서도 적용 가능

   ```c#
   public class Car
   {
      public int Speed { get; set; }
      public Color Color { get; set; }
   }
   ```

   ```xml
   <Label>
      <car:Car Speed="100" Color="Beige" />
   </Label>
   ```

### 명명 규칙
x:name 속성을 사용해서 명명 가능

Code에서 'InitializeComponent()' 호출은 'XAML 상태에 대한 수행'을 의미한다.

## 3.10 이벤트


# 오타
- p.38: Strike -> Stroke
