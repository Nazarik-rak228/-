package org.example.classworkcrudnobd.controller;

import org.example.classworkcrudnobd.model.StudentModel;
import org.example.classworkcrudnobd.service.StudentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class StudentController {
    @Autowired // автоопределение , чтобы самому все не прописывать c привязкой класса
    private StudentService studentService;

    @GetMapping("/")
    public String allStudents(Model model) {
        model.addAttribute("student", studentService.findAll());
        return "student";

    }


    @PostMapping("/student/add")
    public String addStudent(
            @RequestParam String name,
            @RequestParam String surname,
            @RequestParam String secondname
    ) {
        StudentModel model = new StudentModel(0, name, surname, secondname);
        studentService.addStudent(model);
        return "redirect:/student";

    }


}
