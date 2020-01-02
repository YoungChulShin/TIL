## 스프링 부트에서 OAuth 로그인 사용

1. 의존성 추가하기 'spring-boot-starter-oauth2-client'
    ~~~
    compile('org.springframework.boot:spring-boot-starter-oauth2-client')
    ~~~
2. Security 설정
   - URL 별 권한 설정
   - 로그아웃 설정
   - 로그인 이후에 동작 설정
    ~~~java
    @RequiredArgsConstructor
    @EnableWebSecurity  // Spring Security 설정들을 활성화
    public class SecurityConfig extends WebSecurityConfigurerAdapter {

        private final CustomOAuth2UserService customOAuth2UserService;

        @Override
        protected void configure(HttpSecurity http) throws Exception {
            http
                .csrf().disable()
                .headers().frameOptions().disable() // h2-console 화면을 사용하기 위해서 관련 옵션을 disable
                .and()
                    .authorizeRequests()    // URL별 권한 관리를 설정하는 옵션의 시작점
                    .antMatchers("/", "/css/**", "/images/**", "/js/**", "/h2-console/**").permitAll()  // '/'등 지정된 URL등은 전체 열람 권한
                    .antMatchers("/api/v1/**").hasRole(Role.USER.name())
                    .anyRequest().authenticated()   // 설정된 값 이외의 나머지 URL은 인증된 사용자(=로그인된 사용자) 들에게만 허용
                .and()
                    .logout()
                        .logoutSuccessUrl("/")  // 로그아웃 성공시 '/' 경로로 이동
                .and()
                    .oauth2Login() // OAuth2 설정의 진입점
                        .userInfoEndpoint() // OAuth2 로그인 이후에 사용자 정보를 가져올 때 설정
                            .userService(customOAuth2UserService);  // 로그인 성공 이후에 후속 조치를 수행할 UserInterface의 구현체
                                                                    // loadUser 함수를 통해서 사용자 정보를 가져온다
        }
    }
    ~~~

3. 로그인 이후 동작 클래스 작성
    ~~~java
    @RequiredArgsConstructor
    @Service
    public class CustomOAuth2UserService implements OAuth2UserService<OAuth2UserRequest, OAuth2User> {
        private final UserRepository userRepository;
        private final HttpSession httpSession;

        @Override
        public OAuth2User loadUser(OAuth2UserRequest userRequest) throws OAuth2AuthenticationException {
            OAuth2UserService delegate = new DefaultOAuth2UserService();
            OAuth2User oAuth2User = delegate.loadUser(userRequest);

            String registrationId = userRequest.getClientRegistration().getRegistrationId();    // 현재 진행중인 서비스를 구분하는 코드
                                                                                                // 구글, 네이버 등을 구분하는 코드
            String userNameAttributeName = userRequest.getClientRegistration()
                                                .getProviderDetails()
                                                .getUserInfoEndpoint()
                                                .getUserNameAttributeName();    // P.K와 같은 의미

            OAuthAttributes attributes = OAuthAttributes.of(registrationId, userNameAttributeName, oAuth2User.getAttributes());

            User user = saveOrUpdate(attributes);

            httpSession.setAttribute("user", new SessionUser(user));    // 세션에 사용자 정보를 저장하기 위한 Dto 클래스

            return new DefaultOAuth2User(
                    Collections.singleton(new SimpleGrantedAuthority(user.getRoleKey())),
                    attributes.getAttributes(),
                    attributes.getNameAttributeKey());
        }

        private User saveOrUpdate(OAuthAttributes attributes) {
            User user = userRepository.findByEmail(attributes.getEmail())
                    .map(entity -> entity.update(attributes.getName(), attributes.getPicture()))
                    .orElse(attributes.toEntity());

            return userRepository.save(user);
        }
    }
    ~~~

4. 로그인 이후에 Controller에서 세션 설정
    ~~~java
    @GetMapping("/")
    public String index(Model model) {
        model.addAttribute("posts", postsService.findAllDesc());
        SessionUser user = (SessionUser)httpSession.getAttribute("user");
        if (user != null) {
            model.addAttribute("userName", user.getName());
        }
        return "index";
    }
    ~~~

5. HTML 코드에서 기본적으로 제공되는 로그인/로그아웃 설정
   1. 로그인
      ~~~html
      <a href="/logout" class="btn btn-info active" role="button">Logout</a>
      ~~~
   2. 로그아웃
      ~~~html
      <a href="/oauth2/authorization/google" class="btn btn-success active" role="button">Google Login</a>
      ~~~