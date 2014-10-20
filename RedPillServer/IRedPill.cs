using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RedPillServer
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRedPill" in both code and config file together.
  [ServiceContract(Namespace="http://KnockKnock.readify.net")]
  public interface IRedPill
  {
    [OperationContract(Action = "http://KnockKnock.readify.net/IRedPill/WhoAreYou", ReplyAction = "http://KnockKnock.readify.net/IRedPill/WhoAreYouResponse")]
    ContactDetails WhoAreYou();

    [OperationContract(Action = "http://KnockKnock.readify.net/IRedPill/FibonacciNumber", ReplyAction = "http://KnockKnock.readify.net/IRedPill/FibonacciNumberResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentOutOfRangeException), Action = "http://KnockKnock.readify.net/IRedPill/FibonacciNumberArgumentOutOfRangeException" +
           "Fault", Name = "ArgumentOutOfRangeException", Namespace = "http://schemas.datacontract.org/2004/07/System")]
    long FibonacciNumber(long n);

    [OperationContract(Action = "http://KnockKnock.readify.net/IRedPill/WhatShapeIsThis", ReplyAction = "http://KnockKnock.readify.net/IRedPill/WhatShapeIsThisResponse")]
    TriangleType WhatShapeIsThis(int a, int b, int c);

    [OperationContract(Action="http://KnockKnock.readify.net/IRedPill/ReverseWords")]
    [System.ServiceModel.FaultContractAttribute(typeof(System.ArgumentNullException), Action = "http://KnockKnock.readify.net/IRedPill/ReverseWordsArgumentNullExceptionFault", Name = "ArgumentNullException", Namespace = "http://schemas.datacontract.org/2004/07/System")]
    
    string ReverseWords(string s);
  }
}
