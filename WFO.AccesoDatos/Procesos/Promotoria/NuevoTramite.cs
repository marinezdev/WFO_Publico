using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO.Propiedades.Procesos.Promotoria;

namespace WFO.AccesoDatos.Procesos.Promotoria
{
    public class NuevoTramite
    {
        ManejoDatos b = new ManejoDatos();

        //public List<prop.RespuestaNuevoTramiteN1> NuevoTramiteN1(int IdTipoTramite, int IdPromotoria, int IdUsuario, int IdStatus, int idPrioridad, string FechaSolicitud, int IdAgente, string NumeroOrden, int idRamo, string IdSisLegados, string kwik, int IdMoneda, int TipoPersona, string Nombre, string ApPaterno, string ApMaterno, string Sexo, string FechaNacimiento, string RFC, string FechaConst, int IdNacionalidad, string TitularNombre, string TitularApPat, string TitularApMat, int IdTitularNacionalidad, string TitularSexo, string TitularFechaNacimiento, double PrimaCotizacion, int TitularContratante, string Observaciones, int IdProducto, int IdSubProducto)
        public List<prop.RespuestaNuevoTramiteN1> NuevoTramiteN1(prop.TramiteN1 tramiteN1, int filesCount, string filesNames)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("spTramiteNuevo");
            System.Diagnostics.Debug.WriteLine("@IdTipoTramite = " + tramiteN1.IdTipoTramite);
            System.Diagnostics.Debug.WriteLine("@IdPromotoria = " + tramiteN1.IdPromotoria);
            System.Diagnostics.Debug.WriteLine("@IdUsuario = " + tramiteN1.IdUsuario);
            System.Diagnostics.Debug.WriteLine("@IdStatus = " + tramiteN1.IdStatus);
            System.Diagnostics.Debug.WriteLine("@idPrioridad = " + tramiteN1.idPrioridad);
            System.Diagnostics.Debug.WriteLine("@FechaSolicitud = " + string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.FechaSolicitud)));
            //System.Diagnostics.Debug.WriteLine("@FechaSolicitud", FechaSolicitud, SqlDbType.Date);
            System.Diagnostics.Debug.WriteLine("@IdAgente = " + tramiteN1.IdAgente);
            System.Diagnostics.Debug.WriteLine("@NumeroOrden = " + tramiteN1.NumeroOrden);
            System.Diagnostics.Debug.WriteLine("@idRamo = " + tramiteN1.idRamo);
            System.Diagnostics.Debug.WriteLine("@IdSisLegados = " + tramiteN1.IdSisLegados);
            System.Diagnostics.Debug.WriteLine("@kwik = " + tramiteN1.kwik);
            System.Diagnostics.Debug.WriteLine("@IdMoneda = " + tramiteN1.IdMoneda);
            System.Diagnostics.Debug.WriteLine("@TipoPersona = " + tramiteN1.TipoPersona);
            System.Diagnostics.Debug.WriteLine("@Nombre = " + tramiteN1.Nombre);
            System.Diagnostics.Debug.WriteLine("@ApPaterno = " + tramiteN1.ApPaterno);
            System.Diagnostics.Debug.WriteLine("@ApMaterno = " + tramiteN1.ApMaterno);
            System.Diagnostics.Debug.WriteLine("@Sexo = " + tramiteN1.Sexo);
            System.Diagnostics.Debug.WriteLine("@FechaNacimiento = " + string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.FechaNacimiento)));
            System.Diagnostics.Debug.WriteLine("@RFC = " + tramiteN1.RFC);
            System.Diagnostics.Debug.WriteLine("@FechaConst = " + string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.FechaConst)));
            System.Diagnostics.Debug.WriteLine("@IdNacionalidad = " + tramiteN1.IdNacionalidad);
            System.Diagnostics.Debug.WriteLine("@TitularNombre = " + tramiteN1.TitularNombre);
            System.Diagnostics.Debug.WriteLine("@TitularApPat = " + tramiteN1.TitularApPat);
            System.Diagnostics.Debug.WriteLine("@TitularApMat = " + tramiteN1.TitularApMat);
            System.Diagnostics.Debug.WriteLine("@IdTitularNacionalidad = " + tramiteN1.IdTitularNacionalidad);
            System.Diagnostics.Debug.WriteLine("@TitularSexo = " + tramiteN1.TitularSexo);
            System.Diagnostics.Debug.WriteLine("@TitularFechaNacimiento = " + string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.TitularFechaNacimiento)));
            System.Diagnostics.Debug.WriteLine("@PrimaCotizacion = " + tramiteN1.PrimaCotizacion);
            System.Diagnostics.Debug.WriteLine("@SumaBasica = " + tramiteN1.SumaBasica, SqlDbType.Float);
            System.Diagnostics.Debug.WriteLine("@TitularContratante = " + tramiteN1.TitularContratante);
            System.Diagnostics.Debug.WriteLine("@Observaciones = " + tramiteN1.Observaciones);
            System.Diagnostics.Debug.WriteLine("@IdProducto = " + tramiteN1.IdProducto);
            System.Diagnostics.Debug.WriteLine("@IdSubProducto = " + tramiteN1.IdSubProducto);
            System.Diagnostics.Debug.WriteLine("@IdRiesgo = " + tramiteN1.IdRiesgo);
            System.Diagnostics.Debug.WriteLine("@HombreClave = " + tramiteN1.HombreClave);
            System.Diagnostics.Debug.WriteLine("@IdInstitucion = " + tramiteN1.IdInstitucion);
            
            System.Diagnostics.Debug.WriteLine("@filesCount = " + filesCount);
            System.Diagnostics.Debug.WriteLine("@filesName = " + filesNames);
            
