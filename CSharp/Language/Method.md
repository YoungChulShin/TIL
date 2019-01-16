### 익명 메서드(anonymous method)
정의
- 이름이 없는 메서드
- 델리게이트에 전달되는 메서드가 일회성으로만 필요할 때 사용

예시
```csharp
static void Main(string[] args)
{
    Thread thread = new Thread(ThreadFunc);

    Thread thread2 = new Thread(
        delegate (object obj)
        {
            Console.WriteLine("Anonymous call");
        });
        
    Console.ReadLine();
}

private static void ThreadFunc(object obj)
{
    Console.WriteLine("Function call");
}
```

### 확장 메서드(Extension Method)
기능
- static method 호출을 instance method를 호출하듯이 문법적으로 지원

구현 제약
- static class, static method, this가 사용되어야 한다