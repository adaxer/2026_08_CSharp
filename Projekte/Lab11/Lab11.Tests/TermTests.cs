namespace Lab11.Tests;

public class TermTests
{
    [Fact]
    public void CorrectInput_Sets_Properties_Right()
    {
        // Arrange + Act
        Term term = new Term("10+5");

        // Assert
        Assert.Equal(10, term.Zahl1);
        Assert.Equal(5, term.Zahl2);
        Assert.Equal(Rechenoperation.Addition, term.Operation);
    }

    [Fact]
    public void Test2()
    {
        Term term = new Term("10.1*5.3");
        Assert.Equal(10, term.Zahl1);
        Assert.Equal(5, term.Zahl2);
        Assert.Equal(Rechenoperation.Multiplikation, term.Operation);

        //Assert.Throws<FormatException>(() => new Term("10.1*5.3"));
        //Assert.False(term.IsValid)
    }
}
