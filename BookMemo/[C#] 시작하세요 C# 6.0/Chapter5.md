
# 5.1 문법 요소
## 5.1.1 구문
### 전처리기
- C#의 전처리기 지시문(preprocessor directive)는 특정 소스코드를 상황에 따라 컴파일 과정에서 추가/제거하고 싶을 때 사용한다. 
- #if, #endif 를 이용해서 사용 가능하다.
- #elif, #else 를 통해서 구문을 분리해서 처리 가능하다

- #define을 이용하면 컴파일 기호를 넣지 않고도 코드에서 사용 가능하다. 
  - '#define X86'

### 특정 (Attribute)
- 특성도 하나의 Class이다. System.Attribute를 상속받는다
- 이름은 뒤에 'Attribute'를 붙여서 생성한다. 
  - class TestAttribute : System.Attribute 
- ['AttributeName'] 로 사용하는데, 이는 'new AttributeName()'과 동일하다
- Attribute Class는 'System.AttributeUsageAttribte'라는 또 다른 특성을 사용할 수 있다.
  - enum 타입의 'AttributeTarget' 값을 인자로 받는 생성자가 있다
  - 이는 Attribute를 특정 특성 (예: Assembly, Module, Class, Struct, Enum)에 사용될 수 있도록 제한한다. 

## 5.1.2 연산자
### 시프트 연산자
- 비트 단위로 제어할 때 사용
- '>>' : 오른쪽으로 n 비트 이동
- '<<' : 왼쪽으로 n 비트 이동 