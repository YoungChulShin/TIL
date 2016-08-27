for loop in range(input()):
    inputText = raw_input()
    inputLengh = len(inputText)

    outputArray = ['0'] * inputLengh
    oddStartIndex = 0
    if inputLengh % 2 == 0:
        oddStartIndex = inputLengh / 2
    else:
        oddStartIndex = (inputLengh + 1) / 2

    for i in range(len(inputText)):
        if i % 2 == 0:
            outputArray[i/2] = inputText[i]        
        else:
            outputArray[oddStartIndex] = inputText[i]
            oddStartIndex = oddStartIndex + 1    
    print(''.join(outputArray))