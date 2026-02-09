import 'dart:io';
void main(List<String> arguments) {
  int a=7;
  double b = 7.2;
  // var name = "oida";// автовыбор
  /// после присвоения переменной тип менять нельзя
  //num = int or double
  // num f =9;
  // String asasai = "sasasasa";
  // bool isRaining = true;

  int a1 = 5_000_000_000_000;


  print(4.compareTo(5)); //сравниваем и ответ -1 ,
  print(5.compareTo(4)); //сравниваем ---  +1 
  print(4.compareTo(4)); //сравниваем = 0

  print((-5).abs());
  print((5.3).round());
  print(5.3.ceil());
  print(5.3.floor());


  print(6.isEven);
  print(6.isOdd);
  print(3.toRadixString(8));///в систему счисления

  print((a1).isNegative);// с минусом?
  print((a1).bitLength);
  print(30.gcd(10)); // общий делитель


  print(3+5);
  print(3-5);
  print(3*5);
  print(3/5);
  print(3%5);
  print(3~/5); // целочисленное
  print(++a);// сначала добавить к а еденичку, потом нарисует
  print(a++);
  print(--a);
  print(a--);

  print(a>b);
  print(a<b);
  print(a>=b);
  print(a== b);
  print(a!=b);
  print(a+=2); // a = a+2

  bool c1 = (4>5) && (5 == 5); // и то и то 
  print(c1);  
  bool c2 = (5<4) || (5>2);// ИЛИ 
  print(c2);

  print(c2 is int);


  /// 
  /// создание минхронного метода
  stdout.write("goqdf");
  // String? aasa = stdin.readLineSync()!; //ворос для того чтобы работало или выводил null , ! чтобы нельзя было ничего не вписать
  // // int dada = int.parse(aasa);
  // final asasassasasasaassaasasasa=5;// как константа но другое и инициализировать потом можно а не сразу, но если оно за мейном то сразу

  // const pi = 3.14;

  // late String nnn4; //не хроним значение Null и инициализировать потом

  var value = "12121";

  var toint =int.parse(value);
  print(toint);


}
