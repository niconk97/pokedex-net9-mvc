using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pokedex.Dominio;
using Pokedex.Negocio;

namespace Pokedex.Web.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public IActionResult Index()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            return View(negocio.listarSQLITE());
        }

        // GET: Pokemon/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
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
                pokemon.Tipo = new Elemento { Id = 1 }; // TODO: agregar el tipo basado en la entrada del usuario
                pokemon.Debilidad = new Elemento { Id = 1 }; // TODO: agregar la debilidad basada en la entrada del usuario
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
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Pokemon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete logic here
            return RedirectToAction(nameof(Index));
        }
    }
}
