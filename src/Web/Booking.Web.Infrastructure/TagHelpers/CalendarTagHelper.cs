namespace Booking.Web.Infrastructure.TagHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Booking.Web.Models.Periods;
    using Booking.Web.Models.Reservations;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("calendar", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CalendarTagHelper : TagHelper
    {
        public int Month { get; set; }

        public int Year { get; set; }

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
            var monthStart = new DateTime(this.Year, this.Month, 1);

            var html = new XDocument(
                new XElement("div",
                    new XElement("h4", new XAttribute("class", "text-center"), monthStart.ToString("MMMM yyyy")),
                    new XElement("div", new XAttribute("class", "row p-2 d-none d-lg-flex bg-secondary text-white"),
                        Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
                            .Select(d =>
                                new XElement("h5", new XAttribute("class", "col-lg text-center"), d.ToString())
                             )
                    ),
                    new XElement("div", new XAttribute("class", "row border"), GetDatesHtml())
                )
            );

            return html.ToString();

            IEnumerable<XElement> GetDatesHtml()
            {
                var startDate = monthStart.AddDays(-(int)monthStart.DayOfWeek);
                var dates = Enumerable.Range(0, 42).Select(i => startDate.AddDays(i));

                foreach (var d in dates)
                {
                    if (d.DayOfWeek == DayOfWeek.Sunday && d != startDate)
                    {
                        yield return new XElement("div",
                            new XAttribute("class", "w-100"),
                            String.Empty
                        );
                    }

                    if (IsInPeriods(d) && d.Month == monthStart.Month && !this.IsReservation(d))
                    {
                        yield return new XElement("a",
                        new XAttribute("class", $"day col-lg p-2 border bg-success"),
                        d.Day,
                        new XElement("div",
                            new XAttribute("class", "col d-lg-none text-center"),
                            d.DayOfWeek.ToString()
                        ));

                    }
                    else
                    {
                        var mutedClasses = " d-none d-lg-flex muted text-muted";
                        yield return new XElement("div",
                            new XAttribute("class", 
                            $"day col-lg p-2 border{(d.Month != monthStart.Month ? mutedClasses : null)}{(IsReservation(d) ? " bg-danger" : null)}"),
                            d.Day,
                            new XElement("div",
                                new XAttribute("class", "col d-lg-none text-center"),
                                d.DayOfWeek.ToString()
                            )
                        );
                    }
                }
            }
        }

        private bool IsReservation(DateTime date)
        {
            return this.Reservations.Any(r => r.ReservationDate.Date.Equals(date.Date));
        }

        private bool IsInPeriods(DateTime date)
        {
            return this.Periods.Any(p => date.Date >= p.StartDate.Date && date.Date <= p.EndDate.Date);
        }
    }
}