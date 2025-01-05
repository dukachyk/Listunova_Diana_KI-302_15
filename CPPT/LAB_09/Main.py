from Warship import Warship
from ToBoldlyGo import ToBoldlyGo

if __name__ == "__main__":
    ship = Warship(150)
    ship.burnFuel()
    ship.setShipPosition(5, -3)
    ship.goNorth()
    dir = ship.getToBoldlyGoDirection()
    if dir == ToBoldlyGo.Directions.NORTH:
        print("Adventure direction: North")
    elif dir == ToBoldlyGo.Directions.SOUTH:
        print("Adventure direction: South")
    elif dir == ToBoldlyGo.Directions.WEST:
        print("Adventure direction: West")
    elif dir == ToBoldlyGo.Directions.East:
        print("Adventure direction: East")
    else:
        print("Adventure direction: Nowhere")
    ship.goRocketLaunch()
    ship.goGasLaunch()