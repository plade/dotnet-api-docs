﻿// System.Net.WebResponse.GetResponseStream

/* This program demonstrates the 'GetResponseStream' method of the 'WebResponse' class.
It creates a web request and queries for a response. It then gets the response stream. This response stream 
is piped to a higher level stream reader. The reader reads 256 characters at a time, writes them into a string and then displays the string in the console.*/

using System;
using System.Net;
using System.IO;
using System.Text;

class WebResponseSnippet 
{
   public static void Main(string[] args) 
   {
      if (args.Length < 1) 
		{	
			Console.WriteLine("\nPlease enter the Url as command line parameter:");
			Console.WriteLine("Example:");
			Console.WriteLine("WebResponse_GetResponseStream http://www.microsoft.com/net/");
		} 
		else 
		{
			getPage(args[0]);
		}
      Console.WriteLine("Press any key to continue...");
		Console.ReadLine();
      return;
    }

   public static void getPage(String url) 
	{

	try 
   {
// <Snippet1>

        // Create a 'WebRequest' object with the specified url. 
	 WebRequest myWebRequest = WebRequest.Create("http://www.contoso.com"); 

	// Send the 'WebRequest' and wait for response.
	WebResponse myWebResponse = myWebRequest.GetResponse(); 

	// Obtain a 'Stream' object associated with the response object.
	Stream ReceiveStream = myWebResponse.GetResponseStream();
	        	
	Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

        // Pipe the stream to a higher level stream reader with the required encoding format. 
	 StreamReader readStream = new StreamReader( ReceiveStream, encode );
	 Console.WriteLine("\nResponse stream received");
	 Char[] read = new Char[256];

        // Read 256 charcters at a time.    
	 int count = readStream.Read( read, 0, 256 );
        Console.WriteLine("HTML...\r\n");

	while (count > 0) 
	{
    	    // Dump the 256 characters on a string and display the string onto the console.
	    String str = new String(read, 0, count);
	    Console.Write(str);
	    count = readStream.Read(read, 0, 256);
	}

       Console.WriteLine("");
     // Release the resources of stream object.
     readStream.Close();

     // Release the resources of response object.
     myWebResponse.Close(); 

// </Snippet1>			
        	} 
		catch(WebException e) 
			{
				Console.WriteLine("\nWebException Raised.Status is: {0}",e.Status); 
        	}
		catch(Exception e)
			{
				Console.WriteLine("\nThe following Exception was raised.Message is: {0}",e.Message);
			}
	}
}