using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace kaigi
{
    public class Member
    {
        public String title;
        public int fee;
        public int member;
    }

    public class Members
    {
        public Member[] member;

        public Members()
        {
            member = new Member[10];
            for (int i = 0; i < 10; i++)
            {
                member[i] = new Member();
            }
        }

        private String convDefault(String value) 
        {
            if (value == null) return "";
            return value;
        }

        private int convFee(String value)
        {
            if (value == null) return 0;
            return Int32.Parse(value);
        }

        public float getTotalFee()
        {
            float totalFee = 0;
            for (int i = 0; i < 10; i++)
            {
                float fee = member[i].fee * member[i].member;
                fee = fee * 10000 / 20 / 8 / 3600;

                totalFee += fee;
            }
            return totalFee;
        }

        public void load()
        {
            NameValueCollection appConfig = ConfigurationManager.AppSettings;

            member[0].title = convDefault(appConfig["title0"]);
            member[1].title = convDefault(appConfig["title1"]);
            member[2].title = convDefault(appConfig["title2"]);
            member[3].title = convDefault(appConfig["title3"]);
            member[4].title = convDefault(appConfig["title4"]);
            member[5].title = convDefault(appConfig["title5"]);
            member[6].title = convDefault(appConfig["title6"]);
            member[7].title = convDefault(appConfig["title7"]);
            member[8].title = convDefault(appConfig["title8"]);
            member[9].title = convDefault(appConfig["title9"]);

            member[0].fee = convFee(appConfig["fee0"]);
            member[1].fee = convFee(appConfig["fee1"]);
            member[2].fee = convFee(appConfig["fee2"]);
            member[3].fee = convFee(appConfig["fee3"]);
            member[4].fee = convFee(appConfig["fee4"]);
            member[5].fee = convFee(appConfig["fee5"]);
            member[6].fee = convFee(appConfig["fee6"]);
            member[7].fee = convFee(appConfig["fee7"]);
            member[8].fee = convFee(appConfig["fee8"]);
            member[9].fee = convFee(appConfig["fee9"]);

            for (int i = 0; i < 10; i++)
            {
                member[i].member = 0;
            }
        }
    }
}
