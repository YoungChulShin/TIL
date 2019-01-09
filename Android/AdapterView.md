
### Adapter View 구조
활용 구조
- AdapterView <-(완성) Adpater <-(이용) Activity

종류
- ArrayAdapter: 한 항목에 문자열을 순서대로 나열
   - DataSource는 string[]로 전달
      ```java
        ListView arrayView = (ListView)findViewById(R.id.main_listview_array);
        arrayView.setOnItemClickListener(this);

        arrayDatas = getResources().getStringArray(R.array.location);
        ArrayAdapter arrayAdapter = new ArrayAdapter(this, android.R.layout.simple_list_item_1, arrayDatas);
        arrayView.setAdapter(arrayAdapter);
      ```
- Simple Adapter: 문자열 데이터 여러 개를 나열할 때
   ```java
    ArrayList<HashMap<String, String>> datas = new ArrayList<>();
    HashMap<String, String> map = new HashMap<>();
    map.put("name", "테스트");
    map.put("name", "테스트");
    datas.add(map);

    // Sample
    ListView simpleView = (ListView)findViewById(R.id.main_listview_simple);
    ArrayList<HashMap<String, String>> simpleDatas = new ArrayList<>();
    DBHelper helper = new DBHelper(this);
    SQLiteDatabase db = helper.getWritableDatabase();
    Cursor cursor = db.rawQuery("select * from tb_data", null);
    while (cursor.moveToNext()) {
        HashMap<String, String> map = new HashMap<>();
        map.put("name", cursor.getString((1)));
        map.put("content", cursor.getString((2)));
        simpleDatas.add(map);
    }

    SimpleAdapter adapter = new SimpleAdapter(this, simpleDatas,
            android.R.layout.simple_list_item_2,
            new String[]{"name", "content"},
            new int[]{android.R.id.text1, android.R.id.text2});
    simpleView.setAdapter(adapter);
   ```
- Cursor Adapter: 안드로이드 DBMS 프로그램의 select 결과값을 이용해서 항목을 구성
   ```java
    ArrayList<HashMap<String, String>> simpleDatas = new ArrayList<>();
        DBHelper helper = new DBHelper(this);
        SQLiteDatabase db = helper.getWritableDatabase();
        Cursor cursor = db.rawQuery("select * from tb_data", null);
        while (cursor.moveToNext()) {
            HashMap<String, String> map = new HashMap<>();
            map.put("name", cursor.getString((1)));
            map.put("content", cursor.getString((2)));
            simpleDatas.add(map);
    }

    SimpleAdapter adapter = new SimpleAdapter(this, simpleDatas,
            android.R.layout.simple_list_item_2,
            new String[]{"name", "content"},
            new int[]{android.R.id.text1, android.R.id.text2});
    simpleView.setAdapter(adapter);

    CursorAdapter cursorAdapter = new SimpleCursorAdapter(this,
            android.R.layout.simple_list_item_2,
            cursor,
            new String[]{"name", "content"},
            new int[]{android.R.id.text1, android.R.id.text2},
            CursorAdapter.FLAG_REGISTER_CONTENT_OBSERVER);
    cursorView.setAdapter(cursorAdapter);
   ```


View가 Update 되었을 때 변경 사항 반영 방법
- adapter.nofityDataSetChanged();
