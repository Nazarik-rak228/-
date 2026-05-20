package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.RoleModel;
import org.example.pw3models_no_db.repository.RoleRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class RoleServiceImpl implements RoleService {

    private final RoleRepository roleRepository;

    public RoleServiceImpl(RoleRepository roleRepository) {
        this.roleRepository = roleRepository;
    }


    @Override
    public List<RoleModel> findAll() {
        return roleRepository.findAll();
    }

    @Override
    public RoleModel addRole(RoleModel role) {
        return roleRepository.save(role);
    }

    @Override
    public RoleModel updateRole(RoleModel role) {
        return roleRepository.save(role);
    }

    @Override
    public void deleteRole(int id) {
        roleRepository.deleteById(id);
    }

    @Override
    public List<RoleModel> findByRolName(String rolName) {
        return roleRepository.findByRolNameContainingIgnoreCase(rolName);
    }

    @Override
    public RoleModel findById(int id) {
        return roleRepository.findById(id).orElse(null);
    }
}