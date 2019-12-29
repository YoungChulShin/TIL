# 코드 작성
### DB 저장하는 테스트 코드 작성 순서
1. Given
   1. SampleData를 바탕으로 SaveDto 생성
2. When
   1. SaveDto를 사용하는 post를 날린다
3. Then
   1. 결과가 OK인치 체크
   2. Sample데이터의 값과 DB에서 읽어온 값이 일치하는지 검사

### DB 업데이트 테스트 코드 작성 순서
1. Given
   1. InitialData를 바탕으로 DB에 저장
   2. Update 할 데이터를 준비
   3. Update 할 정보를 가지고 있는 UpdateDto 생성
2. When
   1. UpdateDto를 사용하는 put를 날린다
3. Then
   1. 결과가 OK인치 체크
   2. Update데이터의 값과 DB에서 읽어온 값이 일치하는지 검사


# 샘플 코드
## 테스트 코드 작성 샘플 코드 #1 (WebAPI)
~~~java
package com.go1323.book.springboot.web;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)    // 테스트를 진행할 대 JUnit에 내장된 실행자 외에 다른 실행자를 실행한다
                                // 여기서는 SpringRunner이며,스프링부트와 JUnit사이의 연결자 역할을 한다
@WebMvcTest
public class HelloControllerTest {

    @Autowired  // 의존성 주입
    private MockMvc mvc;    // WebAPI를 테스트 할 때 사용

    @Test
    public void hello가_리턴된다() throws Exception {
        String hello = "hello";

        mvc.perform(get("/hello"))
                .andExpect(status().isOk())
                .andExpect(content().string(hello));
    }

    @Test
    public void helloDto가_리턴된다() throws Exception {
        String name = "hello";
        int amount = 1000;

        mvc.perform(get("/hello/dto")
                .param("name", name)
                .param("amount", String.valueOf(amount)))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.name", is(name)))
                .andExpect(jsonPath("$.amount", is(amount)));
    }
}
~~~

##  테스트 코드 작성 샘플 코드 #2
~~~java
package com.go1323.book.springboot.web.dto;

import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class HelloResponseDtoTest {

    @Test
    public void 롬복_기능_테스트() {
        // given
        String name = "test";
        int amount = 1000;

        // when
        HelloResponseDto dto = new HelloResponseDto(name, amount);

        // then
        assertThat(dto.getName()).isEqualTo(name);
        assertThat(dto.getAmout()).isEqualTo(amount);
    }
}
~~~

## 테스트 코드 작성 샘플 코드 #3 (Post에 대한 테스트)
~~~java
    @Test
    public void Posts_등록된다() throws Exception {
        //given
        String title = "title";
        String content = "content";
        PostsSaveRequestDto requestDto = PostsSaveRequestDto.builder()
                .title(title)
                .content(content)
                .author("author")
                .build();

        String url = "http://localhost:" + port + "/api/v1/posts";

        //when
        ResponseEntity<Long> responseEntity = restTemplate.postForEntity(url, requestDto, Long.class);

        //then
        assertThat(responseEntity.getStatusCode()).isEqualTo(HttpStatus.OK);
        assertThat(responseEntity.getBody()).isGreaterThan(0L);

        List<Posts> all = postsRepository.findAll();
        assertThat(all.get(0).getTitle()).isEqualTo(title);
        assertThat(all.get(0).getContent()).isEqualTo(content);
    }
~~~
