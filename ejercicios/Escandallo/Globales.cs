using System;
using System.Windows.Forms;
//using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Mail;

namespace cartera
{
    #region " Clase Globales "

    public class Globales
    {
        #region " Fuentes "

        public static System.Drawing.Font Fuente_Verdana_8_Normal = new System.Drawing.Font("Verdana", 8f, FontStyle.Regular);
        public static System.Drawing.Font Fuente_Verdana_8_Negrita = new System.Drawing.Font("Verdana", 8f, FontStyle.Bold);

        public static System.Drawing.Font Fuente_Verdana_9_Normal = new System.Drawing.Font("Verdana", 9f, FontStyle.Regular);
        public static System.Drawing.Font Fuente_Verdana_9_Negrita = new System.Drawing.Font("Verdana", 9f, FontStyle.Bold);

        public static System.Drawing.Font Fuente_Verdana_14_Normal = new System.Drawing.Font("Verdana", 14f, FontStyle.Regular);
        public static System.Drawing.Font Fuente_Verdana_14_Negrita = new System.Drawing.Font("Verdana", 14f, FontStyle.Bold);

        #endregion

        #region " Colores "

        //Estos campos son los que nos sirven para que se utilize el color correspondiente 
        //  sea cual sea la versión de windows, ya que en Windows 7 los colores del sistema varían
        //  por lo que hay que asignarlos mediante RGB.
        public static Color ColorBordeControl = Color.FromArgb(127, 157, 185);
        public static Color ColorAzulFondo = Color.FromArgb(216, 228, 248);
        public static Color ColorRojo = Color.FromArgb(255, 0, 0);
        public static Color ColorVerde = Color.FromArgb(0, 200, 0);
        public static Color ColorBlanco = Color.FromArgb(255, 255, 255);
        public static Color ColorNegro = Color.FromArgb(0, 0, 0);
        public static Color ColorGris = Color.FromArgb(128, 128, 128);
        public static Color ColorAlternoDGV = Color.FromArgb(228, 237, 250);
        public static Color ColorNaranja = Color.FromArgb(255, 128, 0);
        public static Color ColorFucsia = Color.FromArgb(255, 0, 128);

        #endregion

        #region " SQL "

        public enum TipoBases
        {
            Comun = 1,
            Gestion = 2,
            Contabilidad = 3
        }

        // Correo electrónico para envio de pedidos entregados a transporte.
        public static string emisorCorreoElectronico = "dwinmalogistica@gmail.com";

        // Conexión base datos comun.
        public static string ConnectionStringComun = "";
        // Conexión base datos gestion.
        public static string ConnectionStringGest = "";
        // Conexión base datos contabilidad.
        public static string ConnectionStringCont = "";
        
        // Ejercicio
        public static DateTime FechaMinima;
        public static DateTime FechaMaxima;

        // Empresa
        public static decimal IdEmpresa;
        public static string NombreEmpresa = "";
        public static string CodigoEmpresa = "";

        // Contabilidad
        public static string nombreContabilidad = "";

        // Usuario
        public static decimal IdUsuario;
        public static string Usuario = "";
        public static string NombreUsuario = "";
        public static decimal NivelAcceso;

        // Estado
        public static decimal Estado = 0;

        // Contraseña
        public static string Contraseña = "";

        // Ejemplo válido para oracle.
        //private static string connectionString = "user id=Joaquin;password=Admin;data source=192.168.2.10:1522";

        #endregion

        #region " Mensajes lanzados "

        // Mensajes de aviso.
        public static string MensajeAvisoAtencion = "Atención";
        public static string MensajeAvisoCampoRequerido = "Campo requerido.";
        public static string MensajeAvisoEliminarRegistro = "¿Deseas eliminar el registro?";
        public static string MensajeAvisoEliminarLinea = "¿Deseas eliminar la linea seleccionada?";
        public static string MensajeAvisoFechaIncorrecta = "La fecha no es correcta.";
        public static string MensajeAvisoImpresoraNoValida = "La impresora no es válida o no está preparada.";
        public static string MensajeAvisoNivelErroneo = "Nivel erroneo";
        public static string MensajeAvisoRegistroIVA = "No se puede borrar un registro de IVA.\nConsulte con su Administrador.";
        // Mensajes de error.
        public static string MensajeErrorSqlCodigoExiste = "Ese código ya existe.";
        public static string MensajeErrorSqlFechaRegistroIncorrecta = "Esa fecha es inferior a otra existente para ese contador de registro.";
        public static string MensajeErrorSqlMultiplesRegistrosConEseCodigo = "Hay más de un registro con ese código.\nDespliegue el control y seleccione el correcto.";
        public static string MensajeErrorSqlRegistroEnUso = "Ese registro está en uso. NO SE PUEDE ELIMINAR.";
        public static string MensajeErrorSqlRegistroNoEncontrado = "Registro no encontrado.";
        public static string MensajeErrorSqlRegistroSecundarioBloqueado = "Algún registro secundario está bloqueado y NO SE PUEDE ELIMINAR EL REGISTRO.";
        public static string MensajeErrorSqlYaExisteUnParteDeProduccionCreado = "Ya existe un parte de producción creado.\nConsulte al ADMINISTRADOR.";
        // Constantes de los resultados.
        public static int Resultado_Correcto = 0;
        public static int Resultado_ErrorInsercion = -1;
        public static int Resultado_ErrorModificacion = -2;
        public static int Resultado_ErrorBorrado = -3;
        public static int Resultado_CanceladoElBorradoPorElUsuario = -4;

        #endregion

        #region " Caret "

        public static int ParpadeoCaretSistema;

        #endregion

        #region " Enumeraciones globales "
        
        public enum SituacionPedidoVenta
        {
            Vacio = 0,
            Pendiente = 1,
            EnParteProduccion = 2,
            Anulado = 3,
            EnFabrica = 4,
            Fabricado = 5,
            EnAlbaran = 6
        }

        public enum PrioridadPedidoVenta
        {
            Vacio = 0,
            Normal = 1,
            Especial = 2,
            Urgente = 3,
            Incidencia = 4
        }

        public enum SituacionPedidoCompra
        {
            Vacio = 0,
            Pendiente = 1,
            Imprimido = 2,
            RecibidoEnParte = 3,
            RecibidoCompleto = 4
        }

        public enum SituacionAlbaranVenta
        {
            Vacio = 0,
            Pendiente = 1,
            DePedido = 2,
            Imprimido = 3,
            EnFactura = 4,
            NoFacturable = 5
        }

