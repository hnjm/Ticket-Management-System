﻿using System;
using System.Collections.Generic;
using AutoMapper;
using TicketManagementSystem.Business.DTO;
using TicketManagementSystem.Business.Interfaces;
using TicketManagementSystem.Data.EF.Interfaces;
using TicketManagementSystem.Data.EF.Models;

namespace TicketManagementSystem.Business.Services
{
    public class ColorService : Service, IColorService
    {
        public ColorService(IUnitOfWork database) : base(database)
        {
        }

        public IEnumerable<ColorDTO> GetColors()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Color, ColorDTO>()
                .ForMember(dest => dest.PackagesCount, opt => opt.MapFrom(src => src.Packages.Count))
                .ForMember(dest => dest.TicketsCount, opt => opt.MapFrom(src => src.Tickets.Count))
            );
            return Mapper.Map<IEnumerable<Color>, IEnumerable<ColorDTO>>(Database.Colours.GetAll());
        }

        public ColorDTO GetColor(int id)
        {
            var color = Database.Colours.GetById(id);

            if (color == null)
                return null;

            return MapperInstance.Map<ColorDTO>(color);
        }

        public ColorEditDTO GetColorEdit(int id)
        {
            var color = Database.Colours.GetById(id);

            if (color == null)
                return null;

            return MapperInstance.Map<ColorEditDTO>(color);
        }

        public ColorDTO Create(ColorCreateDTO colorDTO)
        {
            var color = Database.Colours.Create(MapperInstance.Map<Color>(colorDTO));
            Database.SaveChanges();

            return MapperInstance.Map<ColorDTO>(color);
        }

        public void Edit(ColorEditDTO colorDTO)
        {
            var color = Database.Colours.GetById(colorDTO.Id);
            color.Name = colorDTO.Name;
            color.RowVersion = colorDTO.RowVersion;

            Database.Colours.Update(color);
            Database.SaveChanges();
        }

        public void Remove(int id)
        {
            Database.Colours.Remove(Database.Colours.GetById(id));
            Database.SaveChanges();
        }

        public bool ExistsById(int id)
        {
            return Database.Colours.ExistsById(id);
        }

        public bool ExistsByName(string name)
        {
            return Database.Colours
                .Contains(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool IsNameFree(int id, string name)
        {
            return !Database.Colours
                .Contains(m => m.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) && m.Id != id);
        }
    }
}
