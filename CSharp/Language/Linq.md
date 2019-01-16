### LINQ
- 자주 사용되는 정보의 선택/열거 작업을 일관된 방법으로 다루기 위해서 기존 문법을 확장
- Language Integrated Query
- SQL 쿼리의 Select 구문과 유사하다. 
- 확장 메서드를 간편하게 표기하기 위해서 사용

### Data Select
- Select의 구문은 Extention 메서드로도 구현이 가능하다.
    >var dataResult = from data in dataList<br>
    >                   select data

### Data Select + where
- where 반환 조건에 bool 형식인 점만 만족하면 어떤 코드든 사용이 가능하다.
    >var dataResult = from data in dataList<br>
    >where data.Age > 30<br>
    >select data 

### Data Select + Order by
- descending은 orderby 구문 이후에 마지막에 넣어준다.
    >var dataResult = from data in dataList<br>
    >order by data.Age<br>
    >select data

### Data Select + group by 