#endif



            b.ExecuteCommandSP("spTramiteNuevo");
            b.AddParameter("@IdTipoTramite", tramiteN1.IdTipoTramite, SqlDbType.Int);
            b.AddParameter("@IdPromotoria", tramiteN1.IdPromotoria, SqlDbType.Int);
            b.AddParameter("@IdUsuario", tramiteN1.IdUsuario, SqlDbType.Int);
            b.AddParameter("@IdStatus", tramiteN1.IdStatus, SqlDbType.Int);
            b.AddParameter("@idPrioridad", tramiteN1.idPrioridad, SqlDbType.Int);
            b.AddParameter("@FechaSolicitud", string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.FechaSolicitud)), SqlDbType.Date);
            //b.AddParameter("@FechaSolicitud", FechaSolicitud, SqlDbType.Date);
            b.AddParameter("@IdAgente", tramiteN1.IdAgente, SqlDbType.Int);
            b.AddParameter("@NumeroOrden", tramiteN1.NumeroOrden, SqlDbType.NVarChar);
            b.AddParameter("@idRamo", tramiteN1.idRamo, SqlDbType.Int);
            b.AddParameter("@IdSisLegados", tramiteN1.IdSisLegados, SqlDbType.NVarChar);
            b.AddParameter("@kwik", tramiteN1.kwik, SqlDbType.NVarChar);
            b.AddParameter("@IdMoneda", tramiteN1.IdMoneda, SqlDbType.Int);
            b.AddParameter("@TipoPersona", tramiteN1.TipoPersona, SqlDbType.Int);
            b.AddParameter("@Nombre", tramiteN1.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApPaterno", tramiteN1.ApPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApMaterno", tramiteN1.ApMaterno, SqlDbType.NVarChar);
            b.AddParameter("@Sexo", tramiteN1.Sexo, SqlDbType.NVarChar);
            b.AddParameter("@FechaNacimiento", string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.FechaNacimiento)), SqlDbType.Date);
            b.AddParameter("@RFC", tramiteN1.RFC, SqlDbType.NVarChar);
            b.AddParameter("@FechaConst",  string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.FechaConst)), SqlDbType.Date);
            b.AddParameter("@IdNacionalidad", tramiteN1.IdNacionalidad, SqlDbType.Int);
            b.AddParameter("@TitularNombre", tramiteN1.TitularNombre, SqlDbType.NVarChar);
            b.AddParameter("@TitularApPat", tramiteN1.TitularApPat, SqlDbType.NVarChar);
            b.AddParameter("@TitularApMat", tramiteN1.TitularApMat, SqlDbType.NVarChar);
            b.AddParameter("@IdTitularNacionalidad", tramiteN1.IdTitularNacionalidad, SqlDbType.Int);
            b.AddParameter("@TitularSexo", tramiteN1.TitularSexo, SqlDbType.NVarChar);
            b.AddParameter("@TitularFechaNacimiento", string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramiteN1.TitularFechaNacimiento)), SqlDbType.Date);
            b.AddParameter("@PrimaCotizacion", tramiteN1.PrimaCotizacion, SqlDbType.Float);
            b.AddParameter("@SumaBasica", tramiteN1.SumaBasica, SqlDbType.Float);
            b.AddParameter("@TitularContratante", tramiteN1.TitularContratante, SqlDbType.Int);
            b.AddParameter("@Observaciones", tramiteN1.Observaciones, SqlDbType.NVarChar);
            b.AddParameter("@IdProducto", tramiteN1.IdProducto, SqlDbType.Int);
            b.AddParameter("@IdSubProducto", tramiteN1.IdSubProducto, SqlDbType.Int);
            b.AddParameter("@IdRiesgo", tramiteN1.IdRiesgo, SqlDbType.Int);
            b.AddParameter("@HombreClave", tramiteN1.HombreClave, SqlDbType.Int);
            b.AddParameter("@IdInstitucion", tramiteN1.IdInstitucion, SqlDbType.Int);
            
            b.AddParameter("@filesCount", filesCount, SqlDbType.Int);
            b.AddParameter("@filesName", filesNames, SqlDbType.NVarChar);

            List<prop.RespuestaNuevoTramiteN1> resultado = new List<prop.RespuestaNuevoTramiteN1>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.RespuestaNuevoTramiteN1 item = new prop.RespuestaNuevoTramiteN1()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    Folio = reader["Folio"].ToString(),
                    DescError = reader["DescError"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
