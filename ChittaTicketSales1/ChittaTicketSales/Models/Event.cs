namespace ChittaTicketSales.Models
{
    public class Event
    {
        /*
 * Created by Chitta shalini
 * 222222222222
 * This class creates a type for Events 
 * Each Events has an event name (Title property), description for the events,
   the category of the events, and has an image to display
 */
            public int Id { get; set; }
            public string? Title { get; set; }
            public int CategoryID { get; set; }
            public double TicketPrice { get; set; }
            public string? Description { get; set; }
            public string? ImageId { get; set; }

        }
    }
