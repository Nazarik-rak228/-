package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.ResponseModel;
import org.example.pw3models_no_db.repository.ResponseRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ResponseServiceImpl implements ResponseService {

    private final ResponseRepository responseRepository;

    public ResponseServiceImpl(ResponseRepository responseRepository) {
        this.responseRepository = responseRepository;
    }

    @Override
    public List<ResponseModel> findAll() {
        return responseRepository.findAll();
    }

    @Override
    public ResponseModel addResponse(ResponseModel response) {
        return responseRepository.save(response);
    }

    @Override
    public ResponseModel updateResponse(ResponseModel response) {
        return responseRepository.save(response);
    }

    @Override
    public void deleteResponse(int id) {
        responseRepository.deleteById(id);
    }

    @Override
    public List<ResponseModel> findByStatus(String status) {
        return responseRepository.findByStatusContainingIgnoreCase(status);
    }

    @Override
    public List<ResponseModel> findByTaskId(int taskId) {
        return responseRepository.findByTask_Id(taskId);
    }

    @Override
    public ResponseModel findById(int id) {
        return responseRepository.findById(id).orElse(null);
    }
}

