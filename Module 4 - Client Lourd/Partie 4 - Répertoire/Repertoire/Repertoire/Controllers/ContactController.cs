using Repertoire.Helper_code;
using Repertoire.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repertoire.globalVariable;

namespace Repertoire.Controllers
{
    class ContactController
    {
        /// <summary>
        /// Permet de lancer la méthode ExecuteNonQuery avec une query pour ajouter un contact a la db
        /// </summary>
        public static void Register(string lastname, string firstname, string phoneNumber, string mail, string address, string picture = null)
        {
            //On crée notre requête
            string query = "INSERT INTO [dbo].[Contacts]([lastname], [firstname], [mail], [phoneNumber], [address], [picture], [id_Users])" +
                 "VALUES('" + lastname + "','" + firstname + "','" + mail + "','" + phoneNumber + "','" + address + "','" + picture + "','" + userConnected.id + "')";
            //On execute la requête
            sqlHelper.ExecuteNonQuery(query);

        }

        /// <summary>
        /// Permet de lancer la méthode ExecuteReader avec une query pour crée une liste de contact
        /// </summary>
        public static List<ContactModel> listContact()
        {
            //On initialise la list
            List<ContactModel> contactList = new List<ContactModel>();
            string query = "SELECT [id], [lastname], [firstname], [mail], [phoneNumber], [address] FROM [dbo].[Contacts] WHERE [id_Users] = '" + userConnected.id + "'";
            SqlDataReader ResultCommand = sqlHelper.ExecuteReader(query);
            while (ResultCommand.Read())
            {
                //On initialise un new contact a ajouter a la list et on le complete
                ContactModel contactToAddList = new ContactModel();
                contactToAddList.id = int.Parse(ResultCommand["id"].ToString());
                contactToAddList.Lastname = ResultCommand["lastname"].ToString();
                contactToAddList.Firstname = ResultCommand["firstname"].ToString();
                contactToAddList.Mail = ResultCommand["mail"].ToString();
                contactToAddList.PhoneNumber = ResultCommand["phoneNumber"].ToString();
                contactToAddList.Address = ResultCommand["address"].ToString();
                //On ajoute le contact a la list
                contactList.Add(contactToAddList);
            }
            db.Close();
            return contactList;
        }
    }
}
