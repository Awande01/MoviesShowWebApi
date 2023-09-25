using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IProfileRepository
    {
        Task<Profile> GetUserProfile(string userName, string password);
        Task<Profile> GetUserProfileById(int id);
    }
}
