# 참고 문서
JUnit5 user guide: https://junit.org/junit5/docs/current/user-guide/

# JUnit5 Gradle 적용
```groovy
// gradle 의존성 추가
testImplementation 'org.junit.jupiter:junit-jupiter:5.4.2'

// task 추가
test {
    useJUnitPlatform()
}
```

# 설정 정보
## Expected Test
배경 
- JUnit5에서 expected test를 하려고 하니 관련 기능이 없어졌다

대응 방법
1. assertThrows()를 이용해서 검증한다.
   - https://howtodoinjava.com/junit5/expected-exception-example/
2. assertJ를 사용한다면 'Throwable'을 이용해서 검증할 수 있다
   - https://www.baeldung.com/assertj-exception-assertion
      ```java
      // when
      Throwable thrown = catchThrowable(() -> instance.getAccountDto(DATA_ACCOUNT_NO_NOT_EXISTS));
 
      // then
      assertThat(thrown).isInstanceOf(AccountNotFoundException.class);
      ```

## Composed Annotation
내용
- 테스트를 위해서 Class 또는 Method에 애노테이션을 선언할 때, n개의 애노테이션을 1개로 묶는 사용자 정의 애노테이션을 사용할 수 있다

예시
- Nested 테스트에서 'SpringBootTest', 'Transactional' 애노테이션이 함께 사용되어야 한다고 할 때, 아래와 같이 'IntegrationTest' 로 정의해서 사용할 수 있다
- 변경 전
   ```java
    @Nested
    @SpringBootTest
    @Transactional
    @DisplayName("올바른 입력이 주어졌을 때")
    class validInput {
   ```
- 변경 후
   ```java
    // IntegrationTest 애노테이션 정의
    @Target(ElementType.TYPE)
    @Retention(RetentionPolicy.RUNTIME)
    @SpringBootTest // Composed Test #1
    @Transactional // Composed Test #2
    public @interface IntegrationTest { }
    
    // 테스트 코드에서 사용
    @Nested
    @IntegrationTest
    @DisplayName("올바른 입력이 주어졌을 때")
    class validInput {
   ```

## Nested Annotation
내용
- 하나의 테스트 클래스에 Inner Class를 선언하면서 계층적으로 테스트를 작성할 수 있는 방식
- Inner Class에는 'Nested' 애노테이션을 추가해서 하위에 포함된 테스트라는 것을 명시해준다
- 공식 문서의 설명: https://junit.org/junit5/docs/current/user-guide/#writing-tests-nested

## Test Instant Lifecycle
내용
- JUnit5의 경우 개별 테스트 마다 Test Instant가 생성되는데, 추가적인 옵션을 이용하면 이 범위를 클래스 단위로 변경하는 등의 설정을 할 수 있다. 
- 공식 문서에 있는 Lifecycle을 참고하자: https://junit.org/junit5/docs/current/user-guide/#writing-tests-test-instance-lifecycle

## Default Interface를 이용한 테스트
내용
- default interface를 이용하면, 각 테스트클래스에서 기본적으로 수행되어야 하는 동작들을 정의해줄 수 있다
- 예를 들면 로깅 작업을 매 테스트마다 구현하기가 번거롭다면, default interface와 애노테이션을 조합해서 공통 코드로 분리할 수 있다. 

샘플
```java
// interface 구현
@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public interface TestLifeCycle {
 
    @BeforeAll
    default void beforeAllTests() {
        System.out.println("Test Start=================");
    }
 
    @AfterAll
    default void afterAllTests() {
        System.out.println("Test end=================");
    }
}
 
// interface 사용
class MemberServiceTest implements TestLifeCycle{
```

## Parameterized Test
내용
- 1개의 테스트에 n 개의 파라미터를 이용해서 테스트를 수행해야 할 때 Parameterized Test를 이용할 수 있다
- Parameter에 들어가는 값은 하드코딩된 문자, 숫자 정보도 가능하고, Enum 값을 넣어줄 수도 있다

샘플 코드
- 샘플에서는 EnumSource를 사용해서 Enum 값을 넣어줬고, exclude 모드를 사용해서 enum에서 특정 값을 제외하도록 했다. 
   ```java
  @ParameterizedTest
  @EnumSource(value = VirtualBankAccountStatusEnum.class, mode = EnumSource.Mode.EXCLUDE, names = { "SUSPENDED" })
  @DisplayName("False 리턴한다")
  public void returnTrue(VirtualBankAccountStatusEnum status) {
      // given
      VirtualBankAccount virtualBankAccount = new VirtualBankAccount();
      virtualBankAccount.setStatusType(status);
  
      // when
      boolean suspended = virtualBankAccount.isSuspended();
  
      // then
      assertThat(suspended).isFalse();
  }
   ```

ParameterizedTest에서 null 값 사용
- '@ValueSource' 값을 이용해서 정해진 타입의 값을 여러개 입력할 수 있는데, null을 넣을수는 없다. 
- '@MethodSource'를 이용하면 처리할 수 있다. 
- '@NullAndEmptySource' 를 지정해줘도 된다.  
   ```java
  @ParameterizedTest
  @MethodSource("blankString")
  public void message_emptyMessage_shouldFail(final String testValue) {
    // when, then
    Assertions.assertThrows(
        IllegalArgumentException.class,
        () -> {
          ApiResult.message(testValue);
        });
  }
  
  private static Stream<String> blankString() {
    return Stream.of("", " ", null);
  }
   ```

ParameterizedTest에서 parameter가 2개 이상인 기능 대응
- 'CsvSrouce' 를 이용해서 처리 가능하다
   ```java
  @ParameterizedTest
  @CsvSource({ "50, 40", "30, 29", "89, 9"})
  void sut_correctly_prints_too_low_message_in_single_player_game(int answer, int guess) {
   ```

CsvSource에서 null 값 사용
- 'nullValues' 옵션을 사용하면 null값 전달이 가능하다. 
   ```java
   @ParameterizedTest
   @CsvSource(value = { "null, null"}, nullValues = {"null"})
   void should_return_MANDATORY_PARAM_ERROR_if_request_item_is_null_or_empty(String certId, String userId) {
   ```