package com.example.pr3p7.controller;

import com.example.pr3p7.model.StudentModel;
import com.example.pr3p7.service.StudentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class StudentController {

    @Autowired
    private StudentService studentService;

    @GetMapping("/students")
    public String allStudents(Model model){
        model.addAttribute("students", studentService.findAll());
        return "studentList";
    }

    @PostMapping("/students/add")
    public String addStudent(@RequestParam String name,
                             @RequestParam String surname,
                             @RequestParam String secondName){

        StudentModel studentModel = new StudentModel(0, name, surname, secondName);
        studentService.addStudent(studentModel);
        return "redirect:/students";
    }

    @PostMapping("/students/update")
    public String updateStudent( @RequestParam int id,
                                @RequestParam String name,
                                @RequestParam String surname,
                                @RequestParam String secondName){
        StudentModel studentModel = new StudentModel(id, name, surname, secondName);
        studentService.updateStudent(studentModel);
        return "redirect:/students";
    }

    @PostMapping("/students/delete")
    public String deleteStudent(@RequestParam int id){
        studentService.deleteStudent(id);
        return "redirect:/students";
    }
}
