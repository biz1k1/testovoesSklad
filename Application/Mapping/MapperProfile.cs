using AutoMapper;
using Domain.Entity.Entitys;
using Domain.Model.Models.Output.Picket;
using Domain.Model.Models.Output.Platform;
using Domain.Model.Models.Output.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
