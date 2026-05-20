package org.example.pw3models_no_db.model;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;

import java.time.LocalDate;
@Entity
@Table(name = "tasks")
public class TaskModel {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @NotBlank(message = "Нельзя оставить поле пустым")
    private String title;
    @NotBlank(message = "Нельзя оставить поле пустым")
    private String description;
    @NotNull(message = "Нельзя оставить поле пустым")
    private LocalDate deadline;
    @NotNull(message = "Нельзя оставить поле пустым")
    private double price;
    @NotNull(message = "Нельзя оставить поле пустым")
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "user_id", nullable = false)
    private UserModel user;
    @NotNull(message = "Нельзя оставить поле пустым")
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "category_id", nullable = false)
    private CategoryModel category;

    public TaskModel(int id, String title, String description, LocalDate deadline, double price, UserModel user, CategoryModel category) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.deadline = deadline;
        this.price = price;
        this.user = user;
        this.category = category;
    }

    public TaskModel() {

    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public LocalDate getDeadline() {
        return deadline;
    }

    public void setDeadline(LocalDate deadline) {
        this.deadline = deadline;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public UserModel getUser() {
        return user;
    }

    public void setUser(UserModel user) {
        this.user = user;
    }

    public CategoryModel getCategory() {
        return category;
    }

    public void setCategory(CategoryModel category) {
        this.category = category;
    }
}
