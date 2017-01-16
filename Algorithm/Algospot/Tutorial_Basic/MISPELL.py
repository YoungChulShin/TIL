for i in range(input()):
    inputArray = raw_input().split(" ")
    print(str(i + 1) + " " +  inputArray[1][:int(inputArray[0]) - 1] + inputArray[1][int(inputArray[0]):]) 