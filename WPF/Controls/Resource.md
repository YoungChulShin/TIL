# 바이너리 리소스
닷넷프레임워크의 여러분야에서 공통적으로 사용하는 기본 리소스

## 리소스 정의
방법
1. 비주얼스튜디오에 파일 추가
2. 빌드작업(Build Action)을 선택
   - Resource: 위성 어셈블리나 일반 어셈블리에 리소스를 포함한다
   - Content: 리소스를 느슨한 파일로 남겨두지만, AssemlbyAssociatedContentFile 어트리뷰트를 통해서 파일의 상대경로와 파일명을 기록한다
   - ※ EmbeddedResource는 선택하지 않는다: WPF 이전부터 있던 값이며, 별도의 코딩이 없다면 XAML에서 접근 할 수 없다

## 리소스 접근
XAML에서 리소스 접근
- 문자열 URI를 형전환 해주는 Converter가 존재
- 예시
   ```xml
     <StackPanel Orientation="Horizontal" Height="300">
        <Button ToolTip="Previous ...">
            <Image Width="200" Source="Resources/doitc언어입문.jpg" />
        </Button>
    </StackPanel>
   ```

코드에서 리소스 접근
- pack://packageURI/partPath 를 통해서 접근
- 예시: "pack://application:,,,/Simpson.jpg"
   - ,,,는 ///를 인코딩한것
   - XAML에서 logo.jpg는 pack://application:,,,/logo.jpg를 줄여서 사용한 것이다

# 로지컬 리소스
엘리먼트의 Resources 프로퍼티에 닷넷 객체를 저장하고, 여러 자식 엘리먼트 사이에서 공유할 수 있다. 

### 적용 및 참조
- 닷넷의 System.Windows.StaticResourceExtension 클래스와 상응하는 StaticResource 마크업 확장식을 사용해야 한다
- StaticResource를 이용해서 참조
   - WindowResource의 경우는 ResourceKey를 같이 참조
   ```xml
    <Window.Background>
        <StaticResource ResourceKey="backgroundBrush" />
    </Window.Background>
   ```

### 리소스 룩업
리소스를 찾을 때 그 아이템이 반드시 현재 엘리먼트의 리소스 딕셔너리에 있을 필요는 없다. 로지컬 트리를 탐색할 수 있는데, 우선 리소스 딕셔너리인 Resources 컬렉션을 검색하고, 필요한 아이템이 없다면 루트 엘리먼트에 도달할 때까지 부모 엘리먼트를 계속 찾는다. 

그래도 없을 경우에는 InvalidOperation-Exception을 발생시킨다. 

### Static Resource, Dynamic Resource
기능
- Static Resource: 리소스가 처음 필요할 때 오직 한 번 적용된다
- Dynamic Resource: 매번 변경될 때마다 반복 적용될 수 있다

적용
- StaticResource를 적용할 수 있는 곳이면 어디든지 사용할 수 있으며 결과가 동일하다. 어떤 것을 사용해야할지 결정이 필요하다면 리소스를 사용하는 엘리먼트가 리소스가 수정되었다는 것을 알아야 하는지에 따라 결정된다. 

로드&부하
- StaticResource는 윈도우나 페이지가 로드될 때마다 항상 로드되지만 DynamicResource는 사용될 때만 로드된다. DynamicResource가 원하는 값을 찾는 과정에 추가적인 작업이 필요하기 때문에 StaticResource보다는 더 부하가 걸리지만 로딩 시간을 올릴 수 있다. 

선참조 (forward reference)
- StaticResource는 선참조가 지원되지 않는다. 따라서 리소스가 동일한 엘리먼트에 정의되어 있다면 Property Attribute 형식으로 StaticResource를 사용할 수 없다
   ```xml
   <Window ...
         Background="{DynamicResource backgroudBrush}"><!--backgroudBrush를 참조 가능-->
      <Window.Resources>
         <SolidColorBrush x:Key="backgroudBrush">Yellow</SolidColorBrush>
      </Window.Resources>
   </Window>
   ```

### 시스템 정의된 배경색을 사용
System.Windows 내에 SystemColors, SystemFonts, SystemParameters 클래스를 사용할 때에는 DynamicResource가 적당하다. 제어판에서 사용자가 관련 설정을 변경할 수 있기 때문이다. 

```xml
<Button Content="안녕하세요2" Width="100" 
        Background="{DynamicResource {x:Static SystemColors.GrayTextBrush}}" />
```