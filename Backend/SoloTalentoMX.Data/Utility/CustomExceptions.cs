namespace SoloTalentoMX.Data.Utility
{
    public class CustomExceptions : Exception
    {
        private Enumerations.eActions _Accion = Enumerations.eActions.Consultar;
        private string _MensajeTecnico = string.Empty;

        private Enumerations.eMessagesClient _CodigoMensaje = Enumerations.eMessagesClient.Ninguno;
        private Enumerations.eResponse _Respuesta = Enumerations.eResponse.Warning;
        private string[] _Tags = null;

        public Enumerations.eActions Action { get { return _Accion; } }
        public string MessageTechnical { get { return _MensajeTecnico; } }

        public Enumerations.eMessagesClient CodeMessageClient { get { return _CodigoMensaje; } }
        public Enumerations.eResponse Response { get { return _Respuesta; } }
        public string[] Tags { get { return _Tags; } }

        #region Validaciones

        public CustomExceptions(string sMensajeTecnico, Enumerations.eMessagesClient eMensajes)
          : this(sMensajeTecnico, Enumerations.eActions.Validaciones)
        {
            _CodigoMensaje = eMensajes;
        }

        public CustomExceptions(string sMensajeTecnico, Enumerations.eMessagesClient eMensajes, string[] Tags)
          : this(sMensajeTecnico, Enumerations.eActions.Validaciones)
        {
            _CodigoMensaje = eMensajes;
            _Tags = Tags;
        }

        public CustomExceptions(string sMensajeTecnico, Enumerations.eMessagesClient eMensajes, Enumerations.eResponse eRespuesta)
          : this(sMensajeTecnico, Enumerations.eActions.Validaciones)
        {
            _CodigoMensaje = eMensajes;
            _Respuesta = eRespuesta;
        }

        public CustomExceptions(string sMensajeTecnico, Enumerations.eMessagesClient eMensajes, string[] Tags, Enumerations.eResponse eRespuesta)
          : this(sMensajeTecnico, Enumerations.eActions.Validaciones)
        {
            _CodigoMensaje = eMensajes;
            _Tags = Tags;
            _Respuesta = eRespuesta;
        }

        #endregion

        public CustomExceptions(string sMensajeTecnico, Enumerations.eActions eAccion, Enumerations.eMessagesClient eMensajes, string[] Tags = null)
          : this(sMensajeTecnico, eAccion)
        {
            _CodigoMensaje = eMensajes;
            _Tags = Tags;
        }

        public CustomExceptions(string sMensajeTecnico)
          : base()
        {
            _MensajeTecnico = sMensajeTecnico;
        }

        public CustomExceptions(string sMensajeTecnico, Enumerations.eActions eAccion)
          : this(sMensajeTecnico)
        {
            _Accion = eAccion;
        }

        public CustomExceptions(string message, string sMensajeTecnico)
          : base(message)
        {
            _MensajeTecnico = sMensajeTecnico;
        }

        public CustomExceptions(string message, string sMensajeTecnico, Enumerations.eActions eAccion)
          : this(message, sMensajeTecnico)
        {
            _Accion = eAccion;
        }

        public CustomExceptions(string message, string sMensajeTecnico, Exception e)
          : base(message, e)
        {
            _MensajeTecnico = sMensajeTecnico;
        }

        public CustomExceptions(string message, string sMensajeTecnico, Exception e, Enumerations.eActions eAccion)
          : this(message, sMensajeTecnico, e)
        {
            _Accion = eAccion;
        }

        public CustomExceptions(string sMensajeTecnico, Exception e)
          : this(e.Message, sMensajeTecnico, e)
        { }

        public CustomExceptions(string sMensajeTecnico, Exception e, Enumerations.eActions eAccion)
          : this(sMensajeTecnico, e)
        {
            _Accion = eAccion;
        }
    }
}
