package ki302.Listunova.Lab5;

import java.io.*;
import java.util.*;
import java.io.PrintWriter;
import java.io.BufferedReader;


public class FioApp {
	/**
	* @param args
	*/
	public static void main(String[] args) throws FileNotFoundException, IOException
	{
		// TODO Auto-generated method stub
		CalcWFio obj = new CalcWFio();
		Scanner s = new Scanner(System.in);
		System.out.print("Enter X: ");
		float data = s.nextFloat();
		obj.calculate(data);
		System.out.println("Console result is: " + obj.getDecResult());
		obj.writeResTxt("textRes.txt");
		obj.writeResBin("BinRes.bin");
		
		obj.readResBin("BinRes.bin");
		System.out.println("Bin Result is: " + obj.getBinResult());
		obj.readResTxt("textRes.txt");
		System.out.println("Txt Result is: " + obj.getDecResult());
	}
}
class CalcWFio
{
	public void writeResTxt(String fName) throws FileNotFoundException
	{
		PrintWriter f = new PrintWriter(fName);
		f.printf("%f ",result);
		f.close();
	}
	public void readResTxt(String fName)
	{
		try
		{
			File f = new File (fName);
			if (f.exists())
			{
				Scanner s = new Scanner(f);
				result = s.nextFloat();
				s.close();
			}
			else
				throw new FileNotFoundException("File " + fName + "not found");
		}
		catch (FileNotFoundException ex)
		{
			System.out.print(ex.getMessage());
		}
	}
	public void writeResBin(String fName) throws FileNotFoundException, IOException
	{
		DataOutputStream f = new DataOutputStream(new FileOutputStream(fName));
		f.writeFloat(result);
		f.close();
	}
	
	public void readResBin(String fName) throws FileNotFoundException, IOException
	{
		DataInputStream f = new DataInputStream(new FileInputStream(fName));
		result = f.readFloat();
		f.close();
	}
	
	public void calculate(float x)
	{
		result = (float) (Math.cos(2.0 * x) / (1 / Math.tan(3.0 * x - 1.0)));
	}
	
	public float getDecResult()
	{
		return result;
	}
	
	public String getBinResult()
	{
		int intBits = Float.floatToIntBits(result);
		String binary = Integer.toBinaryString(intBits);
		return binary;
	}
	
	private float result;
}

