
// // import 'dart:ffi';

// // class Person {
// //   String name; /// просто базавыйй класс
// //   int? age;
  
// //   Person(this.name,this.age);// просто конструктор
// //   Person.person(this.name, int age2){
// //     String name = "namea;;";
// //     int age = age2;
// //   }
    
// //    // это именнованый конструктор, для чего нужно - потом
  
// //   void display (){
// //     print("name $name age $age" );
// //   }
// //    // именнованый надо если нужно несколько конструкторов 
// //   // НАДО БУДЕТ ПРО ФАБРИЧНЫЙ КОНСТРУКТОР УЗНАТЬ БОЛЬШЕ, ниче не понял
// //   // местные гет конструкции надо понять и сетеры тоже 
// // }
// // void main() {
// //  Person tom = Person("Tomas", 12);  
// //  tom.display();
// //  Persona sasha = Persona("Alexandra ");
// // }


// // class Persona{
// //   late String naming;
// //   Persona(String name){
// //   if(name != "admin") this.naming = name;
// //   else this.naming = "Кусок АДмина";
// // }
// // }

// class Settings{
//   static final Settings _instance = Settings._internal();

//   factory Settings() {
//     return _instance;
//   }
//   Settings._internal();
// }

// class Rectangle{
//   double width;
//   double height;

//   Rectangle(this.width,this.height);
//   double area() => width * height;
//   double perimeter() => 2 * (width * height);
// }
//гтереты 

// class Account{
//   double _balance;

//   Account(this._balance);

//   double get balance => _balance; //геттер

//   set balance2(double value) {
//     if (value < 0) {
//       throw ArgumentError('баланс не может быть отрицательным');
//     }
//     _balance = value;
//   }
// }
// //void main(){
// //  Person tom=Person(34, "Анна");
// //  print(tom.name);
// //  print(tom.age);
// //Person per=Person(name:"ggg");
// //print(per.name);
// //print(per.age);

// //Person per1=Person

// //Rectangle rect=Rectangle(4, 5);
// //print (rect.area);

// //Account ac=Account(-1000);
// //ac._balance=-1000;
// //print(ac.balance);
// //}

// class Person{
//   late String name;
//   late int age;

// // Person(String name, int age)
//   Person(this.name);
//   void setAge(int age){
// //    if(name !="admin") this.name = name;
// //    else this.name="Неизвестно";

//     if(age >0 && age<111) this.age=age;
//     else this.age=18;
//   }


  
//   void display()=>print("$name,$age");
// }

// void main(){
//   Person pr=Person("Tom");
//     Person pr1=Person("Tom");
//   pr.setAge(67);
//   pr.display();
// }

// import 'dart:async';
// import 'dart:math';
// import 'dart:mirrors';

// class Animal{
//   String name; /// просто базавыйй класс
//   String nick;
//   int age;
//   Animal(this.name,this.nick,this.age);// просто конструктор
//   void eat(){
//     print("$name am am am!");
//   }
// }
// class Dog extends Animal{
//   String breed;
//   Dog(String name,String nick, int age,this.breed) : super(name,nick,age);

//   @override
//   void eat(){ // переопределяем метод из родительского, у нас уже наследование и полиморфизм!
//     print("$name mmmmm nam nam nam!");
//   }
//   void tapok(){
//     print("$nick принес вам тапочки)");
//   }
// }

// abstract class Human{
//   int age;
//   Human(this.age);
//   void info();
//   void walk();



// }
// class Persona1 implements Human{
//   String name;
//   String job;
//   int age;
//   Persona1(this.name, this.job,this.age);
//   @override
//   void info(){
//     print('$name, $job');
//   }
//   @override
//   void walk() {
//     print('$name идет работать, он/она $job');
//   }
// }
// void main(){
//   // var bobik = Dog("Боб",'Бобичек' , 4,"злюкен");
//   // bobik.eat();
//   // bobik.tapok();
//   // var mira = Cat("Mira", "mirka", 12, "Британская", "Вислоухая");
//   // mira.eat();
//   // var recta = Rect("");
//   // recta.show();
//   var Sania = Persona1("Александра","ПростиУтка",19);
//   Sania.info();
//   Sania.walk();
// }
// // разница между extand и  emplements=: =ext: копируем параметры, два разных класса,  emp: это все , оба класса работают как один!
// class Cat extends Animal{
//   String breed;
//   String ushki;
//   Cat(String name,String nick, int age,this.breed, this.ushki):super(name,nick,age);

//   @override
//   void eat(){
//     print("nam");
//   }


// }
// // Абстарктный класссс!, поехали, наше любимое
// abstract class Shepe{
//   void show(){}  надо все переопределить через @override обязательно!
//   void area(){} просто класс с функциями без реализации 


