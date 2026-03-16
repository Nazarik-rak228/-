# warehouse_app.py
import tkinter as tk
from tkinter import messagebox


class Item:
    def __init__(self, name, quantity, price):
        self.name = name
        self.quantity = quantity
        self.price = price

    def change_quantity(self, value):
        self.quantity += value

    def get_total(self):
        return self.quantity * self.price

    def info(self):
        return f"{self.name} | Количество: {self.quantity} | Цена: {self.price:.2f} руб."


class Storage:
    def __init__(self):
        self.items = []

    def find_item(self, name):
        for item in self.items:
            if item.name == name:
                return item
        return None

    def add_item(self, name, quantity, price):
        if name == "":
            raise ValueError("Название товара не может быть пустым")

        if quantity < 0:
            raise ValueError("Количество не может быть отрицательным")

        if price < 0:
            raise ValueError("Цена не может быть отрицательной")

        item = self.find_item(name)

        if item:
            item.change_quantity(quantity)
        else:
            new_item = Item(name, quantity, price)
            self.items.append(new_item)

    def delete_item(self, name):
        item = self.find_item(name)

        if item:
            self.items.remove(item)
            return True

        return False

    def change_item_quantity(self, name, value):
        item = self.find_item(name)

        if not item:
            return False

        item.change_quantity(value)

        if item.quantity <= 0:
            self.items.remove(item)

        return True

    def get_items_info(self):
        result = []

        for item in self.items:
            result.append(item.info())

        return result

    def total_value(self):
        total = 0

        for item in self.items:
            total += item.get_total()

        return total


class StorageApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Склад товаров")

        self.storage = Storage()

        frame = tk.Frame(root)
        frame.pack(padx=10, pady=10)

        tk.Label(frame, text="Название товара").grid(row=0, column=0)

        self.name_entry = tk.Entry(frame, width=25)
        self.name_entry.grid(row=0, column=1)

        tk.Label(frame, text="Количество").grid(row=1, column=0)

        self.quantity_entry = tk.Entry(frame, width=10)
        self.quantity_entry.grid(row=1, column=1)

        tk.Label(frame, text="Цена").grid(row=2, column=0)

        self.price_entry = tk.Entry(frame, width=10)
        self.price_entry.grid(row=2, column=1)

        buttons = tk.Frame(root)
        buttons.pack(pady=5)

        tk.Button(buttons, text="Добавить", command=self.add_item).grid(row=0, column=0, padx=5)
        tk.Button(buttons, text="Показать", command=self.show_items).grid(row=0, column=1, padx=5)
        tk.Button(buttons, text="Удалить", command=self.delete_item).grid(row=0, column=2, padx=5)
        tk.Button(buttons, text="Изменить количество", command=self.update_quantity).grid(row=0, column=3, padx=5)
        tk.Button(buttons, text="Стоимость склада", command=self.show_total).grid(row=0, column=4, padx=5)

        self.output = tk.Text(root, width=70, height=12)
        self.output.pack(padx=10, pady=10)

    def clear_fields(self):
        self.name_entry.delete(0, tk.END)
        self.quantity_entry.delete(0, tk.END)
        self.price_entry.delete(0, tk.END)

    def add_item(self):
        name = self.name_entry.get()

        try:
            quantity = int(self.quantity_entry.get())
            price = float(self.price_entry.get())
        except ValueError:
            messagebox.showerror("Ошибка", "Введите корректные данные")
            return

        try:
            self.storage.add_item(name, quantity, price)
        except ValueError as error:
            messagebox.showerror("Ошибка", str(error))
            return

        messagebox.showinfo("Информация", "Товар добавлен")

        self.clear_fields()
        self.show_items()

    def show_items(self):
        self.output.delete(1.0, tk.END)

        items = self.storage.get_items_info()

        if len(items) == 0:
            self.output.insert(tk.END, "Склад пуст\n")
        else:
            for line in items:
                self.output.insert(tk.END, line + "\n")

    def delete_item(self):
        name = self.name_entry.get()

        if name == "":
            messagebox.showerror("Ошибка", "Введите название товара")
            return

        if self.storage.delete_item(name):
            messagebox.showinfo("Информация", "Товар удален")
            self.show_items()
        else:
            messagebox.showinfo("Информация", "Товар не найден")

        self.clear_fields()

    def update_quantity(self):
        name = self.name_entry.get()

        try:
            value = int(self.quantity_entry.get())
        except ValueError:
            messagebox.showerror("Ошибка", "Введите число")
            return

        if self.storage.change_item_quantity(name, value):
            messagebox.showinfo("Информация", "Количество обновлено")
            self.show_items()
        else:
            messagebox.showinfo("Информация", "Товар не найден")

        self.clear_fields()

    def show_total(self):
        total = self.storage.total_value()
        messagebox.showinfo("Стоимость склада", f"Общая стоимость: {total:.2f} руб.")


def main():
    root = tk.Tk()
    app = StorageApp(root)
    root.mainloop()


if __name__ == "__main__":
    main()