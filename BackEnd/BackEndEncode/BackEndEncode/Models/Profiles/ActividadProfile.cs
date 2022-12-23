using AutoMapper;
using BackEndEncode.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndEncode.Models.Profiles
{
    public class ActividadProfile : Profile
    {
        public ActividadProfile()
        {
            CreateMap<Actividad, ActividadDTO>();
            CreateMap<ActividadDTO, Actividad>();
        }
    }
}
