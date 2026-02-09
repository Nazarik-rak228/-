import csv
animal = [
    ['Животное', 'Среда обитания'],
    ['Медведь', 'Лес'],
    ['Дельфин', 'Океан'],
    ['Верблюд', 'Пустыня']
]

with open('animals.csv', 'w',newline='',encoding='utf-8') as file:
    writer = csv.writer(file)
    writer.writerows(animal)
    
with open('animals.csv', 'r', encoding='utf-8') as file:
    reader = csv.reader(file)
    for row in reader:
        if row[1] == 'Лес':
            print(row[0])


data = [
    ['Имя', 'Возраст', 'Город', 'Должность'],
    ['Иван', '25', 'Москва', 'Менеджер'],
    ['Анна', '35', 'Санкт-Петербург', 'Инженер'],
    ['Петр', '40', 'Новосибирск', 'Директор'],
    ['Мария', '28', 'Екатеринбург', 'Аналитик'],
    ['Сергей', 'abc', 'Казань', 'Программист']  # Некорректный возраст для теста
]

with open('csv_file.csv', 'w', newline='', encoding='utf-8') as file:
    writer = csv.writer(file)
    writer.writerows(data)
    
try:
    with open('csv_file', 'r', encoding='utf-8') as file:
        reader = csv.reader(file)
        for row in reader:
            try:
                age = int(row[1])
                if age > 30:
                    print(row[0])
            except ValueError:
                pass  
except FileNotFoundError:
    print("Файл не найден")