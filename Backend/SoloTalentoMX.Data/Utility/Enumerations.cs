namespace SoloTalentoMX.Data.Utility
{
    public class Enumerations
    {
        public enum eResponse
        { Alert = 50, Success = 200, Error = 400, Warning = 300, Information = 500, Confirm = 100 }

        public enum eActions
        {
            Consultar,
            Modificar,
            Crear,
            Eliminar,
            Validaciones
        }

        public enum eMessagesClient
        {
            Ninguno,
            Guardado,
            Modificacion,
            Eliminacion,

            NoGuardado,
            NoModificacion,
            NoEliminacion,

            LoginExitoso,
            ErrorLogin,
        }

        public enum eTypeUser
        {
            Administrador = 1,
            Cliente = 2
        }
    }
}
