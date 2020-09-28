정의
- 일종의 컨베이어 벨트에 데이터를 넣고 하나씩 처리하는 것
- 원본 데이터를 변경하지는 않는다

스트림 파이프라인
- 중계형 오퍼레이터를 여러개 넣을 수 있다
- 마지막에 종료형 오퍼레이터가 한개 와야한다
- 종료형 오퍼레이터가 실행되기 전까지는 중계형 오퍼레이터는 실행되지 않는다. 

특징
- 중계형 오퍼레이터는 lazy로 처리된다
- 병렬 처리
   - `parallelStream`를 사용 (Stream보다 무조건 빠른건 아님)

샘플 코드
- for 문과 스트림 사용 비교
   ~~~java
   List<String> names = new ArrayList<>();
    names.add("keesun");
    names.add("youngchul");
    names.add("toby");
    names.add("foo");

    for (String name : names) {
        System.out.println(name.toUpperCase());
    }

    names.parallelStream().map(String::toUpperCase).collect(Collectors.toList());
   ~~~


스프링이 제공해주는 API 샘플 실습
- 코드
   ~~~java
   List<OnlineClass> springClasses = new ArrayList<>();
   springClasses.add(new OnlineClass(1, "spring boot", true));
   springClasses.add(new OnlineClass(2, "spring data jpa", true));
   springClasses.add(new OnlineClass(3, "spring mvc", false));
   springClasses.add(new OnlineClass(4, "spring core", false));
   springClasses.add(new OnlineClass(5, "rest api development", false));

   System.out.println("spring으로 시작하는 수업");
   springClasses.stream()
            .filter(s -> s.getTitle().startsWith("spring"))
            .forEach(oc -> System.out.println(oc.getId()));

   System.out.println("close 되지 않은 수업");
   springClasses.stream()
            //.filter(Predicate.not(OnlineClass::isClosed))
            .filter(oc -> !oc.isClosed())
            .forEach(oc -> System.out.println(oc.getId()));

   System.out.println("수업 이름만 모아서 스트림하기");
   springClasses.stream()
            .map(OnlineClass::getTitle)
            .forEach(System.out::println);

   List<OnlineClass> javaClasses = new ArrayList<>();
   javaClasses.add(new OnlineClass(6, "The Java, Test", true));
   javaClasses.add(new OnlineClass(7, "The Java, Code manipulation", true));
   javaClasses.add(new OnlineClass(8, "The Java, 8 to 11", false));

   List<List<OnlineClass>> keesunEvents = new ArrayList<>();
   keesunEvents.add(springClasses);
   keesunEvents.add(javaClasses);

   System.out.println("두 수업 목록에 있는 모든 수업 아이디 출력");
   keesunEvents.stream()
            .flatMap(Collection::stream)
            .forEach(oc -> System.out.println(oc.getId()));

   System.out.println("10부터 1씩 증가하는 무제한 스트림 중에서 앞에 10개 빼고 최대 10개 까지만");
   Stream.iterate(10, i -> i + 1)
            .skip(10)
            .limit(10)
            .forEach(System.out::println);


   System.out.println("자바 수업 중에 Test가 들어있는 수업이 있는지 확인");
   boolean test = javaClasses.stream().anyMatch(x -> x.getTitle().contains("Test"));
   System.out.println(test);

   System.out.println("스프링 수업 중에 제목이 spring이 들어가 있는 것만 모아서 List로 만들기");
   List<String> spring = springClasses.stream()
            .filter(oc -> oc.getTitle().contains("spring"))
            .map(OnlineClass::getTitle)
            .collect(Collectors.toList());
   spring.forEach(System.out::println);
   ~~~