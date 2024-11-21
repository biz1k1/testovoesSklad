using AutoMapper;
using Domain.Entity.Entitys;
using Domain.Model.Models.Output;

namespace Application.Mapping
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<PicketEntity,PicketOutput>();
			CreateMap<PlatformEntity, PlatformOutput>();
			CreateMap<WareHouseEntity, WarehouseOutput>();
		}
	}
}