        public enum SituacionFacturaVenta
        {
            Vacio = 0,
            Pendiente = 1,
            DeAlbaran = 2,
            Imprimido = 3,
            Enlazada = 4
        }

        public enum SituacionCobro
        {
            Vacio = 0,
            Pendiente = 1,
            CobradaEnParte = 2,
            Cobrada = 3
        }

        public enum ProcedimientoCobro
        {
            Vacio = 0,
            Incluir = 1,
            NoIncluir = 2
        }

        public enum TipoCuenta
        {
            Vacio = 0,
            Base_Imponible = 1,
            Cuota_IVA = 2,
            Cuota_Recargo = 3,
            Total_Factura = 4
        }

        public enum TipoClienteProveedor
        {
            Vacio = 0,
            Nacional = 1,
            IntraComunitario = 2
        }

        public enum TamañoEsquemaModulo
        {
            Icono = 1,
            Pequeño = 2,
            Mediano = 3,
            Grande = 4
        }

        public enum MesesAño
        {
            Vacio = 0,
            ENERO = 1,
            FEBRERO = 2,
            MARZO = 3,
            ABRIL = 4,
            MAYO = 5,
            JUNIO = 6,
            JULIO = 7,
            AGOSTO = 8,
            SEPTIEMBRE = 9,
            OCTUBRE = 10,
            NOVIEMBRE = 11,
            DICIEMBRE = 12
        }

        public enum Comportamiento
        {
            Vacio = 0,
            POLIPIEL = 1,
            TELA = 2
        }

        public enum ComportamientoMarcada
        {
            Vacio = 0,
            POLIPIEL = 1,
            TELA = 2,
            AMBOS = 3
        }

        public enum CategoriaArticuloParaCosido
        {
            Vacio = 0,
            POLIPIEL_TELA = 1,
            PIEL = 2
        }

        public enum CombinacionesComposicion
        {
            Vacio = 0,
            TODAS_OPCIONES = 1,
            COMPLETO = 2,
            BASE_ALMOHADAS = 3,
            BASE_ASIENTO_RESPALDO = 4,
            BASE_ASIENTO_RIÑONERA_CABEZAL = 5
        }

        public enum Esquema
        {
            Vacio = 0,
            SillonUnAsiento = 1,
            SofaDosAsientos = 2,
            SofaTresAsientos = 3,
            UnAsientoBrazoDerecho = 4,
            UnAsientoBrazoIzquierdo = 5,
            UnAsientoBrazoCortoDerecho =6,
            UnAsientoBrazoCortoIzquierdo = 7,
            UnAsientoRinconDerecho = 8,
            UnAsientoRinconIzquierdo = 9,
            DosAsientosBrazoDerecho = 10,
            DosAsientosBrazoIzquierdo = 11,
            TresAsientosBrazoDerecho = 12,
            TresAsientosBrazoIzquierdo = 13,
            ChaisselongeBrazoDerecho = 14,
            ChaisselongeBrazoIzquierdo = 15,
            DosPouf = 16,
            TresPouf = 17,
            BarraDecorativa = 18,
            Arcon = 19,
            ModuloUnAsientoSinBrazo = 20,
            PoufConBrazo = 21,
            TerminalBrazoDerecho = 22,
            TerminalBrazoIzquierdo = 23,
            ConjuntoChaisselonge3LG = 24,
            Conjunto3LGChaisselonge = 25,
            ModuloDosAsientosSinBrazo = 26,
            ModuloTresAsientosSinBrazo = 27,
            CuatroPouf = 28,
            UnAsientoRinconCurvoDerecho = 29,
            UnAsientoRinconCurvoIzquierdo = 30
        }

        public enum Grupo
        {
            Vacio = 0,
            G1 = 1,
            G2 = 2,
            G3 = 3,
            G4 = 4
        }

        public enum Calcular
        {
            Vacio = 0,
            No_Calcular = 1,
            S3Y5PL_3A = 2,
            S3Y5PL_2A = 3,
            S3PL = 4,
            S2PL = 5,
            S1PL = 6,
            M3Y5PL_3A = 7,
            M3Y5PL_2A = 8,
            M3PL_2A = 9,
            M2PL_2A = 10,
            M1PL_1A = 11,
            Chaiselong = 12,
            Rincon = 13,
            RinconChaiselong = 14,
            Pouf = 15,
            PoufConBrazo = 16,
            Terminal = 17,
            Cojin = 18,
            C3PLYCHAIS = 19,
            C2Y5PLYCHAIS = 20,
            C2PLYCHAIS = 21,
            C3YRINY3YCH = 22,
            C3Y1Y5YPCB =23,
            C3YRY3 = 24,
            C3YRY1Y5 = 25,
            C_CH_3_R_1y5 = 26
            //CCHY3YRY1Y5 = 26
        }

