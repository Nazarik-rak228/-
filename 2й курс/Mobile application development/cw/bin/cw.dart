void main() {
  // 1. Множество из 5 любимых цветов
  Set<String> colors = {'синий', 'зелёный', 'фиолетовый', 'розовый', 'чёрный'};
  print('1. Любимые цвета: $colors');

  // 2. Пустое множество → добавляем числа → повтор 3
  Set<int> numbers = {};
  numbers.add(1);
  numbers.add(2);
  numbers.add(3);
  numbers.add(4);
  numbers.add(5);
  numbers.add(3);           // не добавится
  print('2. После добавлений: $numbers');

  // 3
  Set<int> duplicates = {10, 20, 30, 20, 10};
  print('3. Длина множества: ${duplicates.length}'); // 3, дубли не считает

  // 4
  Set<String> fruits = {'яблоко', 'банан', 'апельсин'};
  print('4. Есть банан?  ${fruits.contains('банан')}');
  print('   Есть виноград? ${fruits.contains('виноград')}');

  // 5
  Set<int> set5 = {1, 2, 3, 4, 5};
  set5.remove(3);
  set5.remove(10);          // ничо не произойдет
  print('5. После удалений: $set5');

  // 6
  List<int> listWithDup = [1, 2, 2, 3, 3, 3, 4, 5];
  Set<int> unique = listWithDup.toSet();
  print('6. Уникальные: $unique');

  // 7
  Set<int> a = {1, 2, 3, 4, 5};
  Set<int> b = {3, 4, 5, 6, 7};
  print('7. Пересечение: ${a.intersection(b)}');

  // 8
  Set<int> c = {1, 2, 3};
  Set<int> d = {3, 4, 5};
  print('8. Объединение: ${c.union(d)}');

  // 9
  Set<int> e = {1, 2, 3, 4, 5};
  Set<int> f = {3, 4, 5};
  print('9. Разность (e - f): ${e.difference(f)}');

  // 10. Подмножество
  Set<int> small = {1, 2};
  Set<int> big = {1, 2, 3, 4, 5};


  // 11
  Set<int> nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
  nums.removeWhere((n) => n % 2 == 0);
  print('11. Только нечётные: $nums');

  // 12
  Set<int> original = {1, 2, 3, 4, 5};
  Set<int> doubled = original.map((n) => n * 2).toSet();
  print('12. Умноженные на 2: $doubled');

  // 13
  Set<int> values = {10, 20, 30, 40, 50, 60};
  Set<int> bigValues = values.where((n) => n > 30).toSet();
  print('13. Больше 30: $bigValues');

  // 14
  Set<int> set1 = {1, 2, 3};
  Set<int> set2 = {3, 2, 1};
  print('14. Множества равны?  ${set1 == set2}'); 

  // 15
  List<int> messy = [1, 2, 2, 3, 3, 3, 4, 5, 5];
  List<int> clean = messy.toSet().toList();
  print('15. Список без дублей: $clean');

  // 16
  Set<int> all = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
  Set<int> even = all.where((n) => n % 2 == 0).toSet();
  Set<int> odd = all.where((n) => n % 2 != 0).toSet();
  print('16. Чётные: $even');
  print('    Нечётные: $odd');

  // 17. 
  String text = "привет как дела дома";
  String cleanText = text.replaceAll(' ', '');
  Set<String> uniqueChars = cleanText.split('').toSet();
  print('17. Уникальные символы: $uniqueChars');

  // 18
  Set<int> multiples = {10, 15, 20, 25, 30, 35, 40};
  Set<int> result = multiples.where((n) => n % 5 == 0 && n > 20).toSet();
  print('18. Делятся на 5 и > 20: $result');

  // 19
  Set<int> left = {5, 1, 8, 3};
  Set<int> right = {3, 8, 1, 5};
  print('19. Одинаковый состав?  ${left == right}'); // да
}