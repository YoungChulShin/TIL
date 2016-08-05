##SQL Lite

##UWP에서 사용 방법
- Netget Package에서 'sqlite-net-pcl' 항목 설치

##DB 생성
- SQLite connection을 만들어서 생성한다. 
- >string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
- >new SQLiteConnection(dbPath);

##Table 생성
- dbconnection.CreateTable<Type>();

##Data 관리
- Update: dbConnection.