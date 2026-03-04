package com.example.pw1maybe;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;



@Controller
public class HomeController {
    @GetMapping("/")
    String home(){
        return "home";
    }
    @GetMapping("/sas")
    String sas(){
        return "sas";
    }
    @PostMapping("/home")
    String homePost(Model model, @RequestParam(value = "TextPrint",
        required = true,defaultValue = "it is empty") String usertext){
            model.addAttribute("Text", usertext);
            return "home";
        }


}
