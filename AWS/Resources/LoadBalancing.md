방식
- Round Robin
   - Real 서버로의 Session 연결을 순차적으로 맺어주는 방식
- Hash
   - Client와 Server간에 연결된 Session을 계속 유지해주는 방식
   - Client가 특정 Server로 연결된 이후 동일한 서버로만 연결해주는 구조로 Session에 대한 보장을 제공한다
- Least Connection
   - Session 수를 고려하여 가장 작은 Session을 보유한 서버로 Session을 맺어주는 연결 방식
- Response Time
   - 응답 시간을 고려해 빠른 응답시간을 제공하는 서버로 Session을 맺어주는 방식

ELB (Elastic Load Balancing)
- 수신되는 트래픽을 여러 EC2 인스턴스에 자동배포
- 종류
   - Application Load Balancer (ALB)
      - HTTP/HTTPS 서비스
      - L7 Layer
      - SSL/TLS 암호화 및 프로토콜 사용
   - Network Load Balancer (NLB)
      - TCP
      - L4 Layer
      - 짧은 지연 시간과 초당 수백만개의 요청 처리가 가능하다
   - Classic Load Blancer (CLB)
      - L4(Transport), L3(Network) 에서 동작
      - EC2-Classic 네트워크 내에 구축된 애플리케이션을 대상으로 제공

인터넷 연결 여부
- 인터넷 연결 여부에 따라 아래 2개로 나뉜다
   - External ELB
      - Private IP, Public IP / 인터넷, VPC 내부
   - Internal ELB
      - Private IP / VPC 내부

특징 
- Health Check
   - 실패하면 해당 인스턴스로 트래픽을 전달하지 않는다
- 고가용성
   - 단일 가용 영역 또는 여러 가용 영역에 있는 대상에 걸쳐 트래픽을 자동으로 분산할 수 있다
- SSL Termination
   - ELB에 공인 인증서 또는 ACM(Amazon Certificate Manager)에서 무료로 발급 받을 수 있는 사설 인증서를 등록함으로써, SSL 인증서를 이용한 HTTPS 활용 트래픽 암호화 및 복호화 서비스를 제공할 수 있다