import java.time.LocalDate;
import java.util.List;
import java.util.stream.Stream;

public class Employee {
    String name;
    String department;
    int salary;
    LocalDate hireDate;
    double perfomanceRating;

    public Employee(String name, String department, int salary, LocalDate hireDate, double perfomanceRating) {
        this.name = name;
        this.department = department;
        this.salary = salary;
        this.hireDate = hireDate;
        this.perfomanceRating = perfomanceRating;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDepartment() {
        return department;
    }

    public void setDepartment(String department) {
        this.department = department;
    }

    public int getSalary() {
        return salary;
    }

    public void setSalary(int salary) {
        this.salary = salary;
    }

    public LocalDate getHireDate() {
        return hireDate;
    }

    public void setHireDate(LocalDate hireDate) {
        this.hireDate = hireDate;
    }

    public double getPerfomanceRating() {
        return perfomanceRating;
    }

    public void setPerfomanceRating(double perfomanceRating) {
        this.perfomanceRating = perfomanceRating;
    }

}

