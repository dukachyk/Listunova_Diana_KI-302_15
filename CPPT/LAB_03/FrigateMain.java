/**
* lab 3 package
*/
package ki302.Listunova.Lab3;
import static java.lang.System.out;
import java.io.*;
/**
* ShipMain class implements main method for Ship class abilities demonstration
*/
abstract public class FrigateMain
{
	/**
	 * @param args
	 * @throws FileNotFoundException
	*/
	public static void main(String[] args) throws FileNotFoundException
	{
		// TODO Auto-generated method stub
		ToBoldlyGo.Directions dir = null;
		Frigate ship = new Frigate();
		
		ship.fuelBurned();
		out.print("fuel resourse: " + ship.getShipFuelResource() + "\n");
		ship.fuelBurned();
		out.print("fuel resourse: " + ship.getShipFuelResource() + "\n");
		
		ship.setShipPosition(5, -3);
		ship.moveShipOnDistance(-4, 6);
		
		
		ship.goNorth();
		
		dir = ship.getToBoldlyGoDirection();
		if (dir == ToBoldlyGo.Directions.SOUTH)
		out.print ("going south" + "\n");
		else if (dir == ToBoldlyGo.Directions.NORTH)
		out.print ("going north" + "\n");
		else if (dir == ToBoldlyGo.Directions.WEST)
		out.print ("going west" + "\n");
		else if (dir == ToBoldlyGo.Directions.EAST)
		out.print ("going south" + "\n");
		else
		out.print ("going nowhere" + "\n");
		
		// Demonstrate missile capabilities
        Missiles missileSystem = new Missiles();
        missileSystem.setTargetNorthKorea();
        missileSystem.missilesUsed();
        out.println("Remaining missile resource: " + missileSystem.getMissileResource());

        missileSystem.setTargetIraq();
        missileSystem.missilesUsed();
        out.println("Remaining missile resource: " + missileSystem.getMissileResource());
		
		ship.dispose();
	}
}
