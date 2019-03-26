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

## 제약 조건
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

### 제약 조건의 상속
상속 받은 메서드의 경우 타입 매개변수의 이름을 바꾸는 것은 가능하지만, 제약을 추가하거나 변경하는 것은 불가능하다
```c#
public virtual void M<T1, T2> () where T1: struct where T2: class 
{
   //
}

public override void M<T3, T4> () where T3: EventArgs // 오류
                                  where T4: class // 오류
{
   //
}
```
   
## 박싱에 대한 성능 
ValueType의 경우 박싱이 많이 일어날 수록 성능에 많은 영향을 미친다. 

Reference Type의 경우는 성능에는 큰 영향이 없으나 타입 안정성과 사용 편의성 때문에 사용. 


## 제너릭 메서드와 타입 유추(Type Inference)
아래와 같은 제너릭 메서드에 대해서 동일 타입을 <T> 없이 호출하는 것은 가능하나, 서로 다른 타입은 컴파일 에러 발생
```c#
private static void Swap<T>(ref T o1, ref T o2)
{
   T temp = o1;
   o1 = o2;
   o2 = temp;
}

int n1 = 1, n2 = 2;
Swap(ref n1, ref n2);   // 호출 가능

string s1 = "Aidan";
Object s2 = "Grant";
Swap(ref s1, ref s2);   // 오류 발생
```



