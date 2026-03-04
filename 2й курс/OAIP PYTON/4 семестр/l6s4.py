import pickle;
class Poin:
    def __init__(self,x,y):
        self.x = x
        self.y = y

points = [Poin(3,4),Poin(2,2)]
with open("point.pkl","wb") as file: # wb для записи байтов
    pickle.dump(points,file)

with open("point.pkl","rb") as file:
    loaded_File = pickle.load(file)
    sas=file.read(40) # прочтет первые 40 байтов



for i in loaded_File:
    print(i.x, i.y)



import json
student = {
    "nave":"b",
    "age":"12",
    "grade":[3,5,4,5,4,3]
}
with open ("sas.json","w",encoding="utf-8") as file:
    json.dump(student,file,ensure_ascii=False,indent=2)# записываем

with open("sas.json","r",encoding="utf-8") as file:
    sasa = json.load(file)
    print(sasa)


class Poin2:
    def __init__(self,x,y):
        self.x = x
        self.y = y
    
    def to_dict(self):
        return{
            "a":self.x,
            "d":self.y
        }
    @classmethod
    def from_dict(cls,st):
        return cls (
            x= st["a"],
            y= st['d']
            )
            




po = Poin2("sas","das")


with open ("ssssss.json","w",encoding="utf-8") as file:
    json.dump(po.to_dict(),file,ensure_ascii=False,indent=2)# записываем
with open ("ssssss.json","r",encoding="utf-8") as file:
    f=json.load(file)
lodst = Poin2.from_dict(f)
print(lodst.x)
