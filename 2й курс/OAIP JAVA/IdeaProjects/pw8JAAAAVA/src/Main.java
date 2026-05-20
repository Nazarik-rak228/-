import java.time.LocalDate;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

//TIP Чтобы <b>запустить</b> код, нажмите <shortcut actionId="Run"/> или
// нажмите на значок <icon src="AllIcons.Actions.Execute"/> на полях.
public class Main {
    public static void main(String[] args) {
        List<Employee> employeeList =  new ArrayList<>();
        employeeList.add((new Employee("Анна", "IT", 120_000, LocalDate.of(2024, 3, 20), 10.0)));
        employeeList.add((new Employee("Иван", "HR", 220_000, LocalDate.of(2018, 3, 12), 0.2)));
        employeeList.add((new Employee("Олег", "IT", 190_000, LocalDate.of(2022, 5, 4), 5.2)));
        employeeList.add((new Employee("Мария", "Финансы", 140_000, LocalDate.of(2021, 1, 10), 4.3)));
        employeeList.add((new Employee("Елена", "IT", 500_000, LocalDate.of(2022, 9, 10), 1.3)));
    System.out.println("Добрый день");
    boolean sas = true;
    while (sas == true){
        System.out.println("Выберите операцию");
        System.out.println("1 - Найдите всех сотрудников, работающих в определенном отделе, с зарплатой выше среднего по компании.");
        System.out.println("2 - Группировка: Подсчитайте количество сотрудников в каждом отделе с рейтингом производительности выше 3.0, используя Map<String, Long>.");
        System.out.println("3 - Поиск: Найдите сотрудника с наивысшей зарплатой, который был нанят в последние два года.");
        System.out.println("4 - Агрегация: Выведите среднюю зарплату сотрудников для каждого отдела.");
        System.out.println("0 - Выход ");

        Scanner read = new Scanner(System.in);
        int reading = read.nextInt();
        switch (reading){
            case 1:
                double averageSalary = employeeList.stream().mapToDouble(Employee::getSalary).average().orElse(0);
                List<Employee> feltForSal = employeeList.stream().filter(employee -> employee.getDepartment().equals("IT")).filter(employee -> employee.getSalary()>averageSalary).collect(Collectors.toList());
                for (Employee e : feltForSal){
                    System.out.println(e.getName() +" | "+ e.getDepartment() +" | "+e.getSalary());
                }

                break;
            case 2:
                Map<String,Long>  filtForRating= employeeList.stream().filter(employee -> employee.getPerfomanceRating()>3.0).collect(Collectors.groupingBy(Employee::getDepartment,Collectors.counting()));
                System.out.println(filtForRating);
                break;
            case 3:
                List<Employee> lastTwoYears = employeeList.stream().filter(employee -> employee.getHireDate().getYear() >= 2024).toList();
                Employee best = lastTwoYears.getFirst();
                for (Employee e : lastTwoYears){
                    if (e.getSalary() > best.getSalary()){
                        best = e;
                    }
                }
                System.out.println( best.getName() + " | " + best.getDepartment() + " | " + best.getSalary());
                break;
            case 4:
                Map<String, Double> filtSakForDep = employeeList.stream().collect(Collectors.groupingBy(Employee::getDepartment,Collectors.averagingDouble(Employee::getSalary)));
                System.out.println(filtSakForDep);
            case 0:
                sas = false;
        }
    }
    }
}