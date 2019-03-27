### 페이지 참고
이 페이지는 아래 항목을 공부하면서 배운 내용을 기록한 것이다
- [책] CLR via C#

---

## 기본 설명
- **인터페이스를 사용하면 타입들 간에 의사소통하는 방법을 표준화할 수 있기 때문에 상당히 좋다**
- CLR과 이를 기반으로 하는 모든 관리 프로그래밍 언어들은 다중 상속을 지원하지 않는다.<br>그 대신 인터페이스를 이용해서 축소된 형태의 다중상속을 지원한다. 
- 인터페이스는 여러 개의 메서드 원형들을 묶어 하나의 이름을 부여하는 것에 지나지 않는다. 
- 클래스를 정의할 때 인터페이스 이름을 이용하여 상속할 수 있으며, 이 경우 해당 클래스는 반드시 인터페이스에서 제안하는 모든 메서드들을 정의해야 한다. 

## 추상화
상속한 타입의 인스턴스는 언제나 기본 클래스의 인스턴스가 필요한 곳에 대신 사용할 수 있다. 유사하게 특정 인터페이스가 필요한 곳에 해당 인터페시으를 구현한 클래스의 인스턴스를 대신 사용 가능하다. <br>
-> 이를 이용해서 추상화 구현이 가능하다. <br>
-> Interface를 통해서 기능만 협의하고, 기능에 대한 세부 내역은 구현부에 따라 달라질 수 있기 때문이다. 

## 인터페이스 정의하기
- '접근 제한자' + interface + '인터페이스 이름' 으로 정의한다. 
    >public interface IDiposable
- 인터페이스의 이름은 앞에 'I'를 붙여서 해당 타입이 인터페이스인지 알아차릴 수 있게 한다. (필수는 아니다.)
- 인터페이스를 상속하는 것은 가능하다.
    - 상속받는 클래스는 반드시 모든 인터페이스가 정의하는 함수를 구현해야 한다.  

## 메서드 테이블
CLR이 임의의 타입을 로드하면, 로드한 타입에 대한 메서드 테이블이 생성되고 초기화 된다.<br>
메서드 테이블에는 각 타입에서 정의한 메서드별로 하나씩 항목이 포함된다. 
```c#
internal sealed class SimpleType : IDisposable 
{
    public void Dispose() 
    {
        Console.WriteLine("Dispose");
    }
}
```
위 코드에 대해서 메서드 테이블에는 아래 항목이 포함된다. 
1. Object에 정의된 메서드들이 상속된다
2. 인터페이스 상속에 의해서 IDisposable 인터페이스가 정의하고 있는 메서드들이 상속된다
3. SimpleType가 구현한 Dispose 메서드가 포함된다

## 제네릭 인터페이스
사용 이점 (_어찌보면 당연하다.._)
- 컴파일 타임에 안정성 강화 
- 값 타입과 함께 사용했을 때 박싱을 훨씬 적게 사용할 수 있다

제약 조건과의 관계
- 단일 제네릭 타입 매개변수가 여러 인터페이스 타입을 동시에 구현하도록 할 수 있다
- 값 타입 인스턴스를 전달할 때 박싱을 최소화 할 수 있다
   - 인터페이스 제약 조건의 경우 C# 컴파일러는 IL 명령어를 추가해서 값 타입의 인스턴스에 대해 박싱이 일어나지 않도록 한다

## 명시적 인터페이스 구현으로 컴파일 시점에 타입 안정화 시키기
비제네릭 인터페이스의 경우 컴파일시 타입 안정성이나 박싱을 유발할 수 있다. 

```c#
internal struct ValueType : IComparable
{
    private int mX;
    public ValueType(int x)
    {
        mX = x;
    }
    public int CompareTo(object obj)
    {
        return (mX - ((ValueType)obj).mX);
    }
}
```
위 코드는 구현부에서 CompareTo를 호출할 때 박싱이 발생하고, 잘못된 값을 넘기면 'InvalidCastException'
이 발생할 수 있다. 

이 경우 명시적 인터페이스 구현으로 이 문제를 해결할 수 있다. 

```c#
internal struct ValueType : IComparable
{
    private int m_x;
    public ValueType(int x)
    {
        m_x = x;
    }
    // 구현부분에서 CompareTo를 호출하면 동작하는 함수
    public int CompareTo(ValueType obj)
    {
        return (m_x - obj.m_x);
    }

    // IComparable CompareTo를 직접 구현
    // 호출할 때 내부 public 함수를 호출한다
    int IComparable.CompareTo(object obj)
    {
        return CompareTo((ValueType)obj);
    }
}
```

### 문제점
하지만 명시적으로 인터페이스를 구현할 경우 아래 문제가 있기 때문에 조심해서 사용해야 한다

인터페이스 타입의 변수를 사용하게 되면 여전히 박싱이 발생하고, 컴파일 시점에 오류를 잡을 수가 없다
```c#
ValueType v = new ValueType(0);
IComparable iComp = v;  // 박싱 발생

Object o = new Object();
int n = iComp.CompareTo(v); // 박싱 발생
n = iComp.CompareTo(v);   // InvalidCastException 발생
```

## IEnumerable 구현 샘플
lazy evaluation
```java
public class NaturalNumber : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new NatualNumberEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return new NatualNumberEnumerator();
    }

    public class NatualNumberEnumerator : IEnumerator<int>
    {
        private int _current;

        public int Current
        {
            get { return _current; }
        }
        object IEnumerator.Current
        {
            get { return _current; }
        }

        public bool MoveNext()
        {
            _current++;
            return true;
        }
        public void Reset()
        {
            _current = 0;
        }

        public void Dispose() { }
    }
}
```