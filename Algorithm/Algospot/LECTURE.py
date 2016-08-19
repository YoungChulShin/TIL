
def SplitStringToArraryByLength(inputString, substringLength):
    return [inputString[i:i+substringLength] for i in range(0, len(inputString), substringLength)]

loopCount = int(raw_input(""))

for loop in range(loopCount):
    inputText = raw_input("")
    inputTextArray = SplitStringToArraryByLength(inputText, 2)

    ouputSortedArray = [inputTextArray[0]]
    for i in range(len(inputTextArray)-1):
        for j in range(len(ouputSortedArray)):
            if ouputSortedArray[j] > inputTextArray[i+1]:
                ouputSortedArray.insert(j, inputTextArray[i+1])
                break
            if j == len(ouputSortedArray) - 1:            
                ouputSortedArray.append(inputTextArray[i+1])
    print(''.join(ouputSortedArray))
     