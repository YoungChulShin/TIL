### Lamda
- MSDN: [Link](https://msdn.microsoft.com/ko-kr/library/bb397687.aspx)

### 정의
- 람다 대수를 C#에서 구현한 문법
- 식 표현: **(x, y) => x + y;**

### 코드로서의 람다 사용
1. Delegate 선언
   - delegate int MyLamda(int a, int b)
2. 함수 구현
   - MyLamda myFunc = (a, b) => a + b;



예시
   ```csharp
   // 일반 사용
   MyDivide myDivide = new MyDivide(Divide);
   // Delegate 익명 함수 사용
   MyDivide myDivide2 = delegate (int a, int b)
   {
        return a + b;
   };
   // 람다 식 사용
   MyDivide myDivide3 = (a, b) => a + b;
   ```

### Delegate가 없는 람다식 사용
- 람다식을 사용하기 위해서 매번 Delegate를 선언해야하는 불편함이 있어서, MS에서 기본으로 제공하는 함수

1. Action()
    - 반환값이 없는 Delegate
    - 식: public delegate void Action<T>(T obj)
    - 예: Action<string> writeText = (txt) => Console.WriteLine(txt);
       - txt는 string 타입

2. Func() 
    - 반환값이 있는 Delegate
    - 식: public delegate TResult Funct<TResult>
    - 예: Func<double> pi = () => 3.141592;

### Collection과 람다 식
- Collection은 람다 식을 만나서 더 기능을 편리하게 사용할 수 있다. 

1. List<T>의 ForEach
   ```csharp
   // delegate 사용
   list.ForEach(delegate(int elem) {
        Console.WriteLine(elem);
    });

   // lamda 사용
   list.ForEach((elem) => Console.WriteLine(elem));
   ```
2. Array의 ForEach
   ```csharp
   Array.ForEach(list.ToArray(), (elem) => Console.WriteLine(elem));
   ```
3. List<T>의 FindAll
   - 리턴이 List<T>
   - 완료 순간 컬렉션의 모든 요소를 대상으로 실행되어 조건을 만족하는 목록을 반환
4. List<T>의 Count
5. List<T>의 Where
   - 리턴이 IEnumerable<T>
   - where가 실행되었을 때는 어떤 코드도 실행되지 않은 상태이고, 이후에 열거자를 통해서 순환될 때 람다식이 하나씩 실행된다
   - lazy evaluation
6. List<T>의 Select
   - 타입을 변환해서 리턴할 때 사용
      ```csharp
      // list: List<int>
      IEnumerable<double> doubleList = list.select(elem => (double)elem);
      ```

- FindAll의 지연평가 버전이 where
- ConvertAll의 지연평가 버전가 select

### Lazy evalucation
장점
- 최초 메소드 호출로 인한 성능 손실은 발생하지 않고 실제로 데이터가 필요한 순간에만 코드가 실행
- 예를 들어서 소수 1만개를 구한다고 해보자. 그런데 여기서 필요한 데이터는 500개만 있으면 된다.<br> FindAll의 경우는 1만개를 모두 계산한 상태에서 500개를 찾아야 하지만<br>
Where의 경우는 500개를 찾을 때마다 하나씩 CPU를 소모하기 때문에 성능 손실이 작게 발생한다
