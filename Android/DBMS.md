## SQLite
### SQLiteDatabase class
- 샘플 코드
   ```java
   SQLiteDatabase db = openOrCreateDatabase("sampledb", MORE_PRIVATE, null);
   ```
- execSQL(String sql) : insert, update 등 select문이 아닌 SQL 수행
   ```java
   DBHelper helper = new DBHelper(this);
   SQLiteDatabase db = helper.getWritableDatabase();
   db.execSQL("insert into tb_memo (title, content) values (?,?)",
            new String[]{title, content});
   db.close();
   ```
- rawQeury(String sql, String[] selectionArgs, Object[] bindArgs): select SQL 수행
   - 리턴 값이 Cursor
      - moveToNext()
      - moveToFirst()
      - moveToLast()
      - moveToPrevious()
   ```java
   while (cursor.moveToNext())
   {
       titleView.SetText(cursor.getString(0));
   }
   ```

### SQLiteOpenHelper class
- 데이터베이스 관리 목적의 Class
- SQLiteOpenHelper는 추상클래스이므로 서브 클래스를 만들어서 사용해 야한다
- 샘플 코드
   ```java
   public class DBHelper extends SQLiteOpenHelper {
    public static final int DATABASE_VERSION = 1;
    public DBHelper(Context context) {
        super(context, "memodb", null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String memoSQL = "create table tb_memo " +
                "(_id integer primary key autoincrement," +
                "title," +
                "content)";
        db.execSQL(memoSQL);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        if (newVersion == DATABASE_VERSION) {
            db.execSQL("drop table tb_memo");
            onCreate(db);
        }
    }
   }

   ```



## Realm
특징
- ORM 제공
- SQLite보다 빠르다

사용 방법
1.  Proejct gradle에 dependency 추가
      ```java
      dependencies {
           classpath 'com.android.tools.build:gradle:3.2.1'
           classpath 'io.realm:realm-gradle-plugin:2.2.0'
      ```
2. Module gradle에 appy 추가
      ```java
      apply plugin: 'com.android.application'
      apply plugin: 'realm-android'
      ```

3. Model 객체 생성
      ```java
      public class DataModel extends RealmObject {
        public String title;
        public  String content;
      }
      ```
4. Realm 초기화 및 사용
      ```java
      Realm.init(this);
        Realm mRealm = Realm.getDefaultInstance();
        mRealm.executeTransaction(new Realm.Transaction() {
            @Override
            public void execute(Realm realm) {
                DataModel model = realm.createObject(DataModel.class);
                model.title = title;
                model.content = content;
            }
        });
      ```