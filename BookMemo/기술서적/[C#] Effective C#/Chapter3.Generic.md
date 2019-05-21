# 3.제네릭 활용
Generic 타입에 따른 코드 공유
- Generic 타입의 매개변수로 참조 타입이 주어지면 공유된 머신 코드를 사용한다.<br>
따라서 이 경우에는 어떤 타입이라 하더라도 메모리의 풋프린트에 영향을 주지 않는다. 
- Generic 타입의 매개변수로 값 타입이 주어지면 각각의 다른 머신코드가 생성된다

Value 타입의 Generic 
- 박싱과 언박싱을 피할 수 있다
- 코드와 데이터의 크기가 줄어든다
- 타입 안정성 -> 런타임에서 확인할 필요가 없다
- Generic Method를 사용하면 해당 메서드만 인스턴스화되므로 추가되는 IL코드의 양이 많지 않다
   
## Item18. 반드시 필요한 제약 조건만 설정하라
제약 조건을 설정하면 컴파일러는 System.Object에 정의된 public 메서드 보다 더 많은 것을 타입 매개변수에 기대할 수 있게 된다. 

제약조건은 컴파일러 입장에서 2가치 측면에서 도움이 된다
1. 제네락 타입을 작성 할 때 도움이 된다. 컴파일러는 타입 매개변수로 전달된 타입이 제약 조건으로 설정 가능한 기능을 모두 구현하고 있을 것이라 가정할 수 있다
2. 컴파일러는 제네릭 타입을 사용하는 사용자가 타입 매개변수로 올바른 타입을 지정했는지를 컴파일타임에 확인할 수 있다

제네릭 타입을 작성할 때 필요한 제약 조건이 있다면 반드시 이를 작성하자. 제약 조건이 없다면 타입의 오용 가능성이 높아지고, 사용자의 잘못된 예측으로 런타입 예외나 오류가 발생할 가능성이 높아지게 된다. 

C# 컴파일러는 제약 조건에 설정된 정보만을 이용해서 IL을 생성한다. 타입 매개변수로 지정된 타입이 설사 인스턴스화 되었을 때 더 나은 메서드를 가졌다 하더라도 제네릭 타입을 컴파일할 때 알려진 내용이 아니라면 사용하지 않는다. 

C#의 default() 연산자는 특정 타입의 기본 값을 가져온다 (값타입 0, 참조타입 null). new T() 대신 default(T)를 사용하는 것이 적절한 대안이 될 수 있다면 new() 제약조건을 설정하지 않는 편이 좋다


아래 코드는 값을 비교하는 2개의 함수이다. 첫번째 함수는 런타임에서 제약조건을 체크하고, 두번째 함수는 컴파일타입에서 제약 조건을 체크한다
   ```csharp
   public bool AreEqual<T>(T left, T right)
   {
      if (left == null)
      {
            return right == null;
      }

      if (left is IComparable<T>)
      {
         IComparable<T> lval = left as IComparable<T>;
         if (right is IComparable<T>)
         {
            return lval.CompareTo(right) == 0;
         }
         else
         {
            throw new ArgumentException("Type does not implement IComparable<T>", nameof(right));
         }
      }
      else
      {
         throw new ArgumentException("Type does not implement IComparable<T>", nameof(left));
      }
   }

   public bool AreEqual2<T>(T left, T right) where T : IComparable<T> => left.CompareTo(right) == 0;
   ```

## Item19. 런타임에 타입을 확인하여 최적의 알고리즘을 사용하라


## Item20. IComparable<T>와 IComparer<T>를 이용해서 객체의 선후 관계를 정의하라
### 닷넷에서 제공하는 2개의 선후관계 인터페이스
1. IComparable<'T'> : 타입의 기본적인 선후 관계를 정의
2. IComparer<'T'> : 기본적인 선후 관계 이외의 추가적인 선후관계를 정의한다

### 구현 시 참고
- 닷넷 최신 API들은 대체로 IComparable<T>를 사용하지만, 일부 오래된 API들은 여전히 IComparable을 사용한다. 따라서 IComparable<T>를 구현할 때는 IComparable도 함께 구현해야 한다. 
- 타입 매개변수를 취하지 않는 IComparable의 경우 런타임에 타입을 확인해야 한다. 박싱/언박싱으로 인한 성능 비용도 발생한다. 

### 추가적인 선후관계 구현
1. Comparison<'T'> 라는 델리게이트에 작업을 위임한다
   ```c#
   public delegate int Comparison<in T>(T x, T y);
   ```
2. 오래된 라이브러리는 IComparer 인터페이스를 통해서 제공

### 구현 예시
   ```c#
   public struct Customer : IComparable<Customer>, IComparable
   {
      private readonly string name;
      private double revenue;

      public Customer(string name, double revenue)
      {
         this.name = name;
         this.revenue = revenue;
      }

      // IComparable<Customer> 멤버
      public int CompareTo(Customer other) => name.CompareTo(other.name);

      // IComparable 멤버
      public int CompareTo(object obj)
      {
         if (!(obj is Customer))
         {
               throw new ArgumentException("Argument is not a Customer", nameof(obj));
         }

         Customer otherCustomer = (Customer)obj;

         return this.CompareTo(otherCustomer);
      }

      // 추가적인 정렬이 필요할 경우 Comparison<Customer> 델리게이트에 작업을 위임한다
      public static Comparison<Customer> CompareByRevenue =>
         (left, right) => left.revenue.CompareTo(right.revenue);

      // 오래된 라이브러리의 경우는 Comparison<T>와 유사한 ICompare 인터페이스를 통해서 제공
      private static Lazy<RevenueComparer> revComp =
         new Lazy<RevenueComparer>(() => new RevenueComparer());

      public static IComparer<Customer> RevenueCompare => revComp.Value;

      private class RevenueComparer : IComparer<Customer>
      {
         public int Compare(Customer x, Customer y)
         {
               return x.revenue.CompareTo(y.revenue);
         }
      }
   }
   ```

## Item21. 타입 매개변수가 IDisposable을 구현한 경우를 대비하여 제네릭 클래스를 작성하라
### 제약 조건의 2가지 역할
1. 런타임 오류가 발생할 가능성이 있는 부분을 컴파일 타임에 오류로 대체할 수 있다
2. 타입 매개변수로 사용할 수 있는 타입을 명확히 규정할 수 있다

하지만 무엇을 해야하는지만을 규정할 수 있고, 무엇을 하면 안되는지에 대한 규정은 없다. 

### 타입 매개변수로 지정하는 타입이 IDisposable을 구현하고 있다면 추가작업이 반드시 필요하다
T가 지역 변수
- using 문을 사용해서 using 블록이 종료될 때 Dispose가 호출되도록 한다
   ```c#
   public class EngineDriverOne<T> where T : IEngine, new()
   {
      public void GetThingsDone()
      {
         //구현 1 - T가 IDisposable을 구현하고 있으면 누수가 발생할 수 있음
         //T driver = new T(); 
         //driver.DoWork();    

         //구현 2 - T가 IDisposable이면 driver.DoWork가 완료되고 Dispose가 호출
         T driver = new T();
         using (driver as IDisposable)
         {
               driver.DoWork();
         }
      }
   }
   ```

T가 멤버 변수
- T가 멤버변수라면 Class가 IDisposable을 구현하여 Dispose함수에 멤버변수 처리 로직을 추가한다
   ```c#
   public sealed class EngineDriverTwo<T> : IDisposable where T : IEngine, new()
   {
      private Lazy<T> driver = new Lazy<T>(() => new T());

      public void GetThingsDone() => driver.Value.DoWork();

      public void Dispose()
      {
         if (driver.IsValueCreated)
         {
               var resource = driver.Value as IDisposable;
               resource?.Dispose();
         }
      }
   }
   ```

이러한 구조가 복잡하다면 T의 처리를 외부로 넘길 수 있다. 생성된 T의 object를 생성자의 파라미터로 처리하면 구조를 간단히 할 수 있다
   ```c#
   public sealed class EngineDriver<T> where T : IEngine
   {
      private T driver;
      public EngineDriver(T driver)
      {
         this.driver = driver;
      }
   }
   ```

중요한 것은 제네릭 클래스의 타입 매개변수로 객체를 생성하는 경우 이 타입이 IDisposable을 구현하고 있는지를 확인해야 한다는 것이다. 항상 방어적으로 코드를 작성하고 객체가 삭제될 때 리소스가 누수되지 않도록 주의해야 한다. 

## Item22. 공변성과 반공변성을 지원하라
### 공변성(covariance)/반공변(contravariance)
정의
- 공변과 반공변이란 타입 매개변수로 주어지는 타입들이 상호 호환 가능할 경우