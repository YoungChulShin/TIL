## Adapter View 구조
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


## Custom Adapter
### 성능 이슈 
- 레이아웃 초기화 성능 이슈: LayoutInflater
   - Adapter가 항목을 구성하려면 레이아웃 XML을 초기화해야 하며 그 작업은 LayoutInflater 클래스의 Inflate() 함수를 사용
   - 하지만 Layout 초기화는 성능상 부담이 되기 때문에 최초로 한번만 해주도록 해야 한다
      - getView() 함수의 두번째 매개변수 conventView가 null일 때만 처리

- 뷰 획득 시 성능 이슈: findViewById
   - findViewById 대상이 되는 뷰들을 묶는 한개의 클래스를 정의해서 관리
      ```java
      public class DriveHolder {
              public DriveHolder(View roort) {
                      typeImageView = (ImageView)findViewByID // ~~
              }
      }

      // 저장
      DriveHolder holder = new DriveHolder(convertView);
      convertView.setTag(holder);

      // 사용
      DriveHolder holder = (DriveHolder)convertView.getTag();

      ```
### 구현
1. VO (Value Object) 클래스 생성
2. ListItem을 기록할 xml 생성
   ```xml
        <?xml version="1.0" encoding="utf-8"?>
        <RelativeLayout xmlns:android="http://schemas.android.com/apk/res/android"
        android:layout_width="match_parent"
        android:layout_height="match_parent">
        <ImageView
                android:id="@+id/custom_item_type_image"
                android:layout_width="wrap_content"
                android:layout_height="wrap_content" />
        <TextView
                android:id="@+id/custom_item_title"
                android:layout_width="wrap_content"
                android:layout_height="wrap_content"
                android:layout_toRightOf="@id/custom_item_type_image"
                android:layout_marginLeft="16dp"/>
        <TextView
                android:id="@+id/custom_item_date"
                android:layout_width="wrap_content"
                android:layout_height="wrap_content"
                android:layout_below="@id/custom_item_title"
                android:layout_alignLeft="@id/custom_item_title"/>
        <ImageView
                android:id="@+id/custom_item_menu"
                android:layout_width="wrap_content"
                android:layout_height="wrap_content"
                android:layout_alignParentRight="true"
                android:src="@drawable/ic_menu"/>
        </RelativeLayout>
   ```
3. Adapter Class 생성
   - ArrayAdapter<T> 를 extends
   - getCount()와 getView()를 Override 해야 한다
   ```java
        public class DriveAdapter extends ArrayAdapter<DriveVO> {
                Context context;
                int resId;
                ArrayList<DriveVO> datas;

                public DriveAdapter(Context context, int resId, ArrayList<DriveVO> datas) {
                super(context, resId);
                this.context = context;
                this.resId = resId;
                this.datas = datas;
                }

                @Override
                public int getCount() {
                return datas.size();
                }

                @NonNull
                @Override
                public View getView(int position, View convertView, ViewGroup parent) {
                if (convertView == null) {
                        LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                        convertView = inflater.inflate(resId, null);
                        DriveHolder holder = new DriveHolder(convertView);
                        convertView.setTag(holder);
                }

                DriveHolder holder = (DriveHolder)convertView.getTag();

                ImageView typeImageView = holder.typeImageView;
                TextView titleView = holder.titleView;
                TextView dateView = holder.dateView;
                ImageView menuImageView = holder.menuImageView;

                final DriveVO vo = datas.get(position);

                titleView.setText(vo.title);
                dateView.setText(vo.date);

                if (vo.type.equals("doc")) {
                        typeImageView.setImageDrawable(ResourcesCompat.getDrawable(
                                context.getResources(), R.drawable.ic_type_doc, null));
                } else if (vo.type.equals("file")) {
                        typeImageView.setImageDrawable(ResourcesCompat.getDrawable(
                                context.getResources(), R.drawable.ic_type_file, null));
                } else if (vo.type.equals("img")) {
                        typeImageView.setImageDrawable(ResourcesCompat.getDrawable(
                                context.getResources(), R.drawable.ic_type_image, null));
                }

                menuImageView.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                        Toast toast = Toast.makeText(context,
                                vo.title + " menu click", Toast.LENGTH_SHORT);
                        toast.show();
                        }
                });

                return convertView;
                }
        }
   ```

4. Activity에 등록
   ```java
   ListView listView = (ListView)findViewById(R.id.custom_listview);
   // 중략
   ArrayList<DriveVO> datas = new ArrayList<>();
   // 중략
   listView.setAdapter(new DriveAdapter(this, R.layout.custom_item, datas));
   ```