


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