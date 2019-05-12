참고 자료
- 테스트주도 개발
- C#으로 배우는 적응형 코드
---
## 테스트 케이스 작성 예시
### 생성자
Null을 허용하지 않는 생성자에 대한 체크
```c#
public void ConstrunctionWithoutRepositoryThrowsArgumentNullException();
public void ConstrunctionWithValidParameterDoesNotThrowException();
```

## 문제 해결 예시
### 테스트 문제 예시
```c#
[TestMethod]
public void Sum_Products_Correctly()
{
    // 문제
    // LinqValueCalculator가 MinimalDiscountHelper에 의존한다. 
    // MinimalDiscountHelper가 변경되면 테스트에 영향을 미친다. 
    // 테스트가 MinimalDiscountHelper의 문제인지 
    // LinqValueCalculator의 문제인지 알수가 없다
    //

    // Arrange
    var discounter = new MinimalDiscountHelper();
    var target = new LinqValueCalculator(discounter);
    var goalTotal = products.Sum(x => x.Price);

    // Act
    var result = target.ValueProducts(products);

    // Assert
    Assert.AreEqual(goalTotal, result);
}
```

### MOCK을 이용한 문제 해결
```c#
Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
var target = new LinqValueCalculator(mock.Object);
```

### 문제 해결 개념
LinqValueCalculator가 가지고 있던 IDiscountHelper와의 의존성을 IDiscountHelper 형식의 MOCK을 만들면서 제거. 

기능에 대한 검증은 MOCK에 IDiscountHelper가 가지고 있는 동작들을 정의해서 동일하게 동작하도록 구현. 

```c#
[TestMethod]
[ExpectedException(typeof(System.ArgumentOutOfRangeException))]
public void Pass_Through_Variable_Discount()
{
// Arrange
// IDiscountHelper의 기능을 구현
Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
mock.Setup(x => x.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
mock.Setup(x => x.ApplyDiscount(It.Is<decimal>(v => v == 0))).Throws<System.ArgumentOutOfRangeException>();
mock.Setup(x => x.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => (total * 0.9M));
mock.Setup(x => x.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => (total * 0.9M));
}
```