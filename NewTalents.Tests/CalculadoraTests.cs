using NewTalents.Console.Models;

namespace NewTalents.Tests;

public class CalculadoraTests
{
    private Calculadora ConstruirClasse()
    {
        string data = "27/04/2024";
        Calculadora calc = new("27/04/2024");

        return calc;
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(5, 4, 9)]
    public void TestarSomar(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Somar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(6, 2, 4)]
    [InlineData(5, 5, 0)]
    public void TestarSubtrair(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Subtrair(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(2, 1, 2)]
    [InlineData(5, 4, 20)]
    public void TestarMultiplicar(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Multiplicar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(5, 5, 1)]
    public void TestarDividir(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();

        int resultadoCalculadora = calc.Dividir(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Calculadora calc = ConstruirClasse();

        Assert.Throws<DivideByZeroException>(() =>
        {
            calc.Dividir(3, 0);
        });
    }

    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = ConstruirClasse();

        calc.Somar(1, 2);
        calc.Somar(3, 4);
        calc.Somar(5, 6);
        calc.Somar(7, 8);

        var lista = calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}