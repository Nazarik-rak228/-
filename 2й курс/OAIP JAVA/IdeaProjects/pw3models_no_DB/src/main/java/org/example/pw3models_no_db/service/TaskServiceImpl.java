package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.TaskModel;
import org.example.pw3models_no_db.repository.TaskRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TaskServiceImpl implements TaskService {

    private final TaskRepository taskRepository;

    public TaskServiceImpl(TaskRepository taskRepository) {
        this.taskRepository = taskRepository;
    }


    @Override
    public List<TaskModel> findAll() {
        return taskRepository.findAll();
    }

    @Override
    public TaskModel addTask(TaskModel task) {
        return taskRepository.save(task);
    }

    @Override
    public TaskModel updateTask(TaskModel task) {
        return taskRepository.save(task);
    }

    @Override
    public void deleteTask(int id) {
        taskRepository.deleteById(id);
    }

    @Override
    public List<TaskModel> findByTitle(String title) {
        return taskRepository.findByTitleContainingIgnoreCase(title);
    }

    @Override
    public List<TaskModel> findByPriceGreaterThan(double minPrice) {
        return taskRepository.findByPriceGreaterThan(minPrice);
    }

    @Override
    public TaskModel findById(int id) {
        return taskRepository.findById(id).orElse(null);
    }
}