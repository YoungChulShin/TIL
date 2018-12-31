### Click Event 구현
1. View.OnClickListener 구현 
   ```java
   public class Lab3_3 extends AppCompatActivity implements View.OnClickListener
   ```
2. onClick 함수 구현
   ```java
    @Override
    public void onClick(View v)
    {
        if (v == toggleBtn)
        {
            checkBox.toggle();
        }
    }
   ```
3. Button에 setOnClickListener 설정
   ```java
   toggleBtn.setOnClickListener(this);
   ```
