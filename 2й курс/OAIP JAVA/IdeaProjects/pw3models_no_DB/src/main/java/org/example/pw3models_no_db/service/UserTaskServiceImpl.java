package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.UserTaskModel;
import org.example.pw3models_no_db.repository.UserTaskRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserTaskServiceImpl implements UserTaskService {

    private final UserTaskRepository userTaskRepository;

    public UserTaskServiceImpl(UserTaskRepository userTaskRepository) {
        this.userTaskRepository = userTaskRepository;
    }

    @Override
    public List<UserTaskModel> findAll() {
        return userTaskRepository.findAll();
    }

    @Override
    public UserTaskModel addUserTask(UserTaskModel userTask) {
        return userTaskRepository.save(userTask);
    }

    @Override
    public UserTaskModel updateUserTask(UserTaskModel userTask) {
        return userTaskRepository.save(userTask);
    }

    @Override
    public void deleteUserTask(int id) {
        userTaskRepository.deleteById(id);
    }

    @Override
    public List<UserTaskModel> findByStatus(String status) {
        return userTaskRepository.findByStatusContainingIgnoreCase(status);
    }

    @Override
    public List<UserTaskModel> findByUserId(int userId) {
        return userTaskRepository.findByUserId(userId);
    }

    @Override
    public UserTaskModel findById(int id) {
        return userTaskRepository.findById(id).orElse(null);
    }
}