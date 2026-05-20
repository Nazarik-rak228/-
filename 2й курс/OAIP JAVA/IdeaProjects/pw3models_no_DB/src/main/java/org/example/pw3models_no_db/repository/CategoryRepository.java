package org.example.pw3models_no_db.repository;

import org.example.pw3models_no_db.model.CategoryModel;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.atomic.AtomicInteger;
import org.example.pw3models_no_db.model.CategoryModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import java.util.List;

@Repository
public interface CategoryRepository extends JpaRepository<CategoryModel, Integer> {
    List<CategoryModel> findByCatNameContainingIgnoreCase(String catName);
}
/*

@Repository
public class CategoryRepository {

    private List<CategoryModel> categories = new ArrayList<>();
    private AtomicInteger idCounter = new AtomicInteger(1);

    public List<CategoryModel> findAll() {
        return new ArrayList<>(categories);
    }

    public CategoryModel addCategory(CategoryModel category) {
        category.setId(idCounter.getAndIncrement());
        categories.add(category);
        return category;
    }

    public CategoryModel updateCategory(CategoryModel category) {
        for (int i = 0; i < categories.size(); i++) {
            if (categories.get(i).getId() == category.getId()) {
                categories.set(i, category);
                return category;
            }
        }
        return null;
    }

    public void deleteCategory(int id) {
        categories.removeIf(category -> category.getId() == id);
    }

    public CategoryModel findById(int id) {
        return categories.stream()
                .filter(category -> category.getId() == id)
                .findFirst()
                .orElse(null);
    }
    public List<CategoryModel> findByCatName(String catName) {
        return categories.stream()
                .filter(c -> c.getCatName() != null &&
                        c.getCatName().toLowerCase().contains(catName.toLowerCase()))
                .toList();
    }
}*/
