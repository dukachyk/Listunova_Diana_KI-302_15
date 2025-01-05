class ToBoldlyGo:
    class Directions:
        NOWHERE = u'NOWHERE'
        NORTH = u'NORTH'
        SOUTH = u'SOUTH'
        WEST = u'WEST'
        EAST = u'EAST'
    def __init__(self):
        self.__direction = ToBoldlyGo.Directions.NOWHERE
    def setNorthDirection(self):
        self.__direction = ToBoldlyGo.Directions.NORTH
    def setSouthDirection(self):
        self.__direction = ToBoldlyGo.Directions.SOUTH
    def setWestDirection(self):
        self.__direction = ToBoldlyGo.Directions.WEST
    def setEastDirection(self):
        self.__direction = ToBoldlyGo.Directions.EAST
    def setNowhereDirection(self):
        self.__direction = ToBoldlyGo.Directions.NOWHERE
    def resetBoldlyGoing(self):
        self.setNowhereDirectionDirection()
    def getDirection(self):
        return self.__direction