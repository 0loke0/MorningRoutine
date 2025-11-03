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

public class Rutina(TimeOnly horaRutina):IMorningRoutine
{
    private readonly List<IEstrategia> _estrategias = new()
    {
        new LeerEstrategia(),
        new EstudiarEstrategia(),
        new DucharseEstrategia(),
        new HacerEjercicioEstrategia(),
        new DesayunarEstrategia(),
    };

    public string WhatShouldIDoNow()
    {
        var estrategiaEncontrada = _estrategias.FirstOrDefault(s => s.EsHorarioActividad(horaRutina));
        return estrategiaEncontrada?.ObtenerActividad() ?? "Sin actividad";
    }
}

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}

public interface IEstrategia
{
    bool EsHorarioActividad(TimeOnly time);
    string ObtenerActividad();
}

public class HacerEjercicioEstrategia : IEstrategia
{
    public bool EsHorarioActividad(TimeOnly time) => time.Hour == 6 && time.Minute <= 45;
    public string ObtenerActividad() => "Hacer ejercicio";
}

public class DucharseEstrategia : IEstrategia
{
    public bool EsHorarioActividad(TimeOnly time) => time.Hour == 6 && time.Minute > 45;
    public string ObtenerActividad() => "Ducharse";
}

public class LeerEstrategia : IEstrategia
{
    public bool EsHorarioActividad(TimeOnly time) => time.Hour == 7 && time.Minute < 30;
    public string ObtenerActividad() => "Leer";
}

public class EstudiarEstrategia : IEstrategia
{
    public bool EsHorarioActividad(TimeOnly time) => time.Hour == 7 && time.Minute > 30;
    public string ObtenerActividad() => "Estudiar";
}
public class DesayunarEstrategia : IEstrategia
{
    public bool EsHorarioActividad(TimeOnly time) => time.Hour == 8;
    public string ObtenerActividad() => "Desayunar";
}