        // Los 4 primeros campos son precio en tela y los 4 últimos precio en piel
        // Y los grupos son G1, G2, G3 y G4
        public static decimal[] S3Y5PL_3A = { 34.50m, 29.30m, 24.90m, 19.90m, 50.00m, 42.50m, 36.10m, 27.90m };
        public static decimal[] S3Y5PL_2A = { 30.00m, 25.50m, 21.70m, 17.30m, 43.50m, 37.00m, 31.40m, 24.30m };
        public static decimal[] S3PL = { 28.00m, 23.80m, 20.20m, 16.20m, 40.60m, 34.50m, 29.30m, 22.70m };
        public static decimal[] S2PL = { 26.00m, 22.10m, 18.80m, 15.00m, 37.70m, 32.00m, 27.20m, 21.00m };
        public static decimal[] S1PL = { 18.00m, 15.30m, 13.00m, 10.40m, 26.10m, 22.20m, 18.90m, 14.60m };
        public static decimal[] M3Y5PL_3A = { 30.50m, 25.90m, 22.00m, 17.60m, 44.20m, 37.60m, 32.00m, 24.70m };
        public static decimal[] M3Y5PL_2A = { 26.00m, 22.10m, 18.80m, 15.00m, 37.70m, 32.00m, 27.20m, 21.00m };
        public static decimal[] M3PL_2A = { 24.00m, 20.40m, 17.30m, 13.90m, 34.80m, 29.60m, 25.10m, 19.40m };
        public static decimal[] M2PL_2A = { 21.00m, 17.90m, 15.20m, 12.10m, 30.50m, 25.90m, 22.00m, 17.00m };
        public static decimal[] M1PL_1A = { 13.00m, 11.10m, 9.40m, 7.50m, 18.90m, 16.00m, 13.60m, 10.50m };
        public static decimal[] Chaiselong = { 16.00m, 13.60m, 11.60m, 9.20m, 23.20m, 19.70m, 16.80m, 12.90m };
        public static decimal[] Rincon = { 16.00m, 13.60m, 11.60m, 9.20m, 23.20m, 19.70m, 16.80m, 12.90m };
        public static decimal[] RinconChaiselong = { 21.00m, 17.90m, 15.20m, 12.10m, 30.50m, 25.90m, 22.00m, 17.00m };
        public static decimal[] Pouf = { 4.00m, 3.40m, 2.90m, 2.30m, 5.80m, 4.90m, 4.20m, 3.20m };
        public static decimal[] PoufConBrazo = { 8.00m, 6.80m, 5.80m, 4.60m, 11.60m, 9.90m, 8.40m, 6.50m };
        public static decimal[] Terminal = { 11.00m, 9.10m, 7.40m, 5.50m, 14.60m, 12.20m, 10.00m, 6.20m };
        public static decimal[] Cojin = { 1.10m, 1.10m, 1.10m, 1.10m, 1.65m, 1.65m, 1.65m, 1.65m };
        public static decimal[] C3PLYCHAIS = { 40.00m, 34.00m, 28.90m, 23.10m, 58.00m, 49.30m, 41.90m, 32.30m };
        public static decimal[] C2Y5PLYCHAIS = { 37.00m, 31.50m, 26.80m, 21.30m, 53.70m, 45.60m, 38.80m, 29.90m };
        public static decimal[] C2PLYCHAIS = { 37.00m, 31.50m, 26.80m, 21.30m, 53.70m, 45.60m, 38.80m, 29.90m };
        // Estos 2 siguientes son específicos de 2 modelos concretos, el baviera/navona y el siguiente el extrem.
        public static decimal[] C3YRINY3YCH = { 80.00m, 00.00m, 00.00m, 00.00m, 116.00m, 00.00m, 00.00m, 00.00m };
        public static decimal[] C3Y1Y5YPCB = { 45.00m, 00.00m, 00.00m, 00.00m, 65.30m, 00.00m, 00.00m, 00.00m };
        public static decimal[] C3YRY3 = { 64.00m, 00.00m, 00.00m, 00.00m, 92.80m, 00.00m, 00.00m, 00.00m };
        public static decimal[] C3YRY1Y5 = { 53.00m, 00.00m, 00.00m, 00.00m, 76.90m, 00.00m, 00.00m, 00.00m };
        public static decimal[] C_CH_3_R_1y5 = { 69.00m, 00.00m, 00.00m, 00.00m, 100.10m, 00.00m, 00.00m, 00.00m };
  

        #endregion

        #region " Imagenes partes y enumeracion "

        public class Modulos
        {
            public class Esquema
            {
                public const int Vacio = 0;
                public const int SillonUnAsiento = 1;
                public const int SofaDosAsientos = 2;
                public const int SofaTresAsientos = 3;
                public const int UnAsientoBrazoDerecho = 4;
                public const int UnAsientoBrazoIzquierdo = 5;
                public const int UnAsientoBrazoCortoDerecho = 6;
                public const int UnAsientoBrazoCortoIzquierdo = 7;
                public const int UnAsientoRinconDerecho = 8;
                public const int UnAsientoRinconIzquierdo = 9;
                public const int DosAsientosBrazoDerecho = 10;
                public const int DosAsientosBrazoIzquierdo = 11;
                public const int TresAsientosBrazoDerecho = 12;
                public const int TresAsientosBrazoIzquierdo = 13;
                public const int ChaisselongeBrazoDerecho = 14;
                public const int ChaisselongeBrazoIzquierdo = 15;
                public const int DosPouf = 16;
                public const int TresPouf = 17;
                public const int BarraDecorativa = 18;
                public const int Arcon = 19;
                public const int ModuloUnAsientoSinBrazo = 20;
                public const int PoufConBrazo = 21;
                public const int TerminalBrazoDerecho = 22;
                public const int TerminalBrazoIzquierdo = 23;
                public const int ConjuntoChaisselonge3LG = 24;
                public const int Conjunto3LGChaisselonge = 25;
                public const int ModuloDosAsientosSinBrazo = 26;
                public const int ModuloTresAsientosSinBrazo = 27;
                public const int CuatroPouf = 28;
                public const int UnAsientoRinconCurvoDerecho = 29;
                public const int UnAsientoRinconCurvoIzquierdo = 30;
}

