﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketManagementSystem.Data.EF.Models
{
    public class Color
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int Id { get; set; }

        [StringLength(32, MinimumLength = 3)]
        public string Name { get; set; }

        #region Navigation properties

        public IList<Package> Packages { get; set; } = new List<Package>();
        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();

        #endregion

        #region System.Object methods

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is Color color)
            {
                return color.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase);
            }
            return false;
        }

        #endregion
    }
}
