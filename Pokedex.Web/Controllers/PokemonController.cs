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
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Pokemon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Numero,Nombre,Descripcion")] object pokemon)
        {
            if (id != 0) // TODO: Replace with actual id comparison
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                return RedirectToAction(nameof(Index));
            }
            return View(pokemon);
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
