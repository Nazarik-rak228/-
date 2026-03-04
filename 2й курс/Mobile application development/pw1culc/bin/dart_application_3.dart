import 'dart:io';
import 'dart:math';
void main(List<String> arguments) {
  while(true){
    print("=== Приветствуем вас в калькуляторе ===");
  print("Введи операцию: \n 1 - Математические \n 2 - Сравнения \n 3 - Логические ");
  int op = int.parse(stdin.readLineSync()!);

  if (op == 1){
    print("Введи число");
    var x=double.parse(stdin.readLineSync()!);// ! чтобы не могла быть не введенная переменная
    print("Введи знак(+, -, *, /, ~/, %, pow)");
    String option = stdin.readLineSync()!;
    print("Введи число");
    var y=double.parse(stdin.readLineSync()!);
    mathem(x,y,option);

  }else if(op ==2){
    print("Введи число");
    var x=double.parse(stdin.readLineSync()!);
    print("Введи знак(>, <, ==, !=, >=, <=)");
    String option = stdin.readLineSync()!;
    print("Введи число");
    var y=double.parse(stdin.readLineSync()!);
    vs(x,y,option);

  }else if(op ==3){  
    print("Введи число");
    var z=double.parse(stdin.readLineSync()!);// ! чтобы не могла быть не введенная переменная
    print("Введи число");
    var c=double.parse(stdin.readLineSync()!);
    print("Выберите логическую операцию: \n&& - Оба числа положительные? \n|| - Хотя бы одно число равно нулю? \n! - Отрицание числа. ");
    String option = stdin.readLineSync()!;
    logik(z,c,option);

  }

  }
  
}
void mathem(double num1, double num2, String opt) {
  switch(opt) {
    case "+":
      print("Результат: ${num1 + num2}");
      break;
      
    case "-":
      print("Результат: ${num1 - num2}");
      break;
      
    case "*":
      print("Результат: ${num1 * num2}");
      break;

    case "/":
      if (num2 != 0) {
        print("Результат: ${num1 / num2}");
      } else {
        print("Ошибка: деление на ноль!");
      }
      break;
      
    case "~/":
      if (num2 != 0) {
        print("Результат (целочисленное деление): ${num1 ~/ num2}");
      } else {
        print("Ошибка: деление на ноль!");
      }
      break;

    case "%":
      if (num2 != 0) {
        print("Остаток от деления: ${num1 % num2}");
      } else {
        print("Ошибка: деление на ноль!");
      }
      break;

    case "pow":
      print("Результат: ${pow(num1, num2)}");
      break;
      
    default:
      print("Неизвестная операция: $opt");
  }
  print("-----------------------------------------------------------------------------------------");
}
void vs(double num1, double num2,String opt){

    bool result;
  
  switch(opt) {
    case ">":
      result = num1 > num2;
      break;
      
    case "<":
      result = num1 < num2;
      break;
      
    case "==":
      result = num1 == num2;
      break;
      
    case "!=":
      result = num1 != num2;
      break;
      
    case ">=":
      result = num1 >= num2;
      break;
      
    case "<=":
      result = num1 <= num2;
      break;
      
    default:
      print("Неизвестная операция сравнения!");
      return;
  }
  print("Результат:");
  print(result);
  print("-----------------------------------------------------------------------------------------");
}
void logik(double num1, double num2, String opt ){
  switch(opt){
    case "&&":
    bool isPositive = num1 > 0 && num2 > 0;
    print(isPositive);
    break;
    case "||":
    bool isZero = num1 == 0 || num2 == 0;
    print(isZero);
    break;
    case "!":
    print(num1*(-1));
    break;
  }
  print("-----------------------------------------------------------------------------------------");
}