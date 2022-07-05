using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionManeger
    {

        public SqlConnection Connection;

        public ConexionManeger(string connection)
        {
            Connection = new SqlConnection(connection);
        }


        public void Open()
        {
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }








    }
}
