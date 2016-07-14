##Lanmda
- MSDN: [Link](https://msdn.microsoft.com/ko-kr/library/bb397687.aspx)

##일반적인 람다 정의<br>
    >Delegate 선언<br>
    >delegate int MyLamda(int a, int b)<br>
    >함수 구현<br>
    >MyLamda myFunc = (a, b) => a + b;<br>

- 람다의 식 표현: (x, y) => x + y;

##Delegate가 없는 람다식 사용
- 람다식을 사용하기 위해서 매번 Delegate를 선언해야하는 불편함이 있어서, MS에서 기본으로 제공하는 함수
1. Action()
    - 반환값이 없는 Delegate
    - 식: public delegate void Action<T>(T obj)
    - 예: Action<string> writeText = (txt) => Console.WriteLine(txt);

2. Func() 
    - 반환값이 있는 Delegate
    - 식: public delegate TResult Funct<TResult>
    - 예: Func<double> pi = () => 3.141592;

    