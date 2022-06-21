using Cake.Data;
using Cake.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Cake.Pages
{
    public class orderModel : PageModel
    {
        private readonly Database data;
        public orderModel(Database data)
        {
            this.data = data;
        }
        /// <summary>
        /// in this page i want to get id from asp route id when i click on photo i get id in http request
        /// </summary>
        [BindProperty(SupportsGet =true)]// now i receive id as parameter in prop id.
        public int ID { get; set; }
        [BindProperty,EmailAddress,Required(ErrorMessage = "Please Enter valid Email"), Display(Name ="Enter Your Email Address")]
        public string Email { get; set; }
        [BindProperty,Required(ErrorMessage ="Please Supply Shipping Address"), Display(Name = "Shipping")]
        public string Shipping { get; set; }
        public int Quantity { get; set; }

        public Product product { get; set; }
        public async Task OnGet()
        {
            product=await data.Products.FindAsync(ID);//get id from Url.first i must make decoration in prop [bindproperty]
        }
        //i used IActionResult as when i return page 
        public async Task<IActionResult> OnPostAsync()
        {
            product = await data.Products.FindAsync(ID);
            if (ModelState.IsValid)
            {
                var body = $"<p> thank u we recived your order for {Quantity} of pieces of {product.name}</p>" +
                    $"< p > yore address is:{Shipping}</ p >" +
                    $"< p >your total price is:{Quantity*product.price}< /p >"+
                    "<p><b>your order will deliverd within 60 minutes</b></p>"
                    ;
                using(var smtp=new SmtpClient())
                {
                    var Googlecredential = new NetworkCredential
                    {
                        UserName = "mahmoudsamer661999@gmail.com",
                        Password="mahmoud661999"
                    };
                    smtp.Credentials=Googlecredential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    var message = new MailMessage();
                    message.To.Add(Email);
                    message.Subject = " your Order of cake ";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress("ms8379407@gmail.com");
                    await smtp.SendMailAsync(message); 
                }

                return RedirectToPage("OrderSuccess");
            }
           
         return Page();
            

        }
    }
}
