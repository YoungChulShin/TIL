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