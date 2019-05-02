# 인터페이스 분리 (Interface Segregation)

인터페이스분리원칙은 인터페이스를 최대한 간소하게 유지하기 위한 원칙이다. 

인터페이스는 한 가지 목적을 위한 하나의 메서드만을 제공해야 한다. 잘게 쪼개면 대리자(delegate)와 비슷하게 보일 수 있지만, 훨씬 더 많은 장점을 제공한다. 


## 인터페이스 분리 예제
리팩토링 대상 인터페이스
```c# 
public interface ICreateReadUpdateDelete<TEntity>
{
    void Create(TEntity entity);
    TEntity ReadOne(Guid identity);
    IEnumerable<TEntity> ReadAll();
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
```

단점
- 한 인터페이스에 정의된 전체 메서드가 아닌 일부에만 적용해야 할 수도 있다. 이 경우에도 전체 인터페이스를 구현해야 한다. 
- 예를 들어 Delete만을 필요로 한다면 Delete를 제외한 함수는 모두 흘려보내게(pass-through)된다.

수정
- Delete 인터페이스를 아래와 같이 분리할 수 있다
```c#
// 인터페이스 선언 1
public interface ICreateReadUpdate<TEntity>
{
    void Create(TEntity entity);
    TEntity ReadOne(Guid identity);
    IEnumerable<TEntity> ReadAll();
    void Update(TEntity entity);
}

// 분리된 인터페이스 선언
public interface IDelete<TEntity>
{
    void Delete(TEntity entity);
}

// 구현 클래스
public class DeleteConfirmation<T> : IDelete<T>
{
    private readonly IDelete<T> decoratedDelete;
    public DeleteConfirmation(IDelete<T> decoratedDelete)
    {
        this.decoratedDelete = decoratedDelete;
    }

    public void Delete(T entity)
    {
        Console.WriteLine("정말 삭제하시겠습니까? ");
        var keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Y)
        {
            decoratedDelete.Delete(entity);
        }
    }
}
```

## 클라이언트의 생성

### 다중 구현과 다중 인스턴스
다중 구현
- 인터페이스르르 여러개로 분리해서 사용
- 예: IRead, ISave, IDelete

다중 인스턴스
- 다중 구현된 클래스의 Object를 만들기 위해서는 각각의 인스턴스를 생성해서 클래스의 인자로 넘겨줘야 한다
    ```c#
    var reader = new Reader<order>();
    var saver = new Reader<order>();
    var deleter = new Reader<order>();

    new OrderController(reader, saver, deleter);
    ```

### 단인 구현과 단일 인스턴스
다중 인스턴스의 구현을 1개의 클래스에서 모두 하기 위한 동작
```c#
var crud = new CreateReadUpdateDelete<order>();

// crud가 reader, saver, deleter의 기능을 모두 가지고 있다
new OrderController(crud, crud, crud);
```

### 인터페이스 수프 안티패턴
분리된 인터페이스를 다시 섞어버리는 인터페이스. 

인터페이스 분리의 장점이 희석된다.

