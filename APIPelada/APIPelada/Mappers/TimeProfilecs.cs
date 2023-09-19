using APIPelada.Model;
using AutoMapper;
using Core;

namespace APIPelada.Mappers
{
    public class TimeProfilecs : Profile
    {
        public TimeProfilecs()
        {
            CreateMap<TimeModel,Time>().ReverseMap();
        }
    }
}
