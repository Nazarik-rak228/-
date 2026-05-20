package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.ReviewModel;
import org.example.pw3models_no_db.repository.ReviewRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ReviewServiceImpl implements ReviewService {

    private final ReviewRepository reviewRepository;

    public ReviewServiceImpl(ReviewRepository reviewRepository) {
        this.reviewRepository = reviewRepository;
    }

    @Override
    public List<ReviewModel> findAll() {
        return reviewRepository.findAll();
    }

    @Override
    public ReviewModel addReview(ReviewModel review) {
        return reviewRepository.save(review);
    }

    @Override
    public ReviewModel updateReview(ReviewModel review) {
        return reviewRepository.save(review);
    }

    @Override
    public void deleteReview(int id) {
        reviewRepository.deleteById(id);
    }

    @Override
    public List<ReviewModel> findByRating(int rating) {
        return reviewRepository.findByRating(rating);
    }

    @Override
    public ReviewModel findById(int id) {
        return reviewRepository.findById(id).orElse(null);
    }
}