### ?? 연산자
```csharp
// 기존 코드
string txt = null;
if (txt == null)
{
    Console.WriteLine("null");
}
else
{
    Console.WriteLine(txt);
}

// ?? 연산자 사용
Console.WriteLine(txt ?? "null");
```

### Nullable 형식
배경: 값 형식을 표현할 때 null 상태를 표시하기 위해서 등장
- bool의 경우 true, false만 존재하는데 예를 들어 미정이라는 상태를 표시하려면 null이 필요
- 참조형식에서는 문제가 되지 않는다

형식
- System.Nullable<T> 구조체를 의미
- HasValue와 Value 속성을 가진다

선언
- Nullable<T>
- T?