package org.example.classworkcrudnobd.service;

import org.example.classworkcrudnobd.model.StudentModel;

import java.util.List;

public interface StudentService {
    public List<StudentModel> findAll();

    public StudentModel addStudent(StudentModel student);

    public StudentModel updateStudent(StudentModel student);

    public void deleteStudent(int id);
}
