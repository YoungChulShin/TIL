정의
- 메서드가 하나만 있는 인터페이스
- static이나 default 메서드가 있는 것은 중요하지 않다

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