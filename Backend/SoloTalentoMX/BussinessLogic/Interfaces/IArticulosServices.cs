﻿using SoloTalentoMX.Api.BussinessLogic.Dto;
using SoloTalentoMX.Api.BussinessLogic.Utility;

namespace SoloTalentoMX.Api.BussinessLogic.Interfaces
{
    public interface IArticulosServices
    {
        Task<ReturnWebApi> RegistrarArticulos(ArticulosCreateDto dto);
    }
}
