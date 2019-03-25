## EventHandler
delegate 타입으로 이벤트에 등록할 메서드의 원형을 정의한다

Generic Type와 NonGenericType으로 사용 가능하다.<br>
Generic Type의 경우는 이벤트 데이터(EventArgs)가 정의한 Generic 타입으로 결정된다.
```c#
// Non Generic 타입
public delegate void EventHandler(object sender, EventArgs e);

// Generic 타입
public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
```

event는 컴파일 시점에 Delegate로 변경된다. (p.297)
- CLR via C# 책의 297페이지
- 컴파일러가 이벤트를 구현하는 방법
   1. 이벤트 선언
        ```c#
        public event EventHandler<Test> NewEvent;
        ```
   2. 컴파일러 코드 변경
        ```c#
        // private 으로 delegate 필드를 생성하고 null로 초기화
        private EventHandler<Test> NewEvent = null;

        // public 'add_이벤트명' 메서드를 추가해서 이벤트에 메서드를 등록할 수 있도록 해준다
        public void add_NewEvent(EventHandler<Test> value) 
        {
            // 세부 구현 생략
        };

        // public 'remove_이벤트명' 메서드를 추가해서 이벤트에 메서드를 삭제 할 수 있도록 해준다
        public void remove_NewEvent(EventHandler<Test> value) 
        {
            // 세부 구현 생략
        };
        ```



