const input = document.getElementById("input");
const addbutton = document.getElementById("add");
const clearbutton = document.getElementById("clear")
const list = document.getElementById("list");
const title = document.getElementById("title")
const count = document.getElementById("count")

title.innerHTML="Список <span >Not Hello </span>"



let nextId=1;

addbutton.addEventListener("click",addTask);
clearbutton.addEventListener("click",clearAll);


input.addEventListener("keydown", (e)=> {
    if(e.key ==="Enter") addTask()
})

list.addEventListener("click", onListClick)
list.addEventListener("dblclick", onListDblClick)

function addTask(){
    const text = input.value.trim()

    if(text===""){
        input.setAttribute("placeholder","empty text ")
        input.style.borderColor= "red"
        input.focus()
        return
    }
    input.setAttribute("placeholder"," write task")
    input.style.borderColor=""
    const li = document.createElement("LI");
    li.textContent = text;
    li.classList.add("task")
    li.style.cursor="pointer"

    li.setAttribute("data-id",String(nextId))
    nextId++
    list.appendChild(li); // это мы добавляем список в html
    input.value = "";
        updateCount();
    

}
function clearAll() {
  while (list.firstElementChild) {
    list.firstElementChild.remove()
  }
  updateCount()
}
function onListClick(e) {
    // Нам важно — кликнули по LI
    if (e.target.tagName !== "LI") return;

    const li = e.target;

    // === Классы ===
    li.classList.toggle("active"); // визуальная подсветка
    li.classList.toggle("done");   // выполнено

    // === Чтение атрибута ===
    const id = li.getAttribute("data-id");
    console.log("Клик по задаче id:", id);

    updateCount();
}

function onListDblClick(e) {
    if (e.target.tagName !== "LI") return;

    // === Удаление элемента ===
    e.target.remove();
    updateCount();
}



function updateCount(){
    const all = list.querySelectorAll("li").length
    const done = list.querySelectorAll("li.done").length

    count.textContent = `Всего: ${all} · Выполнено: ${done}`
}






// button.addEventListener("click",addTask);
//Inner html = внедрение кода в html  и эт не безопасно
// Text context - безопасно
// function addTask(){
//     const tesxt = input.value;
//     const li = document.createElement("LI");
//     li.textContent = tesxt;
//     list.appendChild(li); // это мы добавляем список в html
//     input.value = "";
// }
// list.addEventListener("click", function(e){
//     if(e.target.tagName ==="LI"){
//         e.target.classList.toggle("active")

//     }
// });
// list.addEventListener("dblclick", function(e){
//     if(e.target.tagName ==="LI"){
//         e.target.remove();

//     }
// });