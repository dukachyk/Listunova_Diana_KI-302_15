class RelativePosition:
    def __init__(self, xPos = 0, yPos = 0):
        self.__x = xPos
        self.__y = yPos
    def getXPosition(self):
        return self.__x
    def getYPosition(self):
        return self.__y
    def setXPosition(self, xPos):
        self.__x = xPos
    def setYPosition(self, yPos):
        self.__y = yPos