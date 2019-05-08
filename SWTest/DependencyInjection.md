## 개념
인터페이스와 DI 컨테이너의 조합을 이용해서 MVC 응용프로그램 내부의 구성요소들을 서로 분리시킨다는 개념.

이때 DI 컨테이너는 개체가 의존하는 인터페이스 구현들의 인스턴스를 생성한 다음, 이를 개체의 생성자에 주입해서 개체의 인스턴스들을 생성해주는 역할을 수행하게 된다. 

## 종류
1. 생성자 주입(Constructor Injection)

## 의존성 해결자(Dependency Resolver)
MVC 프레임워크는 요청을 서비스하기 위해서 필요한 클래스들의 인스턴스들을 생성해야 할 때마다 의존성 해결자를 이용한다. 사용자 지정 의존성 해결자를 생성함으로써 MVC 프레임워크가 개체를 생성할 때마다 항상 Ninject를 사용하도록 구성할 수 있다. 

### 사용 방법
1. 사용자 지정 의존성 해결자 등록
   - MVC의 경우는 IDependencyResolver Interface를 구현해서 사용자 지정 의존성 해결자를 등록한다. 
   - IDependencyResolver는 GetService, GetServices라는 Method를 가지고 있는데, kernel을 통해서 binding을 설정 해 놓으면 object를 생성해 준다
        ```c#
        public class NinjectDependencyResolver : IDependencyResolver
        {
            private IKernel kernel;

            public NinjectDependencyResolver(IKernel kernelParam)
            {
                kernel = kernelParam;
                AddBindings();
            }

            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }
        ```
   

2. 사용자 지정 의존자를 생성자에 주입
   - 생성자에 필요로하는 Object를 Parameter로 전달한다
   - 사용자 지정 의존자에서 선언한 Binding을 통해서 NInject에서 Object를 생성해 준다
        ```c#
        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }
        ```

### 


## 의존성 체인
의존성이 필요한 개체들을 연속적으로 등록해서 의존성 체인을 만들어 준다.

아래 예제를 보면 Home Controller는 IValueCalculator 인터페이스에 의존성을 가지고 있고, 이 의존성은 LinqValueCalculator를 생성해서 해결하도록 되어 있다. 

다시 LinqValueCalculator는 IDiscountHelper에 의존성을 가지고 있고, 이 의존성은 DefaultDiscountHelper를 생성해서 해결하도록 되어 있다. 

   ```c#
   private void AddBindings()
   {
       kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
       kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();
   }
   ```
