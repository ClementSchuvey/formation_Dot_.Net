using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repertoire.globalVariable;
using Repertoire.Helper_code;
using Repertoire.Models;

namespace Repertoire.Controllers
{
    class UserController
    {
        /// <summary>
        /// Permet de lancer la méthode ExecuteNonQuery avec une query pour ajouter un user a la db
        /// </summary>
        public static void Register(string lastname, string firstname, string username, string mail, string password)
        {
            //On crée notre requête
            string query = "INSERT INTO [dbo].[Users]([lastname],[firstname],[username],[mail],[password])" +
                 "VALUES('" + lastname + "','" + firstname + "','" + username + "','" + mail + "','" + password + "')";
            //On execute la requête
            sqlHelper.ExecuteNonQuery(query);

        }

        /// <summary>
        /// Permet de lancer la méthode ExecuteScalar avec une query pour chercher si le mail saisie est dans déjà utiliser
        /// </summary>
        public static string CheckMailDispo(string mail)
        {
            string query = "SELECT [id] FROM [dbo].[Users] WHERE [mail] = '" + mail + "'";
            return sqlHelper.ExecuteScalar(query);
        }

        /// <summary>
        /// Permet de lancer la méthode ExecuteReader avec une query pour chercher les données de l'user en fonction des indentifiant saisie
        /// </summary>
        public static bool CheckLogin(string mail, string password)
        {
            bool loginIsOk = false;
            string query = "SELECT [id], [lastname], [firstname], [username], [mail] FROM [dbo].[Users] WHERE [mail] = '" + mail + "' AND [password] = '" + password + "'";
            SqlDataReader ResultCommand = sqlHelper.ExecuteReader(query);
            if (ResultCommand.Read())
            {
                userConnected.id = int.Parse(ResultCommand["id"].ToString());
                userConnected.Lastname = ResultCommand["lastname"].ToString();
                userConnected.Firstname = ResultCommand["firstname"].ToString();
                userConnected.Username = ResultCommand["username"].ToString();
                userConnected.Mail = ResultCommand["mail"].ToString();
                loginIsOk = true;
            }
            db.Close();
            return loginIsOk;
        }
    }
}
