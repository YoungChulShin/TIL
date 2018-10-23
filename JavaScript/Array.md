### 배열 선언
1. 리터럴 생성
   - var arr = ["1","2","3"];
2. Array() 생성자 함수
   - var arr = new Array("1", "2", "3");
   - 인자가 1개이면서, 숫자일 경우: 배열의 길이로 판단<br>그 외에는 배열의 인자

### 배열 요소 추가 및 접근
1. 추가
   - array[new index] = value 로 추가 가능
   - new index는 꼭 마지막 배열의 다음 값일 필요는 없음<br>
   값이 jump 된다면 length는 new index의 값을 기준으로 선정<br>
   jump로 인해서 생기는 공백의 index는 undefined로 나타나며, 메모리를 사용하지 않는다
2. 접근
   - array[index] 로 접근 가능

### 배열의 length, push
1. length
   - 배열의 길이를 나타낸다
   - 실제 배열의 길이는 아니며, 마지막 index 값을 기준으로 결정된다.
2. push
   - 배열의 마지막 index 다음에 값을 추가한다
   - array.push(value)
   - 마지막 index를 기준으로 하기 때문에, undefined 요소라도 그 다음 index에 값이 들어간다
3. pop
   - 배열의 측정 값 제거. length 줄어듬
4. delete
   - 배열의 특정 값 제거. length는 줄어들지 않음
3. splice
   - 배열의 특정 값 제거. range를 지정해서 제거 가능

### 배열의 프로퍼티
- 배열도 Object를 상속받기 때문에 프로퍼티를 선언 가능하다
- Object.Prototype <- Array.Prototype <- 배열

