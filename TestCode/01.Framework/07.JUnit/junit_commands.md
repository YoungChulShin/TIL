# Junit 커맨드 정보

## 응답 처리
### allSatisfy를 이용해서 특정 객체에 대한 반복 처리 개선
변경 전
```java
Assertions.assertThat(history.getAgentDailyWorkHourInfo()).isEqualTo(workHourInfo);
Assertions.assertThat(history.getWorkStatus()).isEqualTo(workHourInfo.getLastWorkStatus());
Assertions.assertThat(history.getUpdatedAt()).isEqualTo(registerCommand.getUpdateTime());
Assertions.assertThat(history.getUpdatedBy()).isEqualTo(registerCommand.getUpdateUser());
```

변경 후
```java
 Assertions.assertThat(workHourInfo.getHistories())
    .hasSize(1)
    .allSatisfy(v -> {
        Assertions.assertThat(v.getAgentDailyWorkHourInfo()).isEqualTo(workHourInfo);
        Assertions.assertThat(v.getWorkStatus()).isEqualTo(workHourInfo.getLastWorkStatus());
        Assertions.assertThat(v.getUpdatedAt()).isEqualTo(registerCommand.getUpdateTime());
        Assertions.assertThat(v.getUpdatedBy()).isEqualTo(registerCommand.getUpdateUser());
    });
```

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
