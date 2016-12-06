using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConestogaVideoGameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConestogaVideoGameStore.Controllers
{
    public class GameController : Controller
    {
        private readonly GameStoreContext _context;

        public GameController(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Game.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _context.Game.SingleOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }
            //return the database result to the view
            return View(game);
        }
        //************************************************Create Action******************************************************//
        public IActionResult Create()
        {
            //send the user to the view
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name, price, genre, esrb, saleDiscountId")] Game game)
        {
            if (ModelState.IsValid)
            {//if the model state is valid
                //add game
                _context.Add(game);
                await _context.SaveChangesAsync();
                //return to the index
                return RedirectToAction("Index");
            }
            //if modelstate isn't valid, return to the create view
            return View(game);
        }


        //************************************************Edit Action******************************************************//
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {//if game is null, return error
                return NotFound();
            }
            //query database for game
            var gameObj = await _context.Game.SingleOrDefaultAsync(m => m.GameId == id);
            if (gameObj == null)
            {//if game is null, return error
                return NotFound();
            }
            //send user to the edit view and display the game listing
            return View(gameObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId, Name, Price, Genre, Esrb, SalesDiscountId")] Game game)
        {
        //     public int GameId { get; set; }
        //public string Name { get; set; }
        //public int? Price { get; set; }
        //public string Genre { get; set; }
        //public int Esrb { get; set; }
        //public int SalesDiscountId { get; set; }
            if (id != game.GameId)
            {//if game has been changed, return error
                return NotFound();
            }

            if (ModelState.IsValid)
            {//if state is valid
                try
                {//try an update
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {//catch errors such as game doesn't exist
                    if (!GameExists(game.GameId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(game);
        }
        //************************************************Delete Action******************************************************//
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {//if gameid is null, show error
                return NotFound();
            }
            //query db
            var gameObj = await _context.Game.SingleOrDefaultAsync(m => m.GameId == id);
            if (gameObj == null)
            {//if game doesn't exist, return error
                return NotFound();
            }
            //send user to the view and display the chosen game
            return View(gameObj);
        }

        // POST: /Delete/5
        // deletes the chosen game from the db
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {//query db, then delete the chosen listing from the db
            var gameObj = await _context.Game.SingleOrDefaultAsync(m => m.GameId == id);
            _context.Game.Remove(gameObj);
            await _context.SaveChangesAsync();
            //return the user to the index
            return RedirectToAction("Index");
        }
        //a private function to see if the game exists
        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }
    }
}