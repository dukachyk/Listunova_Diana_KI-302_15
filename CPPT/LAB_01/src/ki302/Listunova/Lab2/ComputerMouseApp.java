/**
* lab 2 package
*/
package ki302.Listunova.Lab2;
import static java.lang.System.out;
import java.io.*;
/**
* Computer Mouse Application class implements main method for
* ComputerMouse class abilities demonstration
*/
public class ComputerMouseApp
{
	/**
	* @param args
	* @throws FileNotFoundException
	*/
	public static void main(String[] args) throws FileNotFoundException
	{
		// TODO Auto-generated method stub
		Scroller.Directions dir = null;
		ComputerMouse mouse = new ComputerMouse();
		
		mouse.clickLeftButton();
		out.print(mouse.getLeftButtonResource() + "\n");
		mouse.clickRightButton();
		out.print(mouse.getRightButtonResource() + "\n");
		
		mouse.setMousePosition(5, -3);
		mouse.scrollUp();
		
		dir = mouse.getScrollingDirection();
		if (dir == Scroller.Directions.DOWN)
		out.print ("Down" + "\n");
		else if (dir == Scroller.Directions.UP)
		out.print ("Up" + "\n");
		else
		out.print ("Neutral" + "\n");
		mouse.dispose();
	}
}