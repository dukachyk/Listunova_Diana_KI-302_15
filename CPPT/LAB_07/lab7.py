import sys
# Вводимо розмір квадратної матриці
rows_num = int(input("Введіть розмір квадратної матриці: "))

# Перевіряємо чи розмір матриці більший або дорівнює 3
if rows_num < 3:
    print("Розмір квадратної матриці має бути більшим або дорівнювати 3, щоб продемонструвати, що програма працює відповідно до завдання.")
    sys.exit(1)
    
lst = []

# Вводимо символ-заповнювач
filler = input("Введіть символ-заповнювач: ")

# Основна програма, що генерує зубчастий список, який відповідає варіанту
for i in range(rows_num):
    lst.append([])
    for j in range(rows_num):
        if len(filler) == 1:
            if i==0 or j==0 or i==(rows_num-1) or j==(rows_num-1):
                lst[i].append(ord(filler))
                print(" ", end=" ")
            else:
                lst[i].append(ord(filler))
                print(chr(lst[i][j]), end=" ")
        elif len(filler) == 0:
            print("Не введено символ-заповнювач")
            sys.exit(1)
        else:
            print("Забагато символів-заповнювачів")
            sys.exit(1)
    print()