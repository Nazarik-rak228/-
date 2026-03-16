import gzip;
import pickle;
class Student:
    def __init__(self,name,age,grades,secret):
        self.name =name
        self.grades = grades
        self.age =age
        self.secret = secret
    def __getstate__(self):
        state=self.__dict__.copy()# копируем все атрибуты класса в словарик
        del state["secret"]# не сохраняем, в кавычках так как мы переделали в словарь(ключ - значение)
        state["_version"]=1
        return state    
    def __setstate__(self,state):
        self.__dict__.update(state)
        self.secret="default"

student1=Student("anna",15,[5,5,5,5,3,4 ],None)

with open("save.gz","wb") as title:
    pickle.dump(student1,title)

with open("save.gz","rb") as title:
    a=pickle.load(title)




print(a.name)

#еще --------------------------------------------
data= pickle.dumps(student1) # обычно чтобы передавать по сети или в БД
#data1 = pickle.loads(student1)
print(type(data)) # проверяем что в байтах
#print(data1.name)


# не сохраняя какой либо атрибут если не нужен:
print(a.secret )
class Group:
    def __init__(self,gName,):
        self.gName = gName

class StudentG:
    def __init__(self,name,group):
        self.name = name
        self.group = group

gr=Group("pip")
stud =StudentG("pit",gr)
with open("save2.gz","wb") as title:
    pickle.dump(stud,title)

with open("save2.gz","rb") as title:
    st1=pickle.load(title)

print(st1.group)



