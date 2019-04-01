## Polygon
### 샘플
```xml
 <Grid.Background>
    <VisualBrush>
        <VisualBrush.Visual>
            <Canvas>
                <!--특정 Polygon에 Graidation을 적용하기 위해서 Resource 선언-->
                <Canvas.Resources>
                    <!-- 
                    Q: End Position의 값은 어떻게 정한 것인지 확인해보기
                    -->
                    <LinearGradientBrush x:Key="linearGradient-bg" StartPoint="0,0" EndPoint="0.350627841,0.64144199">
                        <LinearGradientBrush.GradientStops>
                            <GradientStopCollection>
                                <GradientStop Color="#A80A8A7C" Offset="0" />
                                <GradientStop Color="#6E076D5E" Offset="1" />
                            </GradientStopCollection>
                        </LinearGradientBrush.GradientStops>
                    </LinearGradientBrush>
                </Canvas.Resources>

                <!--4각형 형태의 좌표로 닫힌 도형을 그림-->
                <Polygon Points="0,675 900,675 900,0 0,0" Fill="#FF006253" StrokeThickness="1"/>
                <Polygon Points="0,675 900,120.71211 900,0 0,0" FillRule="EvenOdd" Fill="#FF045246" StrokeThickness="1"/>
                <Polygon Points="0,675 900,120.71211 900,0 0,0" FillRule="EvenOdd" Fill="{StaticResource linearGradient-bg}" StrokeThickness="1"/>
            </Canvas>
        </VisualBrush.Visual>
    </VisualBrush>
</Grid.Background>
```
## Path
### 샘플
```xml
<Path Stroke="Black" StrokeThickness="3" Fill="Blue">
    <Path.Data>
        <GeometryGroup>
            <!-- 선 그리기 -->
            <LineGeometry StartPoint="0,0" EndPoint="100,100"/>
            <!-- 원 그리기 -->
            <EllipseGeometry Center="10,10" RadiusX="50" RadiusY="40"/>
            <!-- 사각형 그리기 -->
            <RectangleGeometry Rect="0,0 40, 40"/>
        </GeometryGroup>
    </Path.Data>
</Path>
```