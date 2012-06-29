using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace McKinney.Analytics
{
    public class GoogleAnalytics
    {
        private static List<GAEvent> EventQueue { 
            get
            {
                
                if(HttpContext.Current.Session["gaq"] == null)
                {
                    HttpContext.Current.Session["gaq"] = new List<GAEvent>();
                }
                return HttpContext.Current.Session["gaq"] as List<GAEvent>;
            }
            
        }

        public static void PushEvent(string category, string action, string label = null)
        {
            EventQueue.Add(new GAEvent
                               {
                                   Category = category,
                                   Action = action,
                                   Label = label
                               });
        }

        public static IHtmlString OutputEvents()
        {
            StringBuilder s = new StringBuilder();
            for(int i = EventQueue.Count-1; i>= 0; i--)
            {
                GAEvent ev = EventQueue[i];
                s.AppendLine(ev.ToString());
                EventQueue.RemoveAt(i);
            }
            return new HtmlString(s.ToString());
        }
    }

    public class GAEvent
    {
        public string Category { get; set; }
        public string Action { get; set; }
        public string Label { get; set; }

        private  string template = "_gaq.push(['_trackEvent', '{0}', '{1}', '{2}']);";

        public override string ToString()
        {
            return string.Format(template, Category, Action, Label);
        }
    }
}