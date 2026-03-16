
void main(List<String> arguments) {
 var person = { "denis",45};
 print(person);

  (String, int) person1 = ("nazar", 20);
  var person2 =(name:"ivan", age:320);
  ({String text, int age}) person3 =(text:"sasha", age:22);
    (int,{String text} ) person4 =(text:"sasha",22);
  var i = defaultQ();
   print(i);
   var a = [1,2,3,213,12,7,9];
  print(a.where((element)=>element>=200));
  print(a.map((e)=> e*2));
  print(a.take(4));
  print(a.reduce((a,b)=> a*b));
  print(a.every((a)=> a>=4));
}
(int,int) defaultQ(){
  return (5,5);
}
