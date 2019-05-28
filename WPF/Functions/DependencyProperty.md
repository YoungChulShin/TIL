
## Dependency Property
### 기능
- 컨트롤에 속성의 정의해줄 수 있는 기능

### 구현 및 특
- DependencyProperty 변수는 관습적으로 public, static을 이용한다
   - Static으로 구현되기 때문에 일반적인 프로퍼티에 비해서는 메모리 절약효과가 있다
- DependencyProperty.Register를 이용해서 등록한다

### FrameworkPropertyMetadataOptions
- AffectsRender: 값이 변경될 때마다 엘리먼트 자체를 렌더링해야 한다면 사용

### Property Trigger - Style.Triggers
- Style 내에서 사용
- XAML에서 이벤트를 구현 가능
   - 예를 들어 Button에 MouseEnter를 적용하려면 MouseEnter 이벤트를 적용해야 하지만, Property Trigger를 이용하면 IsMouseOver Property를 이용해서 적용 가능
- 예시
    ```xml
    <Button Content="TEST" Width="100" Height="100">
        <Button.Style>
            <Style TargetType="{x:Type Button}">
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Foreground" Value="Red"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
    ```

### 프로퍼티 값 상속
WPF에서 프로퍼티 값은 엘리먼트 트리 구조에서 하위 엘리먼트로 상속이 된다
- 윈도우에서 fontsize를 20으로 설정했으면, 하위 엘리먼트에서 별도의 fontsize 설정이 없다면 20이 적용된다

프로퍼티를 등록할 때(=Reigster), 메타데이터가 FrameworkPropertyMetadataOptions

### 다중 프로바이더 지원
WPF에서는 다중 프로퍼티를 지원한다. 의존 프로퍼티의 값은 아래 처리 절차에 의해서 정해진다

처리 절차
1. 프로퍼티 값 처리 기준 설정
   1. 로컬 값 설정
   2. 스타일 트리거
   3. 템플릿 트리거
   4. 스타일 세터
   5. 테마 스타일 트리거
   6. 테마 스타일 세터
   7. 프로퍼티 값 상속
   8. 기본 값
2. 표현식 전환
   - 동적 리소스나 바인딩 등으로 인한 값의 변경
3. 애니메이션 적용
4. 강제 설정
   - 의존 프로퍼티에 CoerceValueCallback 을 통해서 값의 강제 설정을 할 수 있다
   - 예: ProgressBar의 경우 최솟값과 최댓값을 넘어가면 해당 값을 반영한다
5. 유효성 검사
   - 의존 프로퍼티가 ValidateValueCallback 을 가지고 있다면 결과가 false일 경우 전체 과정이 취소된다


### 첨부 프로퍼티 (Attached Property)
특징
- 임의의 객체에 추가하기 위해 사용하는 특별한 의존 프로퍼티
   - 첨부 프로퍼티를 위한 프로퍼티 메타데이터에 최적화
   - 예를 들어서 StackPanel에는 FontSize관련 프로퍼티가 없지만 TextElement.FontSize를 이용해서 추가할 수 있다
- C# 코드 기준으로 보면 엘리먼트에 관련있는 메서드를 호출하는 것 뿐이다. 어떤 닷넷 프로퍼티와도 연관성이 없다

참고 링크
- [Stackoverflow](https://stackoverflow.com/questions/910579/dependencyproperty-register-or-registerattached)
- [TextElement 소스](https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/Documents/TextElement.cs,e28640b48d79de57)
- [Control 소스](https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/Controls/Control.cs,6750b721a2294fc5)

Control과 TextElement의 'FontSizeProperty' 관계
- TextElement에는 FontSizeProperty에 대해서 'RegisterAttached' 함수가 구현.<br>
이를 통해서 다른 컨트롤에서 사용 가능
- Control에는 FontSizeProperty에 대해서 호출 참조 제공
   ```c#
   public static readonly DependencyProperty FontSizeProperty =
        TextElement.FontSizeProperty.AddOwner(
                typeof(Control),
                new FrameworkPropertyMetadata(SystemFonts.MessageFontSize,
                    FrameworkPropertyMetadataOptions.Inherits));
   ```


## TextBlock의 TextProperty 구현 코드
```C#
// Dependency Property 정의
/// <summary>
/// DependencyProperty for <see cref="Text" /> property.
/// </summary>
[CommonDependencyProperty]
public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(TextBlock),
                new FrameworkPropertyMetadata(
                        string.Empty,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnTextChanged),
                        new CoerceValueCallback(CoerceText)));

// Text 속성 정의
/// <summary>
/// The Text property defines the content (text) to be displayed.
/// </summary>
[Localizability(LocalizationCategory.Text)]
public string Text
{
    get { return (string) GetValue(TextProperty); }
    set { SetValue(TextProperty, value); }
}

// OnTextChanged 함수
private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
{
    OnTextChanged(d, (string)e.NewValue);
}

private static void OnTextChanged(DependencyObject d, string newText)
{
    TextBlock text = (TextBlock) d;

    if (text.CheckFlags(Flags.TextContentChanging))
    {
        // The update originated in a TextContainer change -- don't update
        // the TextContainer a second time.
        return;
    }

    if (text._complexContent == null)
    {
        text._contentCache = (newText != null) ? newText : String.Empty;
    }
    else
    {
        text.SetFlags(true, Flags.TextContentChanging);
        try
        {
            bool exceptionThrown = true;

            Invariant.Assert(text._contentCache == null, "Content cache should be null when complex content exists.");

            text._complexContent.TextContainer.BeginChange();
            try
            {
                ((TextContainer)text._complexContent.TextContainer).DeleteContentInternal((TextPointer)text._complexContent.TextContainer.Start, (TextPointer)text._complexContent.TextContainer.End);
                InsertTextRun(text._complexContent.TextContainer.End, newText, /*whitespacesIgnorable:*/true);
                exceptionThrown = false;
            }
            finally
            {
                text._complexContent.TextContainer.EndChange();

                if (exceptionThrown)
                {
                    text.ClearLineMetrics();
                }
            }
        }
        finally
        {
            text.SetFlags(false, Flags.TextContentChanging);
        }
    }
}

```
