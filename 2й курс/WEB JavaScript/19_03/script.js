const input = document.getElementById("input");
const addBtn = document.getElementById("add");
const clearBtn = document.getElementById("clear");
const list = document.getElementById("list");
const title = document.getElementById("title");
const counter = document.getElementById("counter");

const outer = document.getElementById("outer");
const middle = document.getElementById("middle");
const inner = document.getElementById("inner");
const innerBtn = document.getElementById("innerBtn");

//---------
const logEl = document.getElementById("log");
const logClearBtn = document.getElementById("logClear");
const showDetails = document.getElementById("showDetails");
const demoLink = document.getElementById("demoLink");

//----------

console.log("window.document. ===. document:", window. document === document);

//textContent - безопасный текст
//innerHTML - НЕБЕЗОПАСНЫЙ TEKCT с HTML

title.innerHTML = `Список задач <span style="font-size: 14px">Not hello World</span>`

let nextId = 1;

//-----------------
function eventPhaseName(phase) {
    if(phase === 1) return "CAPTURE(1)"
    if(phase === 2) return "TARGET(2)"
    if(phase === 3) return "BUBBLE(3)"
}

function log(msg) {
    const time = new Date().toLocaleDateString()
    logEl.textContent +=`[${time}] ${msg}\n`;
    logEl.scrollTop = logEl.scrollHeight
}


function logEvent(label, e) {
    if(!showDetails. checked) {
        log(label)
        return
    }

    const t = e.target ?. id ? '#${e.target.id}' : e.target ?. tagName
    const ct = e.currentTarget ?. id ? '#${e.currentTarget.id}' : e.currentTarget ?. tagName

    log(
        `${label} | type=${e.type} phase=${eventPhaseName(e.eventPhase)}` +
        `target=${t} currentTarget = ${ct}`
)
}
//-----------




addBtn.addEventListener("click", addTask)
clearBtn.addEventListener("click", clearAll)

input.addEventListener("keydown", (e) => {
    if(e.key === "Enter") addTask()
})

list.addEventListener("click", onListClick)
list.addEventListener("dblclick", onListDblClick)



function addTask() {
    const text = input.value.trim()

    if(text === ""){
        input.setAttribute("placeholder", "Поле пустое - введите текст задачи!")
        input.style.borderColor = "red"
        input.focus()
        return
    }

    input.setAttribute("placeholder", "Введите задачу")
    input.style.borderColor = ""

    const li = document.createElement ("li")
    li.textContent = text
    li.classList.add("task")
    li.style.cursor = "pointer"

    li.setAttribute("data-id", String(nextId))

    nextId++

    list.appendChild(li)

    input.value = ""
    input.focus()

    updateCounters()

}




function onListClick(e) {
    // Нам важно, что кликнули по LI
    if (e.target.tagName !== "LI") return;

    const li = e.target;

    // ===== Классы
    li.classList.toggle("active"); // визуальная подсветка
    li.classList.toggle("done"); // выполнено

    updateCounters();
}


function onListDblClick(e) {
    if (e.target.tagName !== "LI") return;

    // ==== Удаление элемента
    e.target.remove();
    updateCounters();
}






function clearAll(){
    while(list.firstElementChild){
        list.firstElementChild.remove()
    }

    updateCounters()
}

function updateCounters() {
    const all = list.querySelectorAll("li").length
    const done = list.querySelectorAll("li.done").length

    counter.textContent = `Всего: ${all} · Выполнено: ${done}`
}
    






//-------------------
logClearBtn.addEventListener("click", () => {
    logEl.textContent = ""
    log("Очищен")
}, {once: false})

demoLink.addEventListener("click", (e) => {
    e.preventDefault()
    logEvent ("Отменен", е)
})

outer.addEventListener("click", (e) => logEvent("OUTER capture", e), true)
outer.addEventListener("click", (e) => logEvent("OUTER bubble", e), false)

middle.addEventListener("click", (e) => logEvent("middle capture", e), true)
middle.addEventListener("click", (e) => logEvent("middle bubble", e), false)

inner.addEventListener("click", (e) => logEvent("inner capture", e), true)
inner.addEventListener("click", (e) => logEvent("inner bubble", e), false)

innerBtn.addEventListener("click", (e) => {
    logEvent("Жмак кнопочку", е)
})

log("Тыкайте на OUTER middle inner")
//--------------