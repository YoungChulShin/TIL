## Grid에서 투명도 주기
### OpacityMask 속성 사용
1. 투명도를 배경으로 할 Boarder 구현
    ```xml
    <Border x:Name="Container" 
            Background="{StaticResource BackgroundVeryLightBrush}" 
            CornerRadius="{Binding WindowCornerRadious, FallbackValue=10}">
    </Border>
    ```

2. Grid 속성에서 OpacityMask 적용
    ```xml
    <Grid.OpacityMask>
        <VisualBrush Visual="{Binding ElementName=Container}" />
    </Grid.OpacityMask>
    ```
