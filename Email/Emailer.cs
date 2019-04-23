
namespace LS.Email
{
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Net;
    using System;
    using System.Linq;

    /// <summary>
    /// Generic Emailer class to sent the email through smtp client.
    /// </summary>
    public class Emailer : IHideObjectMembers,IEmailer
    {
        #region Variable Declarations

        private SmtpClient client=null;

        #endregion

        #region Properties

        private MailMessage Message { get; set; }

        #endregion

        #region Private constructor

        private Emailer()
        {
            Message = new MailMessage();
            client = new SmtpClient("smtp.Office365.com",587);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates instance of emailer instance and adds from address to email.
        /// </summary>
        /// <param name="emailAddress">From Address.</param>
        /// <returns>Instace of emailer class.</returns>
        public static Emailer From(string emailAddress,string displayName)
        {
            var email = new Emailer
                            {
                                Message = { From = new MailAddress(emailAddress,displayName) }
                            };
            return email;
        }

        /// <summary>
        /// Adds a reciepient emailaddress to the email and spilts emailaddress on ';' 
        /// </summary>
        /// <param name="emailAddress">Email address of recipient.</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer To(string emailAddress)
        {

            if (emailAddress.Contains(";"))
            {
                foreach (string address in emailAddress.Split(';'))
                {
                    Message.To.Add(new MailAddress(address));
                }
            }
            else
            {
                Message.To.Add(new MailAddress(emailAddress));
            }
            return this;
        }

        /// <summary>
        /// Adds reciepient and display name to the email, splits emailaddress and name on ';'
        /// </summary>
        /// <param name="emailAddress">Email address of recipients.</param>
        /// <param name="name">Name of recipient.</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer To(string emailAddress, string name) 
        {
            if (emailAddress.Contains(";"))
            {
                var nameSplit = name.Split(';');
                var addressSplit = emailAddress.Split(';');
                for (int i = 0; i < addressSplit.Length; i++)
                {
                    var currentName = string.Empty;
                    if ((nameSplit.Length - 1) >= i)
                    {
                        currentName = nameSplit[i];
                    }
                    Message.To.Add(new MailAddress(addressSplit[i], currentName));
                }
            }
            else
            {
                Message.To.Add(new MailAddress(emailAddress, name));
            }
            return this;
        }

        /// <summary>
        /// Adds all recipients in list to email.
        /// </summary>
        /// <param name="mailAddresses">List of recipients.</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer To(IList<string> mailAddresses)
        {
            foreach (var address in mailAddresses)
            {
                Message.To.Add(address);              
            }
            return this;
        }

        /// <summary>
        /// Adds  carbon copy email address and display name to the email,spilts email address and name on ';'.
        /// </summary>
        /// <param name="emailAddress">Email address of cc</param>
        /// <param name="name">Name of cc</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer CC(string emailAddress,string name="")
        {
            if (emailAddress.Contains(";"))
            {
                var nameSplit = name.Split(';');
                var addressSplit = emailAddress.Split(';');
                for (int i = 0; i < addressSplit.Length; i++)
                {
                    var currentName = string.Empty;
                    if ((nameSplit.Length - 1) >= i)
                    {
                        currentName = nameSplit[i];
                    }
                    Message.CC.Add(new MailAddress(addressSplit[i], currentName));
                }
            }
            else
            {
                Message.CC.Add(new MailAddress(emailAddress, name));
            }           
            return this;
        }

        /// <summary>
        /// Adds all carbon copy email addresses in list to email.
        /// </summary>
        /// <param name="mailAddresses">List of recipients to CC</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer CC(IList<string> mailAddresses)
        {
            foreach (var address in mailAddresses)
            {
                Message.CC.Add(address);
            }
            return this;
        }

        /// <summary>
        /// Adds blind carbon copy email address and display name to the email,spilts email address and name on ';'.
        /// </summary>
        /// <param name="emailAddress">Email Address of bcc</param>
        /// <param name="name">Name of bcc</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer BCC(string emailAddress,string name="")
        {
            if (emailAddress.Contains(";"))
            {
                var nameSplit = name.Split(';');
                var addressSplit = emailAddress.Split(';');
                for (int i = 0; i < addressSplit.Length; i++)
                {
                    var currentName = string.Empty;
                    if ((nameSplit.Length - 1) >= i)
                    {
                        currentName = nameSplit[i];
                    }
                    Message.Bcc.Add(new MailAddress(addressSplit[i], currentName));
                }
            }
            else
            {
                Message.Bcc.Add(new MailAddress(emailAddress, name));
            }
            return this;
        }

        /// <summary>
        /// Adds all blind carbon copy email addresses in list to email.
        /// </summary>
        /// <param name="mailAddresses">List of recipients to bcc.</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer BCC(IList<string> mailAddresses)
        {
            foreach (var address in mailAddresses)
            {
                Message.Bcc.Add(address);
            }
            return this;
        }

        /// <summary>
        /// Sets the ReplyTo email address on email and spilts email address on ';'.
        /// </summary>
        /// <param name="emailAddress">ReplyTo email address.</param>
        /// <returns>Instance of Emailer class.</returns>
       public IEmailer ReplyTo(string emailAddress)
        {
            if (emailAddress.Contains(';'))
            {
                foreach (string address in emailAddress.Split(';'))
                {
                    Message.ReplyToList.Add(address);
                }
            }
            else
            {
                Message.ReplyToList.Add(emailAddress);
            }
            return this;
        
        }

       /// <summary>
       ///  Sets the ReplyTo email address and dispaly name of ReplyTo on email,spilts email address and name on ';'.
       /// </summary>
       /// <param name="emailAddress">ReplyTo Address.</param>
       /// <param name="name">Display name of ReplyTo.</param>
       /// <returns>Instance of Emailer class.</returns>
       public IEmailer ReplyTo(string emailAddress, string name)
       {
           if (emailAddress.Contains(';'))
           {
               var nameSplit = name.Split(';');
               var addressSplit = emailAddress.Split(';');
               for (int i = 0; i < addressSplit.Length; i++)
               {
                   var currentName = string.Empty;
                   if ((nameSplit.Length - 1) >= i)
                   {
                       currentName = nameSplit[i];
                   }
                   Message.ReplyToList.Add(new MailAddress(addressSplit[i], currentName));
               }
              
           }
           else
           {
               Message.ReplyToList.Add(new MailAddress(emailAddress,name));
           }
           return this;
      }

       /// <summary>
       /// Adds all ReplyTo email addresses in list to email.
       /// </summary>
       /// <param name="mailAddresses">List of recipients to ReplyTo</param>
       /// <returns>Instance of Emailer class.</returns>
       public IEmailer ReplyTo(IList<string> mailAddresses)
       {
           foreach (var address in mailAddresses)
           {
               Message.ReplyToList.Add(address);
           }
           return this;
       }

       /// <summary>
       /// Sets the subject of the email.
       /// </summary>
       /// <param name="subject">Email subject.</param>
       /// <returns>Instance of Emailer class.</returns>
        public IEmailer Subject(string subject)
        {
            Message.Subject = subject;
            return this;
        }

        /// <summary>
        /// Sets the body of the email.
        /// </summary>
        /// <param name="body">Content of the email</param>
        /// <param name="isHtml">True if Body is HTML, false for plain text (Optional)</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer Body(string body, bool isHtml = true)
        {
            Message.Body = body;
            Message.IsBodyHtml = isHtml;
            return this;
        }

        /// <summary>
        /// Marks the email as high priority.
        /// </summary>
        /// <returns>Instance of IEmailer class.</returns>
        public IEmailer HighPriority()
        {
            Message.Priority = MailPriority.High;
            return this;
        }

        /// <summary>
        /// Marks the email as low priority.
        /// </summary>
        /// <returns>Instance of IEmailer class.</returns>
         public IEmailer LowPriority()
        {
            Message.Priority = MailPriority.Low;
            return this;
        }

         /// <summary>
         /// Adds an attachment to the email.
         /// </summary>
         /// <param name="fliePath">The attachment to add.</param>
         /// <returns>Instance of Emailer class.</returns>
        public IEmailer Attach(string  filePath)
        {
            var attachment = new Attachment(filePath);
            if (!Message.Attachments.Contains(attachment))
                Message.Attachments.Add(attachment);
            return this;
        }

        /// <summary>
        /// Adds multiple attachments to the email.
        /// </summary>
        /// <param name="filePath">The list of attachments to add.</param>
        /// <returns>Instance of Emailer class.</returns>
        public IEmailer Attach(IList<string> filePath)
        {
            foreach(var file in filePath)
            {
                var attachment = new Attachment(file);
                if (!Message.Attachments.Contains(attachment))
                Message.Attachments.Add(attachment);
            }
            return this;
        }
        /// <summary>
        /// This method is used to send the mail.
        /// </summary>
        public void Send()
        {
            client.Send(Message);
            this.Dispose();
            
        }

        /// <summary>
        /// This method is used to release all resources.
        /// </summary>
        public void Dispose()
        {
            if (client != null)
                client.Dispose();

            if (Message != null)
                Message.Dispose();
        }

        #endregion

      
    }
}
