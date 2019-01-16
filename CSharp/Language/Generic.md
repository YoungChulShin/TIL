## 등장
C# 2.0에서 등장

## 이점
- 알고리즘 재사용을 수행 가능
- 타입 안정성
- 간결한 코드: 타입 안정성이 보장되니 별도의 캐스팅 코드가 필요 없다
- 더 나은 성능: 박싱, 언박싱이 없기 때문에
   - 박싱을 수행하면 관리 힙에 새로운 메모리를 할당하기 때문에 더 많은 가비지 수집을 유발할 수 있다. 

## 선언
네임 스페이스
- System.Collections.Generic

클래스와 메서드에 모드 선언 가능
- Generic Class
   - 클래스 이름 뒤에 <T>를 붙여 데이터 타입을 지정하지 않고도 동작될 수 있도록 한다
      ```c#
      public class Add<T> ()
      ``` 
   - T를 타입 매개변수라고 한다
- Generic Method
   ```csharp
   public static void WriteLog<T>(T item)
   ```

T의 기능에 제한을 두고 싶을 때 where를 사용
   - Sample Code
      ```csharp
      public static T Max<T>(T item1, T item2) where T: IComparable
      {
         if (item1.CompareTo(item2) >= 0)
         {
               return item1;
         }

         return item2;
      }

      // 매개변수 2개에 대한 조건
      public static Dic<K, V> where K: ICollection 
                              where V: IComparable 
      {

      }
      ```
   - 기타 where 조건
      - where T: stuct -> T는 값 형식만 가능
      - where T: class -> T는 참조 형식만 가능
      - where T: new() -> T형식 매개변수 타입에는 반드시 매개변수가 없는 공용 생성자가 포함되어 있어야 한다
      - where T: U -> T형식 매개변수는 반드시 U형식 인수에 해당하는 타입이거나 그것으로부터 상속받은 클래스만 가능하다
   