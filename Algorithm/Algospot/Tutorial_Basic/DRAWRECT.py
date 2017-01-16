loopCount = int(raw_input(""))

rectArray = [[0 for col in range(2)] for row in range(4)]
outputArray = [[0 for col in range(2)] for row in range(loopCount)]

for loop in range(loopCount):
    for row in range(0, 3, 1):
        inputTextArray = raw_input("").split(" ")
        rectArray[row][0] = int(inputTextArray[0])
        rectArray[row][1] = int(inputTextArray[1])
    
    for col in range(0, 2, 1):
        if rectArray[1][col] == rectArray[0][col]:
            rectArray[3][col] = rectArray[2][col]
        elif rectArray[1][col] == rectArray[2][col]:
            rectArray[3][col] = rectArray[0][col]
        else:
            rectArray[3][col] = rectArray[1][col]
    
    outputArray[loop][0] = rectArray[3][0]
    outputArray[loop][1] = rectArray[3][1]

for loop in range(0, loopCount, 1):
    print (str(outputArray[loop][0]) + ' ' + str(outputArray[loop][1]))