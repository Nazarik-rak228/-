package com.example.pr3p7.service;

import com.example.pr3p7.model.StudentModel;
import com.example.pr3p7.repository.StudentRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class StudentServiceImpl implements StudentService {
    private final StudentRepository studentRepository;

    public StudentServiceImpl(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    @Override
    public List<StudentModel> findAll(){ return studentRepository.findAll();}

    @Override
    public StudentModel addStudent(StudentModel student){
        return studentRepository.addStudent(student);
    }

    @Override
    public StudentModel updateStudent(StudentModel student){
        return studentRepository.updateStudent(student);
    }

    @Override
    public void deleteStudent(int id){
        studentRepository.deleteStudent(id);
    }
}
