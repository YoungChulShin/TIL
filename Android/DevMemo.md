# Android Studio
폴더 구분
- Package를 만들어서 구분 가능

아이콘 쉽게 만들기: [Link](https://romannurik.github.io/AndroidAssetStudio/)


# Gradle
빌드 종속성
- compile은 사용되지 않으며, implementation이나 api를 주로 사용
    - [Link](https://developer.android.com/studio/build/gradle-plugin-3-0-0-migration?hl=ko)

# 외부 라이브러리 정보
## 라이브러리 버전 확인
- https://javalibs.com/artifact/com.squareup.okhttp3/logging-interceptor

## 라이브러리 종류
retrofit
- 네트워크 통신을 쉽게 할 수 있도록 지원해주는 라이브러리
- [Link](https://square.github.io/retrofit/)

converter-gson
- Java Object의 JSON serialization 지원
- [Link](https://github.com/square/retrofit/tree/master/retrofit-converters/gson)

okhttp3
- Android와 Java를 위한 http client 
- [Link](https://github.com/square/okhttp)

parceler
- JavaObject를 전달할 때 직렬화 과정을 쉽게 도와준다
- [Link](https://github.com/johncarl81/parceler)

circleimageview
- Circle Image 제공
- [Link](https://github.com/hdodenhof/CircleImageView)

picasso
- Image download와 caching library for android
- [Link](https://github.com/square/picasso)

google play service
- 예시: google play map
- base service를 같이 참조한다: play-services-base
- [Link](https://developers.google.com/android/guides/setup)
