using System;
using System.Collections.Generic;

namespace LS.Email
{
    /// <summary>
    /// It contains all the operations that needs to performed to sent an email. 
    /// </summary>
    public interface IEmailer:IDisposable
    {
       
        /// <summary>
        /// Adds a reciepient emailaddress to the email and spilts emailaddress on ';' 
        /// </summary>
        /// <param name="emailAddress">Email address of recipient.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer To(string emailAddress);

        /// <summary>
        /// Adds  reciepient and display name to the email, splits emailaddress and name on ';'
        /// </summary>
        /// <param name="emailAddress">Email address of recipients.</param>
        /// <param name="name">Name of recipient.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer To(string emailAddress, string name);

        /// <summary>
        /// Adds all recipients in list to email.
        /// </summary>
        /// <param name="mailAddresses">List of recipients.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer To(IList<string> mailAddresses);
 
        /// <summary>
        /// Adds carbon copy email address and display name to the email,spilts email address and name on ';'.
        /// </summary>
        /// <param name="emailAddress">Email address of cc</param>
        /// <param name="name">Name of cc</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer CC(string emailAddress,string name="");

        /// <summary>
        /// Adds all carbon copy email addresses in list to email.
        /// </summary>
        /// <param name="mailAddresses">List of recipients to CC</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer CC(IList<string> mailAddresses);
    
       /// <summary>
        /// Adds blind carbon copy email address and display name to the email,spilts email address and name on ';'.
       /// </summary>
        /// <param name="emailAddress">Email Address of bcc</param>
       /// <param name="name">Name of bcc</param>
       /// <returns>Instance of IEmailer class.</returns>
        IEmailer BCC(string emailAddress,string name="");

        /// <summary>
        /// Adds all blind carbon copy email addresses in list to email.
        /// </summary>
        /// <param name="mailAddresses">List of recipients to bcc.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer BCC(IList<string> mailAddresses);

        /// <summary>
        /// Sets the ReplyTo email address on email and spilts email address on ';'.
        /// </summary>
        /// <param name="emailAddress">ReplyTo email address.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer ReplyTo(string emailAddress);

        /// <summary>
        ///  Sets the ReplyTo email address and dispaly name of ReplyTo on email,spilts email address and name on ';'.
        /// </summary>
        /// <param name="emailAddress">ReplyTo Address.</param>
        /// <param name="name">Display name of ReplyTo.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer ReplyTo(string emailAddress, string name);

        /// <summary>
        /// Adds all ReplyTo email addresses in list to email.
        /// </summary>
        /// <param name="mailAddresses">List of recipients to ReplyTo</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer ReplyTo(IList<string> mailAddresses);

        /// <summary>
        /// Sets the subject of the email.
        /// </summary>
        /// <param name="subject">Email subject.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer Subject(string subject);

        /// <summary>
        /// Sets the body of the email.
        /// </summary>
        /// <param name="body">Content of the email</param>
        /// <param name="isHtml">True if Body is HTML, false for plain text (Optional)</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer Body(string body, bool isHtml = true);

       /// <summary>
       /// Marks the email as high priority.
       /// </summary>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer HighPriority();

        /// <summary>
        /// Marks the email as low priority.
        /// </summary>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer LowPriority();

        /// <summary>
        /// Adds an attachment to the email.
        /// </summary>
        /// <param name="filePath">The attachment to add.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer Attach(string filePath);

        /// <summary>
        /// Adds multiple attachments to the email.
        /// </summary>
        /// <param name="attachments">The list of attachments to add.</param>
        /// <returns>Instance of IEmailer class.</returns>
        IEmailer Attach(IList<string> filePath);

        /// <summary>
        /// Sends the email.
        /// </summary>
        void Send();
      
    }
}
