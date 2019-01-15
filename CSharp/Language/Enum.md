
## C#에서 Enum 처리

## 1. Enum의 Class 값을 모두 List로 변환
Enum.GetValues(typeof(DeviceType)).Cast<DeviceType>().Select(v => v.ToString()).ToList();

## 2. Enum의 값을 String으로 리턴
Enum.GetName(Typeof(EnumType), EnumValue)

