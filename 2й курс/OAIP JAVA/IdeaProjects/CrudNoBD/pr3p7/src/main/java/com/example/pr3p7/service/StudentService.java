package com.example.pr3p7.service;

import com.example.pr3p7.model.StudentModel;

import java.util.List;

public interface StudentService {

    public List<StudentModel> findAll();
    public StudentModel addStudent(StudentModel student);
    public StudentModel updateStudent(StudentModel student);
    public void deleteStudent(int id);

}
