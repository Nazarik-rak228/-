
import 'dart:ffi';
import 'dart:convert';

void main(List<String> arguments) {
statuschowConst(Statuss.on_the_vay);
Day today = Day.monday;

switch (today){
  case Day.monday:
  print("5 пар");
  case Day.tuesday:
  print("4");
   case Day.thurshday:
  print("5 пар");
  case Day.friday:
  print("4"); 
  case Day.wednesday:
  print("5 пар");
  default:
  print("Спать");
}
  String str = "ASAS";
  String sus="😒"; 
  final by=utf8.encode(sus);
  print(by.length);
  print(sus.runes); // кодовые точки, где смайл в системе
  print(sus);
    print(sus.runes.first.toRadixString(16)); 
  print(sus.length);// у смайла 2!
  print(str.runes); //узнаем код каждого символа строки
  print(String.fromCharCode(66));
  
  
  String f ="\u{1f612}";
  print(f);


}
  
 

void statuschow(int status){
  if(status==1){
    print("Обработка");
  }
    if(status==2){
    print("В пути");
  }
    if(status==3){
    print("Готов к выдаче");
  }
    if(status==4){
    print("Выдан");
  }
}
void statuschowConst(status){
  if(status==Statuss.processing){
    print("Обработка");
  }
    if(status==Statuss.on_the_vay){
    print("В пути");
  }
    if(status==Statuss.ready){
    print("Готов к выдаче");
  }
    if(status==Statuss.order_complet){
    print("Выдан");
  }
}
// перечисление набора фиксированных значенИЙ, КАК селект в html\
enum Statuss{
  processing,
  on_the_vay,
  ready,
  order_complet;
}
enum Day{

  monday,
  tuesday,
  wednesday,
  thurshday,
  friday,
  saturday,
  sanday;
}
enum Role{
  admin("gon",1),
  sellet("Done", 2),
  user("shtopany",3);



  final String title;
  final int preority;
  
  const Role(this.title,this.preority);

}
enum svetofor{
  red,yello,green;
  bool get carGo=> this==svetofor.green;// изначальное положение
}
//-------------------------
