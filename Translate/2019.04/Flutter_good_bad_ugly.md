## **The good**

You do know the movie ‘[The Good, the Bad and the Ugly](https://en.wikipedia.org/wiki/The_Good,_the_Bad_and_the_Ugly)’, right?

1. The fact that Flutter does its own UI drawing rather than being a wrapper around the platform-specific native components has both pros and cons. 
The pro is that if something is rendered in some way on your test iPhone with iOS 12, for example, it should be rendered in exactly the same way, not only on any other iOS version but also on any Android phone. 


With React Native or Xamarin, the UI components have a number of properties that are only supported in one platform or the other, or maybe they are supported but translated in slightly different ways to their native counterparts behind the scenes. 

This means that you either need to test on a lot of devices and OS versions (and potentially write platform specific code to fix some situations), or just know that it might look broken (or at least different) for some users. Your app might even crash if you use an attribute or a feature that’s not supported on a specific OS version. With Flutter you will be much safer (at least for the UI part of the app). You should still check the app on multiple devices, especially if you use third party plugins that do map to underlying platform-specific native components. This will be the case if you use things like audio/video, push notifications, in-app billing etc.). The negative side of this approach is covered in the next section of the article.

사실 Flutter가 기본 플랫폼별 구성요소를 감싸는 것이 아니라 자체 UI를 그리는 것은 장단점이 있습니다. 장점은 예를 들어서 무언가를 여러분의 iOS 12버전 아이폰에서 렌더링 한다고 할 때, 이것은 다른 iOS 버전 뿐 아니라 안드로이드 폰에서도 동일하게 렌더링 되어야 합니다. React Native 또는 Xamarin에서 제공하는 UI 컴포넌트들은 다수의 속성이 특정 플랫폼에서만 지원되거나 또는 모든 플랫폼을 지원한다고 해도 내부적으로 플랫폼에 따라 약간 다른 방식으로 변환됩니다. 이는 여러분이 다양한 장치와 OS 버전을 대상으로 테스트 해야하는 것을 의미하며  (일부 상황을 해결하기 위해 플랫폼 별 코드를 작성해야 할 수도 있습니다) 일부 사용자에게는 화면이 깨져 (또는 조금 다르게)보일수도 있다는 것을 알고 있어야 합니다. 특정 OS 버전에서 지원되지 않는 속성이나 기능을 사용하면 앱이 다운될 수 도 있습니다. 특히 플랫폼별 고유 구성요소에 대응되는 서드파티 플러그인을 사용한다면, 다양한 장치에서 앱을 확인해야 합니다. 여러분의 앱이 오디오/비디오, 푸쉬 알람 또는 앱 내 결제등을 사용하면 이 경우에 해당될 수 있습니다. 이러한 방법의 단점에 대해서는 다음 섹션에서 다루겠습니다. 

2. 'Hot reloading' is just too useful, it’s a developer’s dream come true: ⌘+S in the editor, and the app reloads in a sec on the sim! Goodbye to the endless build / wait / run / wait / test / start-over endless process. In reality you still need to rebuild when you change assets and plugins, change something in the navigation, state initialisation or logic, but most UI changes are applied immediately while the app is running. For apps that are UI-heavy, this is where you’d dedicate most of your time.

'Hot reloading'은 너무 유용한데, 에디터에서 ⌘+S를 누르면 시뮬레이터에서 앱이 바로 다시 로드 됩니다. 개발자의 꿈이 실현되었습니다! 빌드/대기/실행/대기/테스트/다시시작이라는 끝이 없는 프로세스여 안녕. 사실 여전히 자산이나 플러그인을 변경하거나 탐색, 상태 초기화 또는 로직과 관련된 것을 변경한다면 다시 빌드를 해야하지만, 대부분의 UI 변경사항은 앱 실행 중에 바로 반영됩니다. UI-heavy한 앱의 경우, 대부분의 시간이 여기에 할애됩니다. 

3. I like the overall principle of small reusable components that react to a change in the ‘state’, which is also one of React’s and React Native’s core ideas. Reactive apps can also be developed in pure iOS and Android development of course, but it’s easier and more natural with Flutter (and RN). This is because it’s at the core of the technology, rather than something that’s provided by third-party libs and implemented in dozens of different ways.

React 's와 React Native의 핵심 아이디어 중 하나 인 '국가'의 변화에 ​​반응하는 작은 재사용 가능한 구성 요소의 전반적인 원리가 마음에 든다. 리 액티브 앱은 순수한 iOS 및 Android 개발 과정에서도 개발 될 수 있지만 Flutter (및 RN)를 사용하면 더 쉽고 자연 스럽습니다. 타사 라이브러리에서 제공되고 수십 가지 방법으로 구현되는 것이 아니라 기술의 핵심에 있기 때문입니다.

4. Dart is simple but a powerful and complete language, comparable to Swift, Kotlin or Java. Asynchronous programming with async/await/Future is a breeze, and it also feels complete and consistent (I can’t say the same about JavaScript).
Dart는 간단하지만 Swift, Kotlin 또는 Java에 필적하는 강력하고 완벽한 언어입니다. async/await/Future를 이용한 비동기 프로그래밍은 매우 간편하며, 완벽하고 일관성있습니다. (I can’t say the same about JavaScript).


5. Flutter and Dart have built-in support for both unit testing for logic, and widget testing for UI/interactions. For example, you can send tap and scroll gestures, find child widgets in the widget tree, read text, and verify that the values of widget properties are correct. The official docs does a good job at clearly presenting what’s available. This article by Devon Carew shows how the Flutter plugin makes it all well integrated into your code editor.
Flutter와 Dart는 로직의 단위 테스트와 UI/상호작용을 위한 위젯 테스트를 모두 기본적으로 지원합니다. 

Flutter와 Dart는 로직에 대한 단위 테스트와 UI / 상호 작용에 대한 위젯 테스트를 기본적으로 지원합니다. 예를 들어 탭 및 스크롤 제스처를 보내고 위젯 트리에서 하위 위젯을 찾고 텍스트를 읽고 위젯 속성의 값이 올바른지 확인할 수 있습니다. 공식 문서는 사용 가능한 것을 명확하게 제시하는 데 훌륭한 역할을합니다. Devon Carew가 작성한이 기사에서는 Flutter 플러그인을 사용하여 코드 편집기에 모든 기능을 통합하는 방법을 보여줍니다.


6. I love the built-in support for themingevery aspect of the app’s UI. The most difficult part in creating the light and dark themes of my app was actually picking the right colour (I created just two, but could have created 10 with the same approach). In terms of code, it’s just a few lines (basically set the theme property of the root MaterialApp object — see this for a full example).

Bonus: This is an advantage of any cross-platform technology in reality, not just Flutter, but I’m still going to mention it: creating an app for both platforms at the same time makes it much easier to keep them aligned at all times. With the traditional development process, you might launch both platforms at the same time and with feature parity but then after a short while you realise that one platform is performing better than the other (in terms of downloads, sales, ad revenues, …). Then you start cutting costs on the other, which means that one is partially left behind.