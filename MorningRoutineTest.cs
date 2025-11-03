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
    public void Mostrar_Leer_entre_las_0700_y_las_0729()
    {
        //Arrange
        var hora = new TimeOnly(7, 23, 00);
        var rutina = new Rutina(hora);
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Leer");
    }
    
    [Fact]
    public void Mostrar_Estudiar_entre_las_0730_y_las_0759()
    {
        //Arrange
        var hora = new TimeOnly(7, 35, 00);
        var rutina = new Rutina(hora);
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Estudiar");
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
    
    [Fact]
    public void Mostrar_Ducharse_entre_las_0645_y_las_0659()
    {
        //Arrange
        var hora = new TimeOnly(6, 50, 00);
        var rutina = new Rutina(hora);
        //Act
        
        //Assert
        rutina.WhatShouldIDoNow().Should().Be("Ducharse");
    }
    
}

public class Rutina(TimeOnly horaRutina) :IMorningRoutine
{
    
 
    public string WhatShouldIDoNow()
    {

        if (horaRutina.Hour == 7 && horaRutina.Minute < 30)
            return "Leer";
        if (horaRutina.Hour == 7 && horaRutina.Minute > 30)
            return "Estudiar";
        
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
