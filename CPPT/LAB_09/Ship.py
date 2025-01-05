from ToBoldlyGo import ToBoldlyGo
from RelativePosition import RelativePosition
from Fuel import Fuel

class Ship:
    def __init__(self, resource=100):
        self.__compass = ToBoldlyGo()
        self.__pos = RelativePosition()
        self.__gasOil = Fuel(resource)
    def moveShipOnDistance(self, xPos, yPos):
        self.__pos.setXPosition(self.pos.getXPosition() + xPos)
        self.__pos.setYPosition(self.pos.getYPosition() + yPos)
    def setShipPosition(self, xPos, yPos):
        self.__pos.setXPosition(xPos)
        self.__pos.setYPosition(yPos)
        print(f"Ship position: x = {self.getShipXPosition()}; y = {self.getShipYPosition()}.")
    def getShipXPosition(self):
        return self.__pos.getXPosition()
    def getShipYPosition(self):
        return self.__pos.getYPosition()
    def burnFuel(self):
        self.__gasOil.burnFuel()
        print("Fuel burned")
    def goNorth(self):
        self.__compass.setNorthDirection()
        print("Ship`s going north")
    def goSouth(self):
        self.__compass.setSouthDirection()
        print("Ship`s going south")
    def goWest(self):
        self.__compass.setWestDirection()
        print("Ship`s going west")
    def goEast(self):
        self.__compass.setEastDirection()
        print("Ship`s going east")
    def resetBoldlyGoing(self):
        self.__compass.resetBoldlyGoing()
    def getToBoldlyGoDirection(self):
        return self.__compass.getDirection()