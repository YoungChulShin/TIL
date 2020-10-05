## 시간 표시

기존의 Date
- mutable하기 때문에 멀티쓰레드에 역하다
- month가 0부터 시작
- Date인데 시간 값 까지 다룬다

Instant
- UTC 시간
- zone 정보를 이용해서 현재 시간을 가져올 수 있다
- 샘플 코드
   ~~~java
    Instant instant = Instant.now();
    System.out.println(instant);    // 기준시, UTC

    ZoneId zone = ZoneId.systemDefault();
    System.out.println(zone);

    ZonedDateTime zonedDateTime = instant.atZone(zone);
    System.out.println(zonedDateTime);
   ~~~

LocalDateTime
- 현재 SystemZone을 참고해서 날짜 정보를 가져온다
- 만약에 서버에서 실행하는데 서버가 미국에 있을 경우 미국 시간이 표시된다
- 샘플 코드
   ~~~java
   LocalDateTime now = LocalDateTime.now();
   System.out.println(now);
   LocalDateTime.of(1984, Month.AUGUST, 6, 0, 0, 0);
   ~~~

ZonedDateTime
- 특정 zone의 날짜 정보를 리턴한다
- 샘플 코드
   ~~~java
   ZonedDateTime nowInKorea = ZonedDateTime.now(ZoneId.of("Asia/Seoul"));
   ~~~

타입간 변경
- 샘플 코드
   ~~~java
   // ZonedDateTime to LocalDateTime
   nowInKorea.toLocalDateTime();

   // ZonedDateTime to Instant
   nowInKorea.toInstant();
   ~~~

## 기간 표시
Period
- 기간을 날짜 정보를 이용해서 비교
- 샘플 코드
   ~~~java
    LocalDate today = LocalDate.now();
    LocalDate thisYearBirthDay = LocalDate.of(2020, Month.DECEMBER, 7);

    Period period = Period.between(today, thisYearBirthDay);
    System.out.println(period.getDays());
   ~~~

Duration
- 기간을 Instant를 이용해서 비교
- 샘플 코드
   ~~~java
   Instant now = Instant.now();
   Instant plus = now.plus(10, ChronoUnit.SECONDS);
   Duration between = Duration.between(now, plus);
   System.out.println(between.getSeconds());
   ~~~

## 변환
Formatter
- 날짜 정보를 특정 문자열로 변경해서 표시
- 샘플 코드
   ~~~java
    LocalDateTime now = LocalDateTime.now();

    DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd");
    System.out.println(now.format(formatter));
   ~~~

Parser
- 문자열을 바탕으로 날짜 정보 생성
- 샘플 코드
   ~~~java
   DateTimeFormatter formatter = DateTimeFormatter.ofPattern("MM/dd/yyyy");

   LocalDate parse = LocalDate.parse("09/06/1984", formatter);
   System.out.println(parse);
   ~~~