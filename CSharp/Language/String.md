###C#에서 숫자값에 천 단위 구분자 추가
- #,##0
>int a = 1000
>System.Console.WriteLine(a.ToString(#,##0))
>result: 1,000