from Ship import Ship
from Fuel import Fuel

class Warship(Ship):
    def __init__(self, weight, resource = 1000000):
        super().__init__(resource)
        self.__rocketLaunch = Fuel(resource)
        self.__gasLaunch = Fuel(resource)
        self.__weight = weight
    def getWeight(self):
        return self.__weight 
    def goRocketLaunch(self):
        self.__rocketLaunch.burnFuel()
        print("Rocket launched")
    def goGasLaunch(self):
        self.__gasLaunch.burnFuel()
        print("Gas launched")