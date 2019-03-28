### 페이지 참고
이 페이지는 아래 항목을 공부하면서 배운 내용을 기록한 것이다
- [책] CLR via C#

---
## Delegate
.NET Framework에서 콜백함수 매커니즘을 델리게이트라는 형태로 노출한다.

콜백 메서드의 타입 안정성을 보장하고, 순차적으로 호출할 수 있다. 

## 바인딩 가능 대상
- 정적 메서드
- 인스턴스 메서드

## 바인딩 시 공변성, 반공변성
메서드를 델리게이트에 바인딩할 때 참조 타입에 대한 공변성과 반공변성을 허용한다.<br>
(값 타입은 혀용하지 않는다. 값 타입은 메모리 구조가 각각 다른 반면, 참조 타입은 일정 크기의 포인터로 대표될 수 있다)

공변성
- 반환 타입에 대해서 원형을 상속하는 타입을 설정할 수 있다

반공변성
- 매개변수를 원형에서 정의한 타입의 부모타입으로 설정할 수 있다

```c#
delegate object MyCallback(FileStream s);
string SomeMethod(Stream s);
// SomeMethod는 MyCallback에 바인딩 가능하다
// string은 object를 상속한 타입이기 때문에 바인딩 가능하다
// Stream은 FileStream의 부모타입이기 때문에 바인딩 가능하다 
```

## 컴파일러
델리게이트는 컴파일 시점에 class로 변경된다. 

모든 델리게이트는 System.MulticastDelegate를 상속받는다.
- System.MulticastDelegate는 Syustem.Delegate를 상속한다
- System.Delegate는 System.Object를 상속한다

