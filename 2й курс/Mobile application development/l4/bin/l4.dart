

void main(List<String> arguments) {
  List list =[1,2,3,4,"sdaasd"];
  List<int> listInt = [1,2 ];

  List<int?> fil = List.filled(4, null);

  List<int> gen = List.generate(4,(int x) =>x*2 );

  List<int> cop = List.from(gen);

  const List<int> asa = [1,2,3,4];
  final List<int> asa2 = [1,2,3,4];// с файнал можно не сразу обьявлять, а так как константа
  List<int> s1 =[1,2,3,4,5];
  print(s1[0]);
  print(s1.first);
  print(s1.last);


  print(s1.elementAt(0));
  print(s1.length);
  s1.add(2);
  s1.insert(0, 52);
  s1.remove(2);// не индекс бьет, а элемент ищет и удаляет
  print(s1);
  s1.removeLast();
  s1.removeWhere((element) => element%2==0);
  print(s1);
   s1.removeAt(2);// по индексу
  s1.clear();
  List<int> s2 = [1,2,3,4,5];
  s2[0] = 52;
  s2.fillRange(2, 5, 0);
  print(s2);
  print(s2.indexOf(52));// если нет такого элемента, то -1
  print(s2.contains(52)); // содержет ли = да\нет
  List<int> s3=[1,2,3,4,5];
  s3.any((x)=> x>4);// не строг..о
  print(s3);
  s3.every((x)=> x>4);// строго
  print(s3);


  // срезы
  print(s3.sublist(2,5)); // меж 2 и 5 индексами не включительно
  print(s3.sublist(2));// от второго и дальше

  // надо скопироватть и сразу добить своей инфорй
  List<int> f3 = [...s3, 12,23,34];// можно менять местами 

  // сортировка
  f3.sort(); // от меньшего к большему
  List<String> sas=["Sidr",'dolbanyi-dolbanyi-dolbanyi-dolbanyi-dolbanyi',"alkash"];
  sas.sort((a,b)=> a.length.compareTo(b.length));// жеско сравниваем строчный значения

  print(sas);
  sas.shuffle();// рандомная сортировка
  // новая колекция, не меняя список
  print(f3.map((int x) =>x*2 ));// все умножается на 2
  print(f3.where((int x) =>x*2!=0));

  print(f3.skip(3)); // пишет с 3го элемента
  print(f3.take(3));// заканчивается на 3 элементе
  print(f3.reduce((a,b) => a+b));// берет все по аргументам и делает что сказали, сначала а и б это первый и второй интекс, потом второй и третий...


List listA =['aple','bonano','vinograd','sliva',];
print(listA);
List<int> sasasa =[];
sasasa.add(1);
sasasa.add(2);
sasasa.add(3);
sasasa.add(4);
sasasa.add(5);
print(sasasa);





  
  
  




}
