namespace Booking.Web.Infrastructure.TagHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Booking.Common;
    using Booking.Web.Models.Periods;
    using Booking.Web.Models.Reservations;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("calendar", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CalendarTagHelper : TagHelper
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public int RoomId { get; set; }

        public IEnumerable<PeriodViewModel> Periods { get; set; }

        public IEnumerable<ReservaionDateViewModel> Reservations { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "calendar container");
            output.Content.SetHtmlContent(this.GetHtml());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private string GetHtml()
        {
            var currentMonth = new DateTime(this.Year, this.Month, 1);

            var html = new XDocument(
                new XElement(
                    "div",
                    this.GetCalendarHeaderHtml(currentMonth),
                    this.GetDayOfWeekHtml(),
                    new XElement("div", new XAttribute("class", "row border"), this.GetDatesHtml(currentMonth))));

            return html.ToString();
        }

        private XElement GetDayOfWeekHtml()
        {
            return new XElement(
                "div",
                new XAttribute("class", "row p-2 d-none d-lg-flex bg-secondary text-white"),
                Enum.GetValues(typeof(DayOfWeek))
                    .Cast<DayOfWeek>()
                    .Select(d => new XElement("h5", new XAttribute("class", "col-lg text-center"), d.ToString())));
        }

        private XElement GetCalendarHeaderHtml(DateTime currentMonth)
        {
            return new XElement(
                "div",
                new XAttribute(
                    "class", "calendar_header"),
                this.GetPreviousMonth(currentMonth),
                new XElement(
                    "h2",
                    new XAttribute("class", "text-center"),
                    currentMonth.ToString("MMMM yyyy")),
                this.GetNextMonth(currentMonth));
        }

        private IEnumerable<XElement> GetDatesHtml(DateTime currentMonth)
        {
            var startDate = currentMonth.AddDays(-(int)currentMonth.DayOfWeek);
            var dates = Enumerable.Range(0, 42).Select(i => startDate.AddDays(i));

            foreach (var d in dates)
            {
                if (d.DayOfWeek == DayOfWeek.Sunday && d != startDate)
                {
                    yield return new XElement(
                        "div",
                        new XAttribute("class", "w-100"),
                        string.Empty);
                }

                if (this.IsAvailable(d) && d.Month == currentMonth.Month && !this.IsReserved(d))
                {
                    yield return new XElement(
                        "a",
                        this.GetAvaiavleClasses(d),
                        new XAttribute("href", string.Format(GlobalConstants.ReservationPath, this.RoomId, d.ToString(GlobalConstants.ResevationDateFormat))),
                        d.Day,
                        new XElement(
                            "div",
                            new XAttribute(
                                "class", "col d-lg-none text-center"),
                            d.DayOfWeek.ToString()));
                }
                else
                {
                    var mutedClasses = " d-none d-lg-flex muted text-muted";
                    var reservedClass = " bg-danger";

                    yield return new XElement(
                        "div",
                        new XAttribute("class", $"day col-lg p-2 border{(d.Month != currentMonth.Month ? mutedClasses : null)}{(this.IsReserved(d) ? reservedClass : null)}"),
                        d.Day,
                        new XElement(
                            "div",
                            new XAttribute(
                                "class", "col d-lg-none text-center"),
                            d.DayOfWeek.ToString()));
                }
            }
        }

        private XAttribute GetAvaiavleClasses(DateTime d)
        {
            if (d < DateTime.Now)
            {
                return new XAttribute("class", $"day col-lg p-2 isDisabled border bg-success");
            }

            return new XAttribute("class", $"day col-lg p-2 border bg-success");
        }

        private XElement GetNextMonth(DateTime currentMonth)
        {
            var nextMonth = currentMonth.AddMonths(1);

            return new XElement(
                "a",
                new XAttribute("href", $"?year={nextMonth.Year}&month={nextMonth.Month}"),
                new XAttribute("class", "switch-month"),
                ">");
        }

        private XElement GetPreviousMonth(DateTime currentMonth)
        {
            var previusMonth = currentMonth.AddMonths(-1);

            return new XElement(
                "a",
                new XAttribute("href", $"?year={previusMonth.Year}&month={previusMonth.Month}"),
                new XAttribute("class", "switch-month"),
                "<");
        }

        private bool IsReserved(DateTime date)
        {
            return this.Reservations.Any(r => r.ReservationDate.Date.Equals(date.Date));
        }

        private bool IsAvailable(DateTime date)
        {
            return this.Periods.Any(p => date.Date >= p.StartDate.Date && date.Date <= p.EndDate.Date);
        }
    }
}