// }
// class Rect extends Shepe{
// // @override
//   String? name;

//   Rect(this.name);

//   @override
//   void show(){  
//     print("object");
//   }
//   @override
//   void area(){

//   }
// // }

// class Person{
//   final String name;
//   int age;
//   static const int pens = 60; // если есть по умолчанию, можно не инициализировать сразу
//   // ее нельзя иниц,ведь статические нужны чтобы сделать общедоступную в классе , кней обращатся через класс, а не экземпляра класса.
//   // статическая функция тоже будет относится к всему классу, а не к экземпляра
//   Person(this.name,this.age);
//   //  конструктор тоже может быть константой, то есть потом значения экземпляра незя менять
//   // но тогда надо будет сделать Final атрибуты 
//   static run(Person s){
//     print("$s ходит на работу");
//   }
//   void printinfo(){
//     print("$name");
//   }
//   void check(){
//     if(age > pens){
//       print("пора на пенсию");
//     }
//     else{
//       int das = pens - age;
//       print("до пенсии осталось: $das");
//     }
//   }
// }

// void main(){
//   Person persin = Person("Boba",31);
//   persin.printinfo();
//   persin.check();
//   print("пенсионный возвраст ${Person.pens}");
//   print(Person.run(persin));

// }
// class Person{
//   String name;
//   Person(this.name);
//   void info()=> print("$name");
// }
// class Eamployee extends Person{
//   String company;
//   Eamployee(super.name, this.company);
//   @override
//   String get name => super.name;
//   @override
//   void info(){
//     print("$name работает в компании $company");
//   }
// }
// class Student extends Person{
//   String university;
//   Student(super.name, this.university);
//   @override
//   String get name => super.name;
//   @override
//   void info(){
//     print("студент $name учится в $university");
//   }
// }
// void main(){ // мы в персон засунули экземпляр класса эмплое, это неявное преоразование, оно надо чтобы брать шаблон, и переносить его приколы в дочку
// //   Person pers =Eamployee("Леха", "РКН");
// //   pers.info();

// //   Person pers2 = Student("Ваня", "МПТ");
// //   pers2.info();
// // }
// // интерфейс - класс, который шаблон для других классов
// // прИМЕСЬ?
// // mixin вместо extent чтобы не обязательно все параметры родителя \
// // mixin A{}// бакалея замешать
// // mixin B{}// молочка взбить 
// // class C with A,B{}// блины
// // примесь может убрать дублирование,
// mixin D1{
//   void zames(){
//     print("Надо замешать ");
//   }
// }
// mixin D2{
//   void zames2(){
//     print("Надо Взбить  ");
//   }
// }
// class D3 with D1,D2{
//   @override
//   void zames2(){
//     super.zames2();
//   }
//   @override
//    void zames(){
//     super.zames();
//   }
// }
// void main(){
//   D3 sas = D3();
//   sas.zames();
// }
// миксеры еще называют зверьми 

// mixin class A{
//   String na= "XYU";
//   int age = 18;
//   void hi(){
//     print("Hi, $na");
//   }
// }
// void main(){
//   A sa = A();
//   sa.na = "PepeShni";
//   sa.hi();
// // }
// abstract class Bird{
//   String name;
//   String eat;
//   Bird(this.name, this.eat);
// }

// mixin Fly{
//   void flying(){
//     print("А Я УМЕЮ ЛЕТААААТЬ");
//   }
// }
// mixin Swim{
//   void swiming(){
//     print("А Я УМЕЮ плавать");
//   }
// }

// class Duck extends Bird with Swim,Fly {
//   Duck(super.name,super.eat);
//   @override
//   void flying() {
//     // TODO: implement flying
//     super.flying();
//   }
//   @override
//   void swiming() {
//     // TODO: implement swiming
//     super.swiming();
//   }
// }
// void main(){
//   Duck sasas = Duck("Макдак","20 рыбов");
//   sasas.flying();
//   sasas.swiming();
//   String eat =sasas.eat; 
//   print("$eat");
// }


//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\Джинерики 
// class User{
//   var id;// вот так плохо 
//   User(this.id);
// }
// void main(){
//   User a = User('id');
// }

// class User<S>{
//   S id;// вот так  надо! 
//   User(this.id);
// }
// void main(){
//   User a = User('id');
// }
class Account{
  int money;
  int id;
  Account(this.money,this.id);
}

class Tr <T extends Account>{
  T fromnum;
  T collect;
  int mon;

  void TranspPR(){
    if( fromnum.money >= mon){
      fromnum.money -=mon;
      collect.money+=mon;

    } 
    else{
      print("Лох!");

    }
  }
}
void main(){
  Account a = Account(11110, 1);
  Account d = Account(122222, 2);
  Tr trans = Tr<Account>(a,d,100);
}