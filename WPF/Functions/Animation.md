## Namespace
System.Windows.Media.Animation 

## [Storyboard](https://docs.microsoft.com/ko-kr/dotnet/api/system.windows.media.animation.storyboard?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DKO-KR%26k%3Dk(System.Windows.Media.Animation.Storyboard);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.6.1);k(DevLang-csharp)%26rd%3Dtrue&view=netframework-4.7.2)
Object나 Property를 대상으로 하는 animation의 타임라인 컨테이너 역할

Animation(Timeline class를 상속하는)을 생성하고 Storyboard에 child를 추가해서 관리

## C# Code에서 사용

```c#
// Animation 생성
var animation = new ThicknessAnimation
{
    Duration = new Duration(TimeSpan.FromSeconds(seconds)),
    From = new Thickness(offset, 0, -offset, 0),
    To = new Thickness(0),
    DecelerationRatio = 0.9f
};

// 대상 속성 추가
Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

// Storyboard instance에 child 추가
storyboard.Children.Add(animation);

// Storyboard 시작
// page는 animation을 적용할 대상
storyboard.Begin(page);
```

## XAML에서 사용
XAML에서는 `BeginStoryBoard`를 이용해서 적용 가능하다

```xml
 <ControlTemplate.Triggers>
    <!-- 마우스가 올라갔을 때 이벤트 발생 -->
    <EventTrigger RoutedEvent="MouseEnter">
        <!-- Storyboard 시작 -->
        <BeginStoryboard>
            <!-- Storyboard 정보 설정 -->
            <Storyboard>
                <!-- Animation 구현 -->
                <ColorAnimation To="{StaticResource WordBlue}" 
                                Duration="0:0:0.3" 
                                Storyboard.TargetName="border" 
                                Storyboard.TargetProperty="Background.Color" />
            </Storyboard>
        </BeginStoryboard>
    </EventTrigger>
</ControlTemplate.Triggers>
```