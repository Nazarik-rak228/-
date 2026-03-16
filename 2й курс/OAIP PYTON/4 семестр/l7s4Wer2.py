
import json
from dataclasses import dataclass,asdict
import pickle
# class Student:
#     def init(self,name, age, grades):
#         self.name=name
#         self.age=age
#         self.grades=grades

#     def to_dict(self):
#         return{
#         "name": self.name,
#         "age":self.age,
#         "grades": self.grades
#     }
    
# def to_def(obj):
#     if isinstance(obj, Student):
#         return obj.to_dict()
# raise TypeError(f"Обьект даукн")






@dataclass
class Student:
    name:str
    age:int
    grase:list

student = Student("ass",12,[12,12123])

st_to_dict=asdict(student)
with open ("ssssss121212.json","w",encoding="utf-8") as file:
    json.dump(st_to_dict,file,ensure_ascii=False,indent=2)# записываем
with open ("ssssss121212.json","r",encoding="utf-8") as file:
    f=json.load(file,protocol=pickle.HIGHEST_PROTOCOL)

st1=Student(**f) # ** распаковывает в класс
print(st1.name, st1.grase)

# протоколы - имба какая то, но хз зачем  кроме как разные прилы на разных версиях питона сводить ы 







