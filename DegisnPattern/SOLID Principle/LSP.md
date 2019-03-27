### 페이지 참고
이 페이지는 아래 항목을 공부하면서 배운 내용을 기록한 것이다
- [책] C#으로 배우는 적응형 코드

---

## Liskov substitution principle
클래스가 어떤 종류의 클래스 혹은 서브클래스로도 안정적으로 사용할 수 있는 상속 구조를 구현하기 위한 가이드라인의 집합. 

바라라 리스코프(Barbara Liskov)의 정의
- S가 T의 서브타입이면 T 타입의 객체는 프로그램의 실행에 문제를 일으키지 않고 S타입의 객체로 치환 가능해야 한다

LSP를 준수하기 위해서는 몇가지 규칙을 지켜야 한다. 이 규칙들은 클래스들에 대한 기대 사황과 관련이 있는 계약 규칙(contract rule)과 코드 내에서 교체될 수 있는 타입과 관련이 있는 가변성 규칙으로 분류할 수 있다. 

## 계약
### 사전 조건(Precondition)
사전 조건이란, 메서드가 안정적이고 오류 없이 실행되기 위해 피룡한 모든 조건을 정의한 것을 말한다. 

```c#
public decial CalculateShippingCost (float packingWeightInKilograms)
{
    // 사전 조건
    // 실제 구현하는 기능이 호출되기 전에 검증 작업을 진행
    if(packingWeightInKilograms < 0f)
    {
        throw new ArgumentOutofRangeException("XXX", "YYY");
    }
}
```

사전 조건의 경우 클라이언트에서 올바른 값을 전달하는 테스트 해야하기 때문에 public 속성만이 포함될 수 있다. 

### 사후 조건(Postcondition)
사후 조건이란, 메서드 호출이 완료된 후에도 객체가 유효한 상태로 남아 있는지 여부를 검사하는 것을 말한다. 

방어코드를 메서드의 도입부에 작성하는 것이 아니라, 상태 수정 이후 메서드를 종료하기 전에 작성한다. 

```c#
public decial CalculateShippingCost (float packingWeightInKilograms)
{
    // 사전 조건
    if(packingWeightInKilograms < 0f)
    {
        throw new ArgumentOutofRangeException("XXX", "YYY");
    }

    // 배송비 계산 코드 

    // 사후 조건
    // 상태 변경 계산 이후, 종료전에 호출
    var shippingCost = zzz;
    if (shippingCost <= decimal.Zero)
    {
        throw new ArgumentOutofRangeException("XXX", "YYY");
    }

    return shippingCost;
}
```

### 불변 데이터 
객체의 생명 주기 동안 참인 상태로 유지되는 명제. 이 값은 중간에 상태가 변경되면 안되기 때문에 프로그램 내에서 상태 변경을 막아주도록 해야한다. 

protected 변수의 경우는 생성자 매개변수로 전달 받아서 중간에 변경이 되는 것을 막아준다.<br>
public 변수는 get/set 속성을 이용해서 set 속성에서 중간에 변경이 되는 것을 막아준다. 



