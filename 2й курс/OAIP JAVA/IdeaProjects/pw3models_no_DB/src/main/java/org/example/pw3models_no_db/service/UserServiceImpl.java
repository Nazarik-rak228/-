package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.UserModel;
import org.example.pw3models_no_db.repository.UserRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserServiceImpl implements UserService {

    private final UserRepository userRepository;

    public UserServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public List<UserModel> findAll() {
        return userRepository.findAll();
    }

    @Override
    public UserModel addUser(UserModel user) {
        return userRepository.save(user);
    }

    @Override
    public UserModel updateUser(UserModel user) {
        return userRepository.save(user);
    }

    @Override
    public void deleteUser(int id) {
        userRepository.deleteById(id);
    }

    @Override
    public List<UserModel> findByUsername(String username) {
        return userRepository.findByUsernameContainingIgnoreCase(username);
    }

    @Override
    public List<UserModel> findByEmail(String email) {
        return userRepository.findByEmail(email).map(List::of).orElse(List.of());
    }

    @Override
    public UserModel findById(int id) {
        return userRepository.findById(id).orElse(null);
    }
}