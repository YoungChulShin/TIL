# CSS Selectors
### 기본 개념
CSS를 이용하면 HTML 엘리먼트의 외형을 변경할 수 있다

### 파일에 링크 방법
```html
<link href="https://www.codecademy.com/stylesheets/style.css" type="text/css" rel="stylesheet">
```

- href: 링크 파일 위치
- type: 링크 타입
- rel: HTML과 CSS 파일과의 연결 관계


### tag, class, ID
CSS는 tag, class, ID에 대응해서 적용 대상을 선택할 수 있다
- 우선 순위는 ID > class > tag 순이다

tag
- HTML tag에 해당하는 style 적용이 가능하다
    ```css
    p {
        font-family : Arial;
    }
    ```

class
- HTML class에 해당하는 항목에 style 적용이 가능하다
- 여러개의 class가 1개의 HTML 엘리먼트에 적용 가능하다
- 재 사용가능하다
    ```css
    .capitalize {
        text-transform: capitalize;
    }
    ```

    ```HTML
    <h1 class="green bold"> ... </h1>
    ```

ID
- 고유한 대상에 대해서 사용할 때 사용한다
    ```css
    #large-title {
        text-transform: capitalize;
    }
    ````

    ```HTML
    <h1 id="large-title"> ... </h1>
    ```

tag에 class를 조합해서 사용하는 것도 가능하다
- 이 경우 tag 중에서 해당 class를 사용하는 구성요소에만 적용
    ```css
    h2.destination {
        font-family: cursive;
    }
    ```

Nested 구성요소에 적용
   ```HTML
   <ul class='main-list'>
   <li>1 </li>
   <li>2 </li>
   <li>3 </li>
   </ul>
   ```

   ```css
   .main-list li {

   }
   ```

- 위 css의 경우는 `.main-list` class에서 `li`항목에만 스타일을 적용하겠다는 뜻


2개의 항목에 공통 스타일을 적용
- `,`로 구분해서 적용 가능하다
    ```css
    h1, 
    .menu {
    font-family: Georgia;
    }
    ```

### !important
!important flag
- 모든 것보다 우선 적용된다