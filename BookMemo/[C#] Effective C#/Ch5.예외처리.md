## Item45. 메서드가 실패했음을 알리기 위해서 예외를 이용하라
- 메서드가 요청된 작업을 제대로 수행할 수 없는 경우 예외를 발생시켜 실패가 발생했음을 알려야 한다. 
   - 오류 코드를 이용하면 사용자가 이를 무시할 수 있다 
   - 예외(=Exception)은 클래스 타입으로 오류에 대한 추가적인 정보를 가질 수 있다
- 개발자가 try/catch 블록을 작성하지 않고도 정상적으로 메서드가 수행될 수 있는지를 확인할 수 있는 API를 제공하는 것이 좋다
    - As-Is
        ```C#
        public void DoWork(){}
    - To-Be:
       ```CSharp
       public bool TryDoWork()
       {
           if (!TestCondtions())
           {
                return false;
           }

           DoWork();
           return true;
       }
       private bool TestConditions() {}
       private void DoWork() {}

- 메서드의 이름은 메서드가 어떤 작업을 수행하는지를 명확하게 드러내도록 지어야 한다
- 예외를 발생시키는 메서드를 작성할 때는 항상 예외를 유발하는 조건을 사전에 검사할 수 있는 메서드를 함께 작성하는 것을 권한다

## Item46. 리소스 정리를 위해서 using과 try/finally를 활용하라
- 관리되지 않는 리소스를 사용하는 모든 타입은 IDisposable 인터페이스를 반드시 구현해야 한다
- Dispose()를 호출해야 하는 객체를 사용할 경우 이를 보장하기 위한 가장 간단한 방법은 using 문을 사용하는 것이다. 
   - C# 컴파일러가 using문을 만나면 try/finally 블록을 자동으로 생성해준다
- using문은 IDisposable 인터페이스를 지원하는 타입에 대해서만 사용할 수 있다
   - Object 타입의 경우 사용할 수 없는데, 이 경우 'as'를 이용하면 안전하게 코드 작성이 가능하다
      ```Csharp
      object obj = Factory.CreateResource();
      using (obj as IDisposable)
      {
          // Do dit
      }
    - 임의의 객체에 대해서 using 문을 사용할 수 있을지 확실치 않다면 위와 같이 구현하는 것이 좋다
- 메서드 내에서 IDisposable 인터페이스를 구현한 객체를 지연벽수로 사용하는 경우라면 항상 using문을 사용하기 바란다
- 중첩된 using을 사용하는 것은 IL 코드로 봤을 때는 try/finally를 2번 사용하는 것과 같다. 이 경우에는 try/finally를 사용해서 블록을 자체적으로 구현해주는 것도 좋은 방법이다
- Dispose()와 Close()
   - Dispose
      - 리소스 해제 작업
      - GC.SuppressFinalize()를 호출해서 가비지 수집기에게 이 객체에 대해서는 finalizer를 호출할 필요가 없음을 알리는 작업을 수행
   - Close
      - GC에 호출하는 작업을 하지 않는다. 
   - 두 메서드를 모두 사용할 수 있다면, Dispose()를 호출하는 것이 좋다

    
