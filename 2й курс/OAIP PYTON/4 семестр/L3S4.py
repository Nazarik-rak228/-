
class Vector:
    def __init__(self,x,y):
            self.x=x
            self.y =y
    def __str__(self):
          return f"vector; {self.x}, {self.y}"
    def __add__(self,other):
          return Vector[self.x + other.x, self.y + other.y]
    def __eq__(self, other):
          return self.x == other.x and self.y == other.y
vector = Vector(*map(float,input("Введите значения: ").split()))
vector1 = Vector(*map(float,input("Введите значения: ").split()))
print(vector+vector1)
print(vector*vector1)