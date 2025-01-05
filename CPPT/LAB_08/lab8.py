import os
import struct
import sys
import math

def writeResTxt(fName, result):
    with open(fName, 'w') as f:
        f.write(str(result))
def readResTxt(fName):
    result = 0.0
    try:
        if os.path.exists(fName):
            with open(fName, 'r') as f:
                result = f.read()
        else:
            raise FileNotFoundError(f"File {fName} not found.")
    except FileNotFoundError as e:
        print(e)
    return result
    
def float_to_binary(num):
    integer_part, fractional_part = int(num), num - int(num)
    binary_integer_part = bin(integer_part).lstrip('0b') + '.'
    binary_fractional_part = ''
    
    while fractional_part:
        fractional_part *= 2
        bit = int(fractional_part)
        if bit == 1:
            fractional_part -= bit
            binary_fractional_part += '1'
        else:
            binary_fractional_part += '0'
    
    return binary_integer_part + binary_fractional_part

def writeResBin(fName, result):
    with open(fName, 'w') as f:
        roundRes = round(result, 2)
        if roundRes < 0:
            f.write("-" + str(float_to_binary(abs(roundRes))))
        else:
            f.write(str(float_to_binary(roundRes)))
            
def readResBin(fName):
    result = 0.0
    try:
        if os.path.exists(fName):
            with open(fName, 'r') as f:
                result = f.read()
        else:
            raise FileNotFoundError(f"File {fName} not found.")
    except FileNotFoundError as e:
        print(e)
    return result
    
def calculate(x):
        return math.cos(2*x) / (1 / math.tan(3*x-1))
        
if __name__ == "__main__":
    data = float(input("Введіть x: "))
    result = calculate(data)
    print(f"Результат: {result}")
    try:
        writeResTxt("textRes.txt", result)
        writeResBin("binRes.bin", result)
        print("Результат у двійковому форматі: {0}".format(readResBin("binRes.bin")))
        print("Результат у текстовому форматі: {0}".format(readResTxt("textRes.txt")))
    except FileNotFoundError as e:
        print (e)
        sys.exit(1)