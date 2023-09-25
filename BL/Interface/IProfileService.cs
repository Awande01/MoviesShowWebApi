using BL.DTO;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IProfileService
    {
        Task<ProfileDTO> GetUserProfile(string userName, string password);
        Task<Profile> GetUserProfileById(int id);
    }
}
