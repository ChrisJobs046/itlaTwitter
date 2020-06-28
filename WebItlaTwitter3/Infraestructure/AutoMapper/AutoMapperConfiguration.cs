using AutoMapper;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebItlaTwitter3.ViewModels;

namespace WebItlaTwitter3.Infraestructure.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            ConfigureUsuario();
        }

        private void ConfigureUsuario()
        {
            CreateMap<RegisterViewModel, Usuario>().ReverseMap().ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore());
        }
    }

    
}
