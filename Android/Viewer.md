## View Pager
### 정의
- 드래그를 통해서 화면을 이동할 수 있는 기능 제공

### 사용 코드
- XML 정의
   ```xml
   <android.support.v4.view.ViewPager xmlns:android="http://schemas.android.com/apk/res/android"
       -android:id="@+id/lab2_pager"
       -android:layout_width="match_parent"
       -android:layout_height="match_parent" />
   ```
- Java Code: Adapter를 생성해서 View에 Adapt 시키는 방식
   ```java
   protected void onCreate(Bundle savedInstanceState) {
       super.onCreate(savedInstanceState);
       setContentView(R.layout.activity_lab17_2);
   
       ViewPager pager = (ViewPager)findViewById(R.id.lab2_pager);
       MyPagerAdapter pagerAdapter =
               new MyPagerAdapter(getSupportFragmentManager());
       pager.setAdapter(pagerAdapter);
   }
   
   class MyPagerAdapter extends FragmentPagerAdapter {
       ArrayList<Fragment> fragments;
   
       public  MyPagerAdapter(FragmentManager manager) {
           super(manager);
           fragments = new ArrayList<>();
           fragments.add(new OneFragment());
           fragments.add(new ThreeFragment());
       }
   
       @Override
       public  int getCount() {
           return 2;
       }
   
       @Override
       public  Fragment getItem(int position) {
           return fragments.get(position);
       }
   }
   ```

## RecyclerView
정의
- ListView와 기능이 비슷하지만, 더 많은 기능을 제공해 준다
구성
- Adapter: RecyclerView 항목 구성 (필수)
- ViewHolder: 각 항목 뷰의 재활용을 목적으로 View Holder 역할 (필수)
- LayoutManager: 항목의 배치 (필수)
- ItemDecoration: 항목 꾸미기
- ItemAnimation: 아이템이 추가, 제거, 정렬 될 때의 애니메이션 처리

개발 순서
1. RecyclerView 생성
   ```xml
   <android.support.v7.widget.RecyclerView
    xmlns:android="http://schemas.android.com/apk/res/android"
    android:id="@+id/lab3_recycler"
    android:layout_width="match_parent"
    android:layout_height="match_parent" />
   ```
2. ViewHolder Class 생성
   ```java
    private class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView title;
        public  MyViewHolder (View itemView){
            super(itemView);
            title = (TextView)itemView.findViewById(android.R.id.text1);
        }
    }
   ```
3. Adapter Class 생성
   ```java
   private class MyAdapter extends RecyclerView.Adapter<MyViewHolder> {
        private List<String> list;
        public  MyAdapter(List<String> list){
            this.list = list;
        }

        @NonNull
        @Override
        public MyViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
            View view = LayoutInflater.from(viewGroup.getContext()).inflate(android.R.layout.simple_list_item_1, viewGroup, false);
            return new MyViewHolder(view);
        }

        @Override
        public void onBindViewHolder(@NonNull MyViewHolder myViewHolder, int i) {
            String text = list.get(i);
            myViewHolder.title.setText(text);
        }

        @Override
        public int getItemCount() {
            return list.size();
        }
    }
   ```

4. Recycler View에 Set
   ```java
    recyclerView.setLayoutManager(new LinearLayoutManager(this));
    recyclerView.setAdapter(new MyAdapter(list));
    recyclerView.addItemDecoration(new MyItemDecoration());
   ```

5. Decoration 설정 (옵션)
   ```java
    class MyItemDecoration extends RecyclerView.ItemDecoration {
        @Override
        public void getItemOffsets(@NonNull Rect outRect, @NonNull View view, @NonNull RecyclerView parent, @NonNull RecyclerView.State state) {
            super.getItemOffsets(outRect, view, parent, state);
            int index = parent.getChildAdapterPosition(view) + 1;
            if (index % 3 == 0) {
                outRect.set(20,20, 20, 60);
            } else {
                outRect.set(20,20, 20, 20);
            }

            view.setBackgroundColor(0xFFECE9E9);
            //ViewCompat.setElevation(view, 20.0f);
        }
    }
   ```