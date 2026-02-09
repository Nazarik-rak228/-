class book:
    def __init__(self,avtor,god,name):
        self.avtor = avtor
        self.god = god
        self.name = name
    def about_book(self):
        return [self.avtor, self.god, self.name]
    
Book1 = book("pushkin", 1978, "sultan")
Book2 = book("Gogol", 1987, "Vechera na hutore bliz dikanky")
Book3 = book("Fatty",9999,"Miku is bitch")

print(Book1.about_book())
print(Book2.about_book())
print(Book3.about_book())