package org.example.classworkcrudnobd.model;

import javax.swing.*;

public class StudentModel {
    private int id;
    private Spring name;
    private Spring surname;
    private Spring secondname;

    public StudentModel(int id, Spring name, Spring surname, Spring secondname) {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.secondname = secondname;
    }

    public StudentModel(int id, String name, String surname, String secondname) {
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Spring getName() {
        return name;
    }

    public void setName(Spring name) {
        this.name = name;
    }

    public Spring getSurname() {
        return surname;
    }

    public void setSurname(Spring surname) {
        this.surname = surname;
    }

    public Spring getSecondname() {
        return secondname;
    }

    public void setSecondname(Spring secondname) {
        this.secondname = secondname;
    }
}
