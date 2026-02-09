-- Создание базы данных 
CREATE DATABASE order_zakazi
GO
USE order_zakazi;
GO

-- Таблица Город (city)
CREATE TABLE city (
    id_city INT PRIMARY KEY IDENTiTY (1,1),
    city_name VARCHAR(30) NOT NULL UNIQUE
);
GO

-- Таблица Адрес (address_customer)
CREATE TABLE address_customer (
    id_address INT PRIMARY KEY IDENTiTY (1,1),
    street VARCHAR(30) NOT NULL,
    house INT NOT NULL,
    city_id INT NOT NULL,
    FOREIGN KEY (city_id) REFERENCES city(id_city)
);
GO

-- Таблица Клиент (customer)
CREATE TABLE customer (
    id_customer INT PRIMARY KEY IDENTiTY (1,1),
    name_c VARCHAR(100) NOT NULL,
    address_id INT NOT NULL, 
    FOREIGN KEY (address_id) REFERENCES address_customer(id_address)
);
GO

-- Таблица Изделие (product_order)
CREATE TABLE product_order (
    id_product INT PRIMARY KEY IDENTiTY (1,1),
    title VARCHAR(15) NOT NULL UNIQUE
);
GO

-- Таблица Цвет (colour)
CREATE TABLE colour (
    id_colour INT PRIMARY KEY IDENTiTY (1,1),
    title VARCHAR(25) NOT NULL UNIQUE
);
GO

-- Таблица Размер (size)
CREATE TABLE size (
    id_size INT PRIMARY KEY IDENTiTY (1,1),
    title VARCHAR(5) NOT NULL UNIQUE
);
GO

-- Таблица Статус (status)
CREATE TABLE status_order (
    id_status INT PRIMARY KEY IDENTiTY (1,1),
    status_name VARCHAR(40) NOT NULL UNIQUE
);
GO

