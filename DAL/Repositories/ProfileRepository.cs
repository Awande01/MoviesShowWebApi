using DAL.Data;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProfileRepository: IProfileRepository
    {
        private readonly TestingDatabaseContext _databaseContext;
        public ProfileRepository(TestingDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Profile> GetUserProfile(string userName, string password)
        {
            var profile = await _databaseContext.Profiles.FirstOrDefaultAsync(x=> x.UserName == userName && x.Password == password);
            return profile ;
        }
        public async Task<Profile> GetUserProfileById(int id)
        {
            return await _databaseContext.Profiles.FirstOrDefaultAsync(x => x.ProfileId == id);

        }
    }
}
