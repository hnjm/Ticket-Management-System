﻿namespace TicketManagementSystem.ViewModels.Color
{
    public class ColorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PackagesCount { get; set; }
        public int TicketsCount { get; set; }
        public bool CanBeDeleted { get; set; }
    }
}
