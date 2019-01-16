### LINQ
- 자주 사용되는 정보의 선택/열거 작업을 일관된 방법으로 다루기 위해서 기존 문법을 확장
- Language Integrated Query
- SQL 쿼리의 Select 구문과 유사하다. 
- 확장 메서드를 간편하게 표기하기 위해서 사용
- 쿼리 대상은 IEnumerable<T> 타입이거나 그것을 상속한 객체여야 한다. 
   - C#컴파일러가 내부적으로 IEnumerable<T> 확장 메소드로 변경해서 코드를 빌드한다
- LINQ 쿼리 내에서 함수를 호출도 가능
- 반환 대상이 IEnumerable<T> 또는 IOrderedEnumerable<TElement>가 아니라면 즉시 실행된다

### Data Select
- Select의 구문은 Extention 메서드로도 구현이 가능하다.
- 예시
   ```c#
   var dataResult = from data in dataList   // foreach (data in datalist)
                    select data             // yield return person
                                            // yield return이기 때문에 IEnumerable<T>를 반환

   var all2 = people.Select(x => x);  // 동일한 결과

   // 동일한 결과
   IEnumerable<Person> SelectFunc(List<Person> people) 
   {
       foreach (var item in people)
       {
           yield return item;
       }
   }
   ```
- 특정 값만 리턴도 가능하다
    ```c#
    var dataResult = from data in dataList   // foreach (data in datalist)
                    select data             // yield return person
    ```

- 익명 타입도 가능
   ```C#
   select new { Name = person.Name, MyDate = person.Age }
   ```


### Data Select + where
- where 반환 조건에 bool 형식인 점만 만족하면 어떤 코드든 사용이 가능하다.
- 예시 
   ```c#
    var all = from person in people
            where person.Age > 20
            orderby person.Age descending
            select person ;
   ```


### Data Select + order by 
- order by 는 IComparable 인터페이스가 구현된 타입이기만 하면 된다

### Data Select + group by 
```c#
var all = from person in people
          where person.Age > 10
          orderby person.Address
          group person by person.Address;
```

### Data Join
Inner Join
```c#
var all = from person in people
          join language in languages
          on person.Name equals language.Name
          select new { Name = person.Name, Age = person.Age, Lang = language.Language };
```
Outer Join
```c#
var all = from person in people
        join language in languages
        on person.Name equals language.Name into lang 
        from language in lang.DefaultIfEmpty(new MainLanguage()) 
        select new { Name = person.Name, Age = person.Age, Lang = language.Language };
```

