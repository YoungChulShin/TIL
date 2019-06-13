# 데이터 타입
## 아이템1: 접근 가능한 데이터 멤버 대신 속성을 사용하라
아직토 타입의 필드를 public으로 선언한다면 그만두는 게 좋다. get이나 get 메서드를 직접 작성하고 있었다면 이 역시 그만두자. 

### 속성 특징
- 데이터 필드에 접근하는 것처럼 실행되면서도 메서드가 주는 이점을 그대로 취할 수 있다
- 향후 요구 사항이 변경되어 코드를 수정해야 하는 경우에도 용이하다
    ```c#
    public class Customer 
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                // 처리 로직  <- 수정 포인트
                name = value;
            }
        }
    }
    ```
- 속성은 메서드로 구현되므로 멀티스레드도 쉽게 지원할 수 있다
    ```c#
    public class Customer 
    {
        private object syncHandle = new object();

        private string name;
        public string Name
        {
            get
            {
                lock(syncHandle)
                    return name;
            } 
            set
            {
                // 처리 로직  <- 수정 포인트
                lock(syncHandle)
                    name = value;
            }
        }
    }
    ```
- `virtual`로도 선언 가능하다
- `interface`를 정의할 때도 사용 가능하다
- `get`/`set`의 접근 한정자를 다르게 지정해서 데이터의 노출방식을 다양하게 제어할 수 있다
- `indexer`를 사용할 수 있다
    ```c#
    // 정의
    public int this[int index]
    {
        get => theValues[index];
        set => theValues[index] = value;
    }
    private int[] theValues = new int[100];

    // 접근
    int val = someObject[i];
    ```

    ```c#
    // 정의
    public Address this[string name]
    {
        get => addressValues[name];
        set => addressValues[name] = value;
    }
    private Dictionary<string, Address> addressValues;
    ```
- 암묵적 속성 문법 (get;set;)을 이용하면 코드를 줄일 수 있다
- 데이터 바인딩을 사용할 수 있다
   - 데이터 바인딩을 할 때 대상 값이 public 데이터 필드이면 안된다. 클래스 라이브러리의 설계자가 public 데이터 멤버를 사용하는 것을 나쁜 예로 간주하고, 속성을 사용하도록 설계했기 때문이다. 

### 필드를 속성으로 바꿀 때 고려사항
- 데이터 멤버와 속성은 소스 수준에서는 호환성이 있지만 바이너리 수준에서는 전혀 호환성이 없다
   - 속성은 데이터가 아니므로 C# 컴파일러는 멤버에 접근할 때와는 다른 중간언어를 생성한다
   - 이런 이유로 public 데이터 멤버를 public 속성으로 수정하면, 데이터 멤버를 사용하는 모든 코드를 다시 컴파일 해야 한다. 
- 속성이 데이터 멤버보다 빠르지는 않지만 그렇다고 크게 느리지도 않다
   - JIT 컴파일러는 속성 접근자를 포함하여 일부 메서드 호출코드를 인라인화 하곤 한다. 인라인화 되면 데이터 멤버를 사용했을 때와 성능이 같아지며, 설사 인라인화 되지 않더라도 함수 하나를 덤으로 호출하는 정도이므로 무시할 만하다. 
   - 하지만 속성을 사용하는 코드는 마치 데이터 필드에 접근하는 것처럼 보이므로 성능면에서 큰 차이를 보여서는 안된다. 따라서 속성 접근자 내에서는 시간이 오래 걸리는 연산이나 DB 쿼리 같은 작업을 수행해서는 안된다. 이는 사용자가 기대하는 일관성이 결여된다. 

### 정리
- public이나 protected로 데이터를 노출할 때는 항상 속성을 사용하라
- Sequence나 Dictionary를 노출할 때는 인덱서를 사용하라
- 모든 데이터 멤버는 예외 없이 private으로 선언하라.


## 아이템2: 변경 가능한 데이터에는 암묵적 속성을 사용하는 것이 낫다
### 암묵적 속성(implicit Property) 특징
- 개발자의 생산성과 클래스의 가독성을 높인다
- 명시적 속성과 동일한 접근자 지원
- 향후 데이터 검증을 위해서 암묵적 속성을 명시적 속성으로 구현부를 추가해도 클래스의 바이너리 호환성이 유지된다
    ```c#
    // Original
    public string FirstName {get; set;}

    // Update
    private string firstName;
    public string FirstName
    {
        get => firstName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("First name cannot be null or empty");

            firstName = value;
        }
    }

    ```
- 데이터 검증 코드를 한 군데만 두면 된다 (=속성의 장점)
- _Serializable 특성을 사용한 타입에는 사용할 수 없다_

