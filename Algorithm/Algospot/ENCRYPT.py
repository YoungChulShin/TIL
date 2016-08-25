def SplitStringToArraryByLength(inputString, substringLength):
    return [inputString[i:i+substringLength] for i in range(0, len(inputString), substringLength)]

loopCount = int(raw_input(""))

for loop in range(loopCount):
    inputText = raw_input("")
    outputArray = [len(inputText) * '0']
    #oddStartIndex = len(inputText) + 1
    oddStartIndex = 0
    for i in range(len(inputText)):
        if i * 2 < len(inputText):
            outputArray[i] = inputText[i * 2]
        else:
            outputArray[i] = inputText[1 + oddStartIndex * 2]
        oddStartIndex = oddStartIndex + 1
    print outputArray