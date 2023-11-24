using System;

// Абстрактні класи для компонентів технологічних продуктів
abstract class Screen
{
    public abstract void Display();
}

abstract class Processor
{
    public abstract void Process();
}

abstract class Camera
{
    public abstract void Capture();
}

// Абстрактна фабрика для створення компонентів технологічних продуктів
abstract class TechProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Конкретні класи компонентів для смартфона
class SmartphoneScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Smartphone Screen: AMOLED display");
    }
}

class SmartphoneProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Smartphone Processor: Snapdragon 8 Series");
    }
}

class SmartphoneCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Smartphone Camera: Dual-camera setup");
    }
}

// Конкретні класи компонентів для ноутбука
class LaptopScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Laptop Screen: IPS display");
    }
}

class LaptopProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Laptop Processor: Intel Core i7");
    }
}

class LaptopCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Laptop Camera: Integrated webcam");
    }
}

// Конкретні класи компонентів для планшета
class TabletScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Tablet Screen: Retina display");
    }
}

class TabletProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Tablet Processor: Apple A14 Bionic");
    }
}

class TabletCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Tablet Camera: Single rear camera");
    }
}

// Клас, що використовує фабрику для збірки технологічних продуктів
class TechProductAssembler
{
    private TechProductFactory _factory;

    public TechProductAssembler(TechProductFactory factory)
    {
        _factory = factory;
    }

    public void AssembleProduct()
    {
        Screen screen = _factory.CreateScreen();
        Processor processor = _factory.CreateProcessor();
        Camera camera = _factory.CreateCamera();

        Console.WriteLine("Assembling Tech Product:");
        screen.Display();
        processor.Process();
        camera.Capture();

        Console.WriteLine("Tech Product Assembled!\n");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a tech product to assemble (smartphone/laptop/tablet):");
        string productType = Console.ReadLine().ToLower();

        TechProductFactory factory = null;

        // Вибір фабрики в залежності від вибраного типу продукту
        switch (productType)
        {
            case "smartphone":
                factory = new SmartphoneFactory();
                break;

            case "laptop":
                factory = new LaptopFactory();
                break;

            case "tablet":
                factory = new TabletFactory();
                break;

            default:
                Console.WriteLine("Invalid product type.");
                return;
        }

        // Збірка технологічного продукту
        TechProductAssembler assembler = new TechProductAssembler(factory);
        assembler.AssembleProduct();
    }
}

// Конкретні фабрики для кожного типу продукту
class SmartphoneFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public override Camera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

class LaptopFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new LaptopScreen();
    }

    public override Processor CreateProcessor()
    {
        return new LaptopProcessor();
    }

    public override Camera CreateCamera()
    {
        return new LaptopCamera();
    }
}

class TabletFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new TabletScreen();
    }

    public override Processor CreateProcessor()
    {
        return new TabletProcessor();
    }

    public override Camera CreateCamera()
    {
        return new TabletCamera();
    }
}

