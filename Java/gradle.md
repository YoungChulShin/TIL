# Gradle
### Java 프로젝트 메인 클래스 지정
`build.gradle` 파일에 main class 속성을 추가해준다

```gradle
jar {
    manifest {
        attributes 'Main-Class': 'class name with full package'
    }
}
```
