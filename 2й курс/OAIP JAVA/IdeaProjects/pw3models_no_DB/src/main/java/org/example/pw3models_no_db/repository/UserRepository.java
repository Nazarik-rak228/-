package org.example.pw3models_no_db.repository;

import org.example.pw3models_no_db.model.UserModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.atomic.AtomicInteger;

@Repository
public interface UserRepository extends JpaRepository<UserModel, Integer> {
    List<UserModel> findByUsernameContainingIgnoreCase(String username);
    Optional<UserModel> findByEmail(String email);
}

/*@Repository
public class UserRepository {

    private List<UserModel> users = new ArrayList<>();
    private AtomicInteger idCounter = new AtomicInteger(1);

    public List<UserModel> findAll() {
        return new ArrayList<>(users);
    }

    public UserModel addUser(UserModel user) {
        user.setId(idCounter.getAndIncrement());
        users.add(user);
        return user;
    }

    public UserModel updateUser(UserModel user) {
        for (int i = 0; i < users.size(); i++) {
            if (users.get(i).getId() == user.getId()) {
                users.set(i, user);
                return user;
            }
        }
        return null;
    }

    public void deleteUser(int id) {
        users.removeIf(user -> user.getId() == id);
    }

    public UserModel findById(int id) {
        return users.stream()
                .filter(user -> user.getId() == id)
                .findFirst()
                .orElse(null);
    }
    public List<UserModel> findByUsername(String username) {
        return users.stream()
                .filter(u -> u.getUsername() != null &&
                        u.getUsername().toLowerCase().contains(username.toLowerCase()))
                .toList();
    }

    public List<UserModel> findByEmail(String email) {
        return users.stream()
                .filter(u -> u.getEmail() != null &&
                        u.getEmail().toLowerCase().contains(email.toLowerCase()))
                .toList();
    }

}*/