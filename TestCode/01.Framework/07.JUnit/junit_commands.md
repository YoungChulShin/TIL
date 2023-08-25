# Junit 커맨드 정보

## 에러 핸들링
### catchThrowable을 이용한 에러 catch 
```java
Throwable thrown = catchThrowable(() -> sut.validate(order, agent, inProgressOrdersInfo));
```
위와 같은 방법으로 예외 객체를 추출할 수 있다. 이후에 이 객체를 이용해서 예상하는 예외를 검증할 수 있다. 
```java
Assertions.assertThat(thrown).isNotNull();
Assertions.assertThat(thrown).isInstanceOf(AiAssignFailureException.class);
Assertions.assertThat(((AiAssignFailureException)thrown).getAssignFailReason())
    .isEqualTo(AssignFailReason.ORDERS_EXIST_FOR_DIRECT_DELIVERY);
```

### Assertions.assertThatThrownBy을 이용해서 한번에 에러 처리
assertThatThrownBy를 이용하면 별도의 에러 객체를 추출하지 않아도 체이닝 방법으로 검증할 수 있다. 
```java
Assertions.assertThatThrownBy(() -> sut.validate(order, agent, inProgressOrdersInfo))
    .isInstanceOf(AiAssignFailureException.class)
    .extracting("assignFailReason")
    .containsExactly(ORDERS_EXIST_FOR_DIRECT_DELIVERY);
```