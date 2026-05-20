import random as rd;
import io;
import tkinter as tk;
from tkinter import messagebox as mb;
# -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

mainWind = tk.Tk()
mainWind.title("Рандомайзер : )")
mainWind.geometry("1360x810")
hello =tk.Label(mainWind, text="Это рандомайзер, который сохраняет твой список для выбора или просто выдает рандомную циферку", font=("Impact",20))
hello.pack(padx=0)
res = tk.Label(font=("Impact",20), text=".....................................................................................список.....................................................................................")
res.pack(pady=10)
res.pack(padx=0)
# -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Storage = []
    
def addSwitch(): # добавляю в список элемент
    item = inputUser.get()
    if not item:
        mb.showwarning("Ошибка", "Введите что-нибудь!")
        return
    if item in Storage:
        mb.showinfo("Уже есть", f"«{item}» уже в списке")
        return
    Storage.append(item)
    inputUser.delete(0, tk.END)
    mb.showinfo("Ух-ты",f"Добавлено: {item}\nВсего элементов: {len(Storage)}")
    saving()

def removeSwitch():# удаляю, все просто 
    text = inputUser.get().strip()
    if not text:
        mb.showwarning("Ошибка", "Введите элемент для удаления")
        return
    
    if text in Storage:
        Storage.remove(text)
        inputUser.delete(0, tk.END) # очищаю форму
        mb.showinfo("Ух-ты",f"Удалено: {text}\nОсталось элементов: {len(Storage)}")
    else:
        mb.showwarning("Не найдено", f"«{text}» нет в списке")
        saving()
def showStorage():
    if not Storage:
        mb.showinfo("Ух-ты","Список пуст :(")
    else:
        # красивый вывод списка
        items = "\n".join(f"  • {item}" for item in Storage) # переменная как цикл фор, имба
        mb.showinfo("успешно",f"Список ({len(Storage)} элементов):\n{items}")
def randomaiz():
    if Storage.__len__ != 0:
        i = rd.choice(Storage)
        thinkingRes.config(text=f"{i}",font=("Impact", 40 ))
        randomElemet.config(text="Выбрать еще раз!")
    else:
        mb.showwarning("Ошибка", "Список пуст!")
    
# -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    


inputUser = tk.Entry(mainWind, width=60, border=10,font=("Impact",20))
inputUser.pack(pady=40)
addButton = tk.Button(mainWind, command=addSwitch, text="Добавить в список",font=("Impact", 10 ), width=20)
addButton.pack(padx=0)
removeButton = tk.Button(mainWind, command=removeSwitch, text="Удалиить из списка", font=("Impact", 10 ), width=20)
removeButton.pack(padx=10)
showButton = tk.Button(mainWind,command=showStorage,text="показать список", font=("Impact", 10 ), width=20)
showButton.pack(padx=10)
randomElemet = tk.Button(mainWind,command=randomaiz, text="Выбрать элемент", font=("Impact", 10 ), width=20)
randomElemet.pack(padx=0)
thinkingRes = tk.Label(mainWind, text="=== Результат еще не пришел... ===",font=("Impact", 30 ))
thinkingRes.pack(pady=30)

# -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
# Сохранение и загрузка 
def saving():
    with open  ("SaveList.txt","w",encoding="utf-8") as file:
        for s in Storage:
            file.write(s +"\n")

def loading():
    with open ("SaveList.txt","r",encoding="utf-8") as file:
        for line in file:
            Storage.append(line.strip())   



   
loadingButton = tk.Button(mainWind,command=loading,text="Загрузить последний список", font=("Impact", 10 ), width=30)
loadingButton.pack(padx=10)  


    
mainWind.mainloop()
