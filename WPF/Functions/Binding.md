## 키보드 입력 처리 - InputBindings 사용
```xml
<Window.InputBindings>
    <KeyBinding Command="Help" Key="F2"/>
    <KeyBinding Command="NotACommand" Key="F1"/>
</Window.InputBindings>
```

# Binding 
System.Windows.Data class의 Binding Class 사용

## 코드에서 Binding 설정
```c#
Binding binding = new Binding();
// 소스 객체 설정
binding.Source = btn1;
// 소스 프로퍼티 설정
binding.Path = new PropertyPath("Content");
// 타깃 프로퍼티 추가
btn2.SetBinding(Button.ContentProperty, binding);
```

## XAML에서 Binding 설정
- ElementName: 대상 이름
- Path: 대상 값 속성
    ```xml
    <!-- btn1의 Text값을 txtTest의 값이 변경될 때마다 반영 -->
    <TextBox x:Name="txtTest" Width="100" />
    <Button x:Name="btn1" 
            BorderBrush="{StaticResource borderBrush}" Margin="5" 
            Content="{Binding ElementName=txtTest, Path=Text}"
    />
    ```

## RelativeSource 바인딩
타 Element와의 관계를 통해서 바인딩 설정
- RelativeSource 
   - Self: 자기 자신
   - TemplatedParent
   - FindAncestor: 근접한 곳에서 찾아간다
      - AncestorType: 참조할 타입
      - AncestorLevel: n번째로 가까운 부모 엘리먼트와 동일하게
   - PrevioisData: 바인딩된 컬렉션의 이전 데이터와 동일하게 만들기 위해서

사용 예시
   ```xml
   <DataTrigger Binding="{Binding DisplayMode, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type Calendar}}}" Value="Decade">

   <Slider Width="200" 
           ToolTip="{Binding RelativeSource={RelativeSource Mode=Self}, Path=Value}"/>
   ```

## Property & Binding
- 데이터 바인딩이 되는 타깃 프로퍼티는 의존프로퍼티여야 한다


## Data Template
정의
- 읨의의 닷넷 객체가 렌더링 될 때 적용할 수 있는 UI의 한 부분
- 많은 WPF 컨트롤들이 데이터 템플릿을 효과적으로 사용하기 위해서 DataTemplate 타입의 프로퍼티들을 가지고 있다
- 예
   - ContentControl: Content 객체의 렌더링을 조절할 수 있는 ContentTemplate
   - ItemsControl: ItemTemplate

