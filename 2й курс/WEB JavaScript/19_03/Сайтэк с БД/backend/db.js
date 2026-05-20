// backend/db.js
const { Pool } = require('pg'); // подключаем в работу апиху постгре
require('dotenv').config();// берем настройки авторизации из нашего енв

// Принудительно преобразуем все параметры в строки 
// тут я ниче не менял, а комменты дают все понять, хотрошо что их списал
const config = {
    host: String(process.env.DB_HOST || 'localhost'),
    port: parseInt(process.env.DB_PORT || '5432', 10),
    user: String(process.env.DB_USER || 'postgres'),
    password: String(process.env.DB_PASSWORD || ''), // Ключевая строка!
    database: String(process.env.DB_NAME || 'postgres'),
};

// Для отладки (уберите после решения проблемы)
console.log('DB Config:', {
    host: config.host,
    port: config.port,
    user: config.user,
    database: config.database,
    hasPassword: !!config.password// знаки для обязательности 
});

const pool = new Pool(config);// включаем наши настройки в наш пул 

// Проверка подключения
pool.connect((err, client, release) => {
    if (err) {
        console.error('❌ Ошибка подключения к БД:', err.message);
        console.error('Проверьте пароль в файле .env');
    } else {
        console.log('✅ Успешное подключение к PostgreSQL');
        release();// я так онял для возвратв из бд соединениЯ
    }
});

module.exports = pool; // я так понял это так же как автаризацитя, чтобы был обмен между js файлмаи 