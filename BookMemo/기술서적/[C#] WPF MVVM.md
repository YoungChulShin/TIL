# 3장. WPF 애플리케이션 생성
## 3.4 단순 컨트롤
### 기본 컨트롤
- TextBlock
- TextBox
- ProgressBar
- Slider
- PasswordBox
### 멀티미디어 컨트롤
- Image: 그림 표시
- MediaElement: 동영상 표시
   ```c#
   <Image Source="Images/main.PNG" Height="200" Stretch="Uniform"/>
   ```

WPF는 장치 독립적 픽셀로 제공된다. 하나의 픽셀은 약 0.5밀리미터다. 즉 50은 화면에서 2.5센티를 나타낸다. 

### 그리기 컨트롤
- Ellipse: 타원
- Rectangle: 사각형
- Path: 경로?

### 콘텐츠 컨트롤
- Button
   - Button
   - ToggleButton
   - CheckBox
   - RadioButton 
- Border
- ScrollViewer
- ViewBox

   ```xaml
   <Button>
      <CheckBox IsChecked="True">
         <TextBlock Text="test"/>
      </CheckBox>
   </Button>
   ```

# 오타
- p.38: Strike -> Stroke
