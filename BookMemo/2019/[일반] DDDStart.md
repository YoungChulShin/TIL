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


# 애그리거트
### 특징
- 복잡한 도메인을 이해하고 관리하기 쉬운 단위로 만들려면 상위 수준에서 모델을 조망할 수 있는 방법이 필요한데, 그 방법이 애그리거트다
- 수많은 객체를 애그리거트로 묶어서 바라보면 더 상위 수준에서 모메인 모델간의 관계를 파악할 수 있다
- 애그리거트는 관련된 모델을 하나로 모은 것이기 때문에 한 애그리거트에 속헤 객체는 유사하거나 동일한 라이프사이클을 갖는다
- 한 애그리거트에 속한 객체는 다른 애그리거트에 속하지 않는다. 자기 자신을 관리할 뿐 다른 애그리거트를 관리하지 않는다. 
- 도메인 규칙에 따라 함께 생성되는 구성요소는 한 애그리거트에 속할 가능성이 높다
   - 예: 주문할 상품 개수, 배송지 정보, 주문자 정보는 주문 시점에 함께 생성되므로 이들은 한 애그리거트에 속한다
- 'A가 B를 갖는다'라고 하면 한 애그리거트로 묶어서 생각하기 쉽지만 필수는 아니다
   - 묶는 경우: 주문의 경우 Order가 ShippingInfo와 Orderer를 가지므로 타당성이 있다
   - 분리 경의: Product와 Review는 2개가 함께 생성되지 않고 함께 변경되지도 않는다. 게다가 Product의 변경 주체는 상품담당자라면 Review는 고객이다


## 애그리거트 루트
- 애그리거트는 여러 객체로 구성되기 때문에 한 객체만 상태가 정상이어서는 안된다. 
- 애그리거트에 속한 모든 객체가 일관된 상태를 유지하려면 애그리거트 전체를 관리할 주체가 필요한데 이 책임을 지는 것이 바로 애그리거트의 루트 엔티티이다. 

### 도메인 규칙과 일관성
- 애그리거트 루트의 핵심 역할은 애거리거트의 일관성이 깨지지 않도록 하는 것이다. 이를 위해서 애그리거트 루트는 애그리거트가 제공해야 할 도메인 기능을 구현한다.<br>
예를 들어, 주문 애그리거트는 배송지 변경, 상품 변경과 같은 기능을 제공하는데 애그리거트 루트인 Order가 이 기능을 구현한 메서드를 제공한다
- **애그리거트 루트가 아닌 다른 객체가 애그리거트에 속한 객체를 직접 변경하면 안된다. 이는 애그리거트 루트가 강제하는 규칙을 적용할 수 없어 모델의 일관성을 깨는 원인이 된다**
   ```c#
   ShippingInfo si = order.GetShippingInfo();
   so.setAddress(newAddress);    // 루트인 Order가 아니라 ShippingInfo에서 배송 정보를 변경하고 있다
   ```
- 불필요한 중복을 피하고, 애그리거트 루트를 통해서만 도메인 로직을 구현하게 만들려면 아래 2가지를 습관적으로 적용해야 한다
   1. 단순히 필드를 변경하는 set 메서드를 public으로 만들지 않는다
   2. value 타입은 불변으로 구현한다

### 애그리거트 루트의 기능 구현
- 애그리거트 루트는 애그리거트 내부의 다른 객체를 조합해서 기능을 완성한다
   - 예: Order는 총 주문 금액을 구하기 위해서 OrderLine 목록을 사용한다
   ```c#
   public class Order 
   {
      private Money totalAmounts;
      private List<OrderLine> orderLines;

      private void calculateTotalAmounts()
      {
         int sum = orderLines.stream()
                   .mapToInt(ol -> ol.getPrice() * ol.quantity()).sum();
         this.totlaAmounts = new Money(sum);
      }
   }
   ```

### 트랜잭션 범위
- 한 트랜잭션에서는 한 개의 애그리거트만 수정해야 한다. 이는 애그리거트에서 다른 애그리거트를 변경하지 않는다는 것을 뜻한다.<br>
예를 들어 배송지 정보를 변경하면서 동시에 배송지 정보를 회원의 주소로 설정하는 기능이 있을 때, 주문 애그리거트는 회원 애그리거트의 정보를 변경하면 안된다.
   ```c#
   public class Order
   {
      private Orderer orderer;

      public void shipTo(.....)
      {
         verifyNotYetShipped();
         setShippingInfo(newShippingInfo);   // 배송지 정보 변경
         if (xxxx)
         {
            orderer.getCustomer().changeAddress(...); // 다른 애그리거트의 상태를 변경하면 안됨!
         }
      }
   }
   ```
- 이렇게 되면 애그리거트간 결합도가 높아지게 된다. 결합도가 높아지면 수정 비용이 증가하므로 피해야 한다. 
- 만약 부득이하게 두개 이상의 애그리거트를 수정해야 한다면, 응용 서비스(Application)에서 두 애그리거트를 수정하도록 구현해야 한다. 

