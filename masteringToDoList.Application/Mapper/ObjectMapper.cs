using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using masteringToDoList.Application.Models;
using masteringToDoList.Core.Entities;

namespace masteringToDoList.Application.Mapper
{
    // The best implementation of AutoMapper for class libraries - https://stackoverflow.com/questions/26458731/how-to-configure-auto-mapper-in-class-library-project
    public class ObjectMapper
    {
        public static IMapper Mapper
        {
            get
            {
                return AutoMapper.Mapper.Instance;
            }
        }
        static ObjectMapper()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;
                cfg.CreateMap<ToDoItem, ToDoItemModel>().ReverseMap();
                cfg.CreateMap<ToDoList, ToDoListModel>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                        .ReverseMap();
            });
        }
    }
}
