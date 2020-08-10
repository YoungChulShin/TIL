메모
- 기본적으로 패키지는 Java.Sql을 사용한다
- 순서
   1. Connection 정의
   2. PreparedStatement 정의(SQL 쿼리)
   3. 쿼리 실행
   4. PreparedStatement 해지
   5. Connection 해지
- 쿼리의 경우는 exequteQuery로 가져오고, 리턴값은 ResultSet이다
- ResultSet은 next()를 이용해서 내부 탐색을 할 수 있고, getString()을 이용해서 칼럼 값을 가져올 수 있다

