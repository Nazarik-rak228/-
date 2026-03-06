

void main(List<String> arguments) {
// мап - словари в дарт(ключ - значение)
 Map<String,String> mapik1 = {"черт":"калич"};
 mapik1["sasat"]="America";
 print(mapik1);
 // типы ключей и данных можно ставить любые, очень удобно
   Map<String,String> mapik2 = {
    "черт":"калич",
    "as":"w"
   };
// кстати, можно закинуть мапы в словарь, прикольно
  List<Map<String,String>> list_Map = [{}];
  // copy - paste
  Map<String,String> mapik4=Map.from(  mapik2);

  // ищем в словаре
  String? Iskat=mapik1["черт"];
  print(Iskat);
  // проверяем наличее ключа
  if(mapik1.containsKey("черт")){
    print(mapik1["черт"]);
  }



  // ______________________________________________

  mapik1.addAll({"S":"saas", "sa":"sssssssssssss"});


  //mapik1.putIfAbsent("черт", {}== "asa")// добавляет пару, ТОЛЬКО ЕСЛИ КЛЮЧ НЕ СУЩЕСТВУЕТ

  mapik1.update("sasat", (value) =>value="Абаюнда");
  mapik1.updateAll((key,value) =>value="sas");

  mapik1.updateAll((key,value) =>value="sas");
  mapik2.remove("as");
  print(mapik2);
  mapik4.clear();
  print(mapik4);
  // свойства словаря как и у листа 
  print(mapik1.isNotEmpty);
  print(mapik2.entries);// расписывает ключ:значение


  for(var a in mapik2.values){
    print(a);
  }
  

  List<String> names=["anna","petr","rostislav"];
  Map<String,int> nameMap=Map.fromIterable(names,key:(item) =>item,value:(element)=>(element as String).length); // из элементов списка делаем ключи
  print(nameMap);
//приколы с энтри
  var entries=[
    
    MapEntry("a", 1),
    MapEntry("b", 2)
  ];
  Map<String,int> mapipo = Map.fromEntries(entries);
  print(mapipo);
  ///
  ///
  String str="asas fff fffff sds sds sds dfdfdfd fddf";
  List<String> strok =str.split("");
  Map<String,int> map9={};
  for(var s in strok){

      map9.update(s,
       (elem)=>elem+1, ifAbsent: ()=>1);
  }
  print(map9);




 Map<String,int> mapikss = {
    "s":1,
    "as":5,
    "sas":5
   };
   print(mapikss.values.where((val)=>val==5));
  
}
