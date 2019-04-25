## DI가 없는 코드 (= 코드에 의존성이 많을 때)
- 단위 테스트가 어렵다
- 소스를 보기 전까지는 ViewModel이 어떤 것을 필요로하는지 명확히 인식하기가 어렵다
- 클래스내 구현체가 가진 의존성이 클래스의 잠재적인 의존성으로 포함된다
- 구현체를 다른 객체로 대체할 수 있는 유연성이 떨어진다

**클래스의 프록시화**
- 클라이언트에 대체 구현체를 전달할 수 있다는 것을 말한다

## 실제 구현체 전달
두가지 방법이 존재
- 객체를 직접 생성하여 전달 (Poor Man's Dependency Injection)
   - IoC 컨테이너를 사용하지 않고 new 연산자를 이용해서 직접 생성자를 전달하는 방식
- 제어의 역행 (IoC) 컨테이너를 사용하는 방법

## 객체를 생성해서 전달하는 방법

### Poor Man's Dependency Injection (객체 직접 생성을 통한 의존성 주입)
특징
- 초기화 코드에 따라 다르겠지만 애플리케이션의 진입점은 의존성 주입 코드를 작성하기에 최적의 위치
- 객체 직접 생성 방식을 적용하면 작성할 코드가 많아진다
   - 그 결과로 초기화 코드 복잡해질 수 있다
- 필요한 객체의 그래프를 직접 생성하면 되기 때문에 유연하고, 명확하다

예시
   ```C#
   var settings = new ApplicationSettings();
   var taskService = new TaskServiceAdo(settings);
   var objectMapper = new MapperAutoMapper();
   controller = new TaskListController(taskService
   ```

### 메서드 주입
특징
- 의존성을 주입하기 위해서 메서드의 매개변수를 이용하는 방법
- 호출되는 메서드가 의존성을 필요로하는 유일한 부분일 때 유용하다
- 메서드를 호출하는 클라이언트가 결국 의존 객체를 확보해야하는 점은 단점이다. 클라이언트는 생성자 매개변수나 메서드 매개변수 중 한가지를 통해 의존 객체를 전달할 수 있다.

### 속성 주입
특징
- 속성을 이용해서 의존성을 주입하는 방법
- 런타임에 필요 시점에 속성을 교체 가능하다는 점이 장점

예시
   ```c#
   // 속성 주입
   //taskService.Settings = settings;
   //var taskDtos = taskService.GetAllTasks();

   // 매서드 주입
   //var taskDtos = taskService.GetAllTasks(settings);
   ```

## 제어의 역행
특정
- 객체의 생성을 런타임 시점으로 미룰 수 있다. (생성자를 통한 주입은 컴파일 시점에 생성)
- 애플리케이션에 정의된 인터페이스와 그들의 실제 구현체들을 연결하여 클래스의 인스턴스를 생성할 때 필요한 의존성을 모두 해석(resolve)해준다
- 모든 클래스의 인스턴스를 직접 생서앟여 생성자에 전달했던 객체 직접 생성 방식의 절차를 그대로 따르지만, 모든 것이 자동화되어 있다는 차이점이 있다

예시
   ```c#
   // 생성자 주입
   //var settings = new ApplicationSettings();
   //var taskService = new TaskServiceAdo();
   //var objectMapper = new MapperAutoMapper();
   //controller = new TaskListController(taskService, objectMapper, settings);
   //MainWindow = new TaskListView(controller);

   //ICT 컨테이너
   container = new UnityContainer();
   container.RegisterType<ISettings, ApplicationSettings>();
   container.RegisterType<IObjectMapper, MapperAutoMapper>();
   container.RegisterType<ITaskService, TaskServiceAdo>();
   container.RegisterType<TaskListController>();
   container.RegisterType<TaskListView>();

   MainWindow = container.Resolve<TaskListView>();
   MainWindow.Show();
   ```


등록, 해석, 해제 패턴
- 등록(Register)
   - 초기화 시점에 처음 호출
   - 인터페이스와 구현를 등록하기 위해 여러번 호출 될 수 있다
   - 인터페이스 없이 구현체만 등록될 수도 있다
- 해석(Resolve)
   - 실행되는 동안 호출된다
   - 주로 객체 그래프의 최상위에 위치한 클래스를 해석하고자 할 때 사용된다
   - 이 메서드는 인프라스트럭처에 해당하는 코드에서 호출해야 한다. 즉, 큰터를로, 뷰, 프레젠터, 서비스, 도메인, 비니지스 로직 혹은 데이터 엑세스를 위한 클래스들이 Resolve 메서드를 호출해서는 안된다
- 해제(Release)
- 폐기(Dispose)
   - 완전히 종료될 때 한번 호출
- 기타
   - 메소드를 등록해야 하는 객체가 늘어날 수록 메서드 자체가 복잡해질 수 있기 때문에 여러개의 메서드로 분리하는 것이 좋다

## 안티 패턴
### 서비스 로케이터 안티패턴
특징
- 서비스 로케이터를 통해서 어떤 객체든지 조회가 가능하다<br>
즉, 필요한 객체가 주어지는 것이 아니라 필요에 따라 객체를 요청하게 되었다<br>
생성자 주입을 이용하는 경우 클래스가 필요로 하는 의존성들을 생성자나 인텔릴센스를 통해 한눈에 파악할 수 있었던 것과는 대조적이다

### 사생아 주입(illegitimate injection)
특징
- 기본 생성자에 구현체를 직접 생성하는 생성자를 구현
- 간혹 단위테스트 때문에 적용하는 경우가 있음. 기본 생성자는 아무런 의존성도 갖지 않으며, 내부에서만 사용되는 모의 구현체를 사용하도록 하는 경우이다.<br>
하지만 클래스내부에는 오직 단위 테스트만을 위해 존재하는 것들이 있어서는 안된다

## 컴포지션 루트 (Composition Root)
정의
- 전체 애플리케이션 중 의존성 주입에 대해 인지해야 하는 유일한 위치가 컴포지션 루트이다
- 이 지점에서 객체 직접 생성 방식이나 IoC 컨테이너를 이용해서 매핑 정보를 등록해야한다
- 컴포지션 루트로 가장 이상적인 지점은 애플리케이션의 진입점에서 가장 가까운 곳이다<br>
DI를 빨리 생성해야 컨터이너 없이 의존성이 생성되는 것을 막을 수 있기 때문이다

### 레졸루션 루트(Resolution Root)
정의
- 해석되어야 할 객체 그래프의 최상위 객체에 해당하는 객체 타입

## 규칙을 적용하여 의존성 주입 
특징
- 객체를 직접 생성하거나 규칙을 적용하는 것중 하나를 선택하면 된다
- 프로젝트가 간단하고 매핑이 필요한 객체가 많지 않으면 객체 직접 방식을 선택하면 된다
- 프로젝트가 복잡하고 인터페이스와 클래스들을 맵핑할 필요가 있다면, 규칙을 통해서 진행하고 필요한 매핑만 수동으로 처리하면 된다

### 중요한 것은 UI를 구현하는 방법 보다는 DI를 적용했는지 여부가 중요하다