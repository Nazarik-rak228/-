

void main(List<String> arguments) {

List<int> sas =[1,2,3,4,5,6];
List<int> sasCopy = [...sas, 18,23];

// множества - неупорядоченные коллекции, может содержать дубли, но будет их игнорить
// чтобы создать:
Set<int> setArray ={1,2,2,3,2,4};
Set<int?> aetNull ={1,null};    // есть нули
Set<int>? setFull;   // просто пустой для дальнейшей 
// джинерики это как раз треугольные скобки с типизацией строкой
print(sas);
print(sasCopy);
print(aetNull);
print(setFull);
print(setArray);
// добавлять через Add 
setArray.add(12);
// ТУТ НЕТ ИНДЕКСАЦИИ,  так что найти только первый и последний элемент
// удаление
setArray.remove(1);


// тут почти все как в списках 

//print(setArray.single); //не повторяющийся элемент выведет
print(setArray.map((w)=> w *2));
print(setArray.where((s) => s%2 == 0));



Set<int> copy = Set.from(setArray.where((s) => s%2 !=0));
print(copy);


///////////////////////////////////////////////////////////////////////////////////////////
///
///
///
///
///









































}