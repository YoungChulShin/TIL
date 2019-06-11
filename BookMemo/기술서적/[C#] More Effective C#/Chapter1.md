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