            public static float TareasEsquemaModulo(int esquemaModulo, Graphics gr, float x, float y, TamañoEsquemaModulo tamaño, bool dibujaModulo, bool dibujaArcon, float grosorLapiz)
            {
                // Variables necesarias para saber la posición que debe utilizar para pintar el arcón.
                float xPrima = 0;
                float yPrima = 0;
                // Este valor lo calcula en base a los módulos pedidos.
                float anchoModulo = 0;
                //
                float anchoAsientoPequeño = 16;
                float altoAsientoPequeño = 20;
                float altoAsientoGrande = 40;
                float anchoBrazo = 5;
                float altoBrazoPequeño = 20;
                float altoBrazoGrande = 40;
                float altoBrazoCortoPequeño = 15;
                float anchoPouf = 5.25f;
                float altoPouf = 5.25f;
                float anchoBarra = 2.60f;
                float altoBarra = 35;
                // Reducciones
                float reduccionIcono = 4;
                float reduccionPequeño = 2f;
                float reduccionMediano = 1.5f;
                // Tamaño letra arcon
                float tamañoLetra = 8f;

                switch (tamaño)
                {
                    case TamañoEsquemaModulo.Icono:
                        anchoAsientoPequeño = anchoAsientoPequeño / reduccionIcono;
                        altoAsientoPequeño = altoAsientoPequeño / reduccionIcono;
                        altoAsientoGrande = altoAsientoGrande / reduccionIcono;
                        anchoBrazo = anchoBrazo / reduccionIcono;
                        altoBrazoPequeño = altoBrazoPequeño / reduccionIcono;
                        altoBrazoGrande = altoBrazoGrande / reduccionIcono;
                        altoBrazoCortoPequeño = altoBrazoCortoPequeño / reduccionIcono;
                        anchoPouf = anchoPouf / reduccionIcono;
                        altoPouf = altoPouf / reduccionIcono;
                        anchoBarra = anchoBarra / reduccionIcono;
                        altoBarra = altoBarra / reduccionIcono;
                        //anchoAsientoPequeño = 4;
                        //altoAsientoPequeño = 5;
                        //altoAsientoGrande = 10;
                        //anchoBrazo = 1.25f;
                        //altoBrazoPequeño = 5;
                        //altoBrazoGrande = 10;
                        //altoBrazoCortoPequeño = 3.75f;
                        //anchoPouf = 1.25f;
                        //altoPouf = 1.25f;
                        //anchoBarra = 0.60f;
                        //altoBarra = 7;
                        break;

                    case TamañoEsquemaModulo.Pequeño:
                        anchoAsientoPequeño = anchoAsientoPequeño / reduccionPequeño;
                        altoAsientoPequeño = altoAsientoPequeño / reduccionPequeño;
                        altoAsientoGrande = altoAsientoGrande / reduccionPequeño;
                        anchoBrazo = anchoBrazo / reduccionPequeño;
                        altoBrazoPequeño = altoBrazoPequeño / reduccionPequeño;
                        altoBrazoGrande = altoBrazoGrande / reduccionPequeño;
                        altoBrazoCortoPequeño = altoBrazoCortoPequeño / reduccionPequeño;
                        anchoPouf = anchoPouf / reduccionPequeño;
                        altoPouf = altoPouf / reduccionPequeño;
                        anchoBarra = anchoBarra / reduccionPequeño;
                        altoBarra = altoBarra / reduccionPequeño;
                        tamañoLetra = 6f;
                        //anchoAsientoPequeño = 10;
                        //altoAsientoPequeño = 13;
                        //altoAsientoGrande = 28;
                        //anchoBrazo = 2.75f;
                        //altoBrazoPequeño = 13;
                        //altoBrazoGrande = 28;
                        //altoBrazoCortoPequeño = 9.75f;
                        //anchoPouf = 2.75f;
                        //altoPouf = 2.75f;
                        //anchoBarra = 1f;
                        //altoBarra = 23;
                        break;

                    case TamañoEsquemaModulo.Mediano:
                        anchoAsientoPequeño = anchoAsientoPequeño / reduccionMediano;
                        altoAsientoPequeño = altoAsientoPequeño / reduccionMediano;
                        altoAsientoGrande = altoAsientoGrande / reduccionMediano;
                        anchoBrazo = anchoBrazo / reduccionMediano;
                        altoBrazoPequeño = altoBrazoPequeño / reduccionMediano;
                        altoBrazoGrande = altoBrazoGrande / reduccionMediano;
                        altoBrazoCortoPequeño = altoBrazoCortoPequeño / reduccionMediano;
                        anchoPouf = anchoPouf / reduccionMediano;
                        altoPouf = altoPouf / reduccionMediano;
                        anchoBarra = anchoBarra / reduccionMediano;
                        altoBarra = altoBarra / reduccionMediano;
                        tamañoLetra = 7f;
                        //anchoAsientoPequeño = 12;
                        //altoAsientoPequeño = 15;
                        //altoAsientoGrande = 30;
                        //anchoBrazo = 3.75f;
                        //altoBrazoPequeño = 15;
                        //altoBrazoGrande = 30;
                        //altoBrazoCortoPequeño = 11.25f;
                        //anchoPouf = 3.25f;
                        //altoPouf = 3.25f;
                        //anchoBarra = 1.80f;
                        //altoBarra = 25;
                        break;

                    case TamañoEsquemaModulo.Grande:
                        //anchoAsientoPequeño = 16;
                        //altoAsientoPequeño = 20;
                        //altoAsientoGrande = 40;
                        //anchoBrazo = 5;
                        //altoBrazoPequeño = 20;
                        //altoBrazoGrande = 40;
                        //altoBrazoCortoPequeño = 15;
                        //anchoPouf = 5.25f;
                        //altoPouf = 5.25f;
                        //anchoBarra = 2.60f;
                        //altoBarra = 35;
                        break;
                }

                gr.PageUnit = GraphicsUnit.Millimeter;
                // Por defecto el grosorLapiz debería de ser de 0.2f
                Pen pen = new Pen(Color.Black, grosorLapiz);

                switch (esquemaModulo)
                {
                    case Globales.Modulos.Esquema.SillonUnAsiento:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = (anchoBrazo * 2) + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.SofaDosAsientos:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                xPrima += (anchoAsientoPequeño / 2);
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = (anchoBrazo * 2) + (anchoAsientoPequeño * 2);
                        break;

                    case Globales.Modulos.Esquema.SofaTresAsientos:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                xPrima += anchoAsientoPequeño;
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = (anchoBrazo * 2) + (anchoAsientoPequeño * 3);
                        break;

                    case Globales.Modulos.Esquema.UnAsientoBrazoDerecho:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.UnAsientoBrazoIzquierdo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.UnAsientoBrazoCortoDerecho:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoCortoPequeño);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.UnAsientoBrazoCortoIzquierdo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoCortoPequeño);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.UnAsientoRinconDerecho:
                        if (dibujaModulo)
                        {
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloRincon(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo, true);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño + anchoBrazo;
                        break;

                    case Globales.Modulos.Esquema.UnAsientoRinconIzquierdo:
                        if (dibujaModulo)
                        {
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloRincon(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo, false);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño + anchoBrazo;
                        break;

                    case Globales.Modulos.Esquema.DosAsientosBrazoDerecho:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                xPrima += (anchoAsientoPequeño / 2);
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + (anchoAsientoPequeño * 2);
                        break;

                    case Globales.Modulos.Esquema.DosAsientosBrazoIzquierdo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                xPrima += (anchoAsientoPequeño / 2);
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + (anchoAsientoPequeño * 2);
                        break;

                    case Globales.Modulos.Esquema.TresAsientosBrazoDerecho:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                xPrima += (anchoAsientoPequeño / 2);
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + (anchoAsientoPequeño * 3);
                        break;

                    case Globales.Modulos.Esquema.TresAsientosBrazoIzquierdo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                xPrima += (anchoAsientoPequeño / 2);
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + (anchoAsientoPequeño * 3);
                        break;

                    case Globales.Modulos.Esquema.ChaisselongeBrazoDerecho:
                        if (dibujaModulo)
                        {
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoGrande, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoGrande);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoGrande / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.ChaisselongeBrazoIzquierdo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoGrande);
                            x += anchoBrazo;
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoGrande, anchoBrazo);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoGrande / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño;
                        break;

