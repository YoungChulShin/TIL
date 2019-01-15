### Track 정보
- Part 1: Track 5
- 오후 1
  - Track2 
  - Track1
  - Track3

- 오후 2
   - Track3
   - Track5
   - Track4


### Track 1
Cloud Scale Anaytics
- Ingest
   - Data Factory
- Store
   - Azure data Lake Storgaate
- Prep
   - Azure DataBricks
- Serve
   - SQL Server
- Reporting
  -Power BI

### Track 2 - 개발자 중심의 클라우드 운영 방안

### Track 3 - Data Bricks
99% company struggle with AL
- data is not ready for analytics
   - brings data reliability and performance to cloud data
   - 데이터 처리: Data -> Data Lake -> Analysis
- a zoo of new ML frameowrk   
- data sience & enginerring silos

과정
- Azure Datastore -> Azure databricks -> Power BI

Time
- 일반적으로 6-9mont * 3
- Azure DataBricks: 4-6weeks * 3
(discovery, experiment, production)

### Track 4 -클라우드 중심의 Digital Transform 여정
MES비지니스를 Cloud 환경으로 변경
- AI를 통해서 Fault를 빨리 Detect 한다고 해도, Repaire Process가 이를 따라가 줄 수 있는지도 중요하다

중요한 것은 만드는 것보다 유지보수와 운영이다. 

### Track 5- 글로벌 파트워와 함께하는 Azure의 혁신과 미래(패널토의)

### Track 6 - Azure Function
Serverless 컴퓨팅
- 애플리케이션을 단일 기능의 클러스터로 분리
- 자동으로 관리되는 컴퓨팅 리소스

특징
- 서버의 추상화
- 필요시 확장
- 사용한 만큼 비용 지불
   - CPU 사용시간 + 메모리 사용량

시나리오
- 실시간 스트리밍
- 시간 기반 프로세싱
- 모바일 앱 백엔드
- 실시간 챗봇

Azure Function
- MS의 Serverless 
- AWS의 Lamda

동작
- Input & Output
- __트리거를 통해서 동작__

기타
- Azure Blob Storage에 정적 사이트 업로드 가능

기존에 Client와 Appserver 사이에 연결을 중간에 SignalR이 존재
_Rest API와 Serverless의 차이_??

### Track 7 -  OSS DB on Azure
Popularity
- 최상위: Oracle, MySQL, MSSQL
- 급성장: PostgreSQL, MariaDB(점유율이 많이 올라감)

__OSS DB__
증가 사유
- 무료 비용
- Community를 통해서 활발하게 개선을 하고 있다

powerBI와 연동이 가능



__NO SQL__
Azure CosmosDB


1 RU = 1 read of 1KB read

### Track 8 - Azure + Power BI

Long Term Storage
- Data Lake Store
- Szure Storage
- Cosmos DB
- SQL DB

Data Processing
- Data Lake Analytics
- Azure Databricks
- HDINSIGHT

Serving Storage
- Cosmos DB
- SQL DB
- SQL DW
- Azure Analysis Service

제품
- PowerBI Report Server
   - OnPremise 지원
   - Report 서버
   - SQL Server에 배포가 필요한데, Enterprise 버전이 필요
- Power BI Embeded
   - 특정 제품에 넣을 때 

효과
- 클라우드 환경에서는 실사긴으로 처리 가능
- Dashboard를 통해서(not ML) 대시보드 제공 가능


### Track 9 - Energy와 Utility 산업이 바라보는 인공지능의 미래와 실제
data를 사용가능한 상태로 만드는 것이 주요 과제


Lennox 사례
- ioT 디바이스의 데이터로부터 실패할때의 데이터 패턴을 분석
   - 15 devices 
   - 2,000,000 samples
   - 6시간트레이닝
   - 65% 정확도

Sensor -> Azure Blob Storgage -> Azure Databricks
   - 10billion
   - 95%

