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