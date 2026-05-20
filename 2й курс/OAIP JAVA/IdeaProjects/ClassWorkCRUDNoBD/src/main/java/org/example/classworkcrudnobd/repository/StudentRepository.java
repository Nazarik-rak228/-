package org.example.classworkcrudnobd.repository;

import org.example.classworkcrudnobd.model.StudentModel;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.atomic.AtomicInteger;

@Repository
public class StudentRepository {
    private List<StudentModel> students = new ArrayList<>();
    private AtomicInteger idCounter = new AtomicInteger(1);

    public List<StudentModel> findAll() {
        return new ArrayList<>(students);
    }

    public StudentModel addStudent(StudentModel student) {
        student.setId((idCounter.getAndIncrement()));
        students.add(student);
        return student;
    }

    public StudentModel updateStudent(StudentModel student) {
        for (int i = 0; i < students.size(); i++) {
            if (students.get(i).getId() == student.getId()) {
                students.set(i, student);
                return student;
            }

        }
        return null;
    }

    public void deleteStudent(int id) {
        students.removeIf(student -> student.getId() == id);
    }
}
