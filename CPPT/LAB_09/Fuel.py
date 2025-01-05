class Fuel:
    def __init__(self, res=100):
        self.__fuelResource = res
    def burnFuel(self):
        self.__fuelResource = self.__fuelResource - 1
    def getFuelResource(self):
        return self.__fuelResource