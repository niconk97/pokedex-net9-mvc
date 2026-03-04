# Pokedex .NET 9

## Descripción

Este proyecto es una **readaptación simplificada** del proyecto Pokedex desarrollado originalmente por **MaxiPrograma**, utilizado en sus cursos:
- **Curso C# Nivel 2 [.Net + SQL]**
- **Curso C# Nivel 3 [Web .Net]**

La solución ha sido adaptada para ejecutarse en **Visual Studio Code** con **.NET 9**, manteniendo la funcionalidad core de gestión de Pokémon y simplificando la estructura para facilitar el aprendizaje y desarrollo.

## 📁 Estructura del Proyecto

```
pokedex-net9/
│
├── Pokedex.Dominio/          # Capa de dominio (entidades)
│   ├── Pokemon.cs            # Clase Pokemon
│   ├── Elemento.cs           # Clase Elemento (tipos)
│   └── Trainee.cs            # Clase Trainee
│
├── Pokedex.Negocio/          # Capa de negocio (lógica y acceso a datos)
│   ├── PokemonNegocio.cs     # Lógica de negocio de Pokemon
│   ├── ElementoNegocio.cs    # Lógica de negocio de Elemento
│   ├── AccesoDatos.cs        # Acceso a datos SQL Server
│   ├── AccesoDatosSQLITE.cs  # Acceso a datos SQLite
│   └── script_db/            # Scripts de base de datos
│       ├── POKEDEX_DB.SQL        # Script para SQL Server
│       └── POKEDEX_DB_SQLITE.sql # Script para SQLite
│
└── Pokedex.Net9.sln          # Archivo de solución
```

## 🛠️ Tecnologías Utilizadas

- **.NET 9.0**
- **C#**
- **SQL Server** (opcional)
- **SQLite** (opcional, alternativa ligera)
- **ADO.NET** (acceso a datos)

## 📋 Requisitos Previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/)
- Extensión de C# para VS Code (ms-dotnettools.csharp)
- SQL Server (opcional) o SQLite (opcional)

## 🚀 Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/niconk97/pokedex-net9.git
cd pokedex-net9
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Configurar Base de Datos

#### Opción A: SQL Server

1. Ejecutar el script `Pokedex.Negocio/script_db/POKEDEX_DB.SQL` en SQL Server
2. Configurar la cadena de conexión en tu aplicación

#### Opción B: SQLite

1. Ejecutar el script `Pokedex.Negocio/script_db/POKEDEX_DB_SQLITE.sql` 
2. Configurar la ruta del archivo .db en tu aplicación

### 4. Compilar el proyecto

```bash
dotnet build
```

## 🎯 Uso

Este proyecto sirve como base para desarrollar aplicaciones de gestión de Pokémon. Puedes:

- Extender las capas de dominio y negocio
- Agregar nuevas entidades
- Implementar interfaces de usuario (Console, Web, Desktop)
- Practicar conceptos de arquitectura en capas

## 📚 Créditos

Proyecto original desarrollado por **MaxiPrograma** para sus cursos de C# y .NET.

- Cursos: [MaxiPrograma](https://www.maxiprograma.com/)
- YouTube: [MaxiPrograma en YouTube](https://www.youtube.com/@MaxiPrograma)

## 📄 Licencia

Este proyecto ha sido adaptado con fines educativos.

## 👤 Autor de la Adaptación

- GitHub: [@niconk97](https://github.com/niconk97)

---

⭐ Si este proyecto te resultó útil, considera darle una estrella en GitHub
