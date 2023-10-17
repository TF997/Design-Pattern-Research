/*
 * A pattern for when function calls and properties need to be different and come from
 * different objects but give the same result. For example a Button.Click() function
 * should carry out the same functionality regardless if its a Windows button or Mac
 * button but the creation of the button will differ and will be created through either
 * a windowsButton.create() function or a macButton.Create function.
 */

using System;

namespace Example.Factory;

abstract class Factory
{
    protected abstract IButton CreateButton();
        
    public string ClickButton()
    {
        var product = CreateButton();
        return product.Click();
    }
}

class WindowsButtonFactory : Factory
{
    protected override IButton CreateButton()
    {
        return new WindowsButton();
    }
}

class MacButtonFactory : Factory
{
    protected override IButton CreateButton()
    {
        return new MacButton();
    }
}
    
public interface IButton
{
    string Click();
}
    
class WindowsButton : IButton
{
    public string Click()
    {
        return "Windows Button Click";
    }
}

class MacButton : IButton
{
    public string Click()
    {
        return "Mac Button Click";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("When launched on Windows:");
        UxApplication(new WindowsButtonFactory());
            
        Console.WriteLine("\n");

        Console.WriteLine("When launched on Mac:");
        UxApplication(new MacButtonFactory());
    }
    
    private static void UxApplication(Factory factory)
    {
        Console.WriteLine(factory.ClickButton());
    }
}