import 'dart:async';

void main(){
  print(mu(2,3));


  
  Function fun1=mu1;// приравниваем обьект к функции mu1
  print(fun1(1,2));
  operation(5,3,(x,y)=>x*y);/// можно тупо менять функцию епта, какую хочешь ставь
  int div(a,v)=>a+v;
  Function func=div;// странно, да?
  func(9,3);

  t(4, ()=>print("hello"));
  
  callback(()=>print("hello"));

  var g = make(5);
  print(g(5));
  var list =[1,2,3,4,5];
  int s = 5;
  print(list.map((e)=>e+s));// ленивая функция   
}//  если переменная берется снаружи - будет замыкающая ф

int mu(int x, int y){
  return x+y;
}
int mu1(int a, int b)=> a*b;
// если не указать тип то он автоматическу будет типа dynamic

void operation(int a,int b, Function func){
  int result = func(a,b);
  print(result);
}
int Function(int,int) funb= (int a,int b,){
    return a+b;
  };


void t(int n, void Function() j){
  for (int i=0; i<n;i++){
    j();
  }
}

// колбек - функция, которая может 
void callback(void Function()g){
  print("Основная функция, а потом уже будет вызванная функция");
  g();

}
//фабрики функций или замыкание, я не понял  
int Function (int) make(int x){
  return (int f) {
    return x+f;
  };
}
 var printer=(String value)=>print(object)