                    //case Globales.Modulos.Esquema.ChaisselongeBrazoCortoDerecho:
                    //    anchoModulo = 8;
                    //    gr.DrawRectangle(pen, x, y, 8, 12);
                    //    gr.DrawRectangle(pen, x + 6, y, 2, 7);
                    //    gr.DrawRectangle(pen, x, y, 6, 2);
                    //    break;

                    //case Globales.Modulos.Esquema.ChaisselongeBrazoCortoIzquierdo:
                    //    anchoModulo = 8;
                    //    gr.DrawRectangle(pen, x, y, 8, 12);
                    //    gr.DrawRectangle(pen, x, y, 2, 7);
                    //    gr.DrawRectangle(pen, x + 2, y, 6, 2);
                    //    break;

                    case Globales.Modulos.Esquema.DosPouf:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaPouf(gr, pen, x, y, anchoPouf, altoPouf);
                            Globales.Modulos.dibujaPouf(gr, pen, x, y + altoPouf + 1.5f, anchoPouf, altoPouf);
                        }
                        anchoModulo = anchoPouf;
                        break;

                    case Globales.Modulos.Esquema.TresPouf:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaPouf(gr, pen, x, y, anchoPouf, altoPouf);
                            Globales.Modulos.dibujaPouf(gr, pen, x, y + altoPouf + 1.5f, anchoPouf, altoPouf);
                            Globales.Modulos.dibujaPouf(gr, pen, x, y + ((altoPouf + 1.5f) * 2), anchoPouf, altoPouf);
                        }
                        anchoModulo = anchoPouf;
                        break;

