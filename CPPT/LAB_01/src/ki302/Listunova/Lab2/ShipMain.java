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
		Adventure.Directions dir = null;
		Ship ship = new Ship();
		
		ship.doLeftTurn();
		out.print(ship.getLeftTurnResource() + "\n");
		ship.doRightTurn();
		out.print(ship.getRightTurnResource() + "\n");
		
		ship.setShipPosition(5, -3);
		ship.goNorth();
		
		dir = ship.getAdventureDirection();
		if (dir == Adventure.Directions.SOUTH)
		out.print ("South" + "\n");
		else if (dir == Adventure.Directions.NORTH)
		out.print ("North" + "\n");
		else if (dir == Adventure.Directions.WEST)
		out.print ("West" + "\n");
		else if (dir == Adventure.Directions.EAST)
		out.print ("South" + "\n");
		else
		out.print ("Nowhere" + "\n");
		ship.dispose();
	}
}
