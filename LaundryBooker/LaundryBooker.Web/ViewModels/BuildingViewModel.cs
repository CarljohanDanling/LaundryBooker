namespace LaundryBooker.Web.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class BuildingViewModel
    {
        public List<BuildingModel> Buildings { get; set; }
        public int LaundryRoomId { get; set; }
    }
}