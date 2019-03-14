## LayoutTransform
### ScaleTransform
X, Y 축에 보여주는 크기를 임의의 비율로 조정
```xml
<Setter Property="LayoutTransform">
    <Setter.Value>
        <ScaleTransform ScaleX="1.5" />
    </Setter.Value>
</Setter>
```

## Margin, Padding
Margin: 밖으로 밀어내는 것
Padding: 안으로 깎는 것

## Template 복사
특정 컨트롤의 Style을 구현할 때 기존 컨트롤이 가지고 있는 속성을 확인해야할 때가 있다. 이때 VS에서는 템플릿 복사 기능을 제공한다. 여기서 항목을 복사해서 Style의 template 속성에 value로 사용한다. 복사 후에는 필요한 것만 남겨두고 삭제해도 된다