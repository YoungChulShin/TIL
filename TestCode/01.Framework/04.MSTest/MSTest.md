## Assert 명령어
Assert.IsInstanceOfType : 값의 타입을 검증할 때 사용

   ```c# 
    try
    {
        sut.AddTransactionToAccount("예금 계좌", 100m);
    }
    catch (ServiceException serviceException)
    {
        // Assert
        Assert.IsInstanceOfType(serviceException.InnerException, typeof(DomainException));
    } 
   ``` 


## 초기화
테스트 초기화 함수를 이용해서 테스트 수행 전 객체 생성 등의 작업을 수행 가능

초기화 함수는 이름은 상관 없으나, TestInitialize 특성을 지정해야 한다
```c#
[TestInitialize]
public void Setup()
{
    mockAccount = new Mock<Account>();
    mockRepository = new Mock<IAccountRepository>();
    sut = new AccountService(mockRepository.Object);
}
```

