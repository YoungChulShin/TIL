
## Dependency Property
### 기능
- 컨트롤에 속성의 정의해줄 수 있는 기능

### 구현 및 특
- DependencyProperty 변수는 관습적으로 public, static을 이용한다
   - Static으로 구현되기 때문에 일반적인 프로퍼티에 비해서는 메모리 절약효과가 있다
- DependencyProperty.Register를 이용해서 등록한다

### FrameworkPropertyMetadataOptions
- AffectsRender: 값이 변경될 때마다 엘리먼트 자체를 렌더링해야 한다면 사용

### Property Trigger
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
