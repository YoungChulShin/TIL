## Optional
기본
- java8에서 null 처리를 조금 더 효율적으로 할 수 있도록 
등장한 개념
- 가능하면 리턴 값에서만 사용한다

기본 API
- isPresent
- get
   - 값을 가져오는 API
   - 값이 없으면 NoSuchElementException 예외 발생
- ifPresent
   - isPresent와 get을 이용해서 값을 가져오는 것 보다 한줄에 처리 가능하다
      ~~~
      onlineClasses.ifPresent(oc -> System.out.println(oc.getTitle()));
      ~~~
- orElse
   - 인스턴스를 리턴 받고 싶다면 orElse를 사용한다
   - 단점은 orElse절은 무조건 실행된다. 따라서 상수 같은 값을 리턴할 경우에는 이 방법을 사용한다
   - 동적으로 생성/실행 되는 값을 처리하기 위해서는 `orElseGet`을 이용한다