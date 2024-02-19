using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChittaTicketSales.Models
{
    public class BuyTickets
    {
 /*
 *Created by chitta shalini 
 *55555555555
 *This is supporting model for buy view which is a form taht accesses this class
 *This class has an overloaded constructor with two signature : a default 
 constructor and one with parameters for events name and for sale and ticket price. Default
 parameterless constructor is nedded for binding model
 *The parameterized constructor is called from the cart controler's Buy action method : CaculateDiscount() 
  ProcessSale() methods 
 *One collection fro dropdowm options.
 */
        //constant
        private const Double SR_DISCOUNT_RATE = 0.2D;

        //properties and variables:
        public string? EventName { get; set; }
        public string? CustomerName { get; set; }
        [Required(ErrorMessage = "Email is a required Feild.")]
        [EmailAddress(ErrorMessage = "Please enter a avlid email address")]
        [Display(Name = "Email Address:")]
        public string? Email { get; set; }
        public double? TicketPrice { get; set; }
        public string? SalesDate { get; set; }
        [Required(ErrorMessage = "Please enter number of Tickets.")]
        [Range(1, 10, ErrorMessage = "NUmber of tickets should be between 1 and 10")]
        public int NumberOfTickets { get; set; }
        [Display(Name = " Senior Discount :")]
        public bool SeniorDiscount { get; set; }
        [Required(ErrorMessage = "Delivery option is Required.")]
        [Display(Name = "Select mode of Delivery:")]
        public string? DeliveryMode { get; set; } //underlaying property fro dropdown

        //other properties:
        public double SubTotal { get; set; }
        public double SaleDiscount { get; set; }
        public double DeliveryCharge { get; set; }

        public double AmountDue { get; set; }

        //collection for select dropdown
        public List<SelectListItem> DeliveryOptions = new()
        {
            new SelectListItem {Text = "", Value = "None"},
            new SelectListItem {Text = "Mail", Value = "Mail"},
            new SelectListItem {Text = "Print", Value = "Print at home"},
            new SelectListItem {Text = "Digital", Value = "Digital Ticket"},
            new SelectListItem {Text = "Call", Value = "Will Call"}
        };
        public BuyTickets()
        {
            //parameterless constructor for use with binding model
        }//ctor

        public BuyTickets(string? eventName, double ticketPrice)
        {
            this.EventName = eventName;
            this.TicketPrice = ticketPrice;
        }//ctor-- for use with ValueModel.

        public void CalculateDiscount()
        {
            SaleDiscount = SubTotal * SR_DISCOUNT_RATE;
        } //CalculateDiscount()

        public void CalculateAmountDue()
        {
            //Calculate the amount due and sets the SaleDate.
            SalesDate = DateTime.Today.ToShortDateString();
            SubTotal = (double)(TicketPrice * NumberOfTickets);
            //check if there is senior discount
            if (SeniorDiscount)
            {
                CalculateDiscount();
            }//if
            if (DeliveryMode == "Mail")
            {
                DeliveryCharge = 3.95;
            }
            else
            {
                DeliveryCharge = 0;
            }
            AmountDue = SubTotal - SaleDiscount * DeliveryCharge;
        }

    }
}
