// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;

bool fortfahren = true; 
string username="", password="", acceptedusername="", aceptedPassword="";
char[] passwordChar;
int digitCount = 0,letterCount=0, messageCounter= 0;
string entryMessage="";



while (fortfahren)
{
    int wrongEnter = 0;

    if (messageCounter == 1)
    {
        entryMessage = "your password must be at least 6 characters\nand contain at least one letter and one number.";
    }
    else if (messageCounter == 2)
    {
        entryMessage = "Your account has been locked.please register again\n";
        
    }
    else entryMessage = "";




    Console.Clear();
    Console.WriteLine(entryMessage);
    Console.WriteLine("You must register first to log in.(for exit press 1)");
    Console.WriteLine("Enter your username: ");
    username = Console.ReadLine();


    if (username != "1") {
        Console.WriteLine("enter your passwort :");
        password = Console.ReadLine();
       
        if (password != "1")
        {
            
            passwordChar = password.ToCharArray();
            Console.WriteLine("Kod buraya kadar geldi");
            
                for (int i = 0; i < passwordChar.Length; i++)
                {
                    if (Char.IsDigit(passwordChar[i])) digitCount++;
                    if (Char.IsLetter(passwordChar[i])) letterCount++;
                   
                }
            Console.WriteLine(passwordChar);

            if (digitCount > 0 && letterCount > 0 && password.Length >= 6)
            {
                digitCount = 0; letterCount=0;
                acceptedusername = username;
                aceptedPassword = password;
                bool fortfahren2 = true;
                while (fortfahren2)
                {
                    Console.Clear();
                    
                    string message2 = "";
                 
                    if (wrongEnter == 0) message2 = "\nSuccessful. username and password have been saved.\nYou can now log in\n"; 
                    else if(wrongEnter == 1) message2 = $"\nAccess denied. Remaining attempts: {2-wrongEnter}";
                    
                    Console.WriteLine(message2);
                    
                    Console.WriteLine("Enter your username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("enter your passwort :");
                    password = Console.ReadLine();
                    

                    if (username == acceptedusername && password == aceptedPassword)
                    {
                       Console.Clear() ;
                       // Console.WriteLine(acceptedusername + " " + aceptedPassword);
                       // Console.WriteLine(username + " " + password);
                        Console.WriteLine("\nCongratulations, you have logged in successfully.\n");
                        bool fortfahren3 = true;
                        while (fortfahren3)
                        {
                            Console.WriteLine("Would you like to try again? (y/n)");
                            string answer = Console.ReadLine();
                            if (answer.ToLower().Equals("y"))
                            {
                                messageCounter = 0;
                                fortfahren3 = false;
                                fortfahren2 = false;
                            }
                            else if (answer.ToLower().Equals("n"))
                            {
                                fortfahren3 = false;
                                fortfahren2 = false;
                                fortfahren = false;
                            }
                            else Console.WriteLine("please press y or n");
                        }


                        acceptedusername = "";
                        aceptedPassword = "";
                        username = "";
                        password = "";
                        
                       fortfahren2 = false;
                    }
                    else
                    {

                        wrongEnter++;

                        if (wrongEnter ==2)
                        {
                            acceptedusername = "";
                            aceptedPassword = "";
                            username = "";
                            password = "";
                            messageCounter = 2;
                            fortfahren2 = false;
                            
                        }
                    }
                }
            }
            else messageCounter = 1;
        } else fortfahren = false;
    }else fortfahren = false;
}    
