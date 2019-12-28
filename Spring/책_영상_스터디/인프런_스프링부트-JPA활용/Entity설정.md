### 연관 관계
연관 관계의 주인은 F.K가 가까운 곳으로 정한다

## 엔티티 클래스 개발
### Getter, Setter
- Getter는 가능하면 열어준다
- Setter는 데이터가 변하기 때문에, 변경용 메서드를 제공해서 변경 포인터를 모으는 것이 좋다

### 식별자
- 엔티티의 식별자는 id를 사용
- P.K 칼럼명은 'tablename_id(예: member_id)를 사용

### ManyToMany
- 사용하지 말자
- OneToMany나 ManyToOne으로 풀어서 사용하자

### 주소 값 타입
- 값은 Immutable하게 만들어져야 한다
- Setter를 제거하고, 생성자에서 처리해준다

## 엔티티 설정 주의점
### 가급적 Setter를 사용하지 말자
- 변경 포인터가 많아서 유지보수가 어렵다

### 모든 연관 관계는 지연로딩으로 설정!
- 즉시(Eager) 로딩
   - Member를 조회할 때 필요한 정보(=Order)를 같이 Loading하는 것
   - 모두 지연(Lazy)로딩으로 한다
   - ManyToOne, OneToOne은 기본값이 EAGER, OneToMany는 기본값이 LAZY
      - ManyToOne, OneToOne은 Lazy로 설정해준다

- fetch join이나 엔티티 그래프를 사용해서 연관된 엔티티를 함께 DB애서 조회할 수 있다

### 컬렉션은 필드에서 초기화하자
- null문제에서 안전하다
- 하이버네이트는 엔티티를 영속화할 때 하이버네이트가 제공하는 내장 컬렉션으로 변경한다

### 테이블, 컬럼명 생성 전략
- 별도의 이름이 없으면 스프링부트 설정(SpringPhsicalNamingStrategy)를 사용한다
   1. 카멜 케이스 -> 언더스코어
   2. .(점) -> 언더스코어
   3. 대문자 -> 소문자


### cacade 
- 원래 Entity는 각각을 persist해줘야 하는데, cascade가 설정되어 있으면 같이 해준다 

### 연관관계 편의 메서드
- 양방향 관계를 가지고 있는 엔티티의 경우에 양쪽 모두 업데이트를 해줘야 하며, 한쪽을 놓칠경우 에러가 된다. 
- 이러한 에러를 막기 위해서 한쪽에서 값을 설정할 때, 두쪽 모두 값을 업데이트 해주 방법을 사용한다
   ```java
   // Order Class
    public void setMember(Member member) {
        this.member = member;
        member.getOrders().add(this);
    }

    public void addOrderItem(OrderItem orderItem) {
        orderItems.add(orderItem);
        orderItem.setOrder(this);
    }

    public void setDelivery(Delivery delivery) {
        this.delivery = delivery;
        delivery.setOrder(this);
    }
   ```