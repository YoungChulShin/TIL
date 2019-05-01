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