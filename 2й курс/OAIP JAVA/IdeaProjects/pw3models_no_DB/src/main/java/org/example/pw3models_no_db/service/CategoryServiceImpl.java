package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.CategoryModel;
import org.example.pw3models_no_db.repository.CategoryRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CategoryServiceImpl implements CategoryService {

    private final CategoryRepository categoryRepository;

    public CategoryServiceImpl(CategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }


    @Override
    public List<CategoryModel> findAll() {
        return categoryRepository.findAll();
    }

    @Override
    public CategoryModel addCategory(CategoryModel category) {
        return categoryRepository.save(category);
    }

    @Override
    public CategoryModel updateCategory(CategoryModel category) {
        return categoryRepository.save(category);
    }

    @Override
    public void deleteCategory(int id) {
        categoryRepository.deleteById(id);
    }

    @Override
    public List<CategoryModel> findByCatName(String catName) {
        return categoryRepository.findByCatNameContainingIgnoreCase(catName);
    }

    @Override
    public CategoryModel findById(int id) {
        return categoryRepository.findById(id).orElse(null);
    }
}