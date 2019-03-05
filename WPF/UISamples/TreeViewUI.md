```xml
<Grid>
        <TreeView x:Name="FolderView">
            <TreeView.Resources>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="HeaderTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <Image Width="20" Margin="3" 
                                           Source="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}},
                                                            Path=Tag,
                                                            Converter={x:Static local:HeaderToImageConverter.Instance}}" />
                                    <TextBlock VerticalAlignment="Center" Text="{Binding}" />
                                </StackPanel>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TreeView.Resources>
        </TreeView>
    </Grid>
```

```c#
[ValueConversion(typeof(string), typeof(BitmapImage))]
public class HeaderToImageConverter : IValueConverter
{
    public static HeaderToImageConverter Instance = new HeaderToImageConverter();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var path = (string)value;

        if (path == null)
        {
            return null;
        }

        var name = MainWindow.GetFileFolderName(path);

        var image = "Images/file.png";

        if (string.IsNullOrEmpty(name))
        {
            image = "Images/drive.png";
        }
        else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
        {
            image = "Images/folder-closed.png";
        }


        return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```