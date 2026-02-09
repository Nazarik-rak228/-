import csv

import json

test=[
    ['Имя', 'Возраст', 'Город'],
    ['Анна', 30, 'Москва'],
    ['Михаил', 24, 'Питер'],
]

with open('text_csv', 'w',newline='',encoding='utf-8') as file:
    writer = csv.writer(file)
    writer.writerows(test)

with open('text_csv', 'r', encoding='utf-8') as file:
    reader = csv.reader(file)
    for row_num, row in enumerate(reader,1):
        print(f'Строка {row_num}: {row}')
        print(type(row))

with open('text_csv', 'r', encoding='utf-8') as file:
    reader = csv.DictReader(file)
    for row in reader:
        print(f'{row['Имя']}, Возраст: {row['Возраст']}, Город: {row['Город']}')
        print(f"  Тип: {type(row)}") 


employees = [
    {'Имя': 'Анна', 'Возраст': '28', 'Город': 'Москва', 'Должность': 'Разработчик'},
    {'Имя': 'Иван', 'Возраст': '34', 'Город': 'Санкт-Петербург', 'Должность': 'Менеджер'},
    {'Имя': 'Мария', 'Возраст': '25', 'Город': 'Казань', 'Должность': 'Дизайнер'}
]
OUTPUT_FILE="csv.textik" # constanta

fieldnames=['Возраст','Имя','Город','Должность'] # хотим поменять на такою шапку(просто местами)

with open(OUTPUT_FILE,'w',newline='',encoding='utf-8') as file:
    writer=csv.DictWriter(file,fieldnames=fieldnames) # подключаем ту идею с сменой порядка в заголовке
    writer.writeheader() # заголовки
    writer.writerows(employees) # строки


emp={'Имя': 'Анна', 'Возраст': '28', 'Город': 'Москва', 'Должность': 'Разработчик'}
with open('test2','w',encoding='utf-8') as file:
    json.dump(emp,file,ensure_ascii=False,indent=4) # преобразует джисон в питон, false чтобы не превращались никуда символы 
