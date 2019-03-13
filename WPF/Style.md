## 공용 스타일 적용
### 전체 컨트롤에 스타일 적용
```xml
<Style TargetType="{x:Type Control}" x:Key="BaseStyle">
    <Setter Property="FontFamily" Value="{StaticResource LatoThin}" />
</Style>
```

### 특정 컨트롤에 스타일 적용 (공용 컨트롤을 상속)
```xml
<Style TargetType="{x:Type Button}" BasedOn="{StaticResource BaseStyle}" />
<Style TargetType="{x:Type Label}" BasedOn="{StaticResource BaseStyle}" />
```



## Button에 Style 적용
1. 리소스에 버튼 Style 정의
    ```xml
    <!-- Hoverless button-->
    <Style TargetType="{x:Type Button}" x:Key="Hoverless">
        <Setter Property="Background" Value="Transparent" />
        <Setter Property="BorderThickness" Value="0" />

        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Border Padding="{TemplateBinding Padding}" Background="{TemplateBinding Background}">
                        <ContentPresenter VerticalAlignment="Center" HorizontalAlignment="Center" />
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

    <!--System Icon button-->
    <Style TargetType="{x:Type Button}" x:Key="SystemIconButton" BasedOn="{StaticResource Hoverless}">
        <Setter Property="WindowChrome.IsHitTestVisibleInChrome" Value="True" />
        <Setter Property="Padding" Value="10" />
    </Style>
    ```

2. 할당한 리소스를 UI에서 호출
    ```xml
    <Button Style="{StaticResource SystemIconButton}" Command="{Binding MenuCommand}">
        <Image Source="/Images/Logo/logo-small.png" />
    </Button>
    ```

## 마우스 Over 이벤트 설정
Style에서 Trigger 속성 사용
```xml
<Style.Triggers>
    <Trigger Property="IsMouseOver" Value="True">
        <Setter Property="Background" Value="{StaticResource BackgroundLightBrush}" />
    </Trigger>
</Style.Triggers>
```

## Template 
Style에서 Property로 사용. 

Template 양식 적용
### ControlTemplate
Control이 보여주는 방법을 적용할 때 사용
```xml
 <Style TargetType="{x:Type Button}" x:Key="WindowControlButton" BasedOn="{StaticResource BaseStyle}">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type Button}">
                <Border Padding="{TemplateBinding Padding}" Background="{TemplateBinding Background}">
                    <TextBlock VerticalAlignment="Center" HorizontalAlignment="Center" Text="{TemplateBinding Content}" />
                </Border>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```