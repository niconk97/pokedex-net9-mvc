# Pokedex .NET 9

## Descripción

Este proyecto es una **readaptación simplificada** del proyecto Pokedex desarrollado originalmente por **MaxiPrograma**, utilizado en sus cursos:
- **Curso C# Nivel 2 [.Net + SQL]**
- **Curso C# Nivel 3 [Web .Net]**

La solución ha sido adaptada para ejecutarse en **Visual Studio Code** con **.NET 9**, manteniendo la funcionalidad core de gestión de Pokémon y simplificando la estructura para facilitar el aprendizaje y desarrollo.

## ⚠️ Aclaraciones Importantes

- **Este repositorio está enfocado para ser utilizado en el nivel 4** del curso de MaxiPrograma.
- **Algunas características fueron omitidas** porque en el curso de nivel 4 de .NET no se utilizarán o serán readaptadas a la nueva tecnología con MVC.
- **Algunas cosas pueden ser mejoradas**, ya que aún estoy en proceso de aprendizaje y no soy un experto en .NET.
- **Para usuarios de Linux/macOS**: Se recomienda utilizar la implementación con **SQLite** (`AccesoDatosSQLITE`) o cualquier base de datos relacional compatible con Linux (como PostgreSQL, MySQL o SQL Server para Linux en Docker). La implementación por defecto usa SQL Server Express que está orientado a Windows.

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

#### Opción A: SQL Server (Windows)

1. **Crear la base de datos**: Ejecutar el script `Pokedex.Negocio/script_db/POKEDEX_DB.SQL` en SQL Server Management Studio
2. **Configurar cadena de conexión**: Editar el archivo `Pokedex.Negocio/AccesoDatos.cs` (línea ~27):
   ```csharp
   private const string CadenaConexion = "Server=.\\SQLEXPRESS;Database=POKEDEX_DB;Integrated Security=True;TrustServerCertificate=True";
   ```
3. **Usar en tu código**: Instanciar `AccesoDatos` para operaciones de base de datos

#### Opción B: SQLite (Multiplataforma - Recomendada para Linux/macOS)

1. **Crear la base de datos**: 
   - **Opción 1 - Línea de comandos**:
     - Instalar SQLite: [https://sqlite.org/download.html](https://sqlite.org/download.html)
     - Ejecutar en terminal:
       ```bash
       sqlite3 pokedex.db < Pokedex.Negocio/script_db/POKEDEX_DB_SQLITE.sql
       ```
   - **Opción 2 - DB Browser for SQLite** (interfaz gráfica):
     - Descargar e instalar [DB Browser for SQLite](https://sqlitebrowser.org/)
     - Crear nueva base de datos: `File > New Database` → guardar como `pokedex.db`
     - Ir a la pestaña `Execute SQL`
     - Copiar y pegar el contenido del archivo `POKEDEX_DB_SQLITE.sql` o abrirlo con el botón de carpeta
     - Ejecutar el script (botón ▶ o F5)
     - Guardar cambios: `File > Write Changes`
2. **Ubicar el archivo**: Colocar `pokedex.db` en la raíz del proyecto o en `Pokedex.Negocio/script_db/`
3. **Configuración automática**: `AccesoDatosSQLITE.cs` busca automáticamente el archivo en estas ubicaciones
4. **Usar en tu código**: Instanciar `AccesoDatosSQLITE` para operaciones de base de datos

> **Nota**: Las cadenas de conexión están hardcodeadas en el código para simplificar el aprendizaje. En proyectos reales deberían estar en archivos de configuración.

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
