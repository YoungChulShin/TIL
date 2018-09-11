
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
### 비트 연산자
- & : And
- | : Or
- ^ : XOR
- ~ : 보수 연산자

## 5.1.3 예약어
### 가변 매개변수: params
- 함수의 파라미터를 전달 받을 때, 정확히 수를 모르는 경우 params를 파라미터 앞에 붙여서 n개의 값을 받을 수 있다
- 타입이 서로 다르다면, object 타입을 받아서 처리할 수 도 있다

### Win32 API 호출: extern
- ManagedCode에서 C, C++로 만들어진 함수(UnManagedCode)를 호출할 때 사용
  - P/Invoke: platform invocation
- extern을 위해서는 3가지의 내용이 필요
  1. DLL 이름 : User32.dll
  2. 함수 이름 : MessageBeep
  3. 함수 형식 : BOOL WINAPI MessageBeep (_In_ UINT uType)
- extern은 메서드에 코드가 없어도 실행될 수 있게 해주는 기능
- Win32 API와 C# 코드를 연결하는 것은 [DLLImport] 특성을 이용해서 사용 가능하다. 
- www.pinvoke.net 사이트에서 win32 API를 확인 가능하다


