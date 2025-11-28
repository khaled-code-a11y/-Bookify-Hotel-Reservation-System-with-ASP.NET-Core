

namespace DEPI.BLL.Mapping
{
    public class RoomMap : Profile
    {
        public RoomMap()
        {
            CreateMap<RoomDTO, RoomModel>().ReverseMap();
        }

    }
}
