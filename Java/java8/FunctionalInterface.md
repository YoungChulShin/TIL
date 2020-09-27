정의
- 메서드가 하나만 있는 인터페이스
- static이나 default 메서드가 있는 것은 중요하지 않다

자바에서 함수형 프로그래밍
- 입력이 같으면 출력이 같아야 한다 (=순수 함수)
- 함수의 입력 값에 함수가 들어갈 수 있다
- 불변성

구현
- `@FunctionalInterface`를 인터페이스위에 추가해준다
   ~~~java
   @FunctionalInterface
   public interface RunSomething {

       void doIt();
   }
   ~~~

사용
1. 익명함수 사용
   ~~~java
    RunSomething runSomething = new RunSomething() {
        @Override
        public void doIt() {
            System.out.println("Hello");
        }
    };   
   ~~~
2. 람다 표현식
   ~~~java
   RunSomething runSomething = () -> System.out.println("Hello");
   ~~~

자바에서 기본 제공하는 함수형 인터페이스
- `java.util.function`에 구현되어 있다
   - [Link](https://docs.oracle.com/javase/8/docs/api/java/util/function/package-summary.html)
- Function interface
   - Function<T, R>
   - 샘플 코드
      ~~~java
      Function<Integer, Integer> plus10_new = (number) -> number + 10;
      ~~~
   - compose, andThen 등을 이용해서 함수를 조합하는 것도 가능하다
      ~~~java
      Function<Integer, Integer> plus10_new = (number) -> number + 10;
        Function<Integer, Integer> minus5 = (number) -> number - 5;
        Function<Integer, Integer> minus5_and_plus10 = plus10_new.compose(minus5);
      ~~~


내부 클래스 / 익명 클래스 / 람다
- 공통점
   - 외부 변수를 참조하는데 있어서 final 또는 effectively final (=final은 아니지만 그렇게 동작하는 것)만 사용할 수 있다
- 차이점
   - 함수의 스코프
      - 내부 클래스,익명 클래스는 별도의 스코프를 가지고 있어서 이를 감싸고 있는 클래스와 같은 변수를 선언할 수 있다
      - 람다는 감싸고 있는 클래스와 같은 스코프를 가지기 때문에 같은 이름의 변수를 선언하면 컴파일 에러가 발생한다
- 샘플 코드
   ~~~java
   private void run() {

        int baseNumber = 10;

        // 로컬 클래스
        class LocalClass {
            void printBaseNumber() {
                System.out.println(baseNumber);
            }
        }

        // 익명 클래스
        Consumer<Integer> integerConsumer = new Consumer<Integer>() {
            @Override
            public void accept(Integer baseNumber) {
                System.out.println(baseNumber);
            }
        };

      // 람다
        IntConsumer printInt = (i) -> {
            System.out.println(i + baseNumber);
        };

        printInt.accept(10);
    }
   ~~~


메서드 레퍼런스
- 정의
   - 람다 함수가 사용되는 부분에 동일한 기능(= 같은 입력, 같은 출력)을 하는 다른 함수가 있으면 대신 사용할 수 있는 기능
- 대상의 기준
   - static 메서드
   - 인스턴스 메서드
   - 생성자
- 샘플 코드
   ~~~java
   // 람다를 사용
    UnaryOperator<String> hi = (s) -> "hi " + s;

    // static 메서드 참고
    UnaryOperator<String> hi2 = Greeting::hi;

    // 인스턴스 메서드 참고
    Greeting greeting = new Greeting();
    UnaryOperator<String> hi3 = greeting::hello;

    // 생성자 (인자가 없는 생성자를 참조)
    Supplier<Greeting> greetingSupplier = Greeting::new;

    // 생성자 (인자가 있는 생성자를 참조)
    Function<String, Greeting> myGreeting = Greeting::new;
    Greeting youngchulGreeting = myGreeting.apply("youngchul");
   ~~~