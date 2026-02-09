class Bank:
    def __init__(self,name, balance,account_number):
        self.__name = name
        self.__balance =balance
        self.__account_number = account_number
        
    def get_name(self):
        return self.__name  # иначе мы не получим значение отрибута, нужна по этому эта функция, Но она не работает,нужен геттер
    
    def get_balance(self):
        return self.__balance
    
    def get_account_nember(self):
        return self.__account_number
    
    def set_balance(self,amount):
        self.__balance = amount
    def deposit(self,amount):
        if amount>0:
            self.set_balance=self.__balance+amount
            return self.__balance
        return False
    def withdraw(self,amount):
        if amount>0:
            self.__balance-=amount
            return self.__balance
        return False
        
# сеттеры теперь
    



bank=Bank("asdadasdas",1000,123)
print(bank.get_account_nember())
print(bank.get_balance())
print(bank.deposit(400))
print(bank.withdraw(100))