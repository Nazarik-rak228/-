const taskInput = document.getElementById("taskInput")
const addButton = document.getElementById("addButton")
const searchInput = document.getElementById("searchInput")
const taskCount = document.getElementById("taskCount")
const message = document.getElementById("message")
const column = document.querySelectorAll(".taskList")

let task = JSON.parse(localStorage.getItem("task"))

if(task === null){
    task = []
}

function saveTask(){

    localStorage.setItem(
        "task",
        JSON.stringify(task)
    )

}

function showMessage(text){

    message.textContent = text

    setTimeout(() => {

        message.textContent = ""

    }, 2000)

}

function updateCount(){

    taskCount.textContent = task.length

}

function createTask(taskData){

    const taskCard = document.createElement("div")

    taskCard.classList.add("task")

    taskCard.draggable = true

    taskCard.dataset.id = taskData.id

    const title = document.createElement("p")

    title.textContent = taskData.text

    const status = document.createElement("small")

    let statusText = ""

    if(taskData.status === "inPlane"){
        statusText = "В планах"
    }

    if(taskData.status === "progress"){
        statusText = "Выполняю"
    }

    if(taskData.status === "inInspect"){
        statusText = "На проверке"
    }

    if(taskData.status === "done"){
        statusText = "Готово"
    }

    status.textContent = "Статус: " + statusText

    const deleteButton = document.createElement("button")

    deleteButton.textContent = "Удалить"

    deleteButton.addEventListener("click", () => {

        deleteTask(taskData.id)

    })

    title.addEventListener("dblclick", () => {

        const newText = prompt(
            "Редактировать задачу",
            taskData.text
        )

        if(newText){

            taskData.text = newText

            saveTask()

            renderTask()

            showMessage("Задача изменена")

        }

    })

    taskCard.addEventListener("dragstart", () => {

        taskCard.classList.add("dragging")

    })

    taskCard.addEventListener("dragend", () => {

        taskCard.classList.remove("dragging")

    })

    taskCard.appendChild(title)

    taskCard.appendChild(status)

    taskCard.appendChild(deleteButton)

    return taskCard

}

function renderTask(filter = ""){

    column.forEach(column => {

        column.innerHTML = ""

    })

    task.forEach(taskData => {

        if(
            !taskData.text
            .toLowerCase()
            .includes(filter.toLowerCase())
        ){
            return
        }

        const taskElement = createTask(taskData)

        document
            .getElementById(taskData.status)
            .appendChild(taskElement)

    })

    updateCount()

}

function addTask(){

    const text = taskInput.value.trim()

    if(text === ""){

        showMessage("Введите задачу")

        return

    }

    const newTask = {

        id: Date.now().toString(),

        text: text,

        status: "inPlane"

    }

    task.push(newTask)

    saveTask()

    renderTask()

    taskInput.value = ""

    showMessage("Задача добавлена")

}

function deleteTask(id){

    task = task.filter(taskData => {

        return taskData.id !== id

    })

    saveTask()

    renderTask()

    showMessage("Задача удалена")

}

addButton.addEventListener("click", addTask)

searchInput.addEventListener("input", () => {

    renderTask(searchInput.value)

})

column.forEach(column => {

    column.addEventListener("dragover", event => {

        event.preventDefault()

        column.classList.add("hover")

    })

    column.addEventListener("dragleave", () => {

        column.classList.remove("hover")

    })

    column.addEventListener("drop", event => {

        event.preventDefault()

        const dragged = document.querySelector(".dragging")

        const taskId = dragged.dataset.id

        const foundTask = task.find(taskData => {

            return taskData.id === taskId

        })

        foundTask.status = column.id

        saveTask()

        renderTask(searchInput.value)

        column.classList.remove("hover")

        showMessage("Статус задачи изменен")

    })

})

renderTask()