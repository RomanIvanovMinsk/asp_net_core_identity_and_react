using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RomanCinema.Context;
using RomanCinema.Models;

namespace RomanCinema.Controllers
{
    
    public class TicketsController : Controller
    {
        ApplicationDbContext _context;
        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("myAllowedOrigins")]
        [Route("api/ticket")]
        public ActionResult Get([FromQuery]string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Please check request parameters");
            }

            return Json(_context.Tickets.ToList());
        }
        // POST: Tickets/Create
        [HttpPost]
        [EnableCors("myAllowedOrigins")]
        [Route("api/ticket")]
        public ActionResult Create([FromBody]TicketInfo ticket)
        {
            try
            {
                if ((ticket.MovieId == 0 || string.IsNullOrEmpty(ticket.UserId)))
                {
                    return BadRequest("Please check request parameters");
                }
                var boughtTicketsThisMonth = this._context.Tickets.Where(x => x.UserId == ticket.UserId).Sum((x) => 1);
                this._context.Tickets.Add(new Models.Ticket() { BuyingDate = DateTime.UtcNow, MovieId = ticket.MovieId, UserId = ticket.UserId, TicketsCountInThisMonth = boughtTicketsThisMonth + 1, MovieName = ticket.MovieName, MoviePoster = ticket.MoviePoster
                });
                this._context.SaveChanges();
                return Json(new { code = "200", Text = "Succesfully bought the ticket" });
            }
            catch (Exception ex)
            {
                return Json(new { code = "500", Text = ex.Message });
            }
        }

    }
}