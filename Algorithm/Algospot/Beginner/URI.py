for i in range(input()):
    translateText = raw_input()
    translateDic = {'%20' : ' ', '%21' : '!', '%24' : '$', '%25' : '%', '%28' : '(', '%29' : ')', '%2a' : '*'}

    for key, value in translateDic.iteritems():
        translateText = translateText.replace(key, value)

    print(translateText)
