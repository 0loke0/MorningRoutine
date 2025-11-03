using AwesomeAssertions;

namespace MorningRoutine;

public class MorningRoutineTest
{
    [Fact]
    public void Mostrar_Hacer_ejercicio_entre_las_0600_y_las_0659()
    {
        //Arrange
        var rutina = new Rutina("6:10");
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Hacer ejercicio");
    }
}

public class Rutina(string horaRutina) :IMorningRoutine
{
    public string WhatShouldIDoNow()
    {
        return "Hacer ejercicio";
    }
}

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}
