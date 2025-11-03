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

    [Fact]
    public void Mostrar_Leer_y_estudiar_entre_las_0700_y_las_0759()
    {
        //Arrange
        var hora = new TimeOnly(7, 23, 00);
        var rutina = new Rutina(hora);
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Leer y estudiar");
    }
    [Fact]
    public void Mostrar_Desayunar_entre_las_0800_y_las_0859()
    {
        //Arrange
        var hora = new TimeOnly(8, 23, 00);
        var rutina = new Rutina(hora);
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Desayunar");
    }

    [Fact]
    public void Mostrar_Sin_actividad_fuera_del_intervalo_de_tiempo_definido()
    {
        //Arrange
        var hora = new TimeOnly(9, 23, 00);
        var rutina = new Rutina(hora);
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Sin actividad");
    }
}

public class Rutina(TimeOnly horaRutina) :IMorningRoutine
{
    public string WhatShouldIDoNow()
    {
        return horaRutina.Hour switch
        {
            6 => "Hacer ejercicio",
            7 => "Leer y estudiar",
            8 => "Desayunar",
            _ => "Sin actividad"
        };
    }
}

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}
