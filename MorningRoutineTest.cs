using AwesomeAssertions;

namespace MorningRoutine;

public class MorningRoutineTest
{
    [Fact]
    public void Mostrar_Hacer_ejercicio_entre_las_0600_y_las_0659()
    {
        //Arrange
        var hora = new TimeOnly(6, 23, 00);
        var rutina = new Rutina(hora);
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Hacer ejercicio");
    }
}

public class Rutina(TimeOnly horaRutina) :IMorningRoutine
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
