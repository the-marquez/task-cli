# Task Tracker CLI with C# and .NET 10

Administrador de tareas desde la terminal, desarrollado en **C# y .NET 10**. Permite crear, consultar, actualizar, eliminar y cambiar el estado de tareas. Los datos se almacenan en un archivo `tasks.json`.

**Reto:** [Task Tracker CLI — roadmap.sh](https://roadmap.sh/projects/task-tracker)

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Terminal de comandos (PowerShell, CMD o Bash).

## Instalación

Clona el repositorio y accede al proyecto:

```bash
git clone https://github.com/the-marquez/task-cli.git
cd task-cli
```

Compila el proyecto:

```bash
dotnet build
```

Ejecuta la aplicación según la configuración de compilación o utiliza el ejecutable generado.

## Comandos disponibles

| Comando | Descripción |
|---|---|
| `help` | Muestra la ayuda |
| `version` | Muestra la versión |
| `add "Descripción"` | Crea una tarea |
| `list` | Lista todas las tareas |
| `list todo` | Muestra tareas pendientes |
| `list in-progress` | Muestra tareas en progreso |
| `list done` | Muestra tareas completadas |
| `update <task_id> "Descripción"` | Actualiza una tarea |
| `delete <task_id>` | Elimina una tarea |
| `mark-in-progress <task_id>` | Marca una tarea en progreso |
| `mark-done <task_id>` | Marca una tarea como completada |

> Sustituye `<task_id>` por el identificador de la tarea. Usa comillas cuando la descripción contenga espacios.

## Ejemplos

```bash
task-cli.exe add "Aprender C#"
task-cli.exe list
task-cli.exe update 1 "Practicar C# y .NET"
task-cli.exe mark-in-progress 1
task-cli.exe mark-done 1
task-cli.exe delete 1
```

Para consultar únicamente las tareas pendientes:

```bash
task-cli.exe list todo
```

## Almacenamiento

Las tareas se guardan en `tasks.json` en formato JSON. Cada registro contiene:

- `Id`: identificador de la tarea.
- `Description`: descripción.
- `Status`: estado (`todo`, `in-progress` o `done`).
- `CreatedAt`: fecha de creación.
- `UpdatedAt`: fecha de última modificación.

Los identificadores no se renumeran cuando se elimina una tarea.

## Tecnologías

- **C#**
- **.NET 10**
- **System.Text.Json** para la persistencia de datos.

## Autor

**Elmer Marquez** · [GitHub](https://github.com/the-marquez)

---

Proyecto desarrollado como práctica de programación de aplicaciones de consola y gestión de archivos JSON.