using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace RedPillServer
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RedPill" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select RedPill.svc or RedPill.svc.cs at the Solution Explorer and start debugging.
  public class RedPill : IRedPill
  {
   
    
    public ContactDetails WhoAreYou()
    {
    
      return new ContactDetails
      {
        EmailAddress = "ajai.np@gmail.com",
        FamilyName = "Narayana Pillai",
        GivenName = "Ajai",
        PhoneNumber = "+6593907119 "
      };
    }

    public long FibonacciNumber(long n)
    {
      
      if (n > 92 || n < -92)
      {
        
        throw new FaultException<ArgumentOutOfRangeException>(new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow."));
      }
      long a = 0;
      long b = 1;
    
      for (long i = 0; i < n; i++)
      {
        long temp = a;
        a = b;
        b = temp + b;
      }

    

      return a;
    }

    public TriangleType WhatShapeIsThis(int a, int b, int c)
    {

     
      if (a <= 0 || b <= 0 || c <= 0)
      {
        
        return TriangleType.Error;
      }
      if (a == b && a == c && b == c)
      {
        
        return TriangleType.Equilateral;
      }
      else if (a != b && a != c && b != c)
      {
        
        return TriangleType.Scalene;
      }
      else
      {
        
        return TriangleType.Isosceles;
      }
    }

    public string ReverseWords(string s)
    {

      //Custom reverse logic

      if (s == null)
        throw new FaultException<ArgumentNullException>(new ArgumentNullException("s", "Input argument missing"));
      StringBuilder sbReversed = new StringBuilder();
      Stack<char> stack = new Stack<char>();
      Action reverseWord = () =>
      {

        while (stack.Count > 0)
          sbReversed.Append(stack.Pop());
      };

      s.ToList()
          .ForEach(atIndex =>
          {

            if (atIndex == ' ')
            {
              reverseWord();
              sbReversed.Append(" ");
            }
            else
            {
              stack.Push(atIndex);
            }
          });

      reverseWord();

      string ret = sbReversed.ToString();

     
      return ret;
    }
  }
}
