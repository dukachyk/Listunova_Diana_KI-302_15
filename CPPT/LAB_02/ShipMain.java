/**
* lab 2 package
*/
package ki302.Listunova.Lab2;
import static java.lang.System.out;
import java.io.*;
/**
* ShipMain class implements main method for Ship class abilities demonstration
*/
public class ShipMain
{
	/**
	 * @param args
	 * @throws FileNotFoundException
	*/
	public static void main(String[] args) throws FileNotFoundException
	{
		// TODO Auto-generated method stub
		ToBoldlyGo.Directions dir = null;
		Ship ship = new Ship();
		
		ship.fuelBurned();
		out.print("fuel resourse: " + ship.getShipFuelResource() + "\n");
		ship.fuelBurned();
		out.print("fuel resourse: " + ship.getShipFuelResource() + "\n");
		
		ship.setShipPosition(5, -3);
		ship.moveShipOnDistance(-4, 6);
		
		ship.goSouth();
		
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
		ship.dispose();
	}
}
