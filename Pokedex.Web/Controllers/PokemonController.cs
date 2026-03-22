using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pokedex.Dominio;
using Pokedex.Negocio;

namespace Pokedex.Web.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public IActionResult Index(string filtro)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            var pokemons = negocio.listarSQLITE();

            if (!string.IsNullOrEmpty(filtro))
            {
                // Si se proporciona un filtro, se filtran los pokemons por nombre (ignorando mayúsculas/minúsculas)
                // StringComparison.OrdinalIgnoreCase permite comparar cadenas sin importar mayúsculas o minúsculas
                pokemons = pokemons.FindAll(p => p.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase));
            }
            ViewBag.Filtro = filtro; // Esto permite mantener el valor del filtro en la vista después de realizar la búsqueda
            return View(pokemons);
        }

        // GET: Pokemon/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PokemonNegocio negocioPokemon = new PokemonNegocio();
            var pokemon = negocioPokemon.listarSQLITE().Find(p => p.Id == id);
            return View(pokemon);
        }

        // GET: Pokemon/Create
        public IActionResult Create()
        {
            ElementoNegocio negocioElemento = new ElementoNegocio();
            ViewBag.Elementos = new SelectList(negocioElemento.listarSQLITE(), "Id", "Descripcion");
            return View();
        }

        // POST: Pokemon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pokemon pokemon)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(pokemon); // si hubo algun error de validacion, se vuelve a mostrar el formulario con los datos ingresados
                }
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.agregarSQLITE(pokemon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {   
                return View(pokemon);
            }
        }

        // GET: Pokemon/Edit/5
        public IActionResult Edit(int? id)
        {
            ElementoNegocio negocioElemento = new ElementoNegocio();
            PokemonNegocio negocioPokemon = new PokemonNegocio();
            var pokemon = negocioPokemon.listarSQLITE().Find(p => p.Id == id); // esto me permite obtener el pokemon a editar basado en el id
            var lista = negocioElemento.listarSQLITE();
            // esto me permite cargar el dropdown de tipos y debilidades con la lista de elementos y seleccionar el tipo y debilidad actual del pokemon
            ViewBag.Tipos = new SelectList(lista, "Id", "Descripcion", pokemon.Tipo.Id); 
            ViewBag.Debilidades = new SelectList(lista, "Id", "Descripcion", pokemon.Debilidad.Id);
            return View(pokemon);
        }

        // POST: Pokemon/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pokemon pokemon)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.modificarSQLITE(pokemon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(pokemon);
            }
        }

        // GET: Pokemon/Delete/5
        public IActionResult Delete(int? id)
        {
            PokemonNegocio negocioPokemon = new PokemonNegocio();
            var pokemon = negocioPokemon.listarSQLITE().Find(p => p.Id == id);
            return View(pokemon);
        }

        // POST: Pokemon/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {   
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.eliminarSQLITE(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
    }
}
