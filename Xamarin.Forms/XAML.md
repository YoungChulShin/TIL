### 기본
- XAML: eXtensible Application Markup Language
- 역할
  - 개발자들이 Xamarin.Forms에서 사용자 인터페이스를 정의할 때 사용
  - MVVM(Model-View-ViewModel) 아키텍쳐 프로그램과 어울리며, View를 정의하는데 사용된다.
- 장점
  - Code보다 가독성이 좋다
  - Parent-Child의 Hierarchy 구조로 구성이 가능하다
  - 손으로도 쉽게 작성 가능하다
- 단점
  - 코드를 포함할 수 없어서, 모든 이벤트 처리는 코드 파일에 별도로 정의 되어야 한다
  - 반복 처리를 위한 루프를 가질 수 없다
  - 조건에 대한 처리를 할 수 없다
  - XAML generally cannot instantiate classes that do not define a parameterless constructor.
  - 일반적으로 함수를 호출할 수 없다

https://docs.microsoft.com/ko-kr/xamarin/xamarin-forms/xaml/xaml-basics/get-started-with-xaml?tabs=vswin

### Don't Know
- Markup Language
  - 문서가 화면에 표시되는 형식을 나타내거나 데이터의 논리적인 구조를 명시하기 위한 규칙들을 정의한 언 일종이다. 데이터를 기술한 언어라는 점에서 프로그래밍 언어와는 차이가 있다. 
  - 굳이 어렵게 생각할 필요 없이, 책에 볼펜으로 밑줄을 긋는 행위도 그 내용이 중요하다는 의미를 나타내므로 마크업의 일종이라고 할 수 있다. 
  - 대표적으로는 HTML (Hyper Text Markup Language)