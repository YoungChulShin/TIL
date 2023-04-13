# API 호출
## fetch API
`fetch` api를 이용하면 서버에 요청 및 결과를 받을 수 있다.

샘플 코드
```js
 const getData = async () => {
    const res = await fetch(
      "https://jsonplaceholder.typicode.com/comments"
    ).then((res) => res.json());
};
``` 