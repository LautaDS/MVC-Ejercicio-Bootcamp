using MVC1.Models;
using System.Data.SqlClient;
using System.Data;

namespace MVC1.Datos
{
    public class AutomovilDatos
    {
        
        public List<Automovil> ListarAutos()
        {
            var oList = new List<Automovil>();

            var cn = new Conexion();

            using(var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("TodosLosAutos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                
                using(var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        oList.Add(new Automovil() { 
                            Id = (int)dr["idCar"],
                            Marca = (string)dr["marca"],
                            Model = (string)dr["model"],
                            Año = (int)dr["año"],
                            Kilometros = (int)dr["kilometros"],
                            Precio = (int)dr["precio"],
                        });
                    }
                }
            }

            return oList;
        }

        public Automovil ObtenerAutoPorID(int ID)
        {
            var auto = new Automovil();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerAutoPorId", conexion);
                cmd.Parameters.AddWithValue("IDCAR", ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        auto.Id = (int)dr["idCar"];
                        auto.Marca = (string)dr["marca"];
                        auto.Model = (string)dr["model"];
                        auto.Año = (int)dr["año"];
                        auto.Kilometros = (int)dr["kilometros"];
                        auto.Precio = (int)dr["precios"];
                    }
                }
            }

            return auto;
        }

        public bool GuardarAuto(Automovil automovil)
        {
            bool saved;
            var auto = automovil;

           

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("AddNewCar", conexion);
                    cmd.Parameters.AddWithValue("marca", auto.Marca);
                    cmd.Parameters.AddWithValue("model", auto.Model);
                    cmd.Parameters.AddWithValue("año", auto.Año);
                    cmd.Parameters.AddWithValue("kilometros", auto.Kilometros);
                    cmd.Parameters.AddWithValue("precio", auto.Precio);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    saved = true;
                }
            }
            catch (Exception e)
            {
                saved = false;
            }

            return saved;
        }

        public bool EliminarAuto(int ID)
        {
            bool erased;
            try
            {
                 var cn = new Conexion();
            
                            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                            {
                                conexion.Open();
                                SqlCommand cmd = new SqlCommand("EliminateCar", conexion);
                                cmd.Parameters.AddWithValue("IdCar",ID);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                            
                            }
               erased = true;
            }
            catch (Exception)
            {
                erased = false;
                throw;
            }
           



            return erased;
        }
    }
}
