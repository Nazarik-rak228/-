import 'dart:math';
import 'dart:io';

void main() {
  while (true) {
    print('Выберите раздел:');
    print('1 - Арифметика');
    print('2 - Сравнения');
    print('3 - Логика');
    print('0 - Выход');
    
    String? choice = stdin.readLineSync();
    
    switch (choice) {
      case '1':
        arithmeticOperations();
        break;
      case '2':
        comparisonOperations();
        break;
      case '3':
        logicalOperations();
        break;
      case '0':
        print('До свидания!');
        return;
      default:
        print('Неверный выбор!');
    }
  }
}

void arithmeticOperations() {
  print('\n Арифметические операции');
  
  try {
    print('Введите первое число:');
    double a = double.parse(stdin.readLineSync()!);
    
    print('Введите второе число:');
    double b = double.parse(stdin.readLineSync()!);
    
    print('\nВыберите операцию:');
    print('+ Сложение');
    print('- Вычитание');
    print('* Умножение');
    print('/ Деление');
    print('~/ Целочисленное деление');
    print('% Остаток от деления');
    print('^ Возведение в степень');
    
    String op = stdin.readLineSync()!;
    
    switch (op) {
      case '+':
        print('$a + $b = ${a + b}');
        break;
      case '-':
        print('$a - $b = ${a - b}');
        break;
      case '*':
        print('$a * $b = ${a * b}');
        break;
      case '/':
        if (b != 0) {
          print('$a / $b = ${a / b}');
        } else {
          print('Ошибка: Деление на ноль');
        }
        break;
      case '~/':
        if (b != 0) {
          print('$a ~/ $b = ${a ~/ b}');
        } else {
          print('Ошибка: Деление на ноль');
        }
        break;
      case '%':
        if (b != 0) {
          print('$a % $b = ${a % b}');
        } else {
          print('Ошибка: Деление на ноль');
        }
        break;
      case '^':
        print('$a ^ $b = ${pow(a, b)}');
        break;
      default:
        print('Неизвестная операция');
    }
  } catch (e) {
    print('Ошибка ввода');
  }
}

void comparisonOperations() {
  print('\n--- Операции сравнения ---');
  
  try {
    print('Введите первое число:');
    double a = double.parse(stdin.readLineSync()!);
    
    print('Введите второе число:');
    double b = double.parse(stdin.readLineSync()!);
    
    print('\nВыберите операцию:');
    print('== Равно');
    print('!= Не равно');
    print('> Больше');
    print('< Меньше');
    print('>= Больше или равно');
    print('<= Меньше или равно');
    
    String op = stdin.readLineSync()!;
    
    switch (op) {
      case '==':
        print('$a == $b = ${a == b}');
        break;
      case '!=':
        print('$a != $b = ${a != b}');
        break;
      case '>':
        print('$a > $b = ${a > b}');
        break;
      case '<':
        print('$a < $b = ${a < b}');
        break;
      case '>=':
        print('$a >= $b = ${a >= b}');
        break;
      case '<=':
        print('$a <= $b = ${a <= b}');
        break;
      default:
        print('Неизвестная операция');
    }
  } catch (e) {
    print('Ошибка ввода');
  }
}
void logicalOperations() {
  print('\n--- Логические операции ---');
  
  try {
    print('Выберите операцию:');
    print('1 - И (&&)');
    print('2 - ИЛИ ()');
    print('3 - НЕ (!)');
    
    String? choice = stdin.readLineSync();
    
    switch (choice) {
      case '1':
        print('Введите первое значение (true/false):');
        bool val1 = stdin.readLineSync()!.toLowerCase() == 'true';
        print('Введите второе значение (true/false):');
        bool val2 = stdin.readLineSync()!.toLowerCase() == 'true';
        
        bool result = val1 && val2;
        print('$val1 && $val2 = $result');
        
        if (result) {
          print('Истина');
        } else {
          print('Ложь');
        }
        break;
        
      case '2':
        print('Введите первое значение (true/false):');
        bool val1 = stdin.readLineSync()!.toLowerCase() == 'true';
        print('Введите второе значение (true/false):');
        bool val2 = stdin.readLineSync()!.toLowerCase() == 'true';
        
        bool result = val1 || val2;
        print('$val1 || $val2 = $result');
        
        if (result) {
          print('Истина');
        } else {
          print('Ложь');
        }
        break;
        
      case '3':
        print('Введите значение (true/false):');
        bool val = stdin.readLineSync()!.toLowerCase() == 'true';
        
        bool result = !val;
        print('!$val = $result');
        
        if (result) {
          print('Истина');
        } else {
          print('Ложь');
        }
        break;
        
      default:
        print('Неверный выбор');
    }
  } catch (e) {
    print('Ошибка ввода');
  }
}