import java.awt.event.KeyEvent;
import java.util.Scanner;

public class OperacjiArytmetyczne 
{
	public static void main(String[] args ) 
	{
		Scanner scanner = new Scanner(System.in);
		double result = 0;
		
		System.out.println("HELLO, I'M CALCULATOR :D\nI CAN +,-,*,/ YOUR NUMBERS!\nGOOD LUCK!\n");
		
		try {
		System.out.println("Enter first number: ");
		result += scanner.nextDouble();
		}
		catch (java.util.InputMismatchException ex){
			System.out.println("Wrong number: " + ex);
			return;
		}
		while(true) 
		{
			double next_num = 0;
	        
	        try {
	        System.out.println("Enter next number: ");
	        next_num = scanner.nextDouble(); 
			}
	        catch (java.util.InputMismatchException ex)
	        {
				System.out.println("Wrong number: " + ex);
				break;
	        }
			
	        System.out.println("Choose operation (or 'q' to quit):");
	        System.out.println("1. Addition (+)");
	        System.out.println("2. Subtraction (-)");
	        System.out.println("3. Multiplication (*)");
	        System.out.println("4. Division (/)");
	        
	        char operator = scanner.next().charAt(0);
	        
	        if (operator == 'q') 
	        {
	        	break;
	        }
	        
			
	        switch (operator) {
            case '+':
                result += next_num;
                break;
            case '-':
                result -= next_num;
                break;
            case '*':
                result *= next_num;
                break;
            case '/':
                if (next_num != 0) 
                {
                    result /= next_num;
                } else {
                    System.out.println("Cannot divide by zero.");
                }
                break;
            default:
                System.out.println("Invalid operator. Please enter one of the following: +, -, *, /");
	        }
	        
	        
	        
	        System.out.println("Final result: " + result);
		}	
		System.out.println("Calculator was closed!");   
	    scanner.close();    
	}
}