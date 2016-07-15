#Name: MERCI
#URL: https://algospot.com/judge/problem/read/MERCY
#Problem: The administrators of algospot.com are so merciful, that they prepared really, really easy problem to prevent contestants from frustration.
#Input: Input contains just one positive integer N(N <= 10).
#Output: Print N lines. Every line should contain 'Hello Algospot!'(quotation marks for clarity) and nothing else.

def IsInteger(s):
    try:
        int(s)
        return True
    except:
        return False

loopCount = raw_input("")
while IsInteger(loopCount) == False or int(loopCount) > 10 or int(loopCount) <= 0:
    loopCount = raw_input("")

for i in range(0, int(loopCount), 1):
    print("Hello Algospot!")

