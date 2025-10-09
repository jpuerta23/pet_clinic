using System;
using System.Collections.Generic;

namespace HealthClinic.Models;

public abstract class Animal
{
    // Nombre del animal, inicializado para evitar null
    public string Name { get; set; } = string.Empty;

    // Tipo de animal (ej: perro, gato, ave)
    public string Type { get; set; } = string.Empty;

    // Edad inicial en 0
    public double Age { get; set; } = 0;

   

    public virtual string Emitsound()
    {
        return "Sound generic animal";
    }
}
