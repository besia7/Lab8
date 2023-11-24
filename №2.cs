using System;

// Абстрактний клас або інтерфейс для всіх типів графіків
public abstract class Chart
{
    public abstract void Draw();
}

// Клас для лінійного графіка
public class LineChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Line Chart");
        // Логіка для малювання лінійного графіка
    }
}

// Клас для стовпчикового графіка
public class BarChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
        // Логіка для малювання стовпчикового графіка
    }
}

// Клас для кругової діаграми
public class PieChart : Chart
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
        // Логіка для малювання кругової діаграми
    }
}

// Factory Method для створення різних типів графіків
public abstract class GraphFactory
{
    public abstract Chart CreateChart();
}

// Фабрика для створення лінійного графіка
public class LineChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new LineChart();
    }
}

// Фабрика для створення стовпчикового графіка
public class BarChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new BarChart();
    }
}

// Фабрика для створення кругової діаграми
public class PieChartFactory : GraphFactory
{
    public override Chart CreateChart()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of chart (line/bar/pie):");
        string chartType = Console.ReadLine().ToLower();

        GraphFactory factory = null;

        // Вибір фабрики в залежності від введеного типу графіка
        switch (chartType)
        {
            case "line":
                factory = new LineChartFactory();
                break;

            case "bar":
                factory = new BarChartFactory();
                break;

            case "pie":
                factory = new PieChartFactory();
                break;

            default:
                Console.WriteLine("Invalid chart type.");
                return;
        }

        // Створення та візуалізація графіка
        Chart chart = factory.CreateChart();
        chart.Draw();
    }
}
