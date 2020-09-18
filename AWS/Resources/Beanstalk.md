기능
- EC2 인스턴스 유형 변경, 오토 스케일링, ELB 로드 밸런싱을 통해 부하 분산 및 배포까지 자동으로 해서 개발자의 번거로움을 줄여준다
- 애플리케이션과 데이터 외에는 모두 지원해주기 때문에 전문 IT인력을 고정적으로 운영할 수 없는 조직에서도 유리하다

아키텍처
- [설명 링크](https://medium.com/harrythegreat/%EB%82%B4%EA%B2%8C-%EC%95%8C%EB%A7%9E%EB%8A%94-aws-%EC%BB%B4%ED%93%A8%ED%8C%85-%EC%84%9C%EB%B9%84%EC%8A%A4-%EC%B0%BE%EA%B8%B0-bfd2c409273c)
- EC2 + 로드 밸런서 + 오토스케일링 그룹 + 보안 그룹

구조
- 애플리케이션 데이터로 구성 
   - _구성 정보를 통해서 스프링 설정에 대한 의존성을 넣어줄 수 있는듯_
- 한개의 애플리케이션에 2개 이상의 환경을 구성할 수 있다

역할
- Beanstalk를 생성하면 아래 2개의 역할이 생성되는데, 아래와 같다
1. aws-elasticbeanstalk-ec2-role: 
2. aws-elasticbeanstalk-service-role: 빈스톡 서비스가 접근할 수 있는 권한