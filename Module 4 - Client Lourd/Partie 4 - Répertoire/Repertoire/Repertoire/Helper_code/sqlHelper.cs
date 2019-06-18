using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repertoire.globalVariable;

namespace Repertoire.Helper_code
{
    class sqlHelper
    {
        /// <summary>
        /// Permet d'excuter une requête avec ExecuteNonQuery (permet d'ajouter de'update ou de delete)
        /// </summary>
        public static void ExecuteNonQuery(string query)
        {
            SqlCommand commandSql = new SqlCommand();
            commandSql.CommandText = query;
            commandSql.Connection = db;
            commandSql.CommandTimeout = 12 * 3600;
            db.Open();
            commandSql.ExecuteNonQuery();
            db.Close();
        }

        /// <summary>
        /// Permet d'executer une requête avec ExecuteScalar ( permet de chercher un élément dans une db en fonction d'une données (chercher si le mail est déjà dans la db)
        /// </summary>
        public static string ExecuteScalar(string query)
        {
            string result = null;
            SqlCommand commandSql = new SqlCommand();
            commandSql.CommandText = query;
            commandSql.Connection = db;
            commandSql.CommandTimeout = 12 * 3600;
            db.Open();
            object resultCommand = commandSql.ExecuteScalar();
            if (resultCommand != null)
            {
                result = resultCommand.ToString();
            }
            db.Close();
            return result;
        }

        /// <summary>
        /// Permet d'executer la rêquete ExecuteReader() (Permet de lire les données d'un select)
        /// </summary>
        public static SqlDataReader ExecuteReader(string query)
        {
            SqlCommand commandSql = new SqlCommand();
            commandSql.CommandText = query;
            commandSql.Connection = db;
            commandSql.CommandTimeout = 12 * 3600;
            db.Open();
            SqlDataReader resultCommand = commandSql.ExecuteReader();
            return resultCommand;
        }

    }
}
