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
   - `parallelStream`를 사용

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