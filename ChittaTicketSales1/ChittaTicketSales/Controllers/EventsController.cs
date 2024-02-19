using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using ChittaTicketSales.Models;
using System.Runtime.CompilerServices;

namespace ChittaTicketSales.Controllers
{
    public class EventsController : Controller
    {
        /*created by chitta shalini
 * 7777777
 */
        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult EventList(String id = "All")
        {
            //uses EventsService to get the events,either all by default if there is no incoming value, or based on the Id of the events
            //Instantiate the EventsService class:

            EventsService eventsService = new EventsService();

            //List of Categories :
            List<Category> categories = new List<Category>();

            //List of Events
            List<Event> events = new List<Event>();

            //get the evnts based on category ID:
            if (id == "All")
            {
                //get all events:
                events = eventsService.GetALLEvents();
            }
            else
            {
                //Based on ID fund the category being asked for , if ID is specified then use the ctaegory to retrun all events of that type
                //Variable to hold category id:
                int selectedCategoryId = 0;
                foreach (Category cat in categories)
                {
                    if (cat.CategoryName == id)
                    {
                        selectedCategoryId = cat.Id;
                    }//if
                }//for each
                foreach (Event anEvent in eventsService.GetALLEvents())
                {
                    if (anEvent.CategoryID == selectedCategoryId)
                    {
                        events.Add(anEvent);
                    }//id
                }//loop for finding events.
            }//if eles
            //return ListViewModel  as a ViewModel with a collection of events
            ListViewModel listViewModel = new ListViewModel(events, categories, id);

            return View(listViewModel);
        }//EventList()

        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult Details(int id)
        {
            EventsService eventsService = new EventsService();
            Event oneEvent = eventsService.GetEvent(id);
            return View(oneEvent);
        }//Details()

    }
}
