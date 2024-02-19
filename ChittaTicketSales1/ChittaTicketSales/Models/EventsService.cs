namespace ChittaTicketSales.Models
{
    public class EventsService
    {
 /*
 * Created by Chitta shalini 
 * 3333333333333
 * This is a class that creates a list of events with each events of type 
  event class
 *Creates a list of categories with each category of type category class.
 *Has three methods:
 *GetEvents() which returns events based of incoming parameters category 
 *Get Ctegory () That returns the list of categories  or events 
 *Get AllEvents() Will return all categories.
*/
        private List<Event> _allEvents = new()
    {
       new Event() { Id = 100, Title = "The Lion King", CategoryID = 1, TicketPrice = 50, Description = "Musical Based on Disney's animated movie" , ImageId = "100.png" },

        new Event() { Id = 200, Title = "Holiday Spectacular", CategoryID = 2, TicketPrice = 40, Description = "Holiday extravaganza for the entire family" , ImageId = "200.png" },

        new Event() { Id = 300, Title = "Marry poppins", CategoryID = 1, TicketPrice = 50, Description = "Popular Musical with seven tony awards" , ImageId = "300.png" },

        new Event() { Id = 400, Title = "Taylor Swift", CategoryID = 2, TicketPrice = 90, Description = "Popular singer and songwriter" , ImageId = "400.png" },

        new Event() { Id = 500, Title = "Alice in Wonderland", CategoryID = 1, TicketPrice = 90, Description = "Alice's Adeventures in Wonderland and Through the Looking-Glass by Lewis Carrol" , ImageId = "500.png" }


    };
        private List<Category> _allCategories = new()
        {
            new Category() {Id = 1, CategoryName= "Theater show"},
            new Category() {Id = 2, CategoryName = "Concer"}
        };

        public Event GetEvent(int id)
        {
            Event? selectedEvents = null;

            foreach (Event anEvent in _allEvents)
            {
                if (anEvent.Id == id)
                {
                    selectedEvents = anEvent;
                }//if
            }//foreach
            return selectedEvents;

        }//getEvents()

        public List<Category> GetCategories() { return _allCategories; }
        public List<Event> GetALLEvents() { return _allEvents; }

        internal Event GetEvent(object id)
        {
            throw new NotImplementedException();
        }

    }
}
