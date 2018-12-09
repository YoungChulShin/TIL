## 3.제네릭 활용
- Generic 타입에 따른 코드 공유
   - Generic 타입의 매개변수로 참조 타입이 주어지면 공유된 코드를 사용한다
   - Generic 타입의 매개변수로 값 타입이 주어지면 각각의 다른 머신코드가 생성된다

### Item18. 반드시 필요한 제약 조건만 설정하라
- 제약 조건을 설정하면 컴파일러는 System.Object에 정의된 public 메서드 보다 더 많은 것을 타입 매개변수에 기대할 수 있게 된다. 
   - = 컴파일러에게 제약 조건을 알려준다는 것은 제네릭 타입에서 타입 매개변수로 주어진 타입을 System.Object에서 노출하는 수준 이상으로 사용할 수 있음을 알려주는 것이다
- 제네릭 타입을 작성할 때 필요한 제약 조건이 있다면 반드시 이를 작성하자. 제약 조건이 없다면 타입의 오용 가능성이 높아지고, 사용자의 잘못된 예측으로 런타입 예외나 오류가 발생할 가능성이 높아지게 된다. 
- 아래 코드는 값을 비교하는 2개의 함수이다. 첫번째 함수는 런타임에서 제약조건을 체크하고, 두번째 함수는 컴파일타입에서 제약 조건을 체크한다
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