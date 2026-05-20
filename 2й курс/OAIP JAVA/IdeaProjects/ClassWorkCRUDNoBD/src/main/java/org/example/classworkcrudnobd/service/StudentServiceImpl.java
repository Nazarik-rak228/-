package org.example.classworkcrudnobd.service;

import org.example.classworkcrudnobd.model.StudentModel;
import org.example.classworkcrudnobd.repository.StudentRepository;
import org.springframework.stereotype.Service;

import java.util.List;


@Service
public class StudentServiceImpl implements StudentService {// отличие от наследования, при наследовании родительская функция просто передается, а тут вызывается все, все дочернии в том числе
    private StudentRepository studentRepository;

    public StudentServiceImpl(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    @Override
    public List<StudentModel> findAll() {
        return studentRepository.findAll();
    }

    @Override
    public StudentModel addStudent(StudentModel student) {
        return studentRepository.addStudent(student);
    }

    @Override
    public StudentModel updateStudent(StudentModel student) {
        return studentRepository.updateStudent(student);
    }

    @Override
    public void deleteStudent(int id) {
        studentRepository.deleteStudent(id);
    }
}

