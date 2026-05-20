const API_URL = "http://localhost:3000/api"; // это нащ адрес бекенда




async function registerUser(event) {
    event.preventDefault();// эта штучка очень важная, без нее запросы обрабатуюся формой, а не js, нам же наверное надо js

    const full_name = document.getElementById('full_name').value;
    const email = document.getElementById('email').value;
    const login = document.getElementById('login').value;
    const password = document.getElementById('password').value;
    const role = document.getElementById('role').value;

    try {
        const response = await fetch(`${API_URL}/auth/register`, {// это отправка запроса  http 
            method: 'POST',// тип метода
            headers: { 'Content-Type': 'application/json' }, // это чтука говорит, что тело запроса будет js 
            body: JSON.stringify({ full_name, email, login, password, role })// конвертирует данные в json  строчку
        });

        const data = await response.json(); // чтение от бека 

        document.getElementById('message').textContent =        
            data.message || data.error || 'Ошибка регистрации';

        if (response.ok && data.message === 'Регистрация успешна') {
            setTimeout(() => {// ПРОСТО отлаживаем выполнение
                window.location.href = 'login.html';// это как ридерект ту акшет в аспе
            }, 1000);// сколько ждать 
        }
    } catch (error) {
        console.error('Ошибка подключения к серверу:', error);
        document.getElementById('message').textContent =
            'Сервер недоступен. Проверь, запущен ли backend.';
    }
}




async function loginUser(event) {
    event.preventDefault();

    const login = document.getElementById('login').value;
    const password = document.getElementById('password').value;

    try {
        const response = await fetch(`${API_URL}/auth/login`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ login, password })
        });

        const data = await response.json();

        if (response.ok) {
            localStorage.setItem('user', JSON.stringify(data.user));// это как куки, говорим браузеру сохранить наш юзер

            document.getElementById('message').textContent =// меняем сообзене, опять
                `Добро пожаловать, ${data.user.full_name} (${data.user.role})`;

            setTimeout(() => {
                window.location.href = 'index.html';
            }, 1000);
        } else {
            document.getElementById('message').textContent =
                data.message || data.error || 'Ошибка входа';
        }

    } catch (error) {
        console.error('Ошибка подключения к серверу:', error);
        document.getElementById('message').textContent =
            'Сервер недоступен. Проверь, запущен ли backend.';
    }
}


// =========================
// Проверка авторизации
// =========================

function getCurrentUser() {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
}

function requireAuth() {
    const user = getCurrentUser();

    if (!user) {
        alert('Сначала войдите в аккаунт.');// всплывающее окошко 
        window.location.href = 'login.html';
        return false;
    }

    return true;
}

function logout() {
    localStorage.removeItem('user');
    window.location.href = 'login.html';
}

// =========================
// Показ текущего пользователя
// =========================

function showUserInfo() {
    const userBlock = document.getElementById('user-info');
    if (!userBlock) return;

    const user = getCurrentUser();
    if (user) {
    userBlock.innerHTML = `
        <p><strong>Пользователь:</strong> ${user.full_name}</p>
        <p><strong>Роль:</strong> ${user.role}</p>
        <button onclick="logout()">Выйти</button>
    `;
} else {
    userBlock.innerHTML = `
        <p>Вы не вошли в систему</p>
        <a href="login.html">Войти</a>
    `;
}
}

// =========================
// Загрузка уроков
// =========================

async function loadLessons() {
    if (!requireAuth()) return;

    try {
        const response = await fetch(`${API_URL}/lessons`);
        const lessons = await response.json();

        const container = document.getElementById('lessons-list');
        if (!container) return;

        container.innerHTML = '';

        lessons.forEach((lesson) => {
            container.innerHTML += `
                <div class="card">
            <div> 
                <img class="sas" src="https://i.pinimg.com/736x/11/95/27/11952703558635c705d0a8aefe0e5cd1.jpg" alt="📚">
                <h3>${lesson.title}</h3>
                <p>${lesson.description || 'Нет описания'}</p>
                <p><strong>Преподаватель:</strong> ${lesson.teacher_name || 'Не назначен'}</p>
            </div>
        </div>
            `;
        });

    } catch (error) {
        console.error('Ошибка загрузки уроков:', error);

        const container = document.getElementById('lessons-list');
        if (container) {
            container.innerHTML = '<p>Не удалось загрузить уроки.</p>';
        }
    }
}


// рассписание
async function loadSchedule() {
    if (!requireAuth()) return;

    try {
        const response = await fetch(`${API_URL}/schedule`);
        const schedule = await response.json();

        const container = document.getElementById('schedule-list');
        if (!container) return;

        container.innerHTML = '';

        schedule.forEach((item) => {
            container.innerHTML += `
                <div class="card">
            <div> 
                <img class="sas" src="https://i.pinimg.com/736x/11/95/27/11952703558635c705d0a8aefe0e5cd1.jpg" alt="📅">
                <h3>${item.lesson_title}</h3>
                <p>${item.description || 'Нет описания'}</p>
                <p><strong>Преподаватель:</strong> ${item.teacher_name || 'Не назначен'}</p>
                <p><strong>📅 ${item.lesson_date} в ${item.lesson_time}</strong></p>
            </div>
        </div>
            `;
        });
    } catch (error) {
        console.error('Ошибка загрузки расписания:', error);

        const container = document.getElementById('schedule-list');
        if (container) {
            container.innerHTML = '<p>Не удалось загрузить расписание.</p>';
        }
    }
}
document.addEventListener('DOMContentLoaded', () => {// эта штука делает так, чтобы сначала загрузилось все, а потом уже работал скрипт, а иначе может на рандом выйти нул
    showUserInfo();


if (document.getElementById('lessons-list')) {// говорим чтобы сразу загружались списки, как только html загрузится и js его увидит
    loadLessons();
}

if (document.getElementById('schedule-list')) {
    loadSchedule();
}
});
