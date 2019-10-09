## 기본 용어 및 정의
정의
- XAML은 닷넷의 객체들을 초기화하거나 생성하기에 적합하도록 설계된 간편하고 범용적인 선언형 프로그래밍 언어

Loose XAML Page
- XAML만으로 구성된 페이지


## 엘리먼트
- XAML에서 `object element`를 선언하면 기본 생성자를 사용해서 사응하는 닷넷 객체를 생성하는 것과 동일하다
- `property attribute`를 설정하는 것도 닷넷 객체에 동일 프로퍼티를 설정하는 것과 동일하다

## 네임스페이스
### XAML의 namepsace와 CLR의 namesapce가 맵핑이 가능한 이유
- xaml: `http://schemas.microsoft.com/winfx/2006/xaml/presentation`
- clr: `System.Windows.Controls` 
- WPF 어셈블리 내부에 맵핑 정보가 하드코딩 되어 있다
- `schemas.microsoft.com`: 단지 임의의 네임스페이스를 구별하기 위한 키워드

### 기본 네임스페이스
`xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"`
- System.Windows
- System.Windows.Automation
- System.Windows.Controls
- System.Windows.Controls.Primitives
- System.Windows.Data
- System.Windows.Documents
- System.Windows.Forms.Integration
- System.Windows.Ink
- System.Windows.Input
- System.Windows.Media
- System.Windows.Media.Animation
- System.Windows.Media.Effects
- System.Windows.Media.Imaging
- System.Windows.Media.Media3D
- System.Windows.Media.TextFormatting
- System.Windows.Navigation
- System.Windows.Shapes

`xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`
- x를 붙이는 것은 일종의 관계
- System.Windows.Markup

`xmlns:d="http://schemas.microsoft.com/expression/blend/2008"`
- XAML 디자인을 지원하는 네임스페이스

`xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"`
- 마크업 호환 여부


참고 문서
- MSDN: [Link](https://docs.microsoft.com/en-us/previous-versions/windows/silverlight/dotnet-windows-silverlight/cc189061(v=vs.95)?redirectedfrom=MSDN)



