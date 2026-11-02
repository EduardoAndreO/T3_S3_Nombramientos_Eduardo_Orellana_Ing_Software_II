# Tarea Semana 3 – Nombramientos (Clean Code)

Aplicación de consola en **C# (.NET 8)** que demuestra 6 reglas de nombramiento
del libro *Clean Code* (Robert C. Martin, capítulo 2: "Nombres con significado").

Cada demo contiene la **versión SUCIA** (con los errores típicos) y la
**versión LIMPIA** (con los nombres corregidos). El comportamiento de fondo es
idéntico en ambas versiones: solo cambia la calidad de los nombres.

## Cómo compilar y ejecutar

**Opción A – Con Visual Studio 2022 / 2026:**
1. Abra la carpeta o el archivo `TareaSemana3.Nombramientos.csproj`.
2. Presione **F5** o Ctrl+F5.

**Opción B – Con VS Code + .NET 8 SDK:**
```bash
dotnet build
dotnet run
```

**Opción C – Ejecutar todas las demos de una vez (útil para grabar el video):**
```bash
dotnet run -- all
```

## Mapa del proyecto

| Archivo | Tema demostrado | Regla de Clean Code |
|---|---|---|
| `Demos/Prefijos.cs` | Prefijos y miembros | No use `m_`, `str`, `int`, `b`, `arr`, `dbl` ni `Mtd_`: el nombre dice QUÉ guarda, no de qué tipo es |
| `Demos/AsignacionesMentales.cs` | Asignaciones mentales | Evite letras que obligan a "traducir" (`n`, `s`, `m`, `p`, `r`, `v`) |
| `Demos/NombresClases.cs` | Nombres de clases | Las clases son sustantivos del dominio; evite `Data`, `Info`, `Mgr`, `ProcesaCosas` |
| `Demos/NombresMetodos.cs` | Nombres de métodos | Los métodos son frases verbales: `CalcularPromedio`, no `Hacer` ni `Procesar` |
| `Demos/NoExcederAtractivo.cs` | No exceder el atractivo | "Don't be cute": `MagiaNegra` y `Chiripiorca` solo las entiende el autor |
| `Demos/AbreviaturasSimetrias.cs` | Abreviaturas y simetrías | No abrevie; use pares simétricos (`Agregar/Quitar`, `Inscribir/Retirar`) y una sola palabra por concepto |
| `Program.cs` | Menú principal | Ejecuta cada demo o todas seguidas |
| `Comun/Presentacion.cs` | Apoyo | Títulos de consola compartidos |

## Detalles que conviene destacar al defender el código

- **Espacios de nombres por demo** (`Demos.Prefijos`, `Demos.NombresClases`…):
  permiten que existan clases con el mismo nombre en demos distintas
  (por ejemplo `Estudiante` en la demo 1 y en la demo 3) sin conflictos.
- **La nota mínima de aprobación (70)** es una constante con nombre
  (`NotaMinimaAprobacion`) en lugar de un número mágico repetido.
- **Las propiedades** (`{ get; set; }`) reemplazan a los campos públicos con
  prefijos de la versión sucia.
- Las **versiones sucias se conservan a propósito** para poder compararlas en
  vivo durante la explicación del video.

## Salida esperada

Consulte `SalidaDelPrograma.txt` para ver la salida completa de
`dotnet run -- all`.
# T3_S3_Nombramientos_Eduardo_Orellana_Ing_Software_II
