using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventosDB.MVC.Data;
using EventosDB.MVC.Models;
using RestSharp;

namespace EventosDB.MVC.Controllers
{
    public class GuestsController : Controller
    {
        private readonly EventosVivoContext _context;

        public GuestsController(EventosVivoContext context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Index()
        {
            var eventosVivoContext = _context.Guests.Include(g => g.GuestType);
            return View(await eventosVivoContext.ToListAsync());
        }

        // GET: Guests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guests == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests
                .Include(g => g.GuestType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            ViewData["GuestTypeId"] = new SelectList(_context.GuestTypes, "Id", "Designation");
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,GuestName,Contact,CreatedAt,UpdatedAt,DeletedAt,GuestTypeId")] Guest guest)
        public async Task<IActionResult> Create([Bind("GuestName,Contact,GuestTypeId")] GuestViewModel guestModel)
        {
            

            if (ModelState.IsValid)
            {
                var guest = new Guest();
                guest.GuestName = guestModel.GuestName;
                guest.Contact = guestModel.Contact;
                guest.GuestTypeId = guestModel.GuestTypeId;

                _context.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestTypeId"] = new SelectList(_context.GuestTypes, "Id", "Id", guestModel.GuestTypeId);
            return View(guestModel);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guests == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            ViewData["GuestTypeId"] = new SelectList(_context.GuestTypes, "Id", "Id", guest.GuestTypeId);
            return View(guest);
        }
        
        // GET: Guests/Invite/5
        public async Task<IActionResult> Invite(int? id)
        {
            if (id == null || _context.Guests == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            var url = "https://api.ultramsg.com/instance74531/messages/image";
            var client = new RestClient(url);

            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", "gkv5jkjui2kbkmvh");
            request.AddParameter("to", "+258" + guest.Contact);
            request.AddParameter("image", "https://file-example.s3-accelerate.amazonaws.com/images/test.jpg");
            request.AddParameter("caption", "image Caption");


            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;


            //ViewData["GuestTypeId"] = new SelectList(_context.GuestTypes, "Id", "Id", guest.GuestTypeId);
            return RedirectToAction(nameof(Index));
            //return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GuestName,Contact,CreatedAt,UpdatedAt,DeletedAt,GuestTypeId")] Guest guest)
        {
            if (id != guest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestTypeId"] = new SelectList(_context.GuestTypes, "Id", "Id", guest.GuestTypeId);
            return View(guest);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guests == null)
            {
                return NotFound();
            }

            var guest = await _context.Guests
                .Include(g => g.GuestType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guests == null)
            {
                return Problem("Entity set 'EventosVivoContext.Guests'  is null.");
            }
            var guest = await _context.Guests.FindAsync(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestExists(int id)
        {
          return (_context.Guests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
