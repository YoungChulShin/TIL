## WebAPI의 테스트 코드 작성 샘플 코드
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
}
~~~
