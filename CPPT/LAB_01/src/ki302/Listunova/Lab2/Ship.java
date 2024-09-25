/**
* lab 2 package
*/
package ki302.Listunova.Lab2;
import java.io.*;
/**
* Class <code>Ship</code> implements ship
*/
public class Ship {
	private Adventure compass;
	private ShipCoordinates pos;
	private Turn rightTurn;
	private Turn leftTurn;
	private PrintWriter fout;
	/**
	* Constructor
	* @throws FileNotFoundException
	*/
	public Ship() throws FileNotFoundException
	{
		compass = new Adventure();
		pos = new ShipCoordinates();
		rightTurn = new Turn();
		leftTurn = new Turn();
		fout = new PrintWriter(new File("Log.txt"));
	}
	/**
	* Constructor
	* @param <code>resource</code> Turns resource
	* @throws FileNotFoundException
	*/
	public Ship(int resource) throws FileNotFoundException
	{
		compass = new Adventure();
		pos = new ShipCoordinates();
		rightTurn = new Turn(resource);
		leftTurn = new Turn(resource);
		fout = new PrintWriter(new File("Log.txt"));
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
		fout.print("New mouse X position: " + pos.getXPosition() + "\n");
		fout.print("New mouse Y position: " + pos.getYPosition() + "\n");
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
	* Method simulates ship's right turning
	*/
	public void doRightTurn()
	{
		rightTurn.doTurn();
		fout.print("New ship's right turn resource: " + rightTurn.getTurnResourse() + "\n");
		
		fout.flush();
	}
	/**
	* Method simulates ship's left turning
	*/
	public void doLeftTurn()
	{
		leftTurn.doTurn();
		fout.print("New ship's left turn resource: " + leftTurn.getTurnResourse() + "\n");
		
		fout.flush();
	}
	/**
	* Method returns mouse's right button clicking resource	
	* @return Mouse's right button clicking resource
	*/
	public int getRightTurnResource()
	{
		return rightTurn.getTurnResourse();
	}
	/**
	* Method returns ship's left turning resource
	* @return Ship's left turning resource
	*/
	public int getLeftTurnResource()
	{
		return leftTurn.getTurnResourse();
	}
	/**
	* Method simulates ship's adventure north
	*/
	public void goNorth()
	{
		compass.setNorthDirection();
		fout.print("Ship went north\n");
		fout.flush();
	}
	/**
	* Method simulates ship's adventure south
	*/
	public void goSouth()
	{
		compass.setSouthDirection();
		fout.print("Ship went south\n");
		fout.flush();
	}
	/**
	* Method simulates ship's adventure west
	*/
	public void goWest()
	{
		compass.setWestDirection();
		fout.print("Ship went west\n");
		fout.flush();
	}
	/**
	* Method simulates ship's adventure east
	*/
	public void goEast()
	{
		compass.setEastDirection();
		fout.print("Ship went east\n");
		fout.flush();
	}
	/**
	* Method simulates ship's adventure nowhere
	*/
	public void resetAdventure()
	{
		compass.resetAdventure();
		fout.print("Ship went nowhere");
		fout.flush();
	}
	/**
	* Method returns mouse's scrolling direction
	* @return Ship's adventure direction of
	<code>Adventure.Directions</code> type
	*/
	public Adventure.Directions getAdventureDirection()
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
class Adventure //North South west east //Scroller
{
	// Type for scrolling directions
	enum Directions {NORTH, SOUTH, WEST, EAST, NOWHERE}; //neutral up down
	// current scroller's state
	private Directions direction;
	/**
	* Constructor
	*/
	public Adventure()
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
	public void setNoWhereDirection()
	{
		direction = Directions.NOWHERE;
	}
	/**
	* Method resets direction to nowhere
	*/
	public void resetAdventure()
	{
		setNoWhereDirection();
	}
	/**
	* Method returns adventure direction
	* @return Adventure direction of <code>Destination.Directions</code> type
	*/
	public Directions getDirection()
	{
		return direction;
	}
}

/**
* Class <code>ShipCoordinates</code> implements relative positioning
coordinate system
*
* @author EOMStuff
* @version 1.0
*/
class ShipCoordinates //RelativePosition
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
	* Method returns coordinates of the position in the <code>obj</code>,
	that is passed into method through method parameter
	* @param <code>obj</code> The object, where coordinates of the current
	position are set
	*/
	public void getPosition(ShipCoordinates obj)
	{
		obj.x = x;
		obj.y = y;
	}
	/**
	* Method sets the X coordinate value
	
	22
	
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
* @author EOMStuff 
* Class <code>Turn</code> implements ship`s turn
*/
class Turn //Button
{
	// Turn resource
	private int btnResource;
	/**
	* Constructor
	*/
	public Turn()
	{
		btnResource = 100;
	}
	/**
	* Constructor
	* @param <code>res</code> Turns resource
	*/
	public Turn(int res)
	{
		btnResource = res;
	}
	/**
	* Method simulates turning
	*/
	public void doTurn()
	{
		btnResource = btnResource - 1;
	}
	/**
	* Method returns turns resource available
	* @return Turns resource available
	*/
	public int getTurnResourse()
	{
		return btnResource;
	}
}