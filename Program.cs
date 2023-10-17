using System;
using System.ComponentModel;
// Step 1: Abstraction
public abstract class RemoteControl
{
    protected IDevice device;

    public RemoteControl(IDevice device)  //dependency injection
    {
        this.device = device;
    }
    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract void SetChannel(int channel);
}

// Step 2: Refined Abstraction
public class BasicRemoteControl : RemoteControl
{
    public BasicRemoteControl(IDevice device) : base(device) { }

    public override void TurnOn()
    {
        device.TurnOn();
    }

    public override void TurnOff()
    {
        device.TurnOff();
    }

    public override void SetChannel(int channel)
    {
        device.SetChannel(channel);
    }
}
// Step 3: Implementor

public interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}

// Step 4: Concrete Implementors
public class TV : IDevice
{
    public void TurnOn() { Console.WriteLine("Implementation for turning on the TV"); }
    public void TurnOff() { Console.WriteLine("Implementation for turning off the TV"); }
    public void SetChannel(int channel) { Console.WriteLine("Implementation for setting TV channel"); }
}
public class DVDPlayer : IDevice
{
    public void TurnOn()
    { Console.WriteLine("Implementation for turning on the dvd "); }
    public void TurnOff()
    {
        Console.WriteLine(" Implementation for turning off the DVD player");
    }
    public void SetChannel(int channel)
    {
        Console.WriteLine(" DVD player doesn't have channels");
    }
}
// Step 5: Client Code (Usage)
class Program
{
    static void Main(string[] args)
    {
        IDevice tv = new TV();
        RemoteControl remote = new BasicRemoteControl(tv);
        remote.TurnOn();
        remote.SetChannel(5);
        remote.TurnOff();
    }
}


/*
The Bridge pattern is used when a new version of a software or system is brought out, but the older version of the software still running for its existing client.

/*the Bridge Design Pattern “Decouples an abstraction from its implementation so that the two can vary independently“.

In the Bridge Design Pattern, there are 2 parts. The first part is the Abstraction and the second part is the Implementation. The Bridge Design Pattern allows both Abstraction and Implementation to be developed independently and the client code can only access the Abstraction part without being concerned about the Implementation part.*/

/*Q. Bridge Pattern seems just as Inheritance isn't it?
Ans: Yes but not just inheritance as Bridge Design Pattern focuses on separating an object's abstraction (high-level interface i.e. abstraction) from its implementation (low-level details i.e Interface and Concrete Classes). It does this by introducing two hierarchies, one for abstraction and another for implementation. This separation allows you to vary them independently, providing greater flexibility and avoiding the problems associated with a large class hierarchy. 
    The Bridge Pattern is represented by two hierarchies: one for abstractions and another for implementations, and it is not primarily about creating new 
    classes through inheritance.*/
