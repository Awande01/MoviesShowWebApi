using BL.DTO;
using BL.Interface;
using DAL.Data;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository) 
        { 
            _profileRepository = profileRepository;
        }

        public async Task<ProfileDTO> GetUserProfile(string userName, string password)
        {
            var profile = await _profileRepository.GetUserProfile(userName, password);
            if(profile == null)
                return null;

            return new ProfileDTO 
            { 
                UserName = profile.UserName, 
                ProfileId = profile.ProfileId,
            };
        }
        public async Task<Profile> GetUserProfileById(int id)
        {
            return await _profileRepository.GetUserProfileById(id);

        }
    }
}
