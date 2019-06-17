using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace School.Services
{
   public class UsersServices
    {
        #region Singleton Service
        public static UsersServices Instance
        {
            get
            {
                if (instance == null) instance = new UsersServices();
                return instance;
            }
        }

       

        private static UsersServices instance { get; set; }
        private UsersServices()
        {

        }

        #endregion

        public List<Event> GetAllEvents()
        {
            return Database.Database.Instance.GetAllEvents();
        }

        public bool AddorUpdateEvents(Event model)
        {
            return Database.Database.Instance.AddorUpdateEvents(model);
        }

        public Task<int> RegisterUser(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                return Database.Database.Instance.RegisterUser(user);
              
            });
            
        }

        public bool DeleteEvents(int id)
        {
            return Database.Database.Instance.DeleteEvents(id);
        }

        public Task<int> UpdateUser(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                return Database.Database.Instance.UpdateUser(user);

            });

        }

        public Task<int> UserLog(User user)
        {
            return Task.Factory.StartNew(() => {
               
                    return Database.Database.Instance.UserLog(user);
             
            });
            
        }

        public Task<User> GetDetailofUser(string Email)
        {
            return Task.Factory.StartNew(() => {

                return Database.Database.Instance.GetDetailofUser(Email);

            });

        }



        public Task<bool> ForgetPassword(User user)
        {
            return Task.Factory.StartNew(() => {

               var User=  Database.Database.Instance.ForgetPassword(user);
                if(User != null)
                {
                    string smtpAddress = "smtp.gmail.com";
                    int portNumber = 587;
                    bool enableSSL = true;
                    string emailFrom = "realbazzar4u@gmail.com";
                    string password = "100@cool";
                    string emailTo = User.Email;
                    string subject = "Hello!";
                    string body = "your Password is"+User.Password;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    try
                    {
                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                        return true;
                    }

                    catch
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }

            });

        }

        public Student GetAllUsersEmail(string email)
        {
            return Database.Databasesec.Instance.GetAllUsersEmail(email);
        }

        public Teacher GetAllTeachersEmail(string email)
        {
            return Database.Databasesec.Instance.GetAllTeachersEmail(email);
        }

        public Parent GetAllParentsEmail(string email)
        {
            return Database.Databasesec.Instance.GetAllParentsEmail(email);
        }
    }
}
