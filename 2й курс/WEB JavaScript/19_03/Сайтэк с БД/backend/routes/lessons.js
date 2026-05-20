const express = require('express');
const router = express. Router();
const pool = require('../db');

// Получить все уроки
router.get('/lessons', async (req, res) => {// гетер
//     try { 
//         const result = await pool.query(`
//             SELECT
//                 l.id,
//                 l.title,
//                 l.description,
//                 u.full_name AS teacher_name
//             FROM lessons l
//             LEFT JOIN users u ON 1.teacher_id = u.id
//             ORDER BY l.id
//         `)

//     res.json(result.rows);
//   } catch (error) {
//     console.error(error);
//     res.status(500).json({ error: 'Ошибка получения уроков' });
//   }
try {// запрос в бд через как раз таки файлик

        const result = await pool.query(`
            SELECT c.id, c.title, c.description, u.full_name AS teacher_name 
            FROM courses c 
            LEFT JOIN users u ON c.teacher_id = u.id 
            ORDER BY c.id
        `);
        res.json(result.rows); // возвращаем cтроки из бд как json
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Ошибка получения курсов' });
    }
});

// Получить расписание
router.get('/schedule', async (req, res) => {
    // try {
    //     const result = await pool. query(`
    //         SELECT
    //         s.id,
    //         l.title AS lesson_title,
    //         l.description,
    //         u.full_name AS teacher_name,
    //         s.lesson_date,
    //         s.lesson_time,
    //         s.room
    //         FROM schedule s
    //         JOIN lessons l ON s.lesson_id = l.id
    //         LEFT JOIN users u ON l.teacher_id = u.id
    //         ORDER BY s.lesson_date, s.lesson_time
    //     `);

    //     res.json(result.rows);
    //   } catch (error) {
    //     console.error(error);
    //     res.status(500). json({ error: 'Ошибка получения расписания' });
    //   }
    try {

        const result = await pool.query(`
            SELECT 
                s.id, 
                c.title AS lesson_title, 
                c.description, 
                u.full_name AS teacher_name, 
                s.lesson_date, 
                s.lesson_time
            FROM schedule s 
            JOIN courses c ON s.course_id = c.id 
            LEFT JOIN users u ON s.teacher_id = u.id 
            ORDER BY s.lesson_date, s.lesson_time
        `);
        res.json(result.rows);
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: 'Ошибка получения расписания' });
    }
});

module.exports = router;