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

## 3.13 레이아웃
WPF는 컨트롤의 자식, 부모에 의해 제약된 크기를 조회하고 마지막에 컨트롤 자체의 Width, MinWidth 또는 MaxWidth 속성을 확인한다. 부모 제한 크기는 자식 필수 크기보다 우선이고, Width 속성은 부모나 자식의 값보다 우선한다. 

### Canvas
- Canvas 컨트롤은 자식 크기를 제한하지 않기 때문에, Button을 하위에 정의하면 Button이 Canvas를 벗어날 수 있다
- Canvas.Left, Canvas.Top으로 자식 컨트롤의 위치를 정의
   ```xml
   <Canvas>
      <Button Canvas.Top="0" Canvas.Left="0">A</Button>
      <Button Canvas.Top="25" Canvas.Left="0">B</Button>
      <Button Canvas.Top="25" Canvas.Left="25">C</Button>
      <Button Canvas.Top="0" Canvas.Left="500">C</Button>
   </Canvas>
   ```

### StackPanel
- Orientation 제어를 사용해서 Stack 과 같이 컨트롤르 쌓을 수 있다
- 기본적으로 자식 컨트롤은 StackPanel에 맞게 지정되지만, HorizontalAlignment 또는 VertialAlignment를 통해서 크기를 조정가능하다
   ```xml
   <StackPanel Orientation="Vertical">
      <Button>A</Button>
      <Button>B</Button>
      <Button>C</Button>
      <Button>D</Button>
   </StackPanel>
   ```

### DockPanel
- 데스크탑 애플리케이션과 같은 화면 레이아웃을 빠르게 얻을 수 있다
   ```xml
   <DockPanel>
      <Button DockPanel.Dock="Left" Content="Left" />
      <Button DockPanel.Dock="Right" Content="Right" />
      <Button DockPanel.Dock="Top" Content="Top" Height="30"/>
      <Button DockPanel.Dock="Bottom" Content="Bottom" />
      <Button Content="Takes waht's left" Height="100"/>
   </DockPanel>
   ```

### UniformGrid
- Grid의 Columns 속성을 이용해서 자동으로 필요한 컨트롤의 행과 열을 계산
   ```xml
   <UniformGrid Columns="2">
      <Label>Name</Label>
      <TextBox Width="70" />
      <Label>Age</Label>
      <ComboBox />
   </UniformGrid>
   ```

### Grid
- RowDefinition, ColumnDefinition을 통해서 레이아웃 정의 가능하다
- Grid는 컨트롤은 자식 크기를 제한하기 때문에, Button을 하위에 정의하면 Grid에 맞게 너비가 지정된다
- 컨트롤은 Grid.RowSpan 및 Grid.ColumnSpan 연결 속성을 이용해서 몇개의 열이나 행을 채울 수 있다
- Width, Height 속성
   1. 고정 숫자: 열/행에 픽셀의 수가 할당
   2. Auto: 열/행이 자체 콘텐츠에 대한 크기로 적용
   3. 별 또는 별이 붙은 숫자: 남은 높이/너비에 비례한 비율로 지정된다

   ```xml
   <Grid>
      <Grid.ColumnDefinitions>
            <ColumnDefinition Width="30" />
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="2*" />
            <ColumnDefinition Width="auto" />
      </Grid.ColumnDefinitions>
      <Button Grid.Column="0">0</Button>
      <Button Grid.Column="1">1</Button>
      <Button Grid.Column="2">2</Button>
      <Button Grid.Column="3">3</Button>
   </Grid>
   ```

## 3.14 목록 컨트롤
### 선택 컨트롤
- ListBox, ComboBox
   ```xml
   <ListBox Height="150">
      <Label>Element 1</Label>
      <Label>Element 2</Label>
      <GroupBox Header="Element3">
            With some contents
      </GroupBox>
      <Label>Element 4</Label>
   </ListBox>
   
   <ComboBox>
      <Label>Element 1</Label>
      <Label>Element 2</Label>
      <GroupBox Header="Element3">
            With some contents
      </GroupBox>
      <Label>Element 4</Label>
   </ComboBox>
   ```

# 4장. WPF 애플리케이션에서 데이터 관리
## 4.1 데이터 바인딩
- WPF에서는 Binding을 처리하는 XAML 코드를 통해서 동일한 동작을 C# code로 작성할 때에 비해서 더 짧고 직관적으로 처리 가능하다
   ```xml
   <StackPanel>
      <Slider Maximum="100" Value="10" x:Name="slider" />
      <ProgressBar Value="{Binding Value, ElementName=slider}"/>
      <TextBox Text="{Binding Value, ElementName=slider}"/>
      <TextBox Text="Yellow" x:Name="color" />
   </StackPanel>
   ```
- 바인딩 모드

   |모드|대상 변경|값 변경|
   |--|--|--|
   |TwoWay|Yes|Yes|
   |OneWay|No|Yes|
   |OneWayToSource|Yes|No|
   |OneTime|No|No|

## 4.3 변환기
- XAML 엔진은 데이터 바인딩 시 객체 유형을 반환하는 작업을 수행한다
- IValueConverter를 이용해서 확장 가능하다
   ```c#
   public class TwiceConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         double colorValue = double.Parse(value.ToString());
         if (colorValue > 10)
         {
               return Colors.Red;
         }
         else if (colorValue >= 4 && colorValue <= 10)
         {
               return Colors.Green;
         }
         else
         {
               return Colors.Yellow;
         }
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return null;
      }
   }
   ```
## 4.4 목록 컨트롤을 사용하는 컬렉션 표시
c# 코드
```c#
var cars = new List<Car>();
for (int i = 0; i < 10; i++)
{
      cars.Add(new Car()
      {
         Speed = i * 10,
         Color = Colors.Red
      });
}

this.DataContext = cars;
```
XAML 코드
```xml
<ListBox ItemSource="{Binding}" />
```

하지만 이렇게 하면 ListBox에 표시할 방법이 정해져있지 않기 때문에 ToString으로 표시가 된다. 결국 Class명이 표시된다

## 4.5 목록 컨트롤 사용자 정의
사용자 정의 속성
- ItemPanel: 요소를 배치하는 방법 설명. 항목 레이아웃
- ItemTemplate: 각 요소에 대해 반복이 필요한 템플릿을 제공한다. 각 항목의 모양
- ItemContainerStyle: 항목을 선택하거나 마우스를 올릴 때의 동작 방법을 설명
- Template: 컨트롤 자체를 렌더링하는 방법을 설명한다. 목록 주위(테두리, 배경, 스크롤바)

```xml
 <ListBox ItemsSource="{Binding}">
   <ListBox.ItemTemplate>
         <DataTemplate>
            <StackPanel>
               <TextBlock Text="Speed" />
               <TextBox Text="{Binding Speed}" />
               <Slider Value="{Binding Speed}" Maximum="100" />
               <TextBlock Text="Color" />
               <Border Height="10">
                     <Border.Background>
                        <SolidColorBrush Color="{Binding Color}" />
                     </Border.Background>
               </Border>
               <TextBox Text="{Binding Color}"/>
            </StackPanel>
         </DataTemplate>
   </ListBox.ItemTemplate>
</ListBox>
```

# 오타
- p.38: Strike -> Stroke
- p.114: Static/Resouce -> StaticResouce

