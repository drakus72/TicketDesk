// TicketDesk - Attribution notice
// Contributor(s):
//
//      Stephen Redd (stephen@reddnet.net, http://www.reddnet.net)
//
// This file is distributed under the terms of the Microsoft Public 
// License (Ms-PL). See http://opensource.org/licenses/MS-PL
// for the complete terms of use. 
//
// For any distribution that contains code from this file, this notice of 
// attribution must remain intact, and a copy of the license must be 
// provided to the recipient.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketDesk.Domain.Model
{


    public class TicketTag
    {

        public int TicketTagId { get; set; }

        [Required]
        [StringLength(100)]
        public string TagName { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        #region utility

        public static string[] GetTagsFromString(string tagString)
        {
            var returnTags = new List<string>();
            if (!string.IsNullOrEmpty(tagString))
            {
                string[] tags = tagString.Split(',');
                foreach (string t in tags)
                {
                    var formattedTag = t.ToLowerInvariant().Trim();
                    if (!string.IsNullOrEmpty(formattedTag) && !returnTags.Contains(formattedTag))
                    {
                        returnTags.Add(formattedTag);
                    }
                }
            }
            return returnTags.ToArray();
        }

        #endregion
    }
}
