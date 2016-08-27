def SplitStringToArraryByLength(inputString, substringLength):
    return [inputString[i:i+substringLength] for i in range(0, len(inputString), substringLength)]

loopCount = int(raw_input(""))

for loop in range(loopCount):
    inputText = raw_input("")
    inputLengh = len(inputText)


    outputArray = [inputLengh * '0']
    oddStartIndex = 0
    if inputLengh % 2 == 0:
        oddStartIndex = inputLengh / 2
    else:
        oddStartIndex = (inputLengh + 1) / 2

    for i in range(len(inputText)):
        if i * 2 < len(inputText):
            outputArray[i] = inputText[i * 2]
        else:
            outputArray[i] = inputText[1 + oddStartIndex * 2]
        oddStartIndex = oddStartIndex + 1
    print outputArray


    ## 길이가 홀수: 짝수의 갯수: 전체 길이 + 1 /2
    ## 길이가 짝수: 짝수의 갯수: 전체 길이 /2