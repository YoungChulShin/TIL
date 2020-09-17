개념
- 사용자의 AWS 계정을 위한 전용의 가상 네트워크
- EC2 같은 인스턴스와 같은 AWS 리소스를 VPC에서 실행시킬 수 있다
- region의 모든 AZ에 적용되며, 각 AZ에 하나이상의 서브넷을 추가할 수 있다

구성 요소
- Private IP
- Public IP
   - 인스턴스가 재 시작되면 새로운 IP가 할당된다
- Elastic IP
   - 고정된 IP 주소

Subnet
- VPC 내부에서 서비스 목적에 따라 IP Block으로 나누어 구분할 수 있다
- Subnet은 IP Block의 모음

CIDR(Classless Inter-Domain Routing)
- VPC를 10.0.0.0/24와 같은 형식으로 지정하면 아래와 같이 서브넷을 구분할 수 있다
   1. 10.0.0.0/25 (10.0.0.0 ~ 10.0.0.127)
   2. 10.0.0.128/25 (10.0.0.128 ~ 10.0.0.255)

NAT (Network Address Translate) Gateway
- 외부에서 알려진 것과 다른 IP 주소를 사용하는 내부 네트워크에서 내부 IP주소를 외부 IP 주소로 변환하는 작업을 수행하는 서비스
- AWS NAT Gateway: [Link](https://docs.aws.amazon.com/ko_kr/vpc/latest/userguide/vpc-nat-gateway.html)
