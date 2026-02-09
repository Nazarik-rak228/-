# class Shop():
#     def __init__(self, prise,name):
#         self.prise = prise
#         self.name = name
#     def discounr_prise():
#         pass
# class Product1(Shop):
#     def discounr_prise(self):
#         return self.prise - (self.prise*0.7)
# class Product2(Shop):
#     def discounr_prise(self):
#         return self.prise - (self.prise*0.9)
# pr=[Product1(1000,"LapTop"),Product2(300,"Iphone")]
# for i in pr:
#     print(i.discounr_prise())


# from abc import ABC, abstractmethod
# class SP_oplata(ABC):
#     def __init__(self,price,sp_opl):
#         self.price =price
#         self.sp_opl = sp_opl
#     @abstractmethod
#     def kom(self):
#         pass
# class Nal(SP_oplata):
#     def kom(self):
#         return self.price-0.9
# class BezNal(SP_oplata):
#     def kom(self):
#         return self.price-0.5
# nal=[Nal(10000,"наличка"),BezNal(100000000,"картой") ]
# for i in nal:
#     print(i.Kom())

class Dog:
    def __init__(self,name):
        self.name = name
    def swim(self):
        return "sobaka plavaet"
    def sound(self):
        return " gav emae"

class Fish:
    def __init__(self,name):
        self.name = name
    def swim(self):
        return " plavaet"

class Robot:
    def __init__(self,name):
        self.name = name
    def sound(self):
        return " beeeeeeb beeeeeeeeeb"
    
def Make_sound(animal):
    if hasattr(animal,"sound"):
        return animal.sound()
    else:
        return "не издает звуков"
animal=[Dog("rex"),Fish("Nemo"),Robot("bebob")]
for i in animal:
    print(Make_sound(i))
    
        

        
