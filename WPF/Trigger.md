## DataTrigger
특정 데이터가 변경될 때 그 값을 기준으로 이벤트 설정

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