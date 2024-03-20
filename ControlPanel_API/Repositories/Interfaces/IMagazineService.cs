using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlPanel_API.DTOs;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IMagazineService
    {
        Task AddNewMagazine(MagazineDTO magazineDTO);
        Task UpdateMagazine(UpdateMagazineDTO magazineDTO);
        Task<IEnumerable<MagazineDTO>> GetAllMagazines();
        Task<MagazineDTO> GetMagazineById(int id);
        Task DeleteMagazine(int id);
        Task UpdateMagazineFile(MagazineDTO magazineDTO);
        Task<byte[]> GetMagazineFileById(int id);
    }
}
