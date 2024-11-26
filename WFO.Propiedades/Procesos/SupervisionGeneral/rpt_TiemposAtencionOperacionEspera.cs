using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO.Propiedades.Procesos.SupervisionGeneral
{
    public class rpt_TiemposAtencionOperacionEspera
    {
        public int idTramite { get; set; }
		public string Folio { get; set; }
		public string Promotoria { get; set; }
		public int promoVecesTotales { get; set; }
		public int promoVecesPausadas { get; set; }
		public int promoVecesSuspendidas { get; set; }
		public int promoVecesProcesadas { get; set; }
		public double promoTiempoEfectivo { get; set; }
		public double promoTiempoTotalOperacion { get; set; }
		public double promoTiempoEspera { get; set; }

		public string Admision { get; set; }
		public int ADMVecesTotales { get; set; }
		public int ADMVecesPausadas { get; set; }
		public int ADMVecesSuspendidas { get; set; }
		public int ADMVecesProcesadas { get; set; }
		public double ADMTiempoEfectivo { get; set; }
		public double ADMTiempoTotalOperacion { get; set; }
		public double ADMTiempoEspera { get; set; }

		public string RevDoc { get; set; }
		public int RevDocVecesTotales { get; set; }
		public int RevDocVecesPausadas { get; set; }
		public int RevDocVecesSuspendidas { get; set; }
		public int RevDocVecesProcesadas { get; set; }
		public double RevDocTiempoEfectivo { get; set; }
		public double RevDocTiempoTotalOperacion { get; set; }
		public double RevDocTiempoEspera { get; set; }

		public string RevPlad { get; set; }
		public int RevPladVecesTotales { get; set; }
		public int RevPladVecesPausadas { get; set; }
		public int RevPladVecesSuspendidas { get; set; }
		public int RevPladVecesProcesadas { get; set; }
		public double RevPladTiempoEfectivo { get; set; }
		public double RevPladTiempoTotalOperacion { get; set; }
		public double RevPladTiempoEspera { get; set; }


		public string Seleccion { get; set; }
		public int SelecVecesTotales { get; set; }
		public int SelecVecesPausadas { get; set; }
		public int SelecVecesSuspendidas { get; set; }
		public int SelecVecesProcesadas { get; set; }
		public double SelecTiempoEfectivo { get; set; }
		public double SelecTiempoTotalOperacion { get; set; }
		public double SelecTiempoEspera { get; set; }

		public string Captura { get; set; }
		public int CapVecesTotales { get; set; }
		public int CapVecesPausadas { get; set; }
		public int CapVecesSuspendidas { get; set; }
		public int CapVecesProcesadas { get; set; }
		public double CapTiempoEfectivo { get; set; }
		public double CapTiempoTotalOperacion { get; set; }
		public double CapTiempoEspera { get; set; }


		public string Control { get; set; }
		public int CTRLVecesTotales { get; set; }
		public int CTRLVecesPausadas { get; set; }
		public int CTRLVecesSuspendidas { get; set; }
		public int CTRLVecesProcesadas { get; set; }
		public double CTRLTiempoEfectivo { get; set; }
		public double CTRLTiempoTotalOperacion { get; set; }
		public double CTRLTiempoEspera { get; set; }


		public string Emision { get; set; }
		public int EmisionVecesTotales { get; set; }
		public int EmisionVecesPausadas { get; set; }
		public int EmisionVecesSuspendidas { get; set; }
		public int EmisionVecesProcesadas { get; set; }
		public double EmisionTiempoEfectivo { get; set; }
		public double EmisionTiempoTotalOperacion { get; set; }
		public double EmisionTiempoEspera { get; set; }


		public string Calidad { get; set; }	
		public int CalVecesTotales { get; set; }
		public int CalVecesPausadas { get; set; }
		public int CalVecesSuspendidas { get; set; }
		public int CalVecesProcesadas { get; set; }
		public double CalTiempoEfectivo { get; set; }
		public double CalTiempoTotalOperacion { get; set; }
		public double CalTiempoEspera { get; set; }


		public string Kwik { get; set; }
		public int KwikVecesTotales { get; set; }
		public int KwikVecesPausadas { get; set; }
		public int KwikVecesSuspendidas { get; set; }
		public int KwikVecesProcesadas { get; set; }
		public double KwikTiempoEfectivo { get; set; }
		public double KwikTiempoTotalOperacion { get; set; }
		public double KwikTiempoEspera { get; set; }
}
}
