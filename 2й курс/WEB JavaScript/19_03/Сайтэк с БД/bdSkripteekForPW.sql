
--------------------------------------------------
-- 1. Роли
CREATE TABLE roles (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL
);

--------------------------------------------------
-- 2. Пользователи
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    full_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    login VARCHAR(100) UNIQUE NOT NULL,
    password TEXT NOT NULL,
    role_id INTEGER NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (role_id) REFERENCES roles(id)
);

--------------------------------------------------
-- 3. Курсы
CREATE TABLE courses (
    id SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    teacher_id INTEGER NOT NULL,

    FOREIGN KEY (teacher_id) REFERENCES users(id)
);

--------------------------------------------------
-- 4. Расписание
CREATE TABLE schedule (
    id SERIAL PRIMARY KEY,
    course_id INTEGER NOT NULL,
    teacher_id INTEGER NOT NULL,
    lesson_date DATE NOT NULL,
    lesson_time TIME NOT NULL,

    FOREIGN KEY (course_id) REFERENCES courses(id),
    FOREIGN KEY (teacher_id) REFERENCES users(id)
);

--------------------------------------------------
-- ДАННЫЕ

-- роли
INSERT INTO roles (name) VALUES
('admin'),
('teacher'),
('student');

-- пользователи
INSERT INTO users (full_name, email, login, password, role_id) VALUES
('Иван Иванов', 'ivan@mail.com', 'ivan', '12345', 2),
('Петр Петров', 'petr@mail.com', 'petr', '12345', 3),
('Анна Смирнова', 'anna@mail.com', 'anna', '12345', 2);

-- курсы
INSERT INTO courses (title, description, teacher_id) VALUES
('SQL для начинающих', 'База данных и основы SQL', 1),
('JavaScript база', 'Основы JS', 3),
('HTML + CSS', 'Верстка сайтов', 1);

-- расписание
INSERT INTO schedule (course_id, teacher_id, lesson_date, lesson_time) VALUES
(1, 1, '2026-05-01', '10:00'),
(2, 3, '2026-05-03', '12:00'),
(3, 1, '2026-05-05', '14:00');