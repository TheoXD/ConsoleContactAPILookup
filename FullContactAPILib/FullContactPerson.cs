using System;
using System.Collections.Generic;
using System.Text;



namespace FullContactAPILib
{
    public struct Website
    {
        public string url { get; set; }
    }

    public struct Chat
    {
        public string client { get; set; }
        public string handle { get; set; }
    }

    public struct ContactInfo
    {
        public List<Chat> chats { get; set; }
        public List<Website> websites { get; set; }

        public string familyName { get; set; }
        public string givenName { get; set; }
    }

    public struct SocialProfile
    {
        public string type { get; set; }
        public string typeId { get; set; }
        public string typeName { get; set; }
        public string url { get; set; }
        public string username { get; set; }
        public string id { get; set; }
    }

    public class FullContactPerson
    {

        public string likelihood { get; set; }

        public ContactInfo contactInfo  { get; set; }
        public List<SocialProfile> socialProfiles  { get; set; }

        public override string ToString()
        {
            string ret = "";
            ret += "likelihood: " + this.likelihood + "\n";

            ret += "contactInfo:" + "\n";
            ret += "\t FirstName: " + this.contactInfo.givenName + "\n";

            ret += "\t LastName: " + this.contactInfo.familyName + "\n";

            ret += "websites: " + "\n";
            foreach (Website website in this.contactInfo.websites)
            {
                    ret += "\t " + website.url + "\n";
            }
            
            ret += "chats: " + "\n";
            foreach (Chat chat in this.contactInfo.chats)
            {
                ret += "\t (" + chat.client + ") " + chat.handle + "\n";
            }

            ret += "social media profiles: " + "\n";
            foreach (SocialProfile profile in this.socialProfiles)
            {
                string identifier = "";
                if (!String.IsNullOrEmpty(profile.username)) identifier = " as " + profile.username;
                if (!String.IsNullOrEmpty(profile.id)) identifier += " with ID: " + profile.id;

                ret += "\t on " + profile.typeName + " (" + profile.url + ")" + identifier + "\n";
            }

            return ret;
        }
    }
}
