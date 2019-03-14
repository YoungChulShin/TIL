## FullbackValue
Binding이 실패할 때 대응 값 설정
```xml
<RowDefinition Height="{Binding TitleHeightGridLength, FallbackValue=42}" />
```

## RelativeSource
### 설명
바인딩을 할 때 현재 위치의 대상을 기준으로 특정 위치의 소스를 지정할 때 사용
- [Gets or sets the binding source by specifying its location relative to the position of the binding target](https://docs.microsoft.com/ko-kr/dotnet/api/system.windows.data.binding.relativesource?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DKO-KR%26k%3Dk(System.Windows.Data.Binding.RelativeSource);k(VS.XamlEditor);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.6.1)%26rd%3Dtrue&view=netframework-4.7.2)

### 대상 값 - RelativeSourceMode Enum
- [문서 링크](https://docs.microsoft.com/ko-kr/dotnet/api/system.windows.data.relativesourcemode?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DKO-KR%26k%3Dk(System.Windows.Data.RelativeSourceMode);k(VS.XamlEditor);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.6.1)%26rd%3Dtrue&view=netframework-4.7.2)

### 예시
```xml
<DataTrigger Binding="{Binding Text, RelativeSource={RelativeSource TemplatedParent}}" Value="">
```