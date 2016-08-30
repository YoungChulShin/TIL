for i in range(input()):
    targetUseValue = int(raw_input())
    actualUseValueArray = raw_input().split(" ")
    sumOfActualUseValue = 0
    for j in range(len(actualUseValueArray)):
        sumOfActualUseValue += int(actualUseValueArray[j])

    if sumOfActualUseValue <= targetUseValue:
        print("YES")
    else:
        print("NO")
        
