# truthy, falsy
## 개념
true, false가 아니어도 js에서 해당 값을 true 또는 false로 판단하는 개념

truthy
- 값이 있는 문자
- infinity

falsy
- null
- undefined
- 0
- 공백 문자
- NaN

## 활용
예를 들어서 특정 조건의 값이 올바른지 체크를 할 때, 'undefined', 'null' 등의 조건을 하나하나 체크하기 번거롭다면, 이 값을 사용할 수 있다. 
```js
const getName = (person) => {
  // person이 null, undefied, empty 등등의 조건을 falthy 속성을 이용해서 처리해줄 수 있다
  if (!person) {
    return "객체가 아닙니다";
  }
  return person.name;
};
```