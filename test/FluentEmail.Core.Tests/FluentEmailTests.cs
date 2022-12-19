using System.Collections.Generic;
using FluentEmail.Core.Models;
using NUnit.Framework;
using System.Linq;

namespace FluentEmail.Core.Tests
{
    [TestFixture]
    public class FluentEmailTests
    {
        const string ToEmail = "bob@test.com";
        const string FromEmail = "johno@test.com";
        const string Subject = "sup dawg";
        const string Body = "what be the hipitity hap?";

        [Test]
        public void To_Address_Is_Set()
        {
            var email = Email
                .From(FromEmail)
                .To(ToEmail);

            Assert.AreEqual(ToEmail, email.Data.ToAddresses[0].EmailAddress);
        }

        [Test]
        public void From_Address_Is_Set()
        {
            var email = Email.From(FromEmail);

            Assert.AreEqual(FromEmail, email.Data.FromAddress.EmailAddress);
        }

        [Test]
        public void Subject_Is_Set()
        {
            var email = Email
                .From(FromEmail)
                .Subject(Subject);

            Assert.AreEqual(Subject, email.Data.Subject);
        }

        [Test]
        public void Body_Is_Set()
        {
            var email = Email.From(FromEmail)
                .Body(Body);

            Assert.AreEqual(Body, email.Data.Body);
        }

        [Test]
        public void Can_Add_Multiple_Recipients()
        {
            string toEmail1 = "bob@test.com";
            string toEmail2 = "ratface@test.com";

            var email = Email
                .From(FromEmail)
                .To(toEmail1)
                .To(toEmail2);

            Assert.AreEqual(2, email.Data.ToAddresses.Count);
        }

        [Test]
        public void Can_Add_Multiple_Recipients_From_List()
        {
            var emails = new List<Address>
            {
                new("email1@email.com"),
                new("email2@email.com")
            };

            var email = Email
                .From(FromEmail)
                .To(emails);

            Assert.AreEqual(2, email.Data.ToAddresses.Count);
        }

        [Test]
        public void Can_Add_Multiple_Recipients_From_String_List()
        {
            var emails = new List<string>
            {
                "email1@email.com",
                "email2@email.com"
            };

            var email = Email
                .From(FromEmail)
                .To(emails);

            Assert.AreEqual(2, email.Data.ToAddresses.Count);
        }

        [Test]
        public void Can_Add_Multiple_CCRecipients_From_List()
        {
            var emails = new List<Address>
            {
                new("email1@email.com"),
                new("email2@email.com")
            };

            var email = Email
                .From(FromEmail)
                .CC(emails);

            Assert.AreEqual(2, email.Data.CcAddresses.Count);
        }

        [Test]
        public void Can_Add_Multiple_BCCRecipients_From_List()
        {
            var emails = new List<Address>
            {
                new("email1@email.com"),
                new("email2@email.com")
            };

            var email = Email
                .From(FromEmail)
                .BCC(emails);

            Assert.AreEqual(2, email.Data.BccAddresses.Count);
        }

        [Test]
        public void Is_Valid_With_Properties_Set()
        {
            var email = Email
                .From(FromEmail)
                .To(ToEmail)
                .Subject(Subject)
                .Body(Body);

            Assert.AreEqual(Body, email.Data.Body);
            Assert.AreEqual(Subject, email.Data.Subject);
            Assert.AreEqual(FromEmail, email.Data.FromAddress.EmailAddress);
            Assert.AreEqual(ToEmail, email.Data.ToAddresses[0].EmailAddress);
        }

        [Test]
        public void ReplyTo_Address_Is_Set()
        {
            var replyEmail = "reply@email.com";

            var email = Email.From(FromEmail)
                .ReplyTo(replyEmail);

            Assert.AreEqual(replyEmail, email.Data.ReplyToAddresses.First().EmailAddress);
        }

        #region Refactored tests using setup through constructors.

        [Test]
        public void New_To_Address_Is_Set()
        {
            var email = new Email(FromEmail)
                .To(ToEmail);

            Assert.AreEqual(ToEmail, email.Data.ToAddresses[0].EmailAddress);
        }

        [Test]
        public void New_From_Address_Is_Set()
        {
            var email = new Email(FromEmail);

            Assert.AreEqual(FromEmail, email.Data.FromAddress.EmailAddress);
        }

        [Test]
        public void New_Subject_Is_Set()
        {
            var email = new Email(FromEmail)
                .Subject(Subject);

            Assert.AreEqual(Subject, email.Data.Subject);
        }

        [Test]
        public void New_Body_Is_Set()
        {
            var email = new Email(FromEmail)
                .Body(Body);

            Assert.AreEqual(Body, email.Data.Body);
        }

        [Test]
        public void New_Can_Add_Multiple_Recipients()
        {
            string toEmail1 = "bob@test.com";
            string toEmail2 = "ratface@test.com";

            var email = new Email(FromEmail)
                .To(toEmail1)
                .To(toEmail2);

            Assert.AreEqual(2, email.Data.ToAddresses.Count);
        }

        [Test]
        public void New_Can_Add_Multiple_Recipients_From_List()
        {
            var emails = new List<Address>
            {
                new("email1@email.com"),
                new("email2@email.com")
            };

            var email = new Email(FromEmail)
                .To(emails);

            Assert.AreEqual(2, email.Data.ToAddresses.Count);
        }

        [Test]
        public void New_Can_Add_Multiple_CCRecipients_From_List()
        {
            var emails = new List<Address>
            {
                new("email1@email.com"),
                new("email2@email.com")
            };

            var email = new Email(FromEmail)
                .CC(emails);

            Assert.AreEqual(2, email.Data.CcAddresses.Count);
        }

        [Test]
        public void New_Can_Add_Multiple_BCCRecipients_From_List()
        {
            var emails = new List<Address>
            {
                new("email1@email.com"),
                new("email2@email.com")
            };

            var email = new Email(FromEmail)
                .BCC(emails);

            Assert.AreEqual(2, email.Data.BccAddresses.Count);
        }

        [Test]
        public void New_Is_Valid_With_Properties_Set()
        {
            var email = new Email(FromEmail)
                .To(ToEmail)
                .Subject(Subject)
                .Body(Body);

            Assert.AreEqual(Body, email.Data.Body);
            Assert.AreEqual(Subject, email.Data.Subject);
            Assert.AreEqual(FromEmail, email.Data.FromAddress.EmailAddress);
            Assert.AreEqual(ToEmail, email.Data.ToAddresses[0].EmailAddress);
        }

        [Test]
        public void New_ReplyTo_Address_Is_Set()
        {
            var replyEmail = "reply@email.com";

            var email = new Email(FromEmail)
                .ReplyTo(replyEmail);

            Assert.AreEqual(replyEmail, email.Data.ReplyToAddresses.First().EmailAddress);
        }

        #endregion
    }
}