## 아이템3: 값 타입은 변경 불가능한 것이 낫다
### 불변 타입 (Immutable Type)
- 한번 생성된 후에는 그 값을 변경할 수 없는 타입
- 변경 불가능한 타입으로 객체를 생성할 때 매개변수를 검증했다면, 그 객체의 상태는 항상 유효하다고 할 수 있다
- 생성 후에 상태가 변경되지 않기 때문에 불필요한 오류 검증을 줄일 수 있다
- 멀티스레드에 대해서도 안전하다
   - 여러 스레드가 동시에 접근해도 내부 상태를 변경할 수 없으므로 항상 동일한 값에 접근한다

### 모든 타입을 변경 불가능한 타입으로 만드는 것은 매우 어렵다
이번 아이템은 `원자적으로 상태를 변경하는 타입` 과 `변경 불가능한 타입`에 적용할 수 있다

`원자적으로 상태를 변경하는 타입`
- 다수의 연관된 필드로 구성된 객체이지만, 하나의 필드를 수정하면 다른 필드도 함께 수정해야 하는 타입
- 예) 주소: 이사를 했을 때 `시`, `도`, `군` 과 같은 정보를 바꿨는데, `우편번호`를 변경하지 않으면 이 객체는 잘못된 정보를 가지게 된다
- 반대 예) 고객: `주소`, `이름`, `전화번호` 등으로 구성되어 있다고 할 때, 각각의 값들은 독립적이어서 `주소`를 바꾼다고 해서 `이름`이 같이 변경되어야하 하는 것은 아니다

### 코드 예시
변경 가능한 주소 코드
```c#
// 구현
public struct Address 
{
    private string state;
    private int zipCode;

    public string City {get;set;}
    public string State
    {
        get => state;
        set
        {
            ValidateState(value);
            state = value;
        }
    }
    public int ZipCode
    {
        get => zipCode;
        set 
        {
            ValidateState(value);
            zipCode = value;
        }
    }
}

// 사용
Address a1 = new Address();
a1.City = "서울";
a1.State = "송파구";
a1.ZipCode = 7777777;
// 변경 -> 이사를 갔다
a1.City = "부산"; // 아직 Zip, State가 유효하지 않다
a1.State = "북구"; // State가 유효하지 않다
a1.ZipCode = 0000000; // 정상
```

발생할 수 있는 문제
- 멀티스레드 환경에서 `City` 값을 변경 후에 `State`, `ZipCode`가 변경되기 전에 다른 스레드로 Context Switch가 되면 잘못된 값을 참조할 수 있다
- 우편번호가 유효하지 않은 경우 예외를 던진다고 하면, 주소의 일부가 변경된 상태라 시스템이 불완전한 상태가 된다
- 2경우 모두 동기화 코드를 사용해서 막을 수 있지만 추가 작업 및 코드량이 증가한다

변경 불가능한 타입으로 변경
```c#
// 구현
public struct Address
{
    public string City { get; }
    public string State { get; }
    public int Zip { get; }

    public Address(string city, string state, string zip) : this()
    {
        City = city;
        ValidateState(state);
        State = state;
        ValidateZip(zip);
        Zip = zip;
    }
}

// 사용
Address a1 = new Address("서울", "송파구", 7777777);
a1 = new Address("부산", "북구", 0000000);
```

- 기존 처럼 주소를 수정하다가 잘못된 임시 상태에 놓이는 일은 일어나지 않는다

### 변경 불가능한 타입 내에 변경 가능한 참조 타입 필드가 있을 경우
예: 배열 
- 변경 불가능한 타입에 참조타입의 배열이 있으면 이를 통해서 내부 상태를 변경할 수 있다
- `ImuutableArray` (System.Collections.Immutable) 로 변경해준다

### 변경 불가능한 타입을 초기화 하는 방법
1. 생성자를 정의
   ```c#
   Address a1 = new Address("서울", "송파구", 7777777);
   ```
2. 구조체를 초기화하는 Factory Method를 만드는 것
   ```c#
   Color color = Color.FromKnownColor(KnownColor.AliceBlue);
   Color color2 = Color.FromName("Yellow");
   ```
3. 불변 타입의 인스턴스를 단번에 만들 수 없을 때는 변경 가능한 동반 클래스를 만들어 사용할 수 있다. 
   ```charp
   StringBuilder stringBuilder = new StringBuilder();
   stringBuilder.Append("Hello");
   stringBuilder.Append("World");
   string helloWorld = stringBuilder.ToString();
   ```

### 정리
- 변경 불가능한 타입은 작성하기가 쉽고 관리가 용이하다
- 무작성 속성에 get, set 접근자를 만들지 말자
- 데이터를 저장하기 위한 타입이라면 변경 불가능한 원자적 값 타입으로 구현하자