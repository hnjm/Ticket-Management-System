﻿using System.Collections.Generic;
using TicketManagementSystem.Business.DTO;

namespace TicketManagementSystem.Business.Interfaces
{
    public interface IPackageService
    {
        int TotalCount { get; }

        IEnumerable<PackageDTO> GetPackages();
        IEnumerable<PackageDTO> GetPackages(int skip, int take);

        IEnumerable<PackageDTO> GetPackagesByColor(int colorId);
        IEnumerable<PackageDTO> GetPackagesBySerial(int serialId);

        PackageDTO GetPackage(int id);

        PackageDTO CreatePackage(PackageCreateDTO packageDTO);
        PackageDTO CreateSpecialPackage(PackageSpecialCreateDTO packageDTO);

        PackageEditDTO GetPackageEdit(int id);
        PackageSpecialEditDTO GetSpecialPackageEdit(int id);

        PackageDTO EditPackage(PackageEditDTO packageDTO);
        PackageDTO EditSpecialPackage(PackageSpecialEditDTO packageDTO);
        
        void Remove(int id);

        void OpenPackage(int id);
        void ClosePackage(int id);

        PackageDTO MakeSpecial(int id, string name);
        PackageDTO MakeDefault(int id, int colorId, int serialId, int? firstNumber);

        bool ExistsById(int id);
        bool ExistsByName(string name);
        bool IsNameFree(int id, string name);

        IEnumerable<string> Validate(PackageCreateDTO createDTO);
        IEnumerable<string> Validate(PackageSpecialCreateDTO createDTO);
        IEnumerable<string> Validate(PackageEditDTO editDTO);
        IEnumerable<string> Validate(PackageSpecialEditDTO editDTO);
    }
}
