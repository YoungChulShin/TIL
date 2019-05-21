## 기본 설명
MVC는 도메인 모델 및 컨트롤러 로직을 사용자 인터페이스와 분리시킴으로써 자연스럽게 관심사의 분리(Separation of Concerns)를 이끌어 낸다. 

### Model/View/Controller
Model
- 사용자가 작업할 데이터를 담겨나 표현한다. 
- View Model
   - 뷰와 컨트롤러 사이에 전달되는 데이터만을 담고 있다
- Domain Model
   - 업무 도메인의 데이터
   - 데이터에 대한 작업과 변환 그리고 조작 규칙을 담고 있다

View
- 모델의 특정 부분을 사용자 인터페이스로 렌더하는 데 사용

Controller
- 전달 받은 요청을 처리하고, 모델을 이용해서 작업을 수행하며 사용자에게 렌더될 뷰를 선택한다

기타
- View는 Model을 직접적으로 인식하지 않으며, 어떤방식으로도 직접 Model과 의사소통하지 않는다

Domain Model
- MVC 응용프로그램에서 가장 중요한 부분
- 모델은 응용 프로그램이 반드시 지원해야만 하는 현실 세계의 특정 산업이나 업무에 대한 엔티티, 작업, 규칙들을 규정함으로써 정의하게 되는데, 이를 **Domain**이라 한다
- 이 도메인을 소프트웨어 적으로 표현한 것이 **Domain Model** (C#의 Class, Struct)
- 데이터의 일부분을 표현하기 위해서 도메인 형식을 개체를 생성하는데 이를 **Domain Object**
- ASP.NET MVC에서 Domain Model과 응용프로그램을 분리하는 방법은 Model을 별도의 C# 어셈블리로 작성하는 것이다

## 느슨한 결합
### 예시
PasswordHelper -> IEmailSender <- MyEmailSender

위와 같이 구현된 구조에서 Password와 MyEmailSender사이에는 직접적인 의존성이 없다. IEmailSender를 도입함으로써 PasswordHelper 클래스를 변경하지 않고도 MyEmailSender를 다른 전자메일 공급자로 대체한다거나 테스트를 위해서 Mock 구현을 사용할 수 있다

### 의존성 주입(DI)
하지만 위 코드를 구현한다면 PasswordHelper에서 IEmailSender object를 생성하기 위해서 결국 MyEmailSender를 참조해야한다. 이를 막기 위해서 DI(Dependency Injection)을 사용한다. 

종류
1. 생성자 주입(Constructor Injection)
2. 세터 주입(Setter Injection)
3. 의존성 주입 컨테이너(DI Container)

