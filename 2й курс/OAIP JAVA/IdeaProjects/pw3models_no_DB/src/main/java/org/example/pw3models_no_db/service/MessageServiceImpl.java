package org.example.pw3models_no_db.service;

import org.example.pw3models_no_db.model.MessageModel;
import org.example.pw3models_no_db.repository.MessageRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MessageServiceImpl implements MessageService {

    private final MessageRepository messageRepository;

    public MessageServiceImpl(MessageRepository messageRepository) {
        this.messageRepository = messageRepository;
    }

    @Override
    public List<MessageModel> findAll() {
        return messageRepository.findAll();
    }

    @Override
    public MessageModel addMessage(MessageModel message) {
        return messageRepository.save(message);
    }

    @Override
    public MessageModel updateMessage(MessageModel message) {
        return messageRepository.save(message);
    }

    @Override
    public void deleteMessage(int id) {
        messageRepository.deleteById(id);
    }

    @Override
    public List<MessageModel> findBySenderId(int senderId) {
        return messageRepository.findBySenderId(senderId);
    }

    @Override
    public MessageModel findById(int id) {
        return messageRepository.findById(id).orElse(null);
    }
}