const express = require('express'); // знаем
const router = express.Router();// штука для марщ=шрутизации, как говорит интернет, вместо апп из сервера можно использовать константу, в которую он импортирован.
// именно ждя этого мы делали  const authRoutes = require('./routes/auth')
const pool = require('../db');// подклюбчаем  бд из файлика для подключения

// Регистрация
router.post('/register', async (req, res) => { // ну это пост запрос, асинхронный, работает с файлом register
    // try {
    // const { full_name, email, login, password, role } = req.body;

    // const result = await pool.query(
    // 'SELECT register_user($1, $2, $3, $4, $5) AS message',
    // [full_name, email, login, password, role]
    // );

    // res.json({ message: result.rows[0].message });
    // } catch (error) {
    // console.error(error);
    // res.status(500).json({ error: 'Ошибка регистрации' });
    // }


    try {
        const { full_name, email, login, password, role } = req.body; // тут теория про запрос пользователя вошла в чат, ищем все из запроса пользователя в теге body


        const roleResult = await pool.query('SELECT id FROM roles WHERE name = $1', [role]); // ждем пога из бд будут через селект вытащена роль(ее пйди,ищим по имени), често селекты дело гпт) но я понял что это все отправляется в бд

        if (roleResult.rows.length === 0) {
            return res.status(400).json({ error: 'Неверная роль' });// это проверка на то, еслт ли роль
        }
        
        const role_id = roleResult.rows[0].id;// проверка прошла, принимаем роль


        const checkUser = await pool.query('SELECT id FROM users WHERE login = $1 OR email = $2', [login, email]);
        if (checkUser.rows.length > 0) {
            return res.status(400).json({ error: 'Логин или Email уже заняты' }); // крутая проверка, я о ней потом пожалел, забыл пороли от пользователей с почтами, приходится вводить рандом почтны
        }


        await pool.query(// авайт кстати изза асинхронной функции, чтобы сервер ждал ее
            'INSERT INTO users (full_name, email, login, password, role_id) VALUES ($1, $2, $3, $4, $5)', // еще запрос в бд, добавляем в табличку нового человека, непонимаю значения долларов
            [full_name, email, login, password, role_id]
        );// я переборол лень, гпт сделала правильно, это безопасная вставка, чтобы не делать "фвыфыв" + [sdadas] , звучит как хайп
        res.json({ message: 'Регистрация успешна' });

    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Ошибка регистрации' });
    }
});

// Авторизация
router.post('/login', async (req, res) => {// тут уже легче, разобрался с остальным
    // try {
    //     const { login, password } = req.body;

    //     const result = await pool.query(
    //     'SELECT * FROM authorize_user($1, $2)',
    //     [login, password]
    // );

    //     const user = result.rows[0];

    //     if (!user || !user.id) {
    //         return res.status(401).json({ message: 'Неверный логин или пароль' });
    //     }

    //     res.json({
    //         message: user.auth_status,
    //         user: {
    //             id: user.user_id,
    //             full_name: user.full_name,
    //             email: user.email,
    //             role: user.role
    //         }
    //     });
    // } catch (error) {
    //     console.error(error);
    //     res.status(500).json({ error: 'Ошибка авторизации' });
    // }
     try {
        const { login, password } = req.body;

        // Ищем пользователя и сразу берем название роли через JOIN
        const result = await pool.query(`
            SELECT u.id, u.full_name, u.email, r.name as role 
            FROM users u
            JOIN roles r ON u.role_id = r.id
            WHERE u.login = $1 AND u.password = $2
        `, [login, password]);

        const user = result.rows[0]; // принимаем первую же строку

        if (!user) {
            return res.status(401).json({ message: 'Неверный логин или пароль' });// ошибочка если не получилось, тема с id в html мне нравится
        }

        res.json({// отправляем все назад, вот типо у нас же есть статус юзера, чтобы там оно и было, ну и для процекссов других
            message: 'Вход выполнен',
            user: {
                id: user.id,
                full_name: user.full_name,
                email: user.email,
                role: user.role 
            }
        });

    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Ошибка авторизации' });
    }
});

    module.exports = router;// ээта штука делает прикол, мы же импортируем роутер только суда, его другие не видят, и его данные, чтобы он работал мы оброщаемся к непонятной модели, и иотпровляемв нее наш роутер
    // а что это за модель - незнаю, но факт const authRoutes = require('./routes/auth') без этого ниче не подключает, не принимает