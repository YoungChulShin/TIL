for i in range(input()):
    inputText = raw_input()
    outputText = ''
    i = 0
    while (i < len(inputText)):
        if inputText[i] == '%':
            outputText += chr(int('0x' + inputText[i+1:i+3], 16))
            i += 3
        else:
            outputText += inputText[i]
            i += 1

    print(outputText)
