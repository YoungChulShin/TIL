# 아키텍처 개요
## 영역 설명
Presentaion
- 사용자의 요청을 받아서 Application에 전달하고, Application의 처리 결과를 다시 사용자에게 보여주는 역할

Application
- 시스템에 사용자에게 제공해야할 기능을 구현
- 예: 주문등록, 주문취소, 상세상품조회 와 같은 기능
- 이 기능을 구현하기 위해서 Domain 영역의 Domain Model을 이용한다
   - 로직을 직접 수행하기 보다는 Domain Model에 로직 수행을 위임한다
   - 주문취소라고 하면 `Order`라는 Domain Model을 가져와서 취소한다. 실제 취소 기능은 `Order` Domain Model에 구현되어 있다. 

Domain
- Domain의 핵심 로직을 구현
- 예: 배송지 변경, 결제완료, 주문총액 계산

Infrastructure
- DB연동, 메시지 처리 같은 구현 기술에 대한 것을 다룬다
- Application 영역에서 DB에 보관된 데이터가 필요하다면 Infrastructure 영역의 DB 모듈을 이용해서 데이터를 가져온다

## 계층 구조 아키텍처
### 일반적인 구조
Presentation -> Application -> Domain -> Infrastrucure

특정
- 상위계층에서 하위계층으로의 의존만 존재하고 하위계층은 상위계층에 의존하지 않는다
- 구현의 편리함을 위해서 계층구조는 유연하게 적용한다
   - **Application계층은 아래 계층인 Domain계층에 의존하지만 외부 시스템과의 연동을 위해서 더 아래 계층인 Infrastructure 계층에 의존하기도 한다**

주의 - 의존성!
- Presentation, Application, Domain 영역이 Infrastructure 계층을 이용할 때, Infrastructure 계층에 중속될 수 있다는 점을 주의해야 한다. (p.42)
- 예를 들면, Application에서 Infrastructure에 있는 특정 기술에 직접적으로 참조가 발생한다.이렇게 되면 아래 2가지 문제가 발생한다
   1. 테스트하기 어려운 코드
   2. 기능 확장의 어려움

### DIP
해결 - DIP
- 정의: 저수준 모듈이 고수준 모듈에 의존하도록 바꾼다. 
   - 고수준 모듈: 의미있는 기능을 하는 단일 기능을 제공하는 모듈 (상위 계층)
   - 저수준 모듈: 하위 기능을 실제로 구현한 것
   - 고수준 모듈이 제대로 동작하려면 저수준 모듈을 사용해야 하는데, 고수준 모듈이 저수준 모듈을 사용하면 테스트 어려움과 기능 확장의 어려움이 발생한다
- Interface를 이용해서 구현
   - Interface는 고수준 영역에 구현한다
- 주의 사항
   - DIP를 잘못 생각하면 단순히 인터페이스와 구현 클래스르르 분리하는 정도로 받아들일 수 있다. DIP의 핵심은 고수준 모듈이 저수준 모듈에 의존하지 않도록 하기 위함이다

**DIP와 아키텍쳐**
- DIP를 적용하면 저수준 Infrastructure 계층이 Application과 Domain 계층에 의존하는 구조가 된다

## Domain 영역의 주요 구성요소
### 주요 구성 요소
|요소|설명|
|--|--|
|Entity|고유의 식별자를 갖는 객체로 자신의 라이프사이클을 갖는다.<br>오더(Order), 회원(Member), 상품(Product)과 같이 도메인의 고유한 개념을 표현한다. 도메인 모델의 데이터를 포함하며 해당 데이터와 관련된 기능을 함께 제공한다|
|Value|고유한 식별자를 갖지 않는 객체로 개념적으로 하나인 도메인 객체의 속성을 포현할 때 사용된다.<br>배송 주소를 표현하기 위한 Address나 금액을 위한 Money같은 타입이 속한다|
|Aggregate|Entity와 Value 객체를 개념적으로 하나로 묶은 것이다.<br>예를 들어 주문과 관련된 Order entity, OrderLine value, Orderer value 객체를 '주문' Aggregate로 묶을 수 있다.|
|Repository|도메인 모델의 영속성을 처리한다.<br>예를 들어, DBMS 테이블에서 엔티티 객체를 로딩하거나 저장하는 기능을 제공한다|
|Domain Service|특정 엔티티에 속하지 않은 도메인 로직을 제공한다.<br>예를 들어, '할인 상품 계산'은 상품, 쿠폰, 회원 등급 등 다양한 조건을 이용해서 구현하게 되는데, 이렇게 도메인 로직이 여러 엔티티와 밸류를 필요로 할 경우 도메인 서비스에서 로직을 구현한다|

### 애그리거트 (Aggregate)
정의: 관련 객체를 하나로 묶은 군집

애그리거트는 군집에 속한 객체들을 관리하는 루트 엔티티를 갖는다. 
- 루트 엔티티는 애그리거트에 속해 있는 엔티티와 밸류 객체를 이용해서 애그리거트가 구현해야 할 기능을 제공한다
- 애그리거트 루트를 통해서 간접적으로 애그리거트 내의 다른 엔티티나 밸류 객체에 접근하게 된다

### 리포지터리 (Repository)
리포지터리는 애그리거트 단위로 도메인 객체를 저장하고 조회하는 기능을 정의한다. 
- 엔티티나 밸류: 요구사항에서 도출되는 도메인 모델
- 리포지터리: 구현을 위한 도메인 모델
   ```c#
   // 주문 애그리거트를 위한 리포지터리
   // 대상을 찾고, 저장하는 단위가 애그리거트 루트인 Order이다
   public interface OrderRepository 
   {
      public Order findByNumber(OrderNumber number);
      public void save(Order order);
      public void delete(Order order);
   }
   ```

구조
- Application: `CancelOrderService`
   - DI를 통해서 실제 리포지터리 구현 객체에 접근한다
- Domain: `Order<Root>`, `OrderRepository<Interface>`
- Infrastructure: `JpaOrderRepository`

**응용서비스와 리포지터리 관계**
- 응용서비스는 필요한 도메인 객체를 구하거나 저장할 때 리포지터리를 사용한다
   - 리포지터리 구현 객체는 Interface를 통해서 DI 를 통해 사용
- 응용 서비스는 트랜잭션을 관리하는데, 트랜잭션 처리는 리포지터리 구현 기술에 영향을 받는다

리포지터리의 사용주체가 응용서비스이기 때문에 리포지터리는 응용 서비스가 필요로 하는 메서드를 제공한다
- 애그리거트를 저장하는 메서드
- 애그리거트 루트 식별자로 애그리거트를 조회하는 메서드
   ```c#
   public interface SomeRepository
   {
      void Save(Some some);
      Some findById(SomeId id);
   }
   ```
