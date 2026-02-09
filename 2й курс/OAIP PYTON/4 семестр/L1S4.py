class car:
    def __init__(self, brand, model,dopname):
        self.brand = brand
        self.model = model

        self.dopname = dopname  
    
    def Get_param (self):

        return F"{self.brand, self.model, self.dopname}" 

car2 = car("mazda", "RX8","goida")


print(car2.Get_param())