                    case Globales.Modulos.Esquema.BarraDecorativa:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaBarra(gr, pen, x, y, anchoBarra, altoBarra);
                        }
                        anchoModulo = anchoPouf;
                        break;

                    case Globales.Modulos.Esquema.ModuloUnAsientoSinBrazo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y;
                            x += anchoAsientoPequeño;
                            
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.PoufConBrazo:
                        if (dibujaModulo)
                        {
                            // Dibujamos directamente el asiento.
                            gr.DrawRectangle(pen, x, y, anchoAsientoPequeño, altoAsientoPequeño);

                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            x += anchoAsientoPequeño;

                            // Dibujamos el brazo.
                            gr.DrawRectangle(pen, x, y, anchoBrazo, altoBrazoPequeño);

                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.TerminalBrazoDerecho:
                        if (dibujaModulo)
                        {
                            // Dibujamos directamente el asiento.
                            gr.DrawRectangle(pen, x, y, anchoAsientoPequeño, altoAsientoPequeño);

                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y;
                            x += anchoAsientoPequeño - anchoBrazo;

                            // Dibujamos el brazo.
                            gr.DrawRectangle(pen, x, y, anchoBrazo, altoBrazoPequeño / 2);

                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.TerminalBrazoIzquierdo:
                        if (dibujaModulo)
                        {
                            // Dibujamos directamente el asiento.
                            gr.DrawRectangle(pen, x, y, anchoAsientoPequeño, altoAsientoPequeño);

                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y;

                            // Dibujamos el brazo.
                            gr.DrawRectangle(pen, x, y, anchoBrazo, altoBrazoPequeño / 2);

                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.ConjuntoChaisselonge3LG:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoGrande);
                            x += anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoGrande, anchoBrazo);
                            
                            // Espaciamos un poco el módulo.
                            x += 0.50f;

                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño + anchoAsientoPequeño + anchoAsientoPequeño + anchoBrazo;
                        break;

                    case Globales.Modulos.Esquema.Conjunto3LGChaisselonge:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoPequeño);
                            x += anchoBrazo;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);

                            // Espaciamos un poco el módulo.
                            x += 0.50f;

                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoGrande, anchoBrazo);
                            x += anchoAsientoPequeño;
                            Globales.Modulos.dibujaModuloBrazo(gr, pen, x, y, anchoBrazo, altoBrazoGrande);
                        }
                        anchoModulo = anchoBrazo + anchoAsientoPequeño + anchoAsientoPequeño + anchoAsientoPequeño + anchoBrazo;
                        break;

                    case Globales.Modulos.Esquema.ModuloDosAsientosSinBrazo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);

                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y;
                            x += anchoAsientoPequeño;

                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;

                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.ModuloTresAsientosSinBrazo:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);

                            x += anchoAsientoPequeño;

                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;

                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y;

                            Globales.Modulos.dibujaModuloAsiento(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo);
                            x += anchoAsientoPequeño;

                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño + anchoAsientoPequeño;
                        break;

                    case Globales.Modulos.Esquema.CuatroPouf:
                        if (dibujaModulo)
                        {
                            Globales.Modulos.dibujaPouf(gr, pen, x, y, anchoPouf, altoPouf);
                            Globales.Modulos.dibujaPouf(gr, pen, x, y + altoPouf + 1.5f, anchoPouf, altoPouf);
                            Globales.Modulos.dibujaPouf(gr, pen, x, y + ((altoPouf + 1.5f) * 2), anchoPouf, altoPouf);
                            Globales.Modulos.dibujaPouf(gr, pen, x, y + ((altoPouf + 1.5f) * 3), anchoPouf, altoPouf);
                        }
                        anchoModulo = anchoPouf;
                        break;

                    case Globales.Modulos.Esquema.UnAsientoRinconCurvoDerecho:
                        if (dibujaModulo)
                        {
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloRinconCurvo(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo, true);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño + anchoBrazo;
                        break;

                    case Globales.Modulos.Esquema.UnAsientoRinconCurvoIzquierdo:
                        if (dibujaModulo)
                        {
                            // Nos guardamos el valor actual de la variable x porque si debieramos de pintar el arcón, esta es la posición de x correcta.
                            xPrima = x;
                            yPrima = y + anchoBrazo;
                            Globales.Modulos.dibujaModuloRinconCurvo(gr, pen, x, y, anchoAsientoPequeño, altoAsientoPequeño, anchoBrazo, false);
                            // Si a la función le ha llegado la orden de pintar el arcón...
                            if (dibujaArcon)
                            {
                                yPrima += (altoAsientoPequeño / 3);

                                gr.DrawString("ARCON", new System.Drawing.Font("Verdana", tamañoLetra, FontStyle.Regular), Brushes.Black, new PointF(xPrima, yPrima));
                            }
                        }
                        anchoModulo = anchoAsientoPequeño + anchoBrazo;
                        break;

                    default:
                        // Por defecto no hace nada.
                        break;
                }

                return anchoModulo;
            }

            private static void dibujaModuloBrazo(Graphics gr, Pen pen, float x, float y, float anchoModulo, float altoModulo)
            {
                gr.DrawRectangle(pen, x, y, anchoModulo, altoModulo);
            }
            private static void dibujaModuloAsiento(Graphics gr, Pen pen, float x, float y, float anchoModulo, float altoModulo, float anchoBrazo)
            {
                gr.DrawRectangle(pen, x, y, anchoModulo, altoModulo);
                gr.DrawRectangle(pen, x, y, anchoModulo, anchoBrazo);
            }
            private static void dibujaModuloRincon(Graphics gr, Pen pen, float x, float y, float anchoModulo, float altoModulo, float anchoBrazo, bool derecho)
            {
                if (derecho)
                {
                    gr.DrawRectangle(pen, x, y, anchoModulo + anchoBrazo, anchoBrazo);
                    gr.DrawRectangle(pen, x + anchoModulo, y, anchoBrazo, altoModulo + anchoBrazo);
                    gr.DrawLine(pen, x, y, x, y + altoModulo);
                    gr.DrawLine(pen, x, y + altoModulo, x + anchoBrazo, y + (altoModulo + anchoBrazo));
                    gr.DrawLine(pen, x + anchoBrazo, y + (altoModulo + anchoBrazo), x + (anchoModulo + anchoBrazo), y + (altoModulo + anchoBrazo));
                }
                else
                {
                    gr.DrawRectangle(pen, x, y, anchoModulo + anchoBrazo, anchoBrazo);
                    gr.DrawRectangle(pen, x, y, anchoBrazo, altoModulo + anchoBrazo);
                    gr.DrawLine(pen, x + (anchoBrazo + anchoModulo), y, x + (anchoBrazo + anchoModulo), y + altoModulo);
                    gr.DrawLine(pen, x + (anchoBrazo + anchoModulo), y + altoModulo, x + anchoModulo, y + (altoModulo + anchoBrazo));
                    gr.DrawLine(pen, x + anchoModulo, y + (altoModulo + anchoBrazo), x, y + (altoModulo + anchoBrazo));
                }
            }
            private static void dibujaModuloRinconCurvo(Graphics gr, Pen pen, float x, float y, float anchoModulo, float altoModulo, float anchoBrazo, bool derecho)
            {
                return;
                if (derecho)
                {
                    //gr.DrawRectangle(pen, x, y, anchoModulo + anchoBrazo, anchoBrazo);
                    //gr.DrawRectangle(pen, x + anchoModulo, y, anchoBrazo, altoModulo + anchoBrazo);
                    //gr.DrawLine(pen, x, y, x, y + altoModulo);
                    //gr.DrawLine(pen, x, y + altoModulo, x + anchoBrazo, y + (altoModulo + anchoBrazo));
                    //gr.DrawLine(pen, x + anchoBrazo, y + (altoModulo + anchoBrazo), x + (anchoModulo + anchoBrazo), y + (altoModulo + anchoBrazo));
                    
                    //gr.DrawRectangle(pen, x, y, altoModulo, altoModulo);

                    gr.DrawRectangle(pen, 2f, 2f, 6f, 6f);
                    gr.DrawArc(pen, -6f, -6f, 12f, 12f, 0, -180);

                    
                }
                else
                {
                    gr.DrawRectangle(pen, x, y, anchoModulo + anchoBrazo, anchoBrazo);
                    gr.DrawRectangle(pen, x, y, anchoBrazo, altoModulo + anchoBrazo);
                    gr.DrawLine(pen, x + (anchoBrazo + anchoModulo), y, x + (anchoBrazo + anchoModulo), y + altoModulo);
                    gr.DrawLine(pen, x + (anchoBrazo + anchoModulo), y + altoModulo, x + anchoModulo, y + (altoModulo + anchoBrazo));
                    gr.DrawLine(pen, x + anchoModulo, y + (altoModulo + anchoBrazo), x, y + (altoModulo + anchoBrazo));
                }
            }
            private static void dibujaPouf(Graphics gr, Pen pen, float x, float y, float anchoModulo, float altoModulo)
            {
                gr.DrawRectangle(pen, x, y, anchoModulo, altoModulo);
            }
            private static void dibujaBarra(Graphics gr, Pen pen, float x, float y, float anchoModulo, float altoModulo)
            {
                gr.DrawRectangle(pen, x, y, anchoModulo, altoModulo);
            }
            //private static void dibujaArcon(Graphics gr, Pen pen, float x, float y, float anchoModulo, float altoModulo, float anchoBrazo)
            //{
            //    float desplazamiento = (anchoModulo * 20 / 100) / 2;
            //    float anchoModuloReducido = anchoModulo - (desplazamiento * 2);
            //    float inicioX = x + desplazamiento;
            //    float finalX = x + desplazamiento + anchoModuloReducido;

            //    float inicioY = y + (altoModulo - anchoBrazo) - desplazamiento;
            //    float finalY = inicioY;

            //    gr.DrawLine(pen, inicioX, inicioY, finalX, finalY);

            //    gr.DrawLine(pen, x, y, inicioX, inicioY);
            //    gr.DrawLine(pen, x + anchoModulo, y, finalX, finalY);
            //}
        }

        #endregion
    }
    
    #endregion

    //#region " Clase Conversion "
    
    //public class Conversion
    //{
    //    StreamWriter w;
    //    string ruta;

    //    public string xpath
    //    {
    //        get
    //        {
    //            return ruta;
    //        }

    //        set
    //        {
    //            value = ruta;
    //        }
    //    }

    //    public Conversion(string path)
    //    {
    //        ruta = @path;
    //    }

    //    public void AFormatoXLS(ArrayList titulos, DataTable datos)
    //    {
    //        try
    //        {
    //            FileStream fs = new FileStream(ruta,FileMode.CreateNew, FileAccess.ReadWrite);

    //            w = new StreamWriter(fs);

    //            string comillas = char.ConvertFromUtf32(34);

    //            StringBuilder html = new StringBuilder();

    //            html.Append(@"<!DOCTYPE html PUBLIC" + comillas + "-//W3C//DTD XHTML 1.0 Transitional//EN" + comillas + " " + comillas + " http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" + comillas + ">");
    //            html.Append(@"<html xmlns=" + comillas + "http://www.w3.org/1999/xhtml" + comillas + ">");
    //            html.Append(@"<head>");
    //            html.Append(@"<meta http-equiv=" + comillas + "Content-Type" + comillas + "content=" + comillas + "text/html; charset=utf-8" + comillas + "/>");
    //            html.Append(@"<title>Untitled Document</title>");
    //            html.Append(@"</head>");
    //            html.Append(@"<body>");

    //            //Generando encabezados del archivo
    //            //(aquí podemos dar el formato como a una tabla de HTML)
    //            html.Append(@"<table WIDTH=350 CELLSPACING=0 CELLPADDING=0 border=1 BORDERCOLOR=" + comillas + "#000000" + comillas + " bgcolor=" + comillas + "#FFFFFF" + comillas + ">");

    //            html.Append(@"<tr> <b>");

    //            foreach (object item in titulos)
    //            {
    //                html.Append(@"<th>" + item.ToString() + "</th>");
    //            }

    //            html.Append(@"</b> </tr>");

    //            //Generando datos del archivo
    //            for (int i = 0; i < datos.Rows.Count; i++)
    //            {
    //                html.Append(@"<tr>");

    //                for (int j = 0; j < datos.Columns.Count; j++)
    //                {
    //                    html.Append(@"<td>" +
    //                    datos.Rows[i][j].ToString() + "</td>");
    //                }

    //                html.Append(@"</tr>");
    //            }

    //            html.Append(@"</body>");
    //            html.Append(@"</html>");

    //            w.Write(html.ToString());
    //            w.Close();
    //        }

    //        catch (Exception ex)
    //        {
    //            System.Windows.Forms.MessageBox.Show(ex.Message);
    //            //throw ex;
    //        }
    //    }

    //    public void AFormatoPDF(object objeto)
    //    {
    //        Document document = new Document();

    //        PdfWriter.GetInstance(document, new FileStream("devjoker.pdf", FileMode.OpenOrCreate));

    //        document.Open();

    //        document.Add(new Paragraph("Este es mi primer PDF al vuelo"));
    //        document.NewPage();
    //        document.Add(new Paragraph("segunda página"));

    //        document.Close();
    //    }
    //}

    //#endregion

    #region " Clase envio Mail "

    public class EnvioMail
    {
        private string smtp = "smtp.gmail.com";
        private string destinatario = "";
        private string asunto = "";
        private string cuerpoMensaje = "";
        private string rutaFicheroAdjunto = "";
        private string contraseña = "recontracollons";
        private int puerto = 587;

        public bool Enviar(string destinatario, string asunto, string cuerpoMensaje, string rutaFicheroAdjunto)
        {
            // Marcamos que se ha enviado correctamente el mensaje.
            bool mensajeEnviado = true;

            this.destinatario = destinatario;
            this.asunto = asunto;
            this.cuerpoMensaje = cuerpoMensaje;
            this.rutaFicheroAdjunto = rutaFicheroAdjunto;

            //La cadena "servidor" es el servidor de correo que enviará tu mensaje.
            string servidor = this.smtp;
            // Crea el mensaje estableciendo quién lo manda y quién lo recibe.
            MailMessage mensaje = new MailMessage(Globales.emisorCorreoElectronico, this.destinatario, this.asunto, this.cuerpoMensaje);

            try
            {
                // Envía archivo adjunto.
                Attachment archivo_adjunto = new Attachment(this.rutaFicheroAdjunto);
                mensaje.Attachments.Add(archivo_adjunto);
            }
            catch (ArgumentException)
            {
                // Sin asunto.
            }

            //Envía el mensaje.
            SmtpClient cliente = new SmtpClient(servidor);

            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential(Globales.emisorCorreoElectronico, this.contraseña);
            cliente.Port = this.puerto;
            cliente.Host = this.smtp;
            cliente.EnableSsl = true;

            //Añade credenciales si el servidor lo requiere.
            //cliente.Credentials = CredentialCache.DefaultNetworkCredentials;
            try
            {
                cliente.Send(mensaje);
            }
            catch (SmtpException smtpExcep)
            {
                MessageBox.Show(smtpExcep.Message + "\n" + smtpExcep.InnerException, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Si se produce una excepción es que no se ha podido enviar el mensaje por lo que 
                // indicamos que no se ha enviado.
                mensajeEnviado = false;
            }

            if (mensajeEnviado)
            {
                MessageBox.Show("Mensaje enviado");
            }

            // Devolvemos el resultado.
            return mensajeEnviado;
        }

        //public bool ObtenerDatosCorreoEnviado(decimal idPedidoVenta)
        //{
        //    // Definimos el objeto que tendrá los datos enviados por e-mail.
        //    bool correoEnviado = false;

        //    StringBuilder datosCorreoEnviado = new StringBuilder();
        //    DataTable tablaPedidosEnviadosPorCorreo = Tabla.PedidosEnviadosPorCorreo.TablaADO();
        //    DB.ConsultarSQL(null, "select * from PedidosEnviadosPorCorreo where IdPedidoVenta = '" + idPedidoVenta + "'", tablaPedidosEnviadosPorCorreo, false);

        //    if (tablaPedidosEnviadosPorCorreo.Rows.Count > 0)
        //    {
        //        // Informamos que ya se ha enviado anteriormente un correo.
        //        correoEnviado = true;

        //        datosCorreoEnviado.AppendLine("ENVIADO A: " + Convert.ToString(tablaPedidosEnviadosPorCorreo.Rows[0].ItemArray[Funcion.IndiceColumna(tablaPedidosEnviadosPorCorreo, "EnviadoA")]));
        //        datosCorreoEnviado.AppendLine("FECHA: " + Convert.ToDateTime(tablaPedidosEnviadosPorCorreo.Rows[0].ItemArray[Funcion.IndiceColumna(tablaPedidosEnviadosPorCorreo, "FechaCorreoEnviado")]).ToShortDateString());
        //        datosCorreoEnviado.AppendLine("ASUNTO: " + Convert.ToString(tablaPedidosEnviadosPorCorreo.Rows[0].ItemArray[Funcion.IndiceColumna(tablaPedidosEnviadosPorCorreo, "AsuntoCorreo")]));

        //        MessageBox.Show(datosCorreoEnviado.ToString(), Globales.MensajeAvisoAtencion);
        //    }

        //    // Devolvemos los datos enviados por e-mail.
        //    return correoEnviado;
        //}
    }
    
    #endregion

    #region " Clase DataGridViewCalendar "


    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn() : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell. 
                if (value != null && !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell() : base()
        {
            // Use the short date format. 
            this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CalendarEditingControl ctl = DataGridView.EditingControl as CalendarEditingControl;
            // Use the default row value when Value property is null. 
            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            {
                ctl.Value = (DateTime)this.Value;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses. 
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains. 
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value. 
                return DateTime.Now;
            }
        }
    }

    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue  
        // property. 
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        // This will throw an exception of the string is  
                        // null, empty, or not in the format of a date. 
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        // In the case of an exception, just use the  
                        // default value so we're not left with a null 
                        // value. 
                        this.Value = DateTime.Now;
                    }
                }
            }
        }

        // Implements the  
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method. 
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the  
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method. 
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex  
        // property. 
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey  
        // method. 
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed. 
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit  
        // method. 
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl 
        // .RepositionEditingControlOnValueChange property. 
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlDataGridView property. 
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlValueChanged property. 
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingPanelCursor property. 
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell 
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }

    #endregion

    #region " Clases diseño Pedido, Albarán y Factura de venta "

    public class DocumentoDatosCabecera
    {
        public readonly int BordeSuperior = 10;
        public readonly int BordeInferior = 235;
        public readonly int BordeIzquierdo = 10;
        public readonly int BordeDerecho = 395;

        public string RazonSocial = "";
        public string DniCif = "";
        public string Direccion = "";
        public string ApdoCorreos = "";
        public string CposPobProv = "";
        public string Telefono = "";
        public string Fax = "";
        public string Email = "";
        public string web = "";
    }
    public class DocumentoDatosTipoDocumento
    {
        public readonly int BordeSuperior = 10;
        public readonly int BordeInferior = 125;
        public readonly int BordeIzquierdo = 400;
        public readonly int BordeDerecho = 790;
    }
    public class DocumentoDatosCliente
    {
        public readonly int BordeSuperior = 130;
        public readonly int BordeInferior = 295;
        public readonly int BordeIzquierdo = 400;
        public readonly int BordeDerecho = 740;

        public string RazonSocial = "";
        public string NombreComercial = "";
        public string Direccion1 = "";
        public string Direccion2 = "";
        public string CposPobProv = "";
        public string Telefono = "";
        public string Fax = "";
        public string DniCif = "";
    }
    public class DocumentoDatosDocumento
    {
        public readonly int BordeSuperior = 240;
        public readonly int BordeInferior = 295;
        public readonly int BordeIzquierdo = 10;
        public readonly int BordeDerecho = 395;

        public readonly int InicioCampo1 = 10;
        public readonly int FinCampo1 = 130;

        public readonly int InicioCampo2 = 130;
        public readonly int FinCampo2 = 260;

        public readonly int InicioCampo3 = 260;
        public readonly int FinCampo3 = 395;

        public string Numero = "";
        public string Fecha = "";
        public string CodigoCliente = "";
    }
    public class DocumentoDatosCuerpo
    {
        public readonly int BordeSuperior = 300;
        public readonly int BordeInferior = 990;
        public readonly int BordeIzquierdo = 10;
        public readonly int BordeDerecho = 790;

        public readonly int NumeroMaximoDeLineas = 41;

        public readonly int InicioCampo1 = 10;
        public readonly int FinCampo1 = 65;

        public readonly int InicioCampo2 = 65;
        public readonly int FinCampo2 = 500;

        public readonly int InicioCampo3 = 500;
        public readonly int FinCampo3 = 560;

        public readonly int InicioCampo4 = 560;
        public readonly int FinCampo4 = 640;

        public readonly int InicioCampo5 = 640;
        public readonly int FinCampo5 = 700;

        public readonly int InicioCampo6 = 700;
        public readonly int FinCampo6 = 790;
    }
    public class DocumentoDatosFormaDePago
    {
        public readonly int BordeSuperior = 995;
        public readonly int BordeInferior = 1059;
        public readonly int BordeIzquierdo = 10;
        public readonly int BordeDerecho = 496;

        public string FormaPago = "";
        public string Domiciliacion = "";
    }
    public class DocumentoDatosAgencia
    {
        public readonly int BordeSuperior = 1064;
        public readonly int BordeInferior = 1130;
        public readonly int BordeIzquierdo = 10;
        public readonly int BordeDerecho = 496;

        public string Agencia = "";
        public string Bultos = "";
    }
    public class DocumentoDatosVencimientos
    {
        public readonly int BordeSuperior = 1064;
        public readonly int BordeInferior = 1130;
        public readonly int BordeIzquierdo = 10;
        public readonly int BordeDerecho = 496;

        public readonly int InicioCampo1 = 10;
        public readonly int FinCampo1 = 172;

        public readonly int InicioCampo2 = 172;
        public readonly int FinCampo2 = 334;

        public readonly int InicioCampo3 = 334;
        public readonly int FinCampo3 = 496;
    }
    public class DocumentoDatosTotales
    {
        public readonly int BordeSuperior = 995;
        public readonly int BordeInferior = 1130;
        public readonly int BordeIzquierdo = 500;
        public readonly int BordeDerecho = 790;

        public readonly int InicioCampo1 = 500;
        public readonly int FinCampo1 = 610;

        public readonly int InicioCampo2 = 610;
        public readonly int FinCampo2 = 670;

        public readonly int InicioCampo3 = 670;
        public readonly int FinCampo3 = 790;

        public string ImporteBruto = "";
        public string PorcentajeDescuento = "";
        public string Descuento = "";
        public string ImporteBaseImponible = "";
        public string PorcentajeIva = "";
        public string Iva = "";
        public string PorcentajeRecargo = "";
        public string Recargo = "";
        public string ImporteLiquido = "";
    }
    public class DocumentoDatosSumaYSigue
    {
        public readonly int BordeSuperior = 1005;
        public readonly int BordeInferior = 1032;
        public readonly int BordeIzquierdo = 10;
        public readonly int BordeDerecho = 790;
    }
    
    #endregion

}
