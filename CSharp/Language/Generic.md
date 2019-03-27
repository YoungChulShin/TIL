### 페이지 참고
이 페이지는 아래 항목을 공부하면서 배운 내용을 기록한 것이다
- [책] 시작하세요 C# 6.0
- [책] CLR via C#

---

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

## 주의할 점
- 특정 타입만을 위한 제약 조건을 설정해야 한다면, 비제네릭 메서드를 사용하는게 더 유용하다. 
- 수학 알고리즘에 사용하는 경우 struct로 제약 조건을 두더라도 컴파일 타입에서 오류가 발생한다. (+, -, *, / 등이 기본 타입에서는 컴파일러가 어떻게 처리해야하는지 알고 있으나 그게 아닐 수도 있다. T타입이 어떤 타입일지는 모르기 때문이다)


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

where 조건 종류
- where T: stuct
   - 기본 제약 조건
   - T는 값 형식만 가능
- where T: class 
   - 기본 제약 조건
   - T는 참조 형식만 가능
- where T: new() 
   - T형식 매개변수 타입에는 추상 타입이 아니면서 반드시 매개변수가 없는 공용 생성자가 포함되어 있어야 한다
- where T: U
   - T형식 매개변수는 반드시 U형식 인수에 해당하는 타입이거나 그것으로부터 상속받은 클래스만 가능하다

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

Reference Type의 경우는 성능에는 큰 영향이 없으나 다른 제너릭의 이점(타입 안정성과 코드 편의성(?)) 때문에 사용. 

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

## 코드 폭증 (code explision)
제네릭 타입 매개변수를 사용하는 메서드를 JIT 컴파일 하게 되면 CLR은 메서드의 IL 코드를 가져와 지정된 타입 인자로 대체한 후, 해당 타입을 사용하는 네이티브 코드를 생성한다. (_당연하겠지.._)

그런데 이 경우 안좋은 점은 CLR이 모든 메서드/타입의 조합에 대해서 네이티브 코드를 생성해 두어야 한다는 것이다. 이것을 코드 증폭(code explosion)이라고 한다.

CLR에서는 이를 예방하기 위한 아래의 최적화 기술이 포함되어 있다
- 제네릭 메서드가 특장 타입 인자를 이용해서 호출된 적이 있고, 다시 동일 타입 인자를 사용해서 메서드를 호출하면 CLR은 처음 한번만 컴파일
- 참조 타입의 경우는 모드 동등한 타입으로 분류. 
   - 값 타입의 경우는 개별 값 타입에 대응하는 네이티브 코드를 생성한다

## 제네릭 타입 변수에 기본 값 설정
default 키워드를 이용해서 설정 가능하다. 
- 참조 타입: null
- 값 타입: 0

```c#
private static void SetGenericTypeVariableToDefaultValue<T>() 
{
   T temp = default(T);
}
```