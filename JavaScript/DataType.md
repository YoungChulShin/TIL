## DataType
### 기본 타입
1. 숫자 (Number)
2. 문자열 (String)
3. 불린값 (Boolean)
4. undefined
5. null
### 참조 타입
1. Object
   1. 배열 (Array)
   2. 함수 (Function)
   3. 정규표현식
---
## 기본 타입
### 숫자 타입
- 모든 숫자를 64비트 부동소수점 형태로 저장. (C언어의 Double 타입과 유사)

### 문자 타입
- 한번 생성된 문자열은 읽기는 가능하지만, 수정은 불가능 하다
   - string을 array index로 접근이 가능한데, 이 경우 접근은 가능하지만 수정은 불가능하다

### Boolean 값

### undefined
- 값이 할당되지 않은 변수는 undefined 타입이다. 이 경우 값 또한 undefined 타입이다. 

### null
- 개발자가 명시적으로 값이 비어있음을 나타낼 때 사용
- null의 경우 object 타입이기 때문에, typeof로 비교는 어려우면 ==로 비교해야 한다
   - console.log(nullVar == null);  // true
   - console.log(typeof(nullVar) == null);  // false

---
## 객체 타입
### 객체 생성
1. Object() 생성자 함수를 통한 생성
   - var objectName = new Object() 로 생성하는 방법
   - 프로퍼티는 objetName.XXX = "value"; 로 선언

2. 객체 리터럴 방식 이용
   - var objectName = { 프로퍼티 이름: 프로퍼티 값} 으로 선언하는 방법

### 객체 접근
- '.' 또는 대괄호([])를 이용해서 접근 가능
- 프로퍼티 이름에 '-'가 들어가면 대괄호를 이용해서 생성해야 함
- for 문을 통해서 객체에 접근 가능
   - for (prop in foo) { console.log(prop, foo[prop]); }
   - prop는 프로퍼티 이름

### 객체 프로퍼티 삭제
- delete '프로퍼티' 로 삭제 가능
   - 예: delete foo.name

### 기타
- 기본 값 타입에 대해서는 call by value로 접근
- 객체 값 타입에 대해서는 call by reference로 접근
- 모든 객체는 prototype('\_\_proto\_\_')라는 최상위 객체를 상속받는다 

---
### 기타
- NaN: Not a Number : 수치연산에서 원하는 값을 얻지 못했을 때 출력되는 값
