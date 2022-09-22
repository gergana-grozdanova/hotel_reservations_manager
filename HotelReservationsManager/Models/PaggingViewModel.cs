namespace HotelReservationsManager.Models
{
    public class PaggingViewModel
    {
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int ItemsPerPage { get; set; }
        public bool HasPreviousPage => this.CurrentPage > 1;
        public bool HasNextPage => this.CurrentPage < PagesCount;
        public int PagesCount => (int)Math.Ceiling((double)this.Count / this.ItemsPerPage);
        public int PreviousPageNumber => this.CurrentPage - 1;
        public int NextPageNumber => this.CurrentPage + 1;
    }
}
