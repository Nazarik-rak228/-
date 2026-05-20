package org.example.pw3models_no_db.model;

import jakarta.persistence.*;
import jakarta.validation.constraints.Max;
import jakarta.validation.constraints.Min;

@Entity
@Table(name = "reviews")
public class ReviewModel {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    // Кто оставил отзыв
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "out_user_id", nullable = false)
    private UserModel outUser;

    // Кому оставили отзыв
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "in_user_id", nullable = false)
    private UserModel inUser;

    @Min(1)
    @Max(5)
    private int rating;

    private String comment;

    public ReviewModel(int id, UserModel outUser, UserModel inUser, int rating, String comment) {
        this.id = id;
        this.outUser = outUser;
        this.inUser = inUser;
        this.rating = rating;
        this.comment = comment;
    }

    public ReviewModel() {

    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public UserModel getOutUser() {
        return outUser;
    }

    public void setOutUser(UserModel outUser) {
        this.outUser = outUser;
    }

    public UserModel getInUser() {
        return inUser;
    }

    public void setInUser(UserModel inUser) {
        this.inUser = inUser;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }
}
