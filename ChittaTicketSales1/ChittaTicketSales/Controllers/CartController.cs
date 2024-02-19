using ChittaTicketSales.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChittaTicketSales.Controllers
{
    public class CartController : Controller
    {
        /*
* Created by chitta shalini 
*888888
*/
        public IActionResult Buy(int id)
        {
            //gets the ID of the event taht teh user wants you to ticket for and then
            // using the EventsService, gets an ogbject represnting the event.

            EventsService eventsService = new EventsService();
            Event selectedEvent = eventsService.GetEvent(id);

            //Start buying ticket by  cretaing buyTicket object and setting name of the event and ticket price. (constructor of Buy class).
            BuyTickets buyTickets = new BuyTickets(selectedEvent.Title,
            selectedEvent.TicketPrice);
            return View(buyTickets);
        }
        public IActionResult Confirmation(BuyTickets model)
        {
            if (ModelState.IsValid)
            {
                //call the buyTickets object's method to claculate sale price model.CalculateAmountDue();
                model.CalculateAmountDue();
                //pass buyTickets object as viewmodel to display ticket
                return View(model);
            }
            return View("Buy", model); // take the user back to buy tickets page.
        }

    }
}
