package lab1;
import java.io.*;
import java.util.*;
/**
* Клас Lab1ListunovaKI302 реалізує приклад програми до лабораторної роботи No1
*/
public class Lab1ListunovaKI302
{
	/**
	* Статичний метод main є точкою входу в програму
	*
	* @param args
	* @throws FileNotFoundException
	*
	*/
	public static void main(String[] args) throws FileNotFoundException 
	{
		int nRows;
		char[][] arr;
		String filler;
		Scanner in = new Scanner(System.in);
		File dataFile = new File("MyFile.txt");
		PrintWriter fout = new PrintWriter(dataFile);
		
		System.out.print("Введіть розмір квадратної матриці: ");
		
		if (!in.hasNextInt()) 
		{
		    System.out.print("Розмір квадратної матриці задано некоректно. Введіть ціле число.");
		    fout.close();
		    return;
		}

		nRows = in.nextInt();
		in.nextLine();
		
		if (nRows < 3) 
		{
		    System.out.print("Розмір квадратної матриці має бути більшим або дорівнювати 3, щоби продемонструвати, що програма працює відповідно до завдання.");
		    fout.close();
		    return;
		}
		
		if (nRows >= 224) 
		{
		    System.out.print("Якщо розмір квадратної матриці буде більший або дорівнюватиме 224, консоль не покаже першого рядка матриці. Перевірено ручним способом ;)\n"
		    + "Бачити, що у першому рядку немає символів-заповнювачів, - суттєва складова завдання, тому розмір квадратної матриці було обмежено.");
		    fout.close();
		    return;
		}
		
		arr = new char[nRows][]; //просто [nRows][nRows] теж працює
		for(int i = 0; i < nRows; i++)
		{
			arr[i]= new char[nRows]; //зубчастий масив
		}
		
		System.out.print("\nВведіть символ-заповнювач: ");
		filler = in.nextLine();
		
	exit:
		for(int i = 0; i < nRows; i++) 
		{
			for(int j = 0; j < nRows; j++) 
			{
				if(filler.length() == 1) 
				{
					if (i == 0 || j == 0 || i == nRows-1 || j == nRows-1) 
					{
						arr[i][j] = (char) filler.codePointAt(0);
						System.out.print(" " + " ");
						fout.print(" " + " ");
					} 
					else 
					{
						arr[i][j] = (char) filler.codePointAt(0);
						System.out.print(arr[i][j] + " ");
						fout.print(arr[i][j] + " ");
					}
				} 
				else if (filler.length() == 0) 
				{
					System.out.print("\nНе введено символ-заповнювач.");
					
					break exit;
				} 
				else 
				{
					System.out.print("\nЗабагато символів-заповнювачів.");
					
					break exit;
				}
			}
			System.out.print("\n");
			fout.print("\n");
		}
		fout.flush();
		fout.close();
	}
}