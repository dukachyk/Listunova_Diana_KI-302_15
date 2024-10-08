/**
* lab 2 package 
*/
package ki302.Listunova.Lab2;
import java.io.*;
/**
* Class <code>Ship</code> implements ship
*/
public class Ship {
	private ToBoldlyGo compass;
	private ShipCoordinates pos;
	private Fuel gasOil;
	private PrintWriter fout;
	/**
	* Constructor
	* @throws FileNotFoundException
	*/
	public Ship() throws FileNotFoundException
	{
		compass = new ToBoldlyGo();
		pos = new ShipCoordinates();
		gasOil = new Fuel();
		fout = new PrintWriter(new File("This is where text is stored.txt"));
	}
	/**
	* Constructor
	* @param <code>resource</code> Fuel resource
	* @throws FileNotFoundException
	*/
	public Ship(int resource) throws FileNotFoundException
	{
		compass = new ToBoldlyGo();
		pos = new ShipCoordinates();
		gasOil = new Fuel(resource);
		fout = new PrintWriter(new File("This is where text is stored.txt"));
	}
	/**
	* Method implements ship coordinates offset on (xPos, yPos)
	* @param <code>xPos</code> The X coordinate of the ship position
	* @param <code>yPos</code> The Y coordinate of the ship position
	*/
	public void moveShipOnDistance(int xPos, int yPos)
	{
		pos.setXPosition(pos.getXPosition() + xPos);
		pos.setYPosition(pos.getYPosition() + yPos);
		fout.print("Ship's new X position: " + pos.getXPosition() + "\n");
		fout.print("Ship's new Y position: " + pos.getYPosition() + "\n");
	}
	/**
	* Method sets the new ship position
	* @param <code>xPos</code> The X coordinate of the ship position
	* @param <code>yPos</code> The Y coordinate of the ship position
	*/
	public void setShipPosition(int xPos, int yPos)
	{
		pos.setXPosition(xPos);
		pos.setYPosition(yPos);
	}
	/**
	* Method returns ship's current X position
	* @return Ship's current X position
	*/
	public int getShipXPosition()
	{
		return pos.getXPosition();
	}
	/**
	* Method returns ship's current Y position
	* @return Ship's current Y position
	*/
	public int getShipYPosition()
	{
		return pos.getYPosition();
	}
	/**
	 * Method simulates fuel burning
	 */
	public void fuelBurned() 
	{
		gasOil.Burned();
		fout.print("Ship's new fuel resource: " + gasOil.getFuelResourse() + "\n");
		
		fout.flush();
	}
	/**
	* Method returns ship's fuel resource	
	* @return Ship's fuel resource
	*/
	public int getShipFuelResource()
	{
		return gasOil.getFuelResourse();
	}
	/**
	* Method simulates ship's going north
	*/
	public void goNorth()
	{
		compass.setNorthDirection();
		fout.print("Ship's going north\n");
		fout.flush();
	}
	/**
	* Method simulates ship's going south
	*/
	public void goSouth()
	{
		compass.setSouthDirection();
		fout.print("Ship's going south\n");
		fout.flush();
	}
	/**
	* Method simulates ship's going west
	*/
	public void goWest()
	{
		compass.setWestDirection();
		fout.print("Ship's going west\n");
		fout.flush();
	}
	/**
	* Method simulates ship's going east
	*/
	public void goEast()
	{
		compass.setEastDirection();
		fout.print("Ship's going east\n");
		fout.flush();
	}
	/**
	* Method simulates ship's going nowhere
	*/
	public void resetBoldlyGoing()
	{
		compass.resetBoldlyGoing();
		fout.print("Ship's going nowhere");
		fout.flush();
	}
	/**
	* Method returns ship's direction
	* @return Ship's direction of <code>ToBoldlyGo.Directions</code> type
	*/
	public ToBoldlyGo.Directions getToBoldlyGoDirection()
	{
		return compass.getDirection();
	}
	/**
	* Method releases used recourses
	*/
	public void dispose()
	{
		fout.close();
	}
}
class ToBoldlyGo
{
	enum Directions {NORTH, SOUTH, WEST, EAST, NOWHERE};
	// current ship's state
	private Directions direction;
	/**
	* Constructor
	*/
	public ToBoldlyGo()
	{
		direction = Directions.NOWHERE;
	}
	/**
	* Method sets destination north 
	*/
	public void setNorthDirection()
	{
		direction = Directions.NORTH;
	}
	/**
	* Method sets destination south 
	*/
	public void setSouthDirection()
	{
		direction = Directions.SOUTH;
	}
	/**
	* Method sets destination west
	*/
	public void setWestDirection()
	{
		direction = Directions.WEST;
	}
	/**
	* Method sets destination east
	*/
	public void setEastDirection()
	{
		direction = Directions.EAST;
	}
	/**
	* Method sets destination nowhere
	*/
	public void setNoWhereDirection()
	{
		direction = Directions.NOWHERE;
	}
	/**
	* Method resets direction to nowhere
	*/
	public void resetBoldlyGoing()
	{
		setNoWhereDirection();
	}
	/**
	* Method returns boldly going direction
	* @return Boldly going direction of <code>ToBoldlyGo.Directions</code> type
	*/
	public Directions getDirection()
	{
		return direction;
	}
}

/**
* Class <code>ShipCoordinates</code> implements relative positioning coordinate system
* @author EOMStuff & Diana L.
* @version 1.0
*/
class ShipCoordinates
{
	// coordinates of the ship
	private int x, y;
	/**
	* Constructor
	*/
	public ShipCoordinates()
	{
		x = 0;
		y = 0;
	}
	/**
	* Constructor
	* @param <code>xPos</code> The X coordinate value
	* @param <code>yPos</code> The Y coordinate value
	*/
	public ShipCoordinates(int xPos, int yPos)
	{
		x = xPos;
		y = yPos;
	}
	/**
	* Method returns the X coordinate value
	* @return The X coordinate value
	*/
	public int getXPosition()
	{
		return x;
	}
	/**
	* Method returns the Y coordinate value
	* @return The Y coordinate value
	*/
	public int getYPosition()
	{
		return y;
	}
	/**
	* Method returns coordinates of the position in the <code>obj</code>, that is passed into method through method parameter
	* @param <code>obj</code> The object, where coordinates of the current position are set
	*/
	public void getPosition(ShipCoordinates obj)
	{
		obj.x = x;
		obj.y = y;
	}
	/**
	* Method sets the X coordinate value
	* @param <code>xPos</code> The X coordinate value
	*/
	public void setXPosition(int xPos)
	{
		x = xPos;
	}
	/**
	* Method sets the Y coordinate value
	* @param <code>yPos</code> The Y coordinate value
	*/
	public void setYPosition(int yPos)
	{
		y = yPos;
	}
}
/**
* Class <code>Fuel</code> implements ship`s fuel burning
* @author EOMStuff & Diana L.
*/
class Fuel
{
	// Fuel resource
	private int btnResource;
	/**
	* Constructor
	*/
	public Fuel()
	{
		btnResource = 100;
	}
	/**
	* Constructor
	* @param <code>res</code> Fuel resource
	*/
	public Fuel(int res)
	{
		btnResource = res;
	}
	/**
	* Method simulates fuel burning
	*/
	public void Burned()
	{
		btnResource = btnResource - 1;
	}
	/**
	* Method returns fuel resource available
	* @return Fuel resource available
	*/
	public int getFuelResourse()
	{
		return btnResource;
	}
}