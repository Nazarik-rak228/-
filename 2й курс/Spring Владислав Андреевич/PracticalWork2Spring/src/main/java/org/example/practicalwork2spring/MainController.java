package org.example.practicalwork2spring;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
@RequestMapping("/")
class MainController {
    @GetMapping("/")
    public String home (){
        return "home";
    }

    @GetMapping("/calculator")
    public String calculator(){
        return "calculator";
    }

    @PostMapping("/calculate")
    public String calculate(
            @RequestParam double a,
            @RequestParam double b,
            @RequestParam String operation,
            Model model){

        double result = 0;

        if(operation.equals("add")) result = a + b;
        if(operation.equals("min")) result = a - b;
        if(operation.equals("umn")) result = a * b;
        if(operation.equals("del")) result = a / b;

        model.addAttribute("result", result);

        return "result";
    }

    @GetMapping("/converter")
    public String converter(){
        return "converter";
    }

    @PostMapping("/convert")
    public String convert(
            @RequestParam double amount,
            @RequestParam String from,
            @RequestParam String to,
            Model model){

        double result = amount;

        if(from.equals("USD") && to.equals("EUR")) result = amount * 0.9;
        if(from.equals("EUR") && to.equals("USD")) result = amount * 1.1;

        if(from.equals("USD") && to.equals("GBP")) result = amount * 0.8;
        if(from.equals("GBP") && to.equals("USD")) result = amount * 1.25;

        if(from.equals("EUR") && to.equals("GBP")) result = amount * 0.88;
        if(from.equals("GBP") && to.equals("EUR")) result = amount * 1.14;

        model.addAttribute("result", result);

        return "convertResult";
    }
}