## 리포지터리와 애그리거트
애그리거트는 개념상 한 개의 도메인 모델을 표현하므로 객체의 영속성을 처리하는 리포지터리는 애그리거트 단위로 존재한다
   - 예: Order와 OrderLine이 물리적으로 별도의 DB에 저장된다고 해도, Order가 애그리거트 루트이고 OrderLine이 구성요소 이므로 Order를 위한 리포지터리만 존재한다

새로운 리포지터리를 만들면 적어도 아래 2개의 기능이 지원되어야 한다
- save: 애그리거트 저장
- findById: ID로 애그리거트를 구함

## ID를 이용한 애그리거트 참조
애그리거트의 관리 주체가 애그리거트 루트이므로 애그리거트에서 다른 애그리거트를 참조한다는 것은 애그리거트의 루트를 참조한다는 것과 같다
   ```c#
   // Order Aggregate
   public class Order 
   {
      private Orderer orderer;
   }
   public class Orderer
   {
      private Member member;
   }

   // Member Aggregate
   public class Member {}
   ```

### 한 애그리거트에서 다른 애그리거트를 참조할 때 발생할 수 있는 문제
- 편한 탐색 오용
   - 애그리거트가 관리하는 범위는 자기 자신으로 한정되어야 하는데, 다른 애그리거트로 접근이 편리해지면 수정하고자 하는 유혹에 빠지기 쉽다
      ```c#
      orderer.getCustomer().changeAddress(XXXX);   // Order Aggregate에서 Member Aggregate를 변경 시도
      ```
- 성능 저하
- 확장
   - 사용자가 늘고 트래픽이 증가하면서 도메인별로 시스템이 분리될 수 있다.
      - 서로 다른 DBMS를 사용할 수 있고, 또는 SQL, NOSQL로 분리될 수도 있다
   - 이렇게 되면 JPA(=ORM)을 이용해서 애그리거트 루트를 참조하는게 어려워 질 수 있다

### ID를 이용한 참조
- `편한 탐색 오용`은 ID를 이용한 참조를 통해서 해결할 수 있다.<br>
- ID 참조를 이용하면 모든 객체가 참조로 연결되지 않고 한 애그리거트에 속한 객체들만 참조로 연결된다
   - 애그리거트간 물리적인 연결을 제거하기 때문에 모델의 복잡도를 낮춘다
   - 애그리거트간의 의존을 제거하므로 응집도를 높여준다
   - 구현 복잡도도 낮아진다
   - 애그리거트 별로 서로 다른 구현 기술(예: RDBMS, NoSQL)도 가능하다
- 속도
   - ID 참조를 사용할 경우에 서로 다른 애그리거트 데이터를 가져오려면 각각의 쿼리가 실행되어야 해서 속도 이슈가 있다
   - 이 경우 전용 조회 쿼리를 사용한다. 데이터 조회를 위한 별도의 DAO를 만든다

## 애그리거트를 팩토리로 사용하기
중요한 도메인 로직 처리가 응용 서비스(=Application Layer)에 노출되었을 경우, 도메인에서 해당 기능을 구현하는 것을 검토해볼 필요가 있다

### 예시
```c#
public class RegisterProductService
{
   public ProductId registerNewProduct(....) 
   {
      Store account = accountRepository.findStoreById(....);
      // 상점이 생성 가능한지 테스트
      // Product 생성
      productRepository.save(product);
   }
}
```
- 위 코드는 Store가 Product를 생성할 수 있는지 여부를 판단하고 Product를 생성한다. 그런데 이는 논리적으로 하나의 도메인 기능인데 분리되어 있을 뿐 아니라, 이 기능을 응용 서비스에서 구현하고 있다. 
- 애그리거트가 갖고 있는 데이터를 이용해서 다른 애그리거트를 생성해야 한다면 애그리거트 팩토리 메서드를 구현하는 것을 고려해봐야 한다. 
- 위 예시에서 Product의 경우 Store의 식별자를 필요로 한다. 즉 Store의 데이터를 이용해서 Product를 생성한다. 그리고 Product를 생성할 수 있는 조건을 판단할 때 Store의 상태를 이용한다. 따라서 Store에 Product를 생성하는 팩토리 메서드를 추가하면 Product를 생성할 때 필요한 데이터의 일부를 직접 제공하면서 동시에 도메인로직을 구현할 수 있다. 

```c#
public class Store extends Member 
{
   public Product createProduct(....)
   {
      // 상점이 생성 가능한지 테스트
      // Product 생성
   }
}

public class RegisterProductService
{
   public ProductId registerNewProduct(....) 
   {
      Store account = accountRepository.findStoreById(....);
      // 상점이 생성 가능한지 테스트
      Product product = account.createProduct(...) // store를 이용해서 product 생성
      productRepository.save(product);
   }
}
```
