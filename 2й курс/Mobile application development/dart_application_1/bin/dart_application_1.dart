// import 'package:dart_application_1/dart_application_1.dart' as dart_application_1;

 void main(List<String> arguments) {
//   // String a = "Батылин Иваааааан0";
//   // String a1 ='adsassadasdasdsda';
//   // String a31 ="""dsassadasdasdsda""";
//   // String a122 ='''adsassadasdasdsda''';
//   String str="П"+a.substring(1);// заменяем букву
//   print(str);
//   print(str.toUpperCase());
//   print(str*12);

//   print(str.compareTo(a));//str>a выводит 1
//   print(str.compareTo(str));
//   print(a.compareTo(str));

//   print(str.contains("П"));// есть ли буква?
//   print(str.indexOf("а"));//ищет первый раз этот жлимент в строке и дает его индекс
//   print(str.lastIndexOf("а"));//ищет последний раз этот жлимент в строке и дает его индекс
//   String sasa = "  asdasd asdasd ";
//   print(sasa.trim()); //убирает боковые пробелы у строки
//   print(sasa.trimLeft());
//   print(sasa.trimRight());
//   print(sasa.split(" ")); 
//   print(sasa.split(""));
//   print(sasa.length);

//   print(sasa.isEmpty);
//   print(sasa.isNotEmpty);

//   exe();
  int a = 2;
  int b =4;
  if (a>b){
    print(a);
  }else if(b>a){
    print(b);
  }


  switch(a){
    n2:case 1:
    print("a = 1");
    break;
    case 2:
    print(a);
    continue n2; //переходим в конце на другой кейс
    default:
    print("ЛоХ");
  }
  double v = 9;
  double g = 6;

  double c=v>g? v-g : v/g;///если правда то первый вареан, если нет то второй
  print(c);
}


// void exe(){
//   String sasasa="Я учу джаву";
//   print(sasasa.replaceAll("джаву", "Дарт"));

  