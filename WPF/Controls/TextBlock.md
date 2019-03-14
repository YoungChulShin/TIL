## Run 속성
TextBlock에서 각 단어별로 속성을 주고 싶을 때 사용

```xml
<TextBlock >
    <Run Text="W" Foreground="{StaticResource WordOrangeBrush}" />
    <Run Text="O" Foreground="{StaticResource WordBlueBrush}" />
    <Run Text="R" Foreground="{StaticResource WordRedBrush}" />
    <Run Text="D" Foreground="{StaticResource WordGreenBrush}" />
</TextBlock>
```

## 데이터가 변경되었을 때 속성 처리
Trigger에서 DataTrigger를 사용한다


```xml
<TextBlock Text="{TemplateBinding Tag}">
    <TextBlock.Style>
        <Style TargetType="{x:Type TextBlock}">
            <Setter Property="Visibility" Value="Collapsed" />
            <Style.Triggers>
                <!-- 상위 컨트롤의 텍스트가 공백일 경우에 Visibility를 True로 변경 -->
                <DataTrigger Binding="{Binding Text, RelativeSource={RelativeSource TemplatedParent}}" Value="">
                    <Setter Property="Visibility" Value="Visible" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </TextBlock.Style>
</TextBlock>
```