expenses = [];
function addExpense(title, amount, category) { //добавляем расход ао входным
  if (!title || !amount || amount <= 0 || !category) {
    console.log("Ошибка ввода");
    return;
  }

  const expense = {
    id: expenses.length + 1,
    title: title,
    amount: amount,
    category: category
  };

  expenses.push(expense);
  console.log(`Добавлено: ${title} — ${amount} ₽ (${category})`);
}

function printAllExpenses() { // выводим расскоды 
  if (expenses.length === 0) {
    console.log("Пока расходов нет");
    return;
  }

  console.log("\nВсе расходы:");
  let i;
  for (i = 0; i < expenses.length; i++) {
    const e = expenses[i];
    console.log(`${e.id}) ${e.title} — ${e.amount} ₽ (${e.category})`);
  }
}

function getTotalAmount() { // тоталити - фаталити, короче выводим рассходы
  let total = 0;
  let i;
  for (i = 0; i < expenses.length; i++) {
    total += expenses[i].amount;
  }
  console.log(`\nОбщая сумма: ${total} ₽`);
  return total;
}

function getExpensesByCategory(category) { // Рыщим -сыщим по категориии
  let sum = 0;
  let found = false;

  console.log(`\nКатегория "${category}":`);

  let i;
  for (i = 0; i < expenses.length; i++) {
    if (expenses[i].category.toLowerCase() === category.toLowerCase()) {
      const e = expenses[i];
      console.log(`  ${e.title} — ${e.amount} ₽`);
      sum += e.amount;
      found = true;
    }
  }

  if (!found) {
    console.log("  (ничего нет)");
  } else {
    console.log(`  Итого: ${sum} ₽`);
  }
}

function findExpenseByTitle(search) { // теперь по имени
  if (!search) {
    console.log("Введите строку для поиска");
    return null;
  }

  let i;
  for (i = 0; i < expenses.length; i++) {
    if (expenses[i].title.toLowerCase().includes(search.toLowerCase())) {
      const e = expenses[i];
      console.log(`Найдено: ${e.id}) ${e.title} — ${e.amount} ₽ (${e.category})`);
      return e;
    }
  }

  console.log(`Ничего не найдено по "${search}"`);
  return null;
}

function removeExpense(id) { // а вот раньше людей по Ip вычесляли и убивали, а скоро как ботов в Detroit по ID
  let i;
  for (i = 0; i < expenses.length; i++) {
    if (expenses[i].id === id) {
      const removed = expenses.splice(i, 1)[0];
      console.log(`Удалено: ${removed.title} — ${removed.amount} ₽`);
      return;
    }
  }
  console.log(`ID ${id} не найден`);
}

// Статистика по категориям
function printCategoryStats() { // статистика, была бы у меня в танках она хотябы 50%
  if (expenses.length === 0) {
    console.log("Нет расходов");
    return;
  }

  const stats = {};
  let i;
  for (i = 0; i < expenses.length; i++) {
    const cat = expenses[i].category;
    stats[cat] = (stats[cat] || 0) + expenses[i].amount;
  }

  console.log("\nСтатистика по категориям:");
  for (const cat in stats) {
    console.log(`  ${cat}: ${stats[cat]} ₽`);
  }
}
// ну, пробуем

{ }


while(true){
  let choice = prompt("Выберите операцию");
      
  console.log("Доступные операции \n 1 - добавить \n 2 - выведи все \n 3 - все деньги \n 4 - по категории \n 5 -по названию \n 6 - удали по id \n 7 - статистика по категории ");

  switch(choice){
      case("1"):
        addExpense(title = prompt("Название расхода"),amount = prompt("Введи деньги"), category = prompt("Введите категорию"));
      break;
      case("2"):
        printAllExpenses();
      break;
      case("3"):
        getTotalAmount();
      break;
      case("4"):
        getExpensesByCategory(category = prompt("Введите название категории"));
      break;
      case("5"):
        findExpenseByTitle(search = prompt("Введите названененинюнянюноне"));
      break;
      case("6"):
        removeExpense(id = parseIntprompt("Циферка, циферка, абрама кор, короче надо ID"));
      break;
      case("7"):
        printCategoryStats();
      break;
      case("8"):
        break;
      break;
  }
}




// Интерполяция — способ вставки переменных или выражений внутрь строки с помощью ${} в шаблонных строках.
// Литерал — значение, записанное прямо в коде (число, строка, объект, массив и т.д.).
// Строковый литерал — строка, записанная в кавычках ("text", 'text', text).
// Шаблонный литерал (template literal) — строка в обратных кавычках  , поддерживающая интерполяцию и многострочность.
// Деструктуризация — синтаксис для извлечения значений из объектов или массивов в отдельные переменные.
// Объектная константа — объект, объявленный через const; ссылку менять нельзя, свойства — можно.
// Spread-оператор (...) — оператор разворачивания массива или объекта в отдельные элементы.
// Rest-оператор (...) — оператор сбора оставшихся элементов в массив или объект.
// Стрелочная функция — сокращённая форма записи функции с синтаксисом () => {}.
// объектный литерал - способ создания обьекта напрямую в коде С помощью фигурных скобок 