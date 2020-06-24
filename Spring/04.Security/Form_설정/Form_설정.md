### 셋업 방법
1. 관련 의존성을 추가한다
2. `WebSecurityConfigurerAdapter` 클래스를 확장한다
   ~~~java
   @Configuration
    @EnableWebSecurity
    public class SecurityConfig extends WebSecurityConfigurerAdapter {

        @Autowired
        AccountService accountService;

        @Autowired
        PasswordEncoder passwordEncoder;

        @Bean
        public TokenStore tokenStore() {
            return new InMemoryTokenStore();
        }

        @Bean
        @Override
        public AuthenticationManager authenticationManagerBean() throws Exception {
            return super.authenticationManagerBean();
        }

        @Override
        protected void configure(AuthenticationManagerBuilder auth) throws Exception {
            auth.userDetailsService(accountService)
                    .passwordEncoder(passwordEncoder);
        }

    //    @Override
    //    public void configure(WebSecurity web) throws Exception {
    //        web.ignoring().mvcMatchers("/docs/index.html");
    //        web.ignoring().requestMatchers(PathRequest.toStaticResources().atCommonLocations());
    //    }

        @Override
        public void configure(HttpSecurity http) throws Exception {
            http
                .anonymous()
                    .and()
                .formLogin()
                    .and()
                .authorizeRequests()
                    .mvcMatchers("/docs/index.html").anonymous()
                    .requestMatchers(PathRequest.toStaticResources().atCommonLocations()).anonymous()
                    .mvcMatchers(HttpMethod.GET, "/api/**").authenticated()
                    .anyRequest().authenticated();
        }
    }

   ~~~
3. Password Encodoer
   ~~~java
   @Bean
    public PasswordEncoder passwordEncoder() {
        return PasswordEncoderFactories.createDelegatingPasswordEncoder();
    }
   ~~~

4. `UserDetailService` 를 구현하는 클래스
   - FormLogin에서 사용자 정보를 처리할 때 사용
   ~~~java
   @Service
    public class AccountService implements UserDetailsService {

        @Autowired
        AccountRepository accountRepository;

        @Autowired
        PasswordEncoder passwordEncoder;

        public Account saveAccount(Account account) {
            account.setPassword(passwordEncoder.encode(account.getPassword()));
            return this.accountRepository.save(account);
        }

        @Override
        public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
            Account account = accountRepository.findByEmail(username)
                    .orElseThrow(() -> new UsernameNotFoundException(username));
            return new User(account.getEmail(), account.getPassword(), authorities(account.getRoles()));
        }

        private Collection<? extends GrantedAuthority> authorities(Set<AccountRole> roles) {
            return roles.stream()
                    .map(r -> new SimpleGrantedAuthority("ROLE_" + r.name()))
                    .collect(Collectors.toSet());
        }
    }
   ~~~