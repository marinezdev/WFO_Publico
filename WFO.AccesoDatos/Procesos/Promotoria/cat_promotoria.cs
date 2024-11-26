using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO.Propiedades;

namespace WFO.AccesoDatos.Procesos.Promotoria
{
    public class cat_promotoria
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Procesos.Promotoria.cat_promotoria> Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Promotoria_Seleccionar");
            List<prop.Procesos.Promotoria.cat_promotoria> resultado = new List<prop.Procesos.Promotoria.cat_promotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Procesos.Promotoria.cat_promotoria item = new prop.Procesos.Promotoria.cat_promotoria()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Procesos.Promotoria.cat_promotoria> SeleccionarPorNombre()
        {
            b.ExecuteCommandSP("Cat_Promotoria_seleccionar_PorNombre");
            List<prop.Procesos.Promotoria.cat_promotoria> resultado = new List<prop.Procesos.Promotoria.cat_promotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Procesos.Promotoria.cat_promotoria item = new prop.Procesos.Promotoria.cat_promotoria()
                {
                    Clave = reader["Clave"].ToString(),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
