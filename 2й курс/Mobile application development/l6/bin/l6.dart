
void main(List<String> arguments) {
// новая лекция 
  // for(int i =0; i < 10;i++){
  //   print("количество мудаков в округе:");
  //   print(i);
  // }
  // for(int i = 2;i <20;i+2){
  //   print(i);
  // }
  // for(int i = 1;i <=5 ;i++){
  //   for(int j = 1;j <=5;j++){
  //     int a = i*j;

  //     print("${i}*${j}=${a}");
  //   }
  // }
  // // пустые циклы
  // int sum =0;

  // for(  int i = 1;i<=10;sum+=i,i++);
  // print(sum);
  // List<int> dydy = [10, 20,30,40,50,60];
  // // for In
  // for(int i in dydy ){
  //   print(i);
  // }

  // List<int> listik = [11,22,33,44,55,66,77,88,99,00];
  // for(int j in listik){
  //   print(j);
  // }
  // Set<String> setik={"epsTien", "Trump"};
  //   for(int i = 1;i <setik.length ;i++){
  //     print(i);
  //   }
  // String dart ="sosi america";
  //   for(var da in dart.split("")){
  //     print(da);
  //   }
  // List<String> listik1 = ["epsTien", "Trump"];
  // for(var l in listik1.asMap().entries){
  //   print("${l.key}, ${l.value}");
  // }
  //  // entries превращяет в словарь и дает ключ значениям
  //   int i=1;
  // while(i <= 5){
  //   print(i);
  //   break;
  // }
  // int num = 1000;
  // while(num>0){
  //   print(num);
  //   num~/=2;
  // }
  int sus = 1;
  do {
    sus++;
    print(sus);
  } while (sus<=2);

    int susss = 1;
  do {
    sus++;
    print(susss);
  } while (susss<=5);

  List<int> g = [1,2,3,4,5,6,78,12]; // пропускаем 2 
  g.forEach((a){
    if(a==2){
      return;  
    }print(a);
  });
  g.forEach((a){
    print(a*2);
  }
  );
  

    List<int> f=[1,2,3,4];
  f. forEach((a){
    print(a*2);
  });

  for(var h in f){
    if(h == 3){
      continue;
  
  }print(h);
  }

  for(var h in f){
    if(h == 3){
      break;
    
  }print(h);
  }

  
}



