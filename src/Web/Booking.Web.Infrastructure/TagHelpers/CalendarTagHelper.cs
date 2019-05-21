namespace Booking.Web.Infrastructure.TagHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("calendar", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CalendarTagHelper : TagHelper
    {
        public int Month { get; set; }

        public int Year { get; set; }

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
                    new XElement("div", new XAttribute("class", "row p-2 bg-secondary text-white"),
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

                    var mutedClasses = "bg-light text-muted";
                    yield return new XElement("div",
                        new XAttribute("class", $"day col-lg p-2 border {(d.Month != monthStart.Month ? mutedClasses : null)}"),
                        d.Day
                    );
                }
            }
        }
    }
}