-- Таблица Ответственный (employees)
CREATE TABLE employees (
    id_employees INT PRIMARY KEY IDENTiTY (1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    middle_name VARCHAR(50)
);
GO

-- Таблица Заказы (order)
CREATE TABLE order_zakaz (
    id_order INT PRIMARY KEY IDENTiTY (1,1),	
    date_order DATE NOT NULL CHECK(LEN (date_order) > 0),
    id_customer INT NOT NULL,
    id_status INT NOT NULL,
    id_employees INT NOT NULL,
    FOREIGN KEY (id_customer) REFERENCES customer(id_customer),
    FOREIGN KEY (id_status) REFERENCES status_order(id_status),
    FOREIGN KEY (id_employees) REFERENCES employees(id_employees),
	id_product INT NOT NULL,
	id_colour INT NOT NULL,
	FOREIGN KEY (id_colour) REFERENCES colour(id_colour),
    FOREIGN KEY (id_product) REFERENCES product_order(id_product)
);
GO
-- Таблица Конфигурация изделия (order_configuration)
CREATE TABLE order_configuration (
    id_order_configuration INT PRIMARY KEY IDENTiTY (1,1),
	quantity INT NOT NULL,
	unit VARCHAR(10) NOT NULL,
    id_size INT NOT NULL,
	id_order INT NOT NULL,
    FOREIGN KEY (id_size) REFERENCES size(id_size),
	FOREIGN KEY (id_order) REFERENCES order_zakaz(id_order)
);
GO
   



-- Добавление данных в таблицы


  

-- Таблица Город (city)
INSERT INTO city(city_name)
VALUES
	('Москва'),
	('Казунь'),
	('Мухосранск'),
	('Чуктово')
GO
-- Таблица Адрес (address_customer)
INSERT INTO address_customer(street,house,city_id)
VALUES
	('Ленина',30,1),
	('Незнаюкакая',52,2),
	('Баумана',7,1),
	('Проспект мира',5,3),
	('Академика Янгеля',66,3)
GO
-- Таблица Клиент (customer)
INSERT INTO customer (name_c, address_id)
VALUES
	('ООО Стиль',1),
	('ИП Иванов',2),
	('ООО "Модник"',3),
	('ИП Парамонова',2),
	('ООО "Дениска"',4),
	('ООО КакЖить',1)
GO
-- Таблица Изделие (product_order)
INSERT INTO product_order(title)
VALUES
	('Платье'),
	('Рубашка'),
	('Юбвывфыка'),
	('Футболка'),
	('Брюки'),
	('Пиджак'),
	('Куртка кожаная'),
	('Майка')
GO
-- Таблица Цвет (colour)
INSERT INTO colour(title)
VALUES
	('Красный'),
	('Белый'),
	('Голубой'),
	('Черный'),
	('Серый'),
	('Фиолетовый')
GO
-- Таблица Размер (size)
INSERT INTO size(title)
VALUES
	('XM'),
	('S'),
	('L'),
	('XxL')
GO
-- Таблица Статус (status)
INSERT INTO status_order
VALUES
	('В работе'),
	('Уже завершен'),
	('В ожидании'),
	('Не принят')
GO
-- Таблица Ответственный (employees)
INSERT INTO employees(first_name,last_name,middle_name)
VALUES
	('Сергей','Петров','Филипович'),
	('Москва','Сидоров',NULL),
	('Анатолий','Дроздов','Павлович'),
	('Денис','Баранов','Сергеевич'),
	('Никита','Романов','Алексеевич'),
	('Харитон','Москвин','Ивановоич')
GO
-- Таблица Заказы (order)
INSERT INTO order_zakaz(date_order,id_customer, id_status, id_employees, id_product, id_colour)
VALUES
	('2025-08-13',1,2,1,1,1),
	('2025-07-03',2,2,2,2,2),
	('2025-08-06',3,3,3,3,3),
	('2025-08-16',4,1,3,4,4),
	('2025-08-13',1,1,5,5,4),
	('2025-07-03',2,1,6,6,5),
	('2025-08-06',3,1,3,7,4),
	('2025-08-16',4,2,3,5,4),
	('2025-08-16',4,1,2,5,4),
	('2025-09-04',5,1,2,2,4)
GO
-- Таблица Конфигурация изделия (order_configuration)
INSERT INTO order_configuration(quantity,unit,id_size,id_order)
VALUES
	(50,'Штука',3,1),
	(50,'Штука',1,2),
	(100,'Штука',1,2),
	(100,'Штука',2,2),
	(150,'Штука',3,3),
	(100,'Штука',1,4),
	(100,'Штука',2,4),
	(50,'Штука',1,5),
	(70,'Штука',1,6),
	(30,'Штука',2,7),
	(100,'Штука',3,8),
	(70,'Штука',2,10),
	(100,'Штука',2,10),
	(1000,'Штука',3,10)
GO



--Обновление данных



UPDATE city
SET city_name = 'Казань' -- так мы заменим все имена
WHERE id_city = 2;
GO
UPDATE address_customer
SET house = '10' -- так мы заменим все имена
WHERE id_address = 1;
GO
UPDATE customer
SET name_c = 'ООО Дениска Бээээ' -- так мы заменим все имена
WHERE id_customer = 5;
GO
UPDATE product_order
SET title = 'Юбка' -- так мы заменим все имена
WHERE id_product = 3;
GO
UPDATE colour
SET title = 'Светло-голубой' -- так мы заменим все имена
WHERE id_colour = 2;
GO
UPDATE size
SET title = 'M' -- так мы заменим все имена
WHERE id_size = 1;
GO
UPDATE status_order
SET status_name = 'Завершено' -- так мы заменим все имена
WHERE id_status = 2;
GO
UPDATE employees
SET first_name = 'Антон' -- так мы заменим все имена
WHERE id_employees = 2;
GO
UPDATE order_zakaz
SET id_status = 1  -- так мы заменим все имена
WHERE id_order = 1;
GO
UPDATE order_configuration
SET id_order = 1  -- так мы заменим все имена
WHERE id_order_configuration = 2;
GO


-- удаление данных
DELETE FROM order_configuration
WHERE id_order_configuration = 14;
GO
DELETE FROM order_zakaz
WHERE id_order = 9;
GO
DELETE FROM employees
WHERE id_employees = 4;
GO
DELETE FROM status_order
WHERE id_status = 4;
GO
DELETE FROM size
WHERE id_size = 4;
GO
DELETE FROM colour
WHERE id_colour = 6;
GO
DELETE FROM product_order
WHERE id_product = 8;
GO
DELETE FROM customer
WHERE id_customer = 6;
GO
DELETE FROM address_customer
WHERE id_address = 5;
GO
DELETE FROM city
WHERE id_city = 4;
GO



-- показать таблицы
SELECT * FROM city
GO
SELECT * FROM address_customer
GO
SELECT * FROM customer
GO
SELECT * FROM product_order
GO
SELECT * FROM colour
GO
SELECT * FROM size
GO
SELECT * FROM status_order
GO
SELECT * FROM employees
GO
SELECT * FROM order_zakaz
GO
SELECT * FROM order_configuration
GO
------------------------------------------------------------------------------------------------	- Создание представлений 


------INNER JOIN - количество изделий для каждого заказа.
CREATE VIEW vw_OrderQuantities AS
SELECT o.id_order, SUM(oc.quantity) AS TotalQuantity
FROM order_zakaz o
INNER JOIN order_configuration oc ON o.id_order = oc.id_order
GROUP BY o.id_order;
GO


-----------LEFT JOIN - Все клиенты с количеством заказов
CREATE VIEW vw_CustomersWithOrders AS
SELECT c.id_customer, c.name_c, COUNT(o.id_order) AS OrderCount
FROM customer c
LEFT JOIN order_zakaz o ON c.id_customer = o.id_customer
GROUP BY c.id_customer, c.name_c;
GO


------RIGHT JOIN -статусы заказов и количество заказов по каждому
CREATE VIEW vw_StatusWithOrders AS
SELECT s.id_status, s.status_name, COUNT(o.id_order) AS OrderCount
FROM order_zakaz o
RIGHT JOIN status_order s ON o.id_status = s.id_status
GROUP BY s.id_status, s.status_name;
GO


----------- Демонстрация представлений
SELECT * FROM vw_OrderQuantities;
GO
SELECT * FROM vw_CustomersWithOrders;
GO
SELECT * FROM vw_StatusWithOrders;
GO


 ------------------------------------------------------------------------------------------- Создание процедур
--Добавление нового клиента с адресом
CREATE PROCEDURE sp_AddCustomer
@name VARCHAR(100),
@street VARCHAR(30),
@house INT,
@city_name VARCHAR(30)
AS
BEGIN
DECLARE @city_id INT, @addr_id INT;
SELECT @city_id = id_city FROM city WHERE city_name = @city_name;
IF @city_id IS NULL
BEGIN
INSERT INTO city(city_name) 
VALUES (@city_name);
SET @city_id = SCOPE_IDENTITY();
END
INSERT INTO address_customer(street, house, city_id) 
VALUES (@street, @house, @city_id);
SET @addr_id = SCOPE_IDENTITY();
INSERT INTO customer(name_c, address_id) VALUES (@name, @addr_id);
END
GO
--------- Обновление статуса заказа
CREATE PROCEDURE sp_UpdateOrderStatus
@order_id INT,
@new_status_name VARCHAR(40)
AS
BEGIN
DECLARE @status_id INT;
SELECT @status_id = id_status FROM status_order WHERE status_name = @new_status_name;
IF @status_id IS NOT NULL
BEGIN
UPDATE order_zakaz SET id_status = @status_id WHERE id_order = @order_id;
END
ELSE
BEGIN
RAISERROR('Статус не найден', 16, 1);
END
END
GO
---------------Получение заказов по диапазону дат
CREATE PROCEDURE sp_GetOrdersByDate
@start_date DATE,
@end_date DATE
AS
BEGIN
SELECT * FROM order_zakaz WHERE date_order BETWEEN @start_date AND @end_date;
END
GO
-- Демонстрация процедур
EXEC sp_GetOrdersByDate '2025-07-01', '2025-09-01';
GO
-- Пример добавления (добавит данные, но для демо)
EXEC sp_AddCustomer 'Тест Компания', 'Тест Улица', 1, 'Москва';
GO
-- Пример обновления
EXEC sp_UpdateOrderStatus 1, 'Завершено';
GO


-- Создание триггеров
------=--------------------------------------------------------------------------Проверка на пустое имя при вставке клиента
CREATE TRIGGER tr_CustomerInsert
ON customer
FOR INSERT
AS
BEGIN
IF EXISTS (SELECT 1 FROM inserted WHERE LEN(LTRIM(RTRIM(name_c))) = 0)
BEGIN
RAISERROR('Имя клиента не может быть пустым', 16, 1);
ROLLBACK TRANSACTION;
END
END
GO
----обновление статуса заказа
CREATE TRIGGER tr_OrderStatusUpdate
ON order_zakaz
AFTER UPDATE
AS
BEGIN
IF UPDATE(id_status)
BEGIN
IF EXISTS (
SELECT 1 FROM inserted i
INNER JOIN deleted d ON i.id_order = d.id_order
WHERE i.id_status = (SELECT id_status FROM status_order WHERE status_name = 'Завершено')
AND d.id_status != i.id_status
)
BEGIN
PRINT 'Заказ завершен!';
END
END
END
GO
---удаление конфигураций при удалении заказа
CREATE TRIGGER tr_OrderDelete
ON order_zakaz
INSTEAD OF DELETE
AS
BEGIN
DELETE FROM order_configuration WHERE id_order IN (SELECT id_order FROM deleted);
DELETE FROM order_zakaz WHERE id_order IN (SELECT id_order FROM deleted);
END
GO
--------------------------------------------------------------------------------------------------- Демонстрация триггеров (простая вставка для tr_CustomerInsert, обновление для tr_OrderStatusUpdate, удаление для tr_OrderDelete)
-- Вставка (имя не пустое, пройдет)
INSERT INTO customer (name_c, address_id) VALUES ('Тест Клиент', 1);
GO
-- Обновление статуса (уже сделано выше, но для демо)
UPDATE order_zakaz SET id_status = (SELECT id_status FROM status_order WHERE status_name = 'Завершено') WHERE id_order = 2;
GO
-- Удаление (использует триггер)
DELETE FROM order_zakaz WHERE id_order = 10;
GO




----------- функции 




CREATE FUNCTION fn_GetCustomerFullAddress (@customer_id INT)
RETURNS VARCHAR(200)
AS
BEGIN
    DECLARE @address VARCHAR(200);
    
    SELECT @address = CONCAT(
        city.city_name, ', ',
        ac.street, ', ',
        ac.house
    )
    FROM customer c
    INNER JOIN address_customer ac ON c.address_id = ac.id_address
    INNER JOIN city ON ac.city_id = city.id_city
    WHERE c.id_customer = @customer_id;
    
    RETURN ISNULL(@address, 'Адрес не найден');
END
GO
SELECT name_c
FROM customer
WHERE dbo.fn_GetCustomerFullAddress(id_customer) LIKE '%Москва%';
Go



CREATE FUNCTION fn_GetOrderTotalQuantity (@order_id INT)
RETURNS INT
AS
BEGIN
    DECLARE @total INT = 0;
    
    SELECT @total = SUM(quantity)
    FROM order_configuration
    WHERE id_order = @order_id;
    
    RETURN ISNULL(@total, 0);
END
GO


-- Найти заказы с количеством больше 100
SELECT id_order
FROM order_zakaz
WHERE dbo.fn_GetOrderTotalQuantity(id_order) > 100;
GO



CREATE FUNCTION fn_GetEmployeeFullName (@order_id INT)
RETURNS VARCHAR(150)
AS
BEGIN
    DECLARE @fio VARCHAR(150);
    
    SELECT @fio = CONCAT(
        e.last_name, ' ',
        e.first_name,
        CASE WHEN e.middle_name IS NOT NULL THEN ' ' + e.middle_name ELSE '' END
    )
    FROM order_zakaz o
    INNER JOIN employees e ON o.id_employees = e.id_employees
    WHERE o.id_order = @order_id;
    
    RETURN ISNULL(@fio, 'Сотрудник не назначен');
END
GO

-- Удаление таблиц (в обратном порядке создания для избежания нарушений FOREIGN KEY)




DROP TABLE  order_configuration;-- Таблица Конфигурация изделия (product_configuration)
GO
DROP TABLE  order_zakaz;-- Таблица Заказы (order_zakaz)
GO
-- Таблица Ответственный (employees)
DROP TABLE  employees;
GO
-- Таблица Статус (status_order)
DROP TABLE  status_order;
GO
-- Таблица Размер (size)
DROP TABLE  size;
GO
-- Таблица Цвет (colour)
DROP TABLE  colour;
GO
-- Таблица Изделие (product_order)
DROP TABLE  product_order;
GO
-- Таблица Клиент (customer)
DROP TABLE  customer;
GO
-- Таблица Адрес (address_customer)
DROP TABLE  address_customer;
GO
-- Таблица Город (city)
DROP TABLE  city;
GO
-- Удаление базы данных
USE master;
GO
DROP DATABASE  order_zakazi;

