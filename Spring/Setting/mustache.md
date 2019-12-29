## Mushtache 설정 방법
1. Plugin에서 mushtache 설치
   - ctrl + shift + a 를 이용해서 플러그인 창 확인 가능
2. build.gradle에서 의존성 추가
   ~~~
   compile('org.springframework.boot:spring-boot-starter-mustache')
   ~~~
3. index 페이지 생성
   1. 경로는 src.main.java.resources.templates 
   2. 해당 경로 아래에 *.mustache로 파일 생성
4. index controller 생성
   ~~~java
   @Controller
   public class IndexController {

      @GetMapping("/")
      public String index() {
         return "index";
      }
   }
   ~~~

   - "index" 문자열 앞뒤로 아래의 값이 추가 된다
      - 앞: src.main.resources.templates
      - 뒤: .mustache
      - 최종: src.main.resources.templates.index.mustache