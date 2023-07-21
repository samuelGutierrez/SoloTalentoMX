using SoloTalentoMX.Data.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Utility
{
    public class ReturnWebApi
    {
        public ReturnWebApi()
        {
            CodeResponse = Enumerations.eResponse.Error;
            TypeResponse = Enumerations.eResponse.Error.ToString().ToLower();
            CodeMensaje = Enumerations.eMessagesClient.Ninguno.ToString();
            Tags = null;
        }

        public ReturnWebApi(Enumerations.eMessagesClient eCodeMensaje, Enumerations.eResponse enumRespuesta = Enumerations.eResponse.Success, string[] vTags = null)
        {
            CodeResponse = enumRespuesta;
            TypeResponse = enumRespuesta.ToString().ToLower();
            CodeMensaje = eCodeMensaje.ToString();
            Tags = vTags;
        }

        public void ManageMessage(Enumerations.eMessagesClient eCodeMensaje, Enumerations.eResponse enumRespuesta = Enumerations.eResponse.Success, string[] vTags = null)
        {
            CodeResponse = enumRespuesta;
            TypeResponse = enumRespuesta.ToString().ToLower();
            CodeMensaje = eCodeMensaje.ToString();
            Tags = vTags;
        }

        public Enumerations.eResponse CodeResponse { get; set; }
        public string TypeResponse { get; set; }
        public string CodeMensaje { get; set; }
        public string[] Tags { get; set; }
    }

    public class ReturnWebApi<T> : ReturnWebApi where T : class
    {
        public ReturnWebApi()
          : base()
        { Response = null; }

        public ReturnWebApi(Enumerations.eMessagesClient eCodeMensaje, Enumerations.eResponse enumRespuesta = Enumerations.eResponse.Error, string[] vTags = null)
          : base(eCodeMensaje, enumRespuesta, vTags)
        { Response = null; }

        public ReturnWebApi(T oResponse, Enumerations.eMessagesClient eCodeMensaje = Enumerations.eMessagesClient.Ninguno, Enumerations.eResponse enumRespuesta = Enumerations.eResponse.Success, string[] vTags = null)
          : base(eCodeMensaje, enumRespuesta, vTags)
        {
            Response = oResponse;
        }

        public T Response { get; set; }
    }

    public class ReturnWebApi<T1, T2> : ReturnWebApi<T1> where T1 : class where T2 : class
    {
        public ReturnWebApi()
          : base()
        { Response2 = null; }

        public ReturnWebApi(Enumerations.eMessagesClient eCodeMensaje, Enumerations.eResponse enumRespuesta = Enumerations.eResponse.Error, string[] vTags = null)
           : base(eCodeMensaje, enumRespuesta, vTags)
        { Response2 = null; }

        public ReturnWebApi(T1 oResponse, T2 oResponse2, Enumerations.eMessagesClient eCodeMensaje = Enumerations.eMessagesClient.Ninguno, Enumerations.eResponse enumRespuesta = Enumerations.eResponse.Success, string[] vTags = null)
          : base(oResponse, eCodeMensaje, enumRespuesta, vTags)
        { Response2 = oResponse2; }

        public T2 Response2 { get; set; }
    }
}
