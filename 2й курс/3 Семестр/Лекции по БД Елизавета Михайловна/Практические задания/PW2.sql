CREATE DATABASE fitness_club;
GO

USE fitness_club;
GO

CREATE SCHEMA fit;
GO
CREATE TABLE fit.membership_types (
    id_type INT PRIMARY KEY IDENTITY(1,1),
    type_name_m VARCHAR(50) NOT NULL UNIQUE,
    duration_months INT NOT NULL CHECK (duration_months > 0),
    price DECIMAL(8,2) NOT NULL CHECK (price > 0)
);
GO

CREATE TABLE fit.trainers (
    id_trainer INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    specialization VARCHAR(100) NOT NULL
);
GO

-- Клиенты
CREATE TABLE fit.clients (
    id_client INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    phone VARCHAR(20),
    membership_type_id INT,  
    trainer_id INT ,         
    join_date DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_clients_membership FOREIGN KEY (membership_type_id) REFERENCES fit.membership_types(id_type) ON DELETE SET NULL ON UPDATE SET NULL,
    CONSTRAINT FK_clients_trainer FOREIGN KEY (trainer_id) REFERENCES fit.trainers(id_trainer)ON DELETE SET NULL ON UPDATE CASCADE
);
GO

-- Тренировки
CREATE TABLE fit.workouts (
    id_workout INT PRIMARY KEY IDENTITY(1,1),
    client_id INT NOT NULL,
    trainer_id INT,  
    workout_date DATE NOT NULL,
    duration_minutes INT NOT NULL CHECK (duration_minutes > 0),
    notes VARCHAR(500),
    CONSTRAINT FK_workouts_client FOREIGN KEY (client_id) REFERENCES fit.clients(id_client) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_workouts_trainer FOREIGN KEY (trainer_id) REFERENCES fit.trainers(id_trainer) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO
INSERT INTO fit.membership_types (type_name_m, duration_months, price) VALUES
    ('Базовый', 1, 1500.00),      
    ('Стандарт', 3, 4000.00),     
    ('Премиум', 6, 7000.00),     
    ('VIP с тренером', 12, 12000.00); 
GO

-- 2. Заполнение справочника тренеров
INSERT INTO fit.trainers (first_name, last_name, specialization) VALUES
    ('Анна', 'Иванова', 'Йога и пилатес'),    
    ('Михаил', 'Петров', 'Силовые тренировки'), 
    ('Елена', 'Сидорова', 'Кардио и бег');     
GO

-- 3. Заполнение клиентов (ссылки на типы абонементов и тренеров; join_date указана явно для примера)
INSERT INTO fit.clients (first_name, last_name, email, phone, membership_type_id, trainer_id, join_date) VALUES
    ('Иван', 'Петров', 'ivan.petrov@mail.ru', '+7-999-123-45-67', 1, 1, '2025-11-15'),  -- Базовый, Анна
    ('Мария', 'Смирнова', 'maria.smirnova@yandex.ru', '+7-999-234-56-78', 2, 2, '2025-12-01'), -- Стандарт, Михаил
    ('Алексей', 'Козлов', 'alex.kozlov@gmail.com', NULL, 3, NULL, '2025-10-20'),         -- Премиум, без тренера
    ('Ольга', 'Васильева', 'olga.vas@yandex.ru', '+7-999-345-67-89', 2, 3, '2025-12-02'),   -- Стандарт, Елена
    ('Дмитрий', 'Морозов', 'dmitry.morozov@mail.ru', '+7-999-456-78-90', 4, 1, '2025-11-28'), -- VIP, Анна
    ('Екатерина', 'Новикова', 'ekaterina.novikova@gmail.com', '+7-999-567-89-01', 1, 2, '2025-12-03'); -- Базовый, Михаил
GO

-- 4. Заполнение тренировок (ссылки на клиентов и тренеров; даты в декабре 2025)
INSERT INTO fit.workouts (client_id, trainer_id, workout_date, duration_minutes, notes) VALUES
    (1, 1, '2025-12-01', 45, 'Первая йога-сессия, клиент в хорошей форме'),  -- Иван с Анной
    (1, 1, '2025-12-03', 60, 'Прогресс в позах, добавить растяжку'),         -- Иван с Анной
    (2, 2, '2025-12-02', 90, 'Силовая тренировка, фокус на ноги'),           -- Мария с Михаилом
    (3, 2, '2025-12-01', 30, 'Самостоятельный кардио на беговой дорожке'), -- Алексей без тренера (но trainer_id NULL? Подожди, в workouts trainer_id NOT NULL! Ошибка в схеме? Для примера использую тренера 3)
    (3, 3, '2025-12-01', 30, 'Самостоятельный кардио под присмотром'),       -- Исправлено: Алексей с Еленой
    (4, 3, '2025-12-03', 50, 'Кардио-интервалы, клиент устал на 40-й мин'),   -- Ольга с Еленой
    (5, 1, '2025-12-02', 75, 'VIP-сессия: йога + консультация'),             -- Дмитрий с Анной
    (6, 2, '2025-12-03', 40, 'Вводная силовая для новичка');                  -- Екатерина с Михаилом
GO

PRINT '===	Проверка таблиц до транзакции ==='
SELECT * FROM fit.membership_types;
SELECT * FROM fit.trainers;
SELECT * FROM fit.clients;
SELECT * FROM fit.workouts;
GO
-- Транзакция 1: УСПЕХ (COMMIT)
BEGIN TRANSACTION TransactionSuccess;
BEGIN TRY
    -- INSERT: Новый тип абонемента
    INSERT INTO fit.membership_types (type_name_m, duration_months, price) 
    VALUES ('Супер VIP', 24, 20000.00);  

    -- INSERT: Новый клиент с ссылкой на новый тип и тренера id=1
    DECLARE @NewClientId INT;
    INSERT INTO fit.clients (first_name, last_name, email, phone, membership_type_id, trainer_id, join_date) 
    VALUES ('Новый', 'Клиент', 'new@client.ru', '+7-999-999', @@IDENTITY, 1, GETDATE());  
    SET @NewClientId = SCOPE_IDENTITY();  --чтобы сработало

    -- UPDATE: Изменяем специализацию тренера id=1
    UPDATE fit.trainers 
    SET specialization = 'Йога + силовые' 
    WHERE id_trainer = 1;

    -- DELETE: Удаляем первую тренировку
    DELETE FROM fit.workouts WHERE id_workout = 1;

    COMMIT TRANSACTION TransactionSuccess;
    PRINT '=== COMMIT: УСПЕХ! Изменения зафиксированы ===';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION TransactionSuccess;
    PRINT '=== ОШИБКА! ===';
    PRINT 'Ошибка: ' + ERROR_MESSAGE();
END CATCH
GO

-- Результат после COMMIT (проверь: новый тип, новый клиент, обновлённый тренер, удалённая тренировка)
PRINT '===ПОСЛЕ COMMIT ===';
SELECT * FROM fit.membership_types;
SELECT * FROM fit.trainers;
SELECT * FROM fit.clients;
SELECT * FROM fit.workouts;
GO

--з--- Логины 

USE master;
GO



CREATE LOGIN Sidorovich WITH PASSWORD = 'qwerty';
GO
CREATE LOGIN Mechenyi WITH PASSWORD = 'qwerty2';
GO
CREATE LOGIN Tatyrzha WITH PASSWORD = 'qwerty3';
GO

-- Переключаемся в базу

USE fitness_club;
GO
CREATE USER Sidorovich FOR LOGIN Sidorovich;
GO
CREATE USER Mechenyi FOR LOGIN Mechenyi;
GO
CREATE USER Tatyrzha FOR LOGIN Tatyrzha;
GO
--------права(я бы как пошутил... но нельзя, практос ведь)
----

---- Сидорович: SELECT и INSERT только на workouts
GRANT SELECT ON fit.workouts TO Sidorovich;
GRANT INSERT ON fit.workouts TO Sidorovich;
GO

-- Меченый: Только SELECT на все таблицы 
GRANT SELECT ON fit.membership_types TO Mechenyi;
GRANT SELECT ON fit.trainers TO Mechenyi;
GRANT SELECT ON fit.clients TO Mechenyi;
GRANT SELECT ON fit.workouts TO Mechenyi;
GO

-- Татыржа: SELECT на все( Тоша заслужил )
GRANT SELECT ON fit.membership_types TO Tatyrzha;
GRANT SELECT ON fit.trainers TO Tatyrzha;
GRANT SELECT ON fit.clients TO Tatyrzha;
GRANT SELECT ON fit.workouts TO Tatyrzha;
GO

-- GRANT CREATE TABLE (для новых таблиц)
GRANT CREATE TABLE TO Tatyrzha;
GO

-- GRANT ALTER на существующие таблицы (ALTER структуру)
GRANT ALTER ON fit.membership_types TO Tatyrzha;
GRANT ALTER ON fit.trainers TO Tatyrzha;
GRANT ALTER ON fit.clients TO Tatyrzha;
GRANT ALTER ON fit.workouts TO Tatyrzha;
GO

------------------зырим на права
BEGIN TRY
    EXECUTE AS USER = 'Sidorovich';
    PRINT '--- Сидорович: SELECT из workouts ---';
    SELECT COUNT(*) AS WorkoutCount FROM fit.workouts;
    
    PRINT '--- Сидорович: INSERT в workouts ---';
    INSERT INTO fit.workouts (client_id, trainer_id, workout_date, duration_minutes, notes) 
    VALUES (1, 1, '2025-12-04', 30, 'Сидору пора худеть...');
    SELECT COUNT(*) AS NewWorkoutCount FROM fit.workouts;
    
    PRINT '--- Сидорович: SELECT из clients ---';
    SELECT COUNT(*) FROM fit.clients; 
END TRY
BEGIN CATCH ---- для красаты ыыыыыыыыыыы)
    PRINT 'Сидорович: Ошибка: ' + ERROR_MESSAGE();
END CATCH
REVERT;
GO
BEGIN TRY
    EXECUTE AS USER = 'Mechenyi';
    PRINT '--- Меченый: SELECT из workouts ---';
    SELECT COUNT(*) AS WorkoutCount FROM fit.workouts;
    
    PRINT '--- Меченый: SELECT из clients ---';
    SELECT COUNT(*) AS ClientCount FROM fit.clients;
    
    PRINT '--- Меченый: INSERT в workouts ---';
    INSERT INTO fit.workouts (client_id, trainer_id, workout_date, duration_minutes, notes) 
	VALUES (1, 1, '2025-12-05', 60, 'Тест');  
END TRY
BEGIN CATCH
    PRINT 'Меченый: Ошибка: ' + ERROR_MESSAGE();
END CATCH
REVERT;
GO
BEGIN TRY
EXECUTE AS USER = 'Tatyrzha';
    PRINT '--- Татыржа: SELECT из clients ---';
    SELECT COUNT(*) AS ClientCount FROM fit.clients;
    
    PRINT '--- Татыржа: ALTER TABLE workouts ---';
    ALTER TABLE fit.workouts ADD extra_notes NVARCHAR(100);
    SELECT * FROM fit.workouts
    
    PRINT '--- Татыржа: CREATE TABLE ---';
    CREATE TABLE test_table (
		id INT PRIMARY KEY IDENTITY(1,1),
		test_col VARCHAR(50)
		);
    SELECT COUNT(*) AS TablesCount FROM sys.tables WHERE name = 'test_table'; ---- крутой способ найти таблицу
    
    PRINT '--- Татыржа: INSERT в workouts ---';
    INSERT INTO fit.workouts (client_id, trainer_id, workout_date, duration_minutes, notes) 
	VALUES (1, 1, '2025-12-06', 75, 'Тест');
    
END TRY
BEGIN CATCH
    PRINT 'Татыржа: Ошибка: ' + ERROR_MESSAGE();
END CATCH
REVERT;
GO
---------------------- импортим емае и т д 
EXEC sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
EXEC sp_configure 'xp_cmdshell', 1;
GO
RECONFIGURE;
GO
--- экспорт 
USE fitness_club;
GO
EXEC xp_cmdshell 'bcp fitness_club.fit.workouts out "C:\Users\Public\PW6.csv" -w -t, -T -S BENITO\SQLEXPRESS';
GO

EXEC xp_cmdshell 'bcp fitness_club.fit.workouts out "C:\Users\Public\Documents\owners.csv" -w -t"," -T -S BENITO\SQLEXPRESS';
GO

----импорт
DELETE FROM fit.workouts;  -- Очистим для импорта
EXEC xp_cmdshell 'bcp fitness_club.fit.workouts in "C:\Users\Public\PW6.csv" -w -t, -T -S BENITO\SQLEXPRESS';
GO
SELECT * FROM fit.workouts;  -- Должны вернуться данные
GO

----------------------------- бекапы
USE master;
GO
BACKUP DATABASE fitness_club TO DISK = 'C:\Users\Public\fitness_club.bak'
GO
------------ удаляем БД
USe fitness_club;
GO
DROP TABLE fit.workouts;
DROP TABLE fit.clients;
DROP TABLE fit.trainers;
DROP TABLE fit.membership_types;
GO
USE master;
GO
DROP DATABASE fitness_club;
GO
----- Возвращаем БД
RESTORE DATABASE fitness_club FROM DISK = 'C:\Users\Public\fitness_club.bak'
GO




----Дропы, ну по базе, когда не было то?
USE fitness_club;
GO
DROP TABLE fit.workouts;
DROP TABLE fit.clients;
DROP TABLE fit.trainers;
DROP TABLE fit.membership_types;
GO
