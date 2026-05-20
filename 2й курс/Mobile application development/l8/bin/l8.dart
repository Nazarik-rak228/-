
const global = "global";



void main(){
  const localName = "local0";
  void hello(){
    print("hello");

  }
  hello();
  void hello_arrow() => print("hello");
  hello_arrow();
  
  if(true){
    String local_if ="if";
    print(local_if);
    print(localName);
    print(global);
  }
  print(global);
  // print(age);
  saasa(1, 4);
  printFullName("asassa", "sasasas");
  printFull("asdasasd", "asdasdasd");
}
// void sas(){
//   int age = 23;
// }
void saasa(int a, int b)
  {
    int c = a+b;
    print(c);
  }

void printArgs(name,age){
  print("имя $name");
  print("возвраст $age");
}
perintVoidAuto(name,age){
  print("имя $name");
  print("возвраст $age");
}

void printFullName(String name,String surName,[String? lastName] ){
 if(lastName !=null)
 {
    print("$name,#$surName,$lastName");}
  else{
    print("$name,#$surName, ---");
  }    
}
void printFull(String name,String surName,[String? lastName, String? city] ){
 if(lastName !=null)
 {
    print("$name,#$surName,$lastName");}
  else{
    print("$name,#$surName, ---");
  }    
}

void user2({int nami = 4,int asdas = 6}){// по умолчанию
print(nami+asdas);
}


  // обязательные параметры
void user3({required nami ,int asdas = 6}){// по умолчанию и один обязательный первый
print(nami+asdas);
}
 
void dif(int a, int b){
  final d=a;
  print(a*b);
}