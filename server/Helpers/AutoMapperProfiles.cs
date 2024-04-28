using AutoMapper;
using BMCSDL.DTOs;
using BMCSDL.Models;

namespace BMCSDL.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Account,AccountDTO>();
            CreateMap<Role, RoleDTO>();
        }
    }
}
