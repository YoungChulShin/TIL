## 기능
MVVM에서 데이터를 바인딩할 때 입력되는 값을 바인딩되는 양식에 맞게 변경해주는 기능

## 선언 코드
IValueConverter Interface를 구현해서 사용한다

### Base Value Converter 구현
```c#
public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter 
    where T : class, new()
{
    private static T mConverter = null;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return mConverter ?? (mConverter = new T());
    }

    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
}
```

### Child Value Converter 구현
```c#
public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((ApplicationPage)value)
        {
            case ApplicationPage.Login:
                return new LoginPage();

            default:
                Debugger.Break();
                return null;
        }
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

### ViewModel 구현
```c#
public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
```

### XAML에서 호출 코드
```xml
<Frame x:Name="MainFrame" 
       Content="{Binding CurrentPage, Converter={local:ApplicationPageValueConverter}}" />
```