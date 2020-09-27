### Default Methods
정의
- Interface에서 공통적으로 제공하는 기능을 구현 제공

방법
- `default`를 붙여서 구현

샘플 코드
- 코드
    ~~~java
    /**
        * @implSpec
        * 이 구현체는 getName()으로 가져온 문자들을 대문자로 바꿔준다
        */
    default void printNameUpperCase() {
        System.out.println(getName().toUpperCase());
    }
    ~~~

기타
- `@implSpec`을 이용해서 문서화를 시켜준다
- 하위 클래스에서 오버라이드해서 사용할 수 있다

### Static Methods
정의
- 인스턴스가 없어도 사용 가능하다

### API를 통한 기능 제공
- forEach, spliterator, stream, revserved 등의 api를 제공해준다
