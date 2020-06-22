## 설치
필수 패키지
- Install-Package Ninject -version 3.0.1.10

확장 패키지
- Install-Package Ninject.Web.Common -version 3.0.0.7
- Install-Package Ninject.MVC3 -Version 3.0.0.6

## 사용
예시
```c#
IKernel ninjectKernel = new StandardKernel();
ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
```