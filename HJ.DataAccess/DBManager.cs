using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data.EntityClient;

namespace HJ.DataAccess
{
    public class DBManager
    {
        public static string ConnectionString
        {
            get;
            internal set;
        } 

        public static string EntityConnectionString
        { 
            get;
            internal set;
        }

        public static void setConnectionString(string serverAdress, string username, string password)
        {
            SqlConnectionStringBuilder SQLConnectionString = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder EntityConnection = new EntityConnectionStringBuilder();

            //Set the Provider String for the Entity
            SQLConnectionString.DataSource = serverAdress;
            SQLConnectionString.UserID = username;
            SQLConnectionString.Password = password;
            SQLConnectionString.ConnectTimeout = 10;
            SQLConnectionString.InitialCatalog = "HallidayJames";
            SQLConnectionString.MultipleActiveResultSets = true;
            SQLConnectionString.ApplicationName = "EntityFramework";

            //Save it has a Global String
            ConnectionString = SQLConnectionString.ToString();

            //Set the Entity for the Database Model
            EntityConnection.Metadata = @"res://*/";

            EntityConnection.ProviderConnectionString = ConnectionString;
            EntityConnection.Provider = "System.Data.SqlClient";

            //Save it has a Global String
            EntityConnectionString = EntityConnection.ToString();
        }
    }
}
