# BreakPoint 보기
Shift를 2번 눌려서 `View Breakpoints` 를 들어가서 비활성화

# Http 메서드 실행
*.http 파일을 만들어서 http client를 intellij에서 실행 가능하다
```
### Post 'Hello!'
POST http://localhost:8080
Content-Type: application/json

{
  "text" : "Hello!"
}

---------------------------------

### Get all the messages
GET http://localhost